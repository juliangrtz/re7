using app;
using app.Em3000;
using app.Em8000;
using REFrameworkNET;
using REFrameworkNET.Attributes;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;

using Em8000WeaponGroup = Em8000Define.WeaponGroup.Group;
using EnemyResistType = EnemyResistParameter.EnemyResistType;
using ForbidDamageReactionType = EnemyActionController.ForbidDamageReactionType;

public partial class REFPlugin {
    [ThreadStatic] private static bool _forceEm8000KneeDownDamageResult;

    [ThreadStatic] private static Em8000WeaponGroup _forceEm8000KneeDownWeaponGroup;

    private static bool IsVanillaEm8000KneeDownWeaponGroup(Em8000WeaponGroup weaponGroup)
        => weaponGroup is Em8000WeaponGroup.Handgun
            or Em8000WeaponGroup.Shotgun
            or Em8000WeaponGroup.Melee
            or Em8000WeaponGroup.Saw;

    private static bool IsEm8000LargeDamageReactionForbidden(Em3000ActionController controller) {
        var flags = controller.DictForbidDamageReactionTypeFlag;
        if (flags == null)
            return true;

        try {
            return flags[ForbidDamageReactionType.Large];
        }
        catch {
            return true;
        }
    }

    private static bool ShouldForceEm8000KneeDown(
        Em3000ActionController? controller,
        EnemyActionController.ResistResultSet? resultSet,
        Em8000WeaponGroup weaponGroup) {
        if (controller?.MyEm8000ActionStatus == null || resultSet == null)
            return false;

        if (IsVanillaEm8000KneeDownWeaponGroup(weaponGroup))
            return false;

        if (resultSet.resistType != EnemyResistType.Large)
            return false;

        var think = controller.MyThink;
        if (think == null || think._Mode == Em3000Think.Mode.Em8000Hand)
            return false;

        return !IsEm8000LargeDamageReactionForbidden(controller);
    }

    [MethodHook(typeof(Em3000ActionController), nameof(Em3000ActionController.isEm8000KneeDownDamage),
        MethodHookType.Pre)]
    private static PreHookResult Em3000ActionController_isEm8000KneeDownDamage_Pre(Span<ulong> args) {
        _forceEm8000KneeDownDamageResult = false;
        if (args.Length < 4)
            return PreHookResult.Continue;

        var controller = ManagedObject.ToManagedObject(args[1])?.As<Em3000ActionController>();
        var resultSet = ManagedObject.ToManagedObject(args[2])?.As<EnemyActionController.ResistResultSet>();
        var weaponGroup = (Em8000WeaponGroup)unchecked((int)args[3]);
        if (ShouldForceEm8000KneeDown(controller, resultSet, weaponGroup)) {
            _forceEm8000KneeDownDamageResult = true;
            _forceEm8000KneeDownWeaponGroup = weaponGroup;
        }

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(Em3000ActionController), nameof(Em3000ActionController.isEm8000KneeDownDamage),
        MethodHookType.Post)]
    private static void Em3000ActionController_isEm8000KneeDownDamage_Post(ref ulong retval) {
        if (!_forceEm8000KneeDownDamageResult)
            return;

        _forceEm8000KneeDownDamageResult = false;
        if (retval != 0)
            return;

        retval = 1;
        Logger.Log($"Allowed Em8000 knee down for unsupported weapon group {_forceEm8000KneeDownWeaponGroup}.",
            isVerbose: true);
    }
}