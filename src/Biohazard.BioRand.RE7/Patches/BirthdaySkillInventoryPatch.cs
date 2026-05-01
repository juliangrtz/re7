using Biohazard.BioRand.RE7.REEngine;
using Enums.app;
using IntelOrca.Biohazard.BioRand;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Patches;

internal class BirthdaySkillInventoryPatch(IPatchContext context) : IPatch
{
    private readonly string _birthdaySkillSettingsPath = PakPath.UserFile("prefab/item/birthdayskillitemsetting.user");
    private readonly string _keyItemSettingsPath = PakPath.UserFile("prefab/item/keyitemsettings.user");
    private readonly string _itemResourcesScenePath = PakPath.SceneFile("scenes/items/itemresources.scn");
    private readonly string _itemResourceTemplateScenePath = PakPath.SceneFile("scenes/items/resources/powerupcoin01a.scn");
    private readonly string _skillDropPrefabTemplatePath = GetPrefabPakPath("Prefab/Props_Dynamic/sm2479_PowerUpCoin01A/Get/sm2479_PowerUpCoin01A_Get.pfb");
    private readonly string _uiItemMessagePath = PakPath.MessageFile("message/ui_item_mes.msg");
    private readonly string _uiBirthdayMessagePath = PakPath.MessageFile("message/ui_birthday_mes.msg");

    public void Apply()
    {
        var birthdaySkills = context
            .DeserializeUserFile<app.ItemSettings>(_birthdaySkillSettingsPath)
            ._Settings
            .Where(IsBirthdaySkill)
            .OrderBy(x => x.ItemDataID, StringComparer.OrdinalIgnoreCase)
            .ToArray();

        CopySkillInventoryAssets(birthdaySkills);
        ApplyKeyItemSettings(birthdaySkills);
        ApplyDropPrefabs(birthdaySkills);
        ApplyItemResources(birthdaySkills);
        ApplyBirthdayMessages(birthdaySkills);
    }

    private void CopySkillInventoryAssets(IReadOnlyList<app.ItemData> birthdaySkills)
    {
        foreach (var skill in birthdaySkills)
        {
            CopyRequiredFile(GetSkillItemPrefabPath(skill), $"Birthday skill '{skill.ItemDataID}' item prefab");
            CopyRequiredFile(GetPassiveSkillUserPath(skill), $"Birthday skill '{skill.ItemDataID}' passive skill userdata");
        }
    }

    private void CopyRequiredFile(string path, string description)
    {
        var data = context.GetFile(path) ?? throw new RandomizerUserException($"Unable to read {description} at '{path}'.");
        context.SetFile(path, data);
    }

    private void ApplyKeyItemSettings(IReadOnlyList<app.ItemData> birthdaySkills)
    {
        var transformedSkillSettings = birthdaySkills
            .Select(CreateCampaignInventorySkill)
            .ToArray();

        context.ModifyUserFile<app.ItemSettings>(_keyItemSettingsPath, root =>
        {
            root._Settings =
            [
                .. root._Settings.Where(x => !IsBirthdaySkill(x)),
                .. transformedSkillSettings
            ];
            return root;
        });
    }

    private void ApplyItemResources(IReadOnlyList<app.ItemData> birthdaySkills)
    {
        context.ModifyScnFile(_itemResourcesScenePath, scene =>
        {
            var templateFolder = scene.Children
                .OfType<RszFolder>()
                .First(x => x.Name == "PowerUpCoin01A");
            var resourceIds = birthdaySkills
                .Select(x => x.ItemDataID)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var children = scene.Children
                .Where(child => child is not RszFolder folder || !resourceIds.Contains(folder.Name))
                .ToList();
            foreach (var skill in birthdaySkills)
            {
                children.Add(CreateResourceFolder(templateFolder, skill.ItemDataID));
            }

            return scene.WithChildren(children.ToImmutableArray());
        });

        foreach (var skill in birthdaySkills)
        {
            var template = context.GetScnFile(_itemResourceTemplateScenePath)
                .ToBuilder(context.TypeRepository);
            template.Scene = template.Scene.VisitComponents((_, component) =>
                component.Type.Name != "app.ItemResource"
                    ? component
                    : component
                        .Set("_ItemDataId", skill.ItemDataID)
                        .Set("_ResourcePrefab.Standby", true)
                        .Set("_ResourcePrefab.Path", GetSkillDropPrefabReference(skill)));
            context.SetScnFile(GetItemResourceScenePath(skill.ItemDataID), template.AddMissingResources().Build());
        }
    }

    private void ApplyDropPrefabs(IReadOnlyList<app.ItemData> birthdaySkills)
    {
        foreach (var skill in birthdaySkills)
        {
            var template = context.GetPfbFile(_skillDropPrefabTemplatePath)
                .ToBuilder(context.TypeRepository);

            template.Scene = template.Scene
                .VisitGameObjects(gameObject => gameObject.Name switch
                {
                    "sm2479_PowerUpCoin01A_Get" => gameObject
                        .WithName($"{skill.ItemDataID}_Get"),
                    _ => gameObject
                })
                .VisitComponents((_, component) =>
                {
                    return component.Type.Name switch
                    {
                        "app.Item" => component
                            .Set("SaveGUID", $"BirthdaySkillDrop:{skill.ItemDataID}:Item".GetGuidHash())
                            .Set("ItemDataID", skill.ItemDataID)
                            .Set("ItemStackNum", 1),
                        "app.InteractDetailSearch" => component
                            .Set("SaveGUID", $"BirthdaySkillDrop:{skill.ItemDataID}:Interact".GetGuidHash())
                            .Set("IsGetItemCountEnabled", false),
                        _ => component,
                    };
                });

            context.SetPfbFile(GetSkillDropPrefabPath(skill), template.RebuildResources().Build());
        }
    }

    private string GetPassiveSkillUserPath(app.ItemData skill)
    {
        var itemPrefab = context.GetPfbFile(GetSkillItemPrefabPath(skill))
            .ReadScene(context.TypeRepository);
        var passiveSkillComponent = itemPrefab.GetGameObjects()
            .Select(x => x.FindComponent("app.PassiveSkillItem"))
            .FirstOrDefault(x => x != null)
            ?? throw new RandomizerUserException($"Birthday skill '{skill.ItemDataID}' item prefab has no app.PassiveSkillItem component.");

        if (passiveSkillComponent["PassiveSkill"] is not RszUserDataNode passiveSkill)
        {
            throw new RandomizerUserException($"Birthday skill '{skill.ItemDataID}' passive component has no PlayerPassiveSkill userdata.");
        }

        return PakPath.UserFile(passiveSkill.Path);
    }

    private void ApplyBirthdayMessages(IReadOnlyList<app.ItemData> birthdaySkills)
    {
        if (!context.Exists(_uiBirthdayMessagePath))
        {
            return;
        }

        var birthdayMessages = context.GetMsgFile(_uiBirthdayMessagePath);
        context.ModifyMsgFile(_uiItemMessagePath, itemMessages =>
        {
            foreach (var skill in birthdaySkills)
            {
                CopyMessageIfMissing(itemMessages, birthdayMessages, skill.NameMsg);
                CopyMessageIfMissing(itemMessages, birthdayMessages, skill.ManualMsg);
            }
        });
    }

    private static bool IsBirthdaySkill(app.ItemData item)
        => item.ItemDataID.StartsWith("skl", StringComparison.OrdinalIgnoreCase)
        && !item.ItemDataID.EndsWith("no", StringComparison.OrdinalIgnoreCase); // Exclude dummy skills

    private static app.ItemData CreateCampaignInventorySkill(app.ItemData source)
    {
        var cloned = Clone(source);

        cloned.Category = Enums.app.Item.ItemCategoryType.KeyItem;
        cloned.SortCategory = ItemSortCategory.EquipItem;
        cloned.SortPriority = 100 + ParseSkillNumber(source.ItemDataID);
        cloned.SlotSize = Enums.app.Item.ItemSlotSize.Slot1;
        cloned.MaxStackNum = 1;
        cloned.CanStoreItembox = true;
        cloned.DropItemSetting = new app.ItemData.DropItemData
        {
            DropItemPrefab = new via.Prefab
            {
                Standby = true,
                Path = GetSkillDropPrefabReference(source),
            }
        };

        return cloned;
    }

    private static int ParseSkillNumber(string itemDataId)
        => int.TryParse(itemDataId.AsSpan(3), out var value) ? value : 0;

    private static RszFolder CreateResourceFolder(RszFolder template, string itemDataId)
    {
        return new RszFolder(
            template.Settings
                .Set("Name", itemDataId)
                .Set("ScenePath", GetItemResourceSceneReference(itemDataId)),
            []);
    }

    private static void CopyMessageIfMissing(MsgFile.Builder destination, MsgFile source, Guid guid)
    {
        if (guid == Guid.Empty || destination.FindMessage(guid) != null)
        {
            return;
        }

        var sourceMessage = source.FindMessage(guid);
        if (sourceMessage == null)
        {
            return;
        }

        destination.Messages.Add(CreateDestinationMessage(destination, sourceMessage));
    }

    private static Msg CreateDestinationMessage(MsgFile.Builder destination, Msg source)
    {
        var sourceValues = source.Values.ToDictionary(x => x.Language, x => x.Text);
        var englishFallback = sourceValues.TryGetValue(LanguageId.English, out var english)
            ? english
            : sourceValues.Values.FirstOrDefault() ?? string.Empty;

        return new Msg
        {
            Guid = source.Guid,
            Crc = source.Crc,
            Name = source.Name,
            Values =
            [
                .. destination.Languages.Select(language => new MsgValue(
                    language,
                    sourceValues.TryGetValue(language, out var text) ? text : englishFallback))
            ],
            Attributes =
            [
                .. destination.Attributes.Select(CreateDefaultAttributeValue)
            ]
        };
    }

    private static MsgAttributeValue CreateDefaultAttributeValue(MsgAttributeDefinition definition)
    {
        return definition.Type switch
        {
            MsgAttributeType.Wstring => new MsgAttributeValue(definition, string.Empty),
            MsgAttributeType.Int64 => new MsgAttributeValue(definition, 0L),
            MsgAttributeType.Double => new MsgAttributeValue(definition, 0d),
            _ => new MsgAttributeValue(definition, 0UL),
        };
    }

    private static string GetItemResourceScenePath(string itemDataId)
        => PakPath.SceneFile($"scenes/items/resources/{itemDataId}.scn");

    private static string GetItemResourceSceneReference(string itemDataId)
        => $"Scenes/Items/Resources/{itemDataId}.scn";

    private static string GetSkillDropPrefabReference(app.ItemData skill)
    {
        var inventoryPrefabPath = skill.ItemPrefab.Path?.ToString();
        if (string.IsNullOrWhiteSpace(inventoryPrefabPath) || !inventoryPrefabPath.EndsWith(".pfb", StringComparison.OrdinalIgnoreCase))
        {
            return $"Prefab/Skill/{skill.ItemDataID}/{skill.ItemDataID}Get.pfb";
        }

        return $"{inventoryPrefabPath[..^".pfb".Length]}Get.pfb";
    }

    private static string GetSkillDropPrefabPath(app.ItemData skill)
        => GetPrefabPakPath(GetSkillDropPrefabReference(skill));

    private static string GetSkillItemPrefabPath(app.ItemData skill)
    {
        var itemPrefabPath = skill.ItemPrefab.Path?.ToString();
        if (string.IsNullOrWhiteSpace(itemPrefabPath))
        {
            throw new RandomizerUserException($"Birthday skill '{skill.ItemDataID}' has no item prefab.");
        }

        return GetPrefabPakPath(itemPrefabPath);
    }

    private static string GetPrefabPakPath(string prefabPath)
        => $"{PakPath.Of(prefabPath)}.{FileVersions.PfbFileVersion}".ToLowerInvariant();

    private static via.Prefab CreatePrefabReference(object path)
        => new()
        {
            Standby = true,
            Path = path,
        };

    private static app.ItemData.DropItemData CreateDropItemData(object path)
        => new()
        {
            DropItemPrefab = CreatePrefabReference(path),
        };

    private static via.Prefab NormalizePrefab(via.Prefab source)
        => CreatePrefabReference(source.Path);

    private static app.ItemData.DropItemData NormalizeDropItemData(via.Prefab source)
        => CreateDropItemData(source.Path);

    private static app.ItemData Clone(app.ItemData source)
        => new()
        {
            _Comment = source._Comment,
            ItemDataID = source.ItemDataID,
            NameMsg = source.NameMsg,
            ManualMsg = source.ManualMsg,
            Category = source.Category,
            SortCategory = source.SortCategory,
            SortPriority = source.SortPriority,
            SlotSize = source.SlotSize,
            MaxStackNum = source.MaxStackNum,
            CanStoreItembox = source.CanStoreItembox,
            ItemPrefab = NormalizePrefab(source.ItemPrefab),
            WeaponSetting = Clone(source.WeaponSetting),
            UISetting = Clone(source.UISetting),
            DropItemSetting = NormalizeDropItemData(source.ItemPrefab),
        };

    private static app.ItemData.WeaponData Clone(app.ItemData.WeaponData source)
        => new()
        {
            ReticleType = source.ReticleType,
            WeaponInfoType = source.WeaponInfoType,
        };

    private static app.ItemData.UIData Clone(app.ItemData.UIData source)
        => new()
        {
            IconFrameNo = source.IconFrameNo,
            RoomID = source.RoomID,
            MapIconFrameNo = source.MapIconFrameNo,
        };
}
