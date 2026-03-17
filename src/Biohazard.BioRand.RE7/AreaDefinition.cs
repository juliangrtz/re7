using System.Text.Json.Serialization;

namespace Biohazard.BioRand.RE7;

public class AreaDefinition
{
    public string Path { get; set; } = "";
    public int? Chapter { get; set; }
    public string? Description { get; set; } = "";
    public Difficulty? OnlyDifficulty { get; set; }
    public DlcType? Dlc { get; set; }
    public AreaKind Kind { get; set; }

    [JsonIgnore]
    public bool IsCopy
        => Path.Contains("/copyasset/") || Path.Contains("/copyscene/");
}

public enum AreaKind
{
    General,
    Item,
    Enemy,
}