using app;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using Biohazard.BioRand.RE7.Weapons;
using Enums.app.Item;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Text;
using System.Text.RegularExpressions;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

/// <summary>
/// TODO DLCs
/// </summary>
internal class WeaponDefinitionGenerator : IFileGenerator {
    public string Id => "weapon_definitions";
    public bool CopyToDataDirectory => true;

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJson(EmbeddedData.GetFile("rszre7rt.json.gz").Ungzip());

    private readonly PakFile _pakFile = Constants.BioRandPakFile;

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private readonly string _weaponPathPrefix = "natives/stm/prefab/weapon/";
    private readonly string _itemSettingsFile = "natives/stm/prefab/item/resourceitemsettings.user.2";
    private readonly string _nameLookupFile = "natives/stm/message/ui_item_mes.msg.17";

    private readonly List<string> _weaponExclusions =[
        "wp2170", // Gimmick Knife (no RCOL)
        "wp1370" // Golden Crowbar (no RCOL)
    ];

    private readonly Regex _pfbRegex = new("natives/stm/prefab/weapon.*_item.pfb.*", RegexOptions.Compiled);

    private readonly Dictionary<string, string?> _nameLookup = new();
    private readonly List<string> _pakPaths = [];
    private readonly MsgFile _msgFile;

    private app.ItemSettings? ReadItemSettings() {
        var userFile = new UserFile(_pakFile.GetEntryData(_itemSettingsFile));
        return RszSerializer.Deserialize<app.ItemSettings>(userFile.GetObjects(_rszRepository)[0]);
    }

    public WeaponDefinitionGenerator() {
        _msgFile = new MsgFile(_pakFile.GetEntryData(_nameLookupFile));

        var settings = ReadItemSettings()!;
        foreach (var setting in settings._Settings) {
            if (setting.Category is ItemCategoryType.Weapon or ItemCategoryType.StackWeapon) {
                var name = FindMessageByGuid(setting.NameMsg)!;
                _nameLookup.Add(setting.ItemDataID, name);
            }
        }
    }

    private string? FindMessageByGuid(Guid guid) {
        var message = _msgFile.FindMessage(guid)!;
        return message
            .Values
            .Single(v => v.Language == LanguageId.English)
            .Text;
    }

    private readonly Regex wpIdRegex = new(@"wp\d*", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private string ExtractId(string str)
        => wpIdRegex.Match(str).Groups[0].Value.ToLowerInvariant();

    private List<string> GetRcolPaths(string weaponId)
        => weaponId switch{
            "wp0060" =>[
                PakPath.RcolFile("collision/collider/weapon/weapon0060/wp0060.rcol"),
                PakPath.RcolFile("collision/collider/weapon/weapon0060/wp0060_chainsaw.rcol")
            ],
            "wp0020" or
                "wp2150" or
                "wp2140" or
                "wp2100" or
                "wp2090" or
                "wp2040" or
                "wp1360" or
                "wp1320" or
                "wp1250" or
                //"wp1230" or
                "wp1190" or
                "wp1090" or
                //"wp1030"
                "wp1000" or
                "wp0070" or
                "wp0040" => _pakPaths
                    .Where(p => new Regex($"{weaponId}.*.rcol.{FileVersions.RcolFileVersion}").IsMatch(p)).ToList(),
            "wp1110" =>[
                PakPath.RcolFile("collision/collider/weapon/acidbullets.rcol"),
                PakPath.RcolFile("collision/collider/weapon/flamebullets.rcol"),
            ],
            "wp1270" =>[PakPath.RcolFile("collision/collider/weapon/liquidbomb.rcol")],
            _ =>[PakPath.RcolFile("collision/collider/weapon/defaultbullet.rcol")]
        };

    private Dictionary<string, WeaponDamageStats> GetDamageStats(List<string> rcolPaths, string id,
        bool isDefaultBulletWeapon) {
        var result = new Dictionary<string, WeaponDamageStats>();

        foreach (var rcolPath in rcolPaths) {
            var rcolFile =
                new RcolFile(FileVersions.RcolFileVersion, _pakFile.GetEntryData(rcolPath)).ToBuilder(_rszRepository);
            var requestSets = isDefaultBulletWeapon
                ? rcolFile.RequestSets.Where(rs => rs.Name.Equals(id, StringComparison.InvariantCultureIgnoreCase))
                : rcolFile.RequestSets;

            foreach (var requestSet in requestSets) {
                if (requestSet?.UserData?.Type.Name != "app.Collision.AttackUserData")
                    continue;

                var attackUserData = RszSerializer.Deserialize<app.Collision.AttackUserData>(requestSet.UserData!)!;
                if (attackUserData.Damage > 0 || attackUserData.Stun > 0) {
                    result.Add($"{Path.GetFileNameWithoutExtension(rcolPath)}/{requestSet.Name}", new WeaponDamageStats{
                        Damage = attackUserData.Damage,
                        Stun = attackUserData.Stun
                    });
                }
            }
        }

        return result;
    }

    private List<WeaponDefinition> GetWeaponDefinitions(GenerateSettings settings) {
        var result = new List<WeaponDefinition>();

        foreach (var hash in _pakFile.FileHashes) {
            _pakPaths.Add(_pakList.GetPath(hash)!);
        }

        foreach (var path in _pakPaths) {
            if (path == null || !path.StartsWith(_weaponPathPrefix) || !path.Contains(".pfb"))
                continue;

            var pfbFile = new PfbFile(FileVersions.PfbFileVersion, _pakFile.GetEntryData(path));
            var go = pfbFile.ReadScene(_rszRepository).GetGameObjects().FirstOrDefault(
                g => g?.FindComponent("app.Weapon") != null || g?.FindComponent("app.WeaponGun") != null, null);
            var weaponComponent = go?.FindComponent<Weapon>();
            var weaponGunComponent = go?.FindComponent<WeaponGun>();

            if (go == null || (weaponComponent == null && weaponGunComponent == null)) {
                continue;
            }

            var mesh = go.FindComponent("via.render.Mesh");
            if (weaponComponent != null) {
                List<string>? adaptiveTriggerUserDataPaths =[
                    weaponComponent.HoldAdaptiveTriggerUserData.Path,
                    weaponComponent.FireAdaptiveTriggerUserData.Path,
                    weaponComponent.ActiveAdaptiveTriggerUserData.Path,
                ];
                adaptiveTriggerUserDataPaths = adaptiveTriggerUserDataPaths.Choose().ToList().EmptyToNull();

                var id = ExtractId(mesh?.Children[2].ToString() ?? go.Name);
                if (_weaponExclusions.Contains(id)) continue;

                var rcolPaths = GetRcolPaths(id);
                var damage = GetDamageStats(rcolPaths, weaponComponent.WeaponID.ToString(),
                    rcolPaths.Any(p => p.Contains("defaultbullet")));
                var motlistPaths = _pakPaths.Where(p => p.Contains(id) &&
                                                        p.EndsWith($".motlist.{FileVersions.MotlistFileVersion}")
                ).ToList().EmptyToNull();

                var pfbPath = _pakPaths.First(
                    p => p.Contains($"prefab/weapon/{id}.pfb.{FileVersions.PfbFileVersion}") ||
                         (p.Contains(weaponComponent.WeaponID.ToString(),
                             StringComparison.InvariantCultureIgnoreCase) && _pfbRegex.IsMatch(p))
                );

                result.Add(new WeaponDefinition{
                    WeaponId = weaponComponent.WeaponID,
                    Id = id,
                    IsGun = false,
                    Name = _nameLookup[weaponComponent.WeaponID.ToString()],
                    UserType = weaponComponent.UserType,
                    AdaptiveTriggerUserDataPaths = adaptiveTriggerUserDataPaths,
                    IsInventoryWeapon = weaponComponent.IsInventoryWeapon,
                    BulletItemIDs = null,
                    IsBulletStackNumInfinity = false,
                    IsLoadNumInfinity = false,
                    Mesh = mesh?.Children[2].ToString() ?? "",
                    Material = mesh?.Children[3].ToString() ?? "",
                    MaxLoadNum = 0,
                    Damage = damage,
                    UserParamsPath = null,
                    RcolPaths = rcolPaths,
                    MotlistPaths = motlistPaths,
                    PrefabPath = pfbPath,
                    Range = null
                });
            } else if (weaponGunComponent != null) {
                List<string>? adaptiveTriggerUserDataPaths =[
                    weaponGunComponent.HoldAdaptiveTriggerUserData.Path,
                    weaponGunComponent.FireAdaptiveTriggerUserData.Path,
                    weaponGunComponent.ActiveAdaptiveTriggerUserData.Path,
                ];
                adaptiveTriggerUserDataPaths = adaptiveTriggerUserDataPaths.Choose().ToList().EmptyToNull();

                var id = ExtractId(mesh?.Children[2].ToString() ?? go.Name);
                if (_weaponExclusions.Contains(id)) continue;

                var rcolPaths = GetRcolPaths(id);
                var damage = GetDamageStats(rcolPaths, weaponGunComponent.WeaponID.ToString(),
                    rcolPaths.Any(p => p.Contains("defaultbullet")));
                var userParamsPath = weaponGunComponent.WeaponGunParameter.Path.EmptyToNullStr();
                var userParamsPathFull = userParamsPath == null
                    ? null
                    : $"natives/stm/{userParamsPath.ToLowerInvariant()}.{FileVersions.UserFileVersion}";

                WeaponGunParameter? weaponParams = null;
                if (userParamsPath != null) {
                    var weaponParamsFile = new UserFile(_pakFile.GetEntryData(userParamsPathFull!));
                    weaponParams =
                        RszSerializer.Deserialize<WeaponGunParameter>(weaponParamsFile.GetObjects(_rszRepository)[0]);
                }

                var motlistPaths = _pakPaths.Where(p => p.EndsWith($"{id}.motlist.{FileVersions.MotlistFileVersion}")
                ).ToList().EmptyToNull();

                var pfbPath = _pakPaths.First(
                    p => p.Contains($"prefab/weapon/{id}.pfb.{FileVersions.PfbFileVersion}") ||
                         (p.Contains(weaponGunComponent.WeaponID.ToString(),
                             StringComparison.InvariantCultureIgnoreCase) && _pfbRegex.IsMatch(p))
                );


                result.Add(new WeaponDefinition{
                    WeaponId = weaponGunComponent.WeaponID,
                    Id = id,
                    Name = _nameLookup[weaponGunComponent.WeaponID.ToString()],
                    IsGun = true,
                    BulletItemIDs = weaponGunComponent.BulletInfoList.Select(b => b.BulletItemID).ToList(),
                    Mesh = mesh?.Children[2].ToString() ?? "",
                    Material = mesh?.Children[3].ToString() ?? "",
                    UserType = weaponGunComponent.UserType,
                    AdaptiveTriggerUserDataPaths = adaptiveTriggerUserDataPaths,
                    IsInventoryWeapon = weaponGunComponent.IsInventoryWeapon,
                    UserParamsPath = userParamsPathFull,
                    RcolPaths = rcolPaths,
                    Damage = damage,
                    IsBulletStackNumInfinity = weaponParams?.IsBulletStackNumInfinity,
                    IsLoadNumInfinity = weaponParams?.IsLoadNumInfinity,
                    MaxLoadNum = weaponParams?.MaxLoadNum,
                    Range = weaponParams?.Range,
                    MotlistPaths = motlistPaths,
                    PrefabPath = pfbPath
                });
            }
        }

        return result;
    }

    public object Generate(GenerateSettings settings) {
        var itemDefinitions = GetWeaponDefinitions(settings);
        AnsiConsole.MarkupLine($"[green]Generated {itemDefinitions.Count} weapon definitions.[/]");
        return itemDefinitions
            .OrderBy(it => it.WeaponId)
            .DistinctBy(it => it.WeaponId);
    }
}
