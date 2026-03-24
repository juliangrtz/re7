using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Weapons;

public sealed class WeaponDefinitionRepository
{
    private static WeaponDefinitionRepository? _default;
    public ImmutableList<WeaponDefinition> WeaponDefinitions { get; private set; } = [];
    public ImmutableDictionary<WeaponID, WeaponDefinition> IdToWeaponMap { get; private set; } = [];
    private readonly List<WeaponID> _restrictedWeapons = [];

    private const string WeaponDefinitionFileName = "weapon_definitions.json";

    public static WeaponDefinitionRepository Default
    {
        get
        {
            if (_default == null)
            {
                _default = new WeaponDefinitionRepository
                {
                    WeaponDefinitions = EmbeddedData.GetFile(WeaponDefinitionFileName).DeserializeJson<List<WeaponDefinition>>().ToImmutableList()
                };
                _default.Initialize();
            }
            return _default;
        }
    }

    private void Initialize()
    {
        WeaponDefinitions = EmbeddedData.GetFile(WeaponDefinitionFileName).DeserializeJson<List<WeaponDefinition>>().ToImmutableList();
        IdToWeaponMap = WeaponDefinitions.ToImmutableDictionary(x => x.WeaponId, x => x);
    }

    public WeaponDefinition FromWeaponId(string id)
        => IdToWeaponMap[Enum.Parse<WeaponID>(id)];

    public WeaponDefinition FromWeaponId(WeaponID id)
    => IdToWeaponMap[id];

    public void Restrict(WeaponID wp)
    {
        _restrictedWeapons.Add(wp);
    }

    public bool IsRestricted(WeaponID wp) =>
        _restrictedWeapons.Contains(wp);

    public List<WeaponDefinition> Guns
        => WeaponDefinitions
            .Where(wp => wp.IsGun)
            .Where(wp => wp.UserType == Enums.app.CharacterDefine.Type.Player)
            .Where(wp => ItemDefinitionRepository.Default.FromWeaponId(wp.WeaponId) != null)
            .ToList();

    public List<WeaponDefinition> MeleeWeapons
        => WeaponDefinitions
            .Where(wp => !wp.IsGun)
            .Where(wp => wp.UserType == Enums.app.CharacterDefine.Type.Player)
            .Where(wp => ItemDefinitionRepository.Default.FromWeaponId(wp.WeaponId) != null)
            .ToList();

    public List<WeaponDefinition> PlayerWeapons
        => WeaponDefinitions.Where(wp => wp.UserType == Enums.app.CharacterDefine.Type.Player).ToList();

    public List<WeaponDefinition> EnemyWeapons
    => WeaponDefinitions.Where(wp => wp.UserType == Enums.app.CharacterDefine.Type.Enemy).ToList();
}
