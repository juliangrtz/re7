using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Items {
    public class ItemDefinition {
        //[JsonConverter(typeof(StringEnumConverter))]
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Kind { get; set; }
        public string? Mode { get; set; }
        public string? Size { get; set; }
        public string? Class { get; set; }
        public bool Bonus { get; set; }
        public bool Dlc { get; set; }
        public int Stack { get; set; }
        public int Value { get; set; }
        public string[]? Weapons { get; set; }
        public int? WeaponId { get; set; }
        public string? DropKind { get; set; }
        public ImmutableArray<string> Slots { get; set; } = [];

        public int Width => int.Parse((Size ?? "1x1").Split('x')[0]);
        public int Height => int.Parse((Size ?? "1x1").Split('x')[1]);

        public override string ToString() => Name ?? Id.ToString();
    }
}
