using app;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using static app.InventoryMenu;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

public partial class REFPlugin {
    private static string? GetPlayerName() {
        var objectManager = API.GetManagedSingleton("app.ObjectManager");
        if (objectManager == null)
            return null;

        var playerObj = objectManager.GetField("PlayerObj") as ManagedObject;
        if (playerObj == null)
            return null;

        return playerObj.Call("get_Name") as string;
    }

    private static Inventory.ExtendLvDef? ConfigInventorySizeToEnum(string str)
        => str switch{
            "12" => Inventory.ExtendLvDef.Lv1,
            "16" => Inventory.ExtendLvDef.Lv2,
            "20" => Inventory.ExtendLvDef.Lv3,
            _ => null
        };

    private static Inventory.ExtendLvDef? GetDesiredInventorySize() {
        var playerName = GetPlayerName();
        if (playerName == null) return null;

        if (playerName.StartsWith("Pl00", StringComparison.Ordinal)) {
            var ethanSize =
                ConfigInventorySizeToEnum(Config.ReadOrDefault("random-starting-inventory-size-ethan", "12"));
            Logger.Log($"Playing as Ethan, configured inventory size: {ethanSize}", isVerbose: true);
            return ethanSize;
        } else if (playerName.StartsWith("Pl2", StringComparison.Ordinal)) {
            var miaSize = ConfigInventorySizeToEnum(Config.ReadOrDefault("random-starting-inventory-size-mia", "12"));
            Logger.Log($"Playing as Mia, configured inventory size: {miaSize}", isVerbose: true);
            return miaSize;
        } else {
            return null;
        }
    }

    private static bool IsBirthdaySkillItem(Item? item) {
        var itemDataId = item?.ItemDataID;
        return itemDataId != null
               && itemDataId.StartsWith("skl", StringComparison.OrdinalIgnoreCase)
               && !itemDataId.EndsWith("no", StringComparison.OrdinalIgnoreCase);
    }

    private static bool CanForceDiscard(Item? item) {
        var itemData = item?.ItemData;
        if (itemData == null) {
            return false;
        }

        var itemDataId = item?.ItemDataID ?? itemData.ItemDataID;
        if (itemDataId != null && itemDataId.StartsWith("FoundFootage", StringComparison.OrdinalIgnoreCase)) {
            return true;
        }

        return itemData.Category is not Item.ItemCategoryType.KeyItem
            and not Item.ItemCategoryType.UsableKeyItem;
    }

    [MethodHook(typeof(Item), nameof(Item.isCanDiscard), MethodHookType.Post)]
    private static void Item_isCanDiscard_Post(Span<ulong> args, ref ulong retval) {
        if (retval != 0 || !Config.ReadOrDefault("inventory-unrestricted-management", true)) {
            return;
        }

        var item = ManagedObject.ToManagedObject(args[1]).As<Item>();
        if (CanForceDiscard(item)) {
            Logger.Log($"Patch Item.isCanDiscard for '{item?.ItemDataID}'.", isVerbose: true);
            retval = 1;
        }
    }

    private static IPlayerOrder? GetPlayerOrder() {
        var objectManager = API.GetManagedSingleton("app.ObjectManager");
        if (objectManager == null)
            return null;

        var playerObj = (objectManager.GetField("PlayerObj") as ManagedObject)?.As<via.GameObject>();
        var playerOrderType = PlayerOrder.REFType.GetRuntimeType().As<_System.Type>();
        return playerOrderType == null
            ? null
            : playerObj?.getComponent(playerOrderType)?.Cast<IPlayerOrder>();
    }

    private static bool TryRegisterBirthdayPassiveSkill(PassiveSkillItem? passiveSkillItem) {
        if (passiveSkillItem == null || !IsBirthdaySkillItem(passiveSkillItem.Item))
            return false;

        var passiveSkill = passiveSkillItem.PassiveSkill;
        if (passiveSkill == null) {
            Logger.Log("Birthday skill item had no PassiveSkill userdata.");
            return true;
        }

        var playerOrder = GetPlayerOrder();
        if (playerOrder == null) {
            Logger.Log(
                $"Unable to register Birthday skill '{passiveSkillItem.Item.ItemDataID}' because app.PlayerOrder was unavailable.");
            return true;
        }

        passiveSkillItem.PlayerOrder = playerOrder;
        playerOrder.registerPassiveSkill(passiveSkill);
        Logger.Log($"Registered Birthday passive skill '{passiveSkillItem.Item.ItemDataID}'.", isVerbose: true);
        return true;
    }

    [MethodHook(typeof(PassiveSkillItem), nameof(PassiveSkillItem.onInsertInventory), MethodHookType.Pre)]
    private static PreHookResult PassiveSkillItem_onInsertInventory_Pre(Span<ulong> args) {
        var passiveSkillItem = ManagedObject.ToManagedObject(args[1]).As<PassiveSkillItem>();
        return TryRegisterBirthdayPassiveSkill(passiveSkillItem)
            ? PreHookResult.Skip
            : PreHookResult.Continue;
    }

    [MethodHook(typeof(Inventory), nameof(Inventory.setupItemSlotManager), MethodHookType.Pre)]
    private static PreHookResult Inventory_ctor_Pre(Span<ulong> args) {
        var inventory = ManagedObject.ToManagedObject(args[1]).As<Inventory>()!;

        var desiredLevel = GetDesiredInventorySize();
        if (desiredLevel == null)
            return PreHookResult.Continue;

        if (inventory.ExtendLv < desiredLevel) {
            Logger.Log("Increase Inventory._ExtendLv", isVerbose: true);
            inventory._ExtendLv = desiredLevel.Value;
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(Inventory), nameof(Inventory.setExtendLv), MethodHookType.Pre)]
    private static PreHookResult Inventory_setExtendLv_Pre(Span<ulong> args) {
        var newLevel = (int)args[2];
        var desiredLevel = GetDesiredInventorySize();
        if (desiredLevel == null)
            return PreHookResult.Continue;

        if (newLevel < (int)desiredLevel) {
            Logger.Log("Prevent Inventory._ExtendLv shrinking");
            args[2] = (ulong)desiredLevel;
        }

        return PreHookResult.Continue;
    }

    private const int MaxCombineUIRowNum = 5;

    [MethodHook(typeof(DictionaryCombineUIController), nameof(DictionaryCombineUIController.deactivate),
        MethodHookType.Pre)]
    private static PreHookResult DictionaryCombineUIController_deactivate_Pre(Span<ulong> args) {
        var controller = ManagedObject.ToManagedObject(args[1]).As<DictionaryCombineUIController>();
        var type = TDB.Get().FindType("app.InventoryMenu.DictionaryCombineUIController");
        var field = type.GetField("RowNum");
        var current = (int)field.GetDataBoxed(controller.Address(), false);

        if (current != MaxCombineUIRowNum) {
            Logger.Log($"Patch DictionaryCombineUIController.RowNum from {current} to {MaxCombineUIRowNum}",
                isVerbose: true);
            field.SetDataBoxed(controller.Address(), MaxCombineUIRowNum, false);
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(InventoryMenu), nameof(InventoryMenu.DictionaryCombine_UnlockedCombine), MethodHookType.Post)]
    private static void InventoryMenu_DictionaryCombine_UnlockedCombine_Post(ref ulong retval) {
        if (retval != 1) {
            Logger.Log("Patch InventoryMenu.DictionaryCombine_UnlockedCombine from false to true", isVerbose: true);
            retval = 1;
        }
    }
}
