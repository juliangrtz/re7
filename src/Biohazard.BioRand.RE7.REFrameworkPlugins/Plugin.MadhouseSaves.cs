using app;
using REFrameworkNET;
using REFrameworkNET.Attributes;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

public partial class REFPlugin {
    private static bool IsMadhouseNormalSaveSystemEnabled() {
        if (!Config.ReadOrDefault(MadhouseNormalSavesConfigKey, true))
            return false;

        var gameManager = API.GetManagedSingleton("app.GameManager")?.As<GameManager>();
        return gameManager?.GameDifficulty == GameManager.Difficulty.Hard;
    }

    [MethodHook(typeof(MenuManager), nameof(MenuManager.openSelectItemMenu), MethodHookType.Post)]
    private static void MenuManager_openSelectItemMenu_Post(ref ulong retval) {
        if (!IsMadhouseNormalSaveSystemEnabled())
            return;

        _pendingMadhouseSaveSelectItemMenu = ManagedObject.ToManagedObject(retval)?.As<MenuHandle>();
    }

    [MethodHook(typeof(SaveDataManager), nameof(SaveDataManager.doUpdate), MethodHookType.Pre)]
    private static PreHookResult SaveDataManager_doUpdate_Pre(Span<ulong> args)
        => TryBypassMadhouseSaveSelectItemMenu(args);

    [MethodHook(typeof(SaveDataManager), nameof(SaveDataManager.doLateUpdate), MethodHookType.Pre)]
    private static PreHookResult SaveDataManager_doLateUpdate_Pre(Span<ulong> args)
        => TryBypassMadhouseSaveSelectItemMenu(args);

    private static PreHookResult TryBypassMadhouseSaveSelectItemMenu(Span<ulong> args) {
        var manager = ManagedObject.ToManagedObject(args[1])?.As<SaveDataManager>();
        TryBypassMadhouseSaveSelectItemMenu(manager);
        return PreHookResult.Continue;
    }

    private static void TryBypassMadhouseSaveSelectItemMenu(SaveDataManager? manager) {
        var menuHandle = _pendingMadhouseSaveSelectItemMenu;
        if (manager?.IsNowSaveHardSelectDispGUI != true || menuHandle == null)
            return;

        _pendingMadhouseSaveSelectItemMenu = null;

        var inventoryMenu = menuHandle._Menu?.Cast<InventoryMenu>();
        if (inventoryMenu == null) {
            return;
        }

        inventoryMenu.setSelectItemResult(false, "SaveTape");
        menuHandle.requestClose();
        Logger.Log("Bypassed Madhouse cassette selection.", isVerbose: true);
    }

    [MethodHook(typeof(SaveDataManager), nameof(SaveDataManager.isHardModeSubTape), MethodHookType.Pre)]
    private static PreHookResult SaveDataManager_isHardModeSubTape_Pre(Span<ulong> args)
        => SkipMadhouseTapeAccounting(args);

    [MethodHook(typeof(SaveDataManager), nameof(SaveDataManager.isHardModeAddTape), MethodHookType.Pre)]
    private static PreHookResult SaveDataManager_isHardModeAddTape_Pre(Span<ulong> args)
        => SkipMadhouseTapeAccounting(args);

    private static PreHookResult SkipMadhouseTapeAccounting(Span<ulong> args) {
        if (!IsMadhouseNormalSaveSystemEnabled())
            return PreHookResult.Continue;

        var manager = ManagedObject.ToManagedObject(args[1])?.As<SaveDataManager>();
        if (manager != null) {
            manager.IsTapeSub = false;
        }

        Logger.Log("Removing Madhouse cassette tape requirement.", isVerbose: true);
        return PreHookResult.Skip;
    }
}
