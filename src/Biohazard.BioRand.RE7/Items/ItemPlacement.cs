using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Biohazard.BioRand.RE7.Items;

[DebuggerDisplay("{GuidOrAuto}")]
public class ItemPlacement
{
    public bool IsExtra { get; set; }
    public string? Comment { get; set; } = "";
    public ImmutableArray<string> Tags { get; set; } = [];
    public required string Id { get; set; }
 
    public bool Enabled { get; set; }
    public int StackNum { get; set; }
    public int EasyNum { get; set; } = -1;
    public int HardNum { get; set; } = -1;

    public Difficulty? Difficulty { get; set; }

    public int Chapter { get; set; }

    public float PosX { get; set; }
    public float PosY { get; set; }
    public float PosZ { get; set; }
    public float RotX { get; set; }
    public float RotY { get; set; }
    public float RotZ { get; set; }
    public float RotW { get; set; }

    [Key]
    public Guid Guid { get; set; }

    public Guid SaveGuid { get; set; }
    public string GameObjectName { get; set; } = "";
    public string SceneFile { get; set; } = "";
    public string Mesh { get; set; } = "";
    public string Material { get; set; } = "";
    public DlcType? Dlc { get; set; }

    public Guid GuidOrAuto => Guid == default ? $"item_{Id}".GetGuidHash() : Guid;
    public SerializablePosition Position => new SerializablePosition(PosX, PosY, PosZ);
    public SerializableRotation Rotation => new SerializableRotation(RotX, RotY, RotZ, RotW);
    public EulerAngles Euler => new(Rotation);

    // Tags
    public const string WoodenCrateTag = "wooden_crate";
    public const string RandomItemTag = "random";
}