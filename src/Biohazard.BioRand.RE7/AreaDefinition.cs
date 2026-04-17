namespace Biohazard.BioRand.RE7;

public class AreaDefinition
{
    public string Path { get; set; } = "";
    public int? Chapter { get; set; }
    public string? Description { get; set; } = "";
    public Difficulty? OnlyDifficulty { get; set; }
    public DlcType? Dlc { get; set; }
    public AreaKind Kind { get; set; }
}

public enum AreaKind
{
    General,
    Item,
    Enemy,
}