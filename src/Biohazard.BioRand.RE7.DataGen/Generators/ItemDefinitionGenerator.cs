using Biohazard.BioRand.RE7.DLC;
using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using IntelOrca.Biohazard.REE.Compression;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using Spectre.Console;
using System.Collections.Concurrent;
using System.Text;
using static Biohazard.BioRand.RE7.DataGen.Commands.GenerateCommand;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

/// <summary>
/// TODO: non-RT
/// </summary>
internal class ItemDefinitionGenerator : IFileGenerator
{
    public string Id => "item_definitions";

    private readonly RszTypeRepository _rszRepository =
        RszRepositorySerializer.Default.FromJsonGz(EmbeddedData.GetFile("rszre7rt.json.gz"));

    private readonly PakFile _pakFile =
        new(EmbeddedData.GetFile("biorand-re7.pak"));

    private readonly PakList _pakList =
        new(Encoding.UTF8.GetString(Gzip.DecompressData(EmbeddedData.GetFile("pakcontentsrt.txt.gz"))));

    private readonly string _itemPathPrefix = @"natives/stm/prefab/item/";
    private readonly string _messagesPathPrefix = @"natives/stm/message/";

    private app.ItemSettings? ReadItemSettings(ulong hash)
    {
        try
        {
            var userFile = new UserFile(_pakFile.GetEntryData(hash));
            return RszSerializer.Deserialize<app.ItemSettings>(userFile.GetObjects(_rszRepository)[0]);
        }
        catch
        {
            return null;
        }
    }

    private readonly Lazy<List<MsgFile>> _messageFiles;

    public ItemDefinitionGenerator()
    {
        _messageFiles = new Lazy<List<MsgFile>>(GetMessageFiles);
    }

    private List<MsgFile> GetMessageFiles()
    {
        var messages = new ConcurrentBag<MsgFile>();

        Parallel.ForEach(_pakFile.FileHashes, hash =>
        {
            var path = _pakList.GetPath(hash);
            if (path == null || !path.StartsWith(_messagesPathPrefix) || !path.Contains(".msg"))
                return;
            messages.Add(new MsgFile(_pakFile.GetEntryData(hash)));
        });

        return [.. messages];
    }

    private string? FindMessageByGuid(Guid guid)
    {
        foreach (var msgFile in _messageFiles.Value)
        {
            var message = msgFile.FindMessage(guid);
            if (message != null)
                return message
                    .Values
                    .Single(v => v.Language == LanguageId.English)
                    .Text;
        }

        return null;
    }

    /// <summary>
    /// <a href="https://steamcommunity.com/sharedfiles/filedetails?id=1761418830">https://steamcommunity.com/sharedfiles/filedetails?id=1761418830</a>
    /// </summary>
    private static bool IsUnlockable(string itemId) =>
        new string[] {
            "UnlimitedAmmo", "EasyBoots", "Handgun_Albert_Reward",
            "BookDefence01", "BookDefence02", "AlphaGrass",
            "CircularSaw", "CoinOld"
        }.Contains(itemId);

    private List<ItemDefinition> GetItemDefinitions(GenerateSettings settings)
    {
        var result = new ConcurrentBag<ItemDefinition>();

        Parallel.ForEach(_pakFile.FileHashes, hash =>
        {
            var path = _pakList.GetPath(hash);
            if (path == null || !path.StartsWith(_itemPathPrefix) || !path.Contains(".user.2"))
                return;

            var itemSettings = ReadItemSettings(hash);
            if (itemSettings == null)
            {
                if (settings.Verbose)
                {
                    AnsiConsole.MarkupLine($"[yellow]{path.Without(_itemPathPrefix)}[/] does not contain item settings.");
                }

                return;
            }

            var items = itemSettings._Settings;
            foreach (var item in items)
            {
                result.Add(new ItemDefinition
                {
                    Id = item.ItemDataID,
                    Name = FindMessageByGuid(item.NameMsg)?.RemoveControlCharacters(),
                    CategoryType = item.Category,
                    Size = item.SlotSize,
                    MaxStack = item.MaxStackNum,
                    Dlc = DlcTypeExtensions.FromPakFileName(path),
                    WeaponId = EnumExtensions.ParseOrNull<WeaponID>(item.ItemDataID),
                    CanStoreInItemBox = item.CanStoreItembox,
                    DeveloperComment = item._Comment.RemoveControlCharacters(),
                    IsUnlockable = IsUnlockable(item.ItemDataID),
                    SourceUserFile = Path.GetFileName(path)
                });
            }
            AnsiConsole.MarkupLine($"[green]Extracted {items.Count} item definitions from {path.Without(_itemPathPrefix)}[/].");
        });

        return [.. result];
    }

    public object Generate(GenerateSettings settings)
    {
        var itemDefinitions = GetItemDefinitions(settings);
        AnsiConsole.MarkupLine($"[green]Generated {itemDefinitions.Count} item definitions.[/]");
        return itemDefinitions.OrderBy(it => it.Id);
    }
}