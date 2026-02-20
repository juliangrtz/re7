namespace Biohazard.BioRand.RE7.Items {
    public readonly struct Item(string id, int count) {
        public string Id { get; } = id;
        public int Count { get; } = count;

        public Item(string id) : this(id, -1) { }
    }
}
