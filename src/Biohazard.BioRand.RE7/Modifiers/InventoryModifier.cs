namespace Biohazard.BioRand.RE7.Modifiers;

/// <summary>
/// TODO Starting inventory, backpacks
/// </summary>
internal class InventoryModifier : Modifier
{
    /*
     * Must not be more than 8 items if unmodded!
     * -------------------------------------------------------------------------------------------------------------
     * Ethan starting inventory: natives\stm\leveldesign\fsm\chapter1\other -> tested successfully with chainsaw
     *
     * Mia starting inventory (VHS): natives\stm\leveldesign\fsm\chapter4\chapter4_1\other\4-1startinventory.user.2
     *
     * Mia starting inventory (w/ machine gun): natives\stm\leveldesign\fsm\ff050\other\ff050_startinventory.user.2
     *
     * Clancy VHS starting inventory? natives\stm\leveldesign\fsm\ff000\other\startinventory_ff000.user.2
     * -------------------------------------------------------------------------------------------------------------
     */

    public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
    {
    }

    public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
    {
    }
}