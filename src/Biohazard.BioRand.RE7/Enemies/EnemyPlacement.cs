using Biohazard.BioRand.RE7.Enemies.Molded;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Biohazard.BioRand.RE7.Enemies;

[DebuggerDisplay("{EnemyID}")]
public class EnemyPlacement
{
    public bool IsExtra { get; set; }
    public string? Comment { get; set; } = "";
    public ImmutableArray<string> Tags { get; set; } = [];

    public required EnemyID EnemyID { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public Difficulty? Difficulty { get; set; }
    public DlcType? Dlc { get; set; }
    public bool IsForceSpawn { get; set; }
    public int Chapter { get; set; }

    public float PosX { get; set; }
    public float PosY { get; set; }
    public float PosZ { get; set; }
    public float RotX { get; set; }
    public float RotY { get; set; }
    public float RotZ { get; set; }
    public float RotW { get; set; }

    public Guid? SpawnInfoGuid { get; set; }
    //public Guid EnemyGameObjectGuid { get; set; }

    public string SceneFile { get; set; } = "";

    // Special Molded properties
    public MoldedBodyPartMask? MoldedBodyPartMask { get; set; }
    public Enums.app.MoldedActionController.ExtraHatUnit.Type? HatType { get; set; }

    public SerializablePosition Position => new SerializablePosition(PosX, PosY, PosZ);
    public SerializableRotation Rotation => new SerializableRotation(RotX, RotY, RotZ, RotW);
    public EulerAngles Euler => new(Rotation);
}
