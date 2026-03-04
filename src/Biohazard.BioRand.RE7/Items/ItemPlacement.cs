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
    [Key]
    public required string Id { get; set; }

    public bool Enabled { get; set; }
    public int StackNum { get; set; }
    public int EasyNum { get; set; } = -1;
    public int HardNum { get; set; } = -1;

    //public MainCampaignCharacter Character { get; set; }
    public Difficulty? Difficulty { get; set; }

    public int Chapter { get; set; }
    public Guid Guid { get; set; }
    public Guid SaveGuid { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public SerializableQuaternion Rotation { get; set; } = Quaternion.Zero;
    public string Container { get; set; } = "";

    [JsonIgnore]
    public Guid GuidOrAuto => Guid == default ? $"item_{Id}".GetGuidHash() : Guid;

    [JsonIgnore]
    public Vector3 Position => new(X, Y, Z);

    [JsonIgnore]
    public EulerAngles Euler => new(Rotation);
}