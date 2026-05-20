namespace Biohazard.BioRand.RE7.Enemies;

public sealed class EnemySceneLimit {
    public string SceneFile { get; set; } = "";
    public string Label { get; set; } = "";
    public int MaxEnemies { get; set; }
    public string? Comment { get; set; }
}