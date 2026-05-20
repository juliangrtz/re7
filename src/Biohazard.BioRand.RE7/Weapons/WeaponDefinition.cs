using Enums.app;
using System.ComponentModel.DataAnnotations;

namespace Biohazard.BioRand.RE7.Weapons;

public sealed class WeaponDefinition {
    [Key] public required WeaponID WeaponId { get; set; }

    public string Id { get; set; } = "";
    public string? Name { get; set; } = null;
    public bool IsGun { get; set; }
    public Dictionary<string, WeaponDamageStats> Damage { get; set; } = new();
    public bool IsInventoryWeapon { get; set; }
    public int? MaxLoadNum { get; set; }
    public bool? IsLoadNumInfinity { get; set; }
    public bool? IsBulletStackNumInfinity { get; set; }
    public float? Range { get; set; }
    public List<ItemID>? BulletItemIDs { get; set; }
    public Enums.app.CharacterDefine.Type UserType { get; set; }
    public string Mesh { get; set; } = "";
    public string Material { get; set; } = "";

    // For easier randomization of weapon parameters, we also include the paths to the relevant files here.
    // These are not necessarily used by all weapon modifiers, but they are included here for convenience and easier lookup.
    public List<string>? AdaptiveTriggerUserDataPaths { get; set; } = new(); // stm/hikako/userdata/adaptivetrigger
    public List<string> RcolPaths { get; set; } = new(); // stm/collision/collider/weapon
    public List<string>? MotlistPaths { get; set; } // stm/animation/weapon
    public string? PrefabPath { get; set; } = ""; // stm/prefab/weapon
    public string? UserParamsPath { get; set; } = ""; // stm/prefab/weapon

    public override string ToString()
        => $"{Name ?? WeaponId.ToString()} ({Id})";
}

public sealed class WeaponDamageStats {
    public int Damage { get; set; }
    public int Stun { get; set; }

    public override string ToString()
        => $"{Damage} Dmg / {Stun} Stun";
}