using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Biohazard.BioRand.RE7.Items;

[DebuggerDisplay("{GuidOrAuto}")]
public class ItemPlacement
{
    public required string Id { get; set; }

    public bool Enabled { get; set; }
    public int StackNum { get; set; }
    public int EasyNum { get; set; } = -1;
    public int HardNum { get; set; } = -1;

    //public MainCampaignCharacter Character { get; set; }
    public Difficulty? Difficulty { get; set; }

    public int Chapter { get; set; }

    [Key]
    public Guid Guid { get; set; }

    public Guid SaveGuid { get; set; }
    public SerializableVector3 Position { get; set; } = Vector3.Zero;
    public SerializableQuaternion Rotation { get; set; } = Quaternion.Zero;
    public string GameObjectName { get; set; } = "";
    public string Container { get; set; } = "";
    public string Mesh { get; set; } = "";
    public string Material { get; set; } = "";
    public DlcType? Dlc { get; set; }
    public bool IsExtra { get; set; }

    [JsonIgnore]
    public Guid GuidOrAuto => Guid == default ? $"item_{Id}".GetGuidHash() : Guid;

    [JsonIgnore]
    public EulerAngles Euler => new(Rotation);

}