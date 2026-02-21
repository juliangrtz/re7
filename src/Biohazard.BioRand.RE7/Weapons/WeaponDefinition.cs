namespace Biohazard.BioRand.RE7.Weapons;

public class WeaponDefinition(string key, int id, bool ranged)
{
    public string Key { get; } = key;
    public int Id { get; } = id;
    public bool Ranged { get; } = ranged;

    public override string ToString() => Key;
}