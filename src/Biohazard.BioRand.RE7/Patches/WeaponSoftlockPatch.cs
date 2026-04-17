using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Weapons;

namespace Biohazard.BioRand.RE7.Patches;

internal class WeaponSoftlockPatch(IPatchContext context) : IPatch
{
    private readonly string weaponPrefabPath = PakPath.UserFile("prefab/item/resourceitemsettings.user");

    public void Apply()
    {
        var problematicWeapons = WeaponDefinitionRepository.Default.PlayerWeapons
            .Where(wp => ItemDefinitionRepository.Default.FromWeaponId(wp.WeaponId)!.IsStoryProgressionItem)
            .Select(wp => wp.WeaponId.ToString());

        // Increase stack size to 2
        context.ModifyUserFile<app.ItemSettings>(weaponPrefabPath, root =>
        {
            foreach (var setting in root._Settings)
            {
                if (!problematicWeapons.Contains(setting.ItemDataID))
                    continue;

                setting.MaxStackNum = 2;
            }

            return root;
        });

        // Special fixes
        // TODO: Implement these. Softlocks occur despite the increased stack size.
    }
}
