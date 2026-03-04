namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

using app;
using Hexa.NET.ImGui;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using REFrameworkNET.Callbacks;
using static app.InventoryMenu;
using static Logger;

public class REFPlugin
{
    private static bool IsInitialized = false;
    private static readonly Configuration config = new();

    [PluginEntryPoint]
    public static void Main()
        => Initialize();

    private static void Initialize()
    {
        ImGuiDrawUI.Post += OnImGuiDrawUi;
        IsInitialized = true;
        Log("Loaded.");
    }

    [PluginExitPoint]
    public static void OnUnload()
    {
        IsInitialized = false;
        Log("Unloaded.");
    }

    #region Inventory

    private static string? GetPlayerName()
    {
        var objectManager = API.GetManagedSingleton("app.ObjectManager");
        if (objectManager == null)
            return null;

        var playerObj = objectManager.GetField("PlayerObj") as ManagedObject;
        if (playerObj == null)
            return null;

        return playerObj.Call("get_Name") as string;
    }

    private static Inventory.ExtendLvDef? ConfigInventorySizeToEnum(string str)
        => str switch
        {
            "12" => Inventory.ExtendLvDef.Lv1,
            "16" => Inventory.ExtendLvDef.Lv2,
            "20" => Inventory.ExtendLvDef.Lv3,
            _ => null
        };

    private static Inventory.ExtendLvDef? GetDesiredInventorySize()
    {
        var playerName = GetPlayerName();
        if (playerName == null) return null;

        if (playerName.StartsWith("Pl00", StringComparison.Ordinal))
        {
            var ethanSize = ConfigInventorySizeToEnum(config.Read("random-starting-inventory-size-ethan"));
            Log($"Playing as Ethan, configured inventory size: {ethanSize}");
            return ethanSize;
        }
        else if (playerName.StartsWith("Pl2", StringComparison.Ordinal))
        {
            var miaSize = ConfigInventorySizeToEnum(config.Read("random-starting-inventory-size-mia"));
            Log($"Playing as Mia, configured inventory size: {miaSize}");
            return miaSize;
        }
        else
        {
            return null;
        }
    }

    [MethodHook(typeof(Inventory), nameof(Inventory.setupItemSlotManager), MethodHookType.Pre)]
    private static PreHookResult Inventory_ctor_Pre(Span<ulong> args)
    {
        var inventory = ManagedObject.ToManagedObject(args[1]).As<Inventory>()!;

        var desiredLevel = GetDesiredInventorySize();
        if (desiredLevel == null)
            return PreHookResult.Continue;

        if (inventory.ExtendLv < desiredLevel)
        {
            Log("Increase Inventory._ExtendLv");
            inventory._ExtendLv = desiredLevel.Value;
        }
        return PreHookResult.Continue;
    }

    [MethodHook(typeof(Inventory), nameof(Inventory.setExtendLv), MethodHookType.Pre)]
    private static PreHookResult Inventory_setExtendLv_Pre(Span<ulong> args)
    {
        var newLevel = (int)args[2];
        var desiredLevel = GetDesiredInventorySize();
        if (desiredLevel == null)
            return PreHookResult.Continue;

        if (newLevel < (int)desiredLevel)
        {
            Log("Prevent Inventory._ExtendLv shrinking");
            args[2] = (ulong)desiredLevel;
        }

        return PreHookResult.Continue;
    }

    private const int MaxCombineUIRowNum = 5;

    [MethodHook(typeof(DictionaryCombineUIController), nameof(DictionaryCombineUIController.deactivate), MethodHookType.Pre)]
    private static PreHookResult DictionaryCombineUIController_deactivate_Pre(Span<ulong> args)
    {
        var controller = ManagedObject.ToManagedObject(args[1]).As<DictionaryCombineUIController>();
        var type = TDB.Get().FindType("app.InventoryMenu.DictionaryCombineUIController");
        var field = type.GetField("RowNum");
        var current = (int)field.GetDataBoxed(controller.Address(), false);

        if (current != MaxCombineUIRowNum)
        {
            Log($"Patch DictionaryCombineUIController.RowNum from {current} to {MaxCombineUIRowNum}");
            field.SetDataBoxed(controller.Address(), MaxCombineUIRowNum, false);
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(InventoryMenu), nameof(InventoryMenu.DictionaryCombine_UnlockedCombine), MethodHookType.Post)]
    private static void InventoryMenu_DictionaryCombine_UnlockedCombine_Post(ref ulong retval)
    {
        if (retval != 1)
        {
            Log("Patch InventoryMenu.DictionaryCombine_UnlockedCombine from false to true");
            retval = 1;
        }
    }

    #endregion Inventory

    #region UI

    private static void OnImGuiDrawUi()
    {
        if (!IsInitialized) return;

        if (ImGui.TreeNode("BioRand 7"))
        {
            ImGui.TreePop();
        }
    }

    #endregion UI
}