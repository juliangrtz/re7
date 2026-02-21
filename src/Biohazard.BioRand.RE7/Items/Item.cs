using Enums.app;
using System;

namespace Biohazard.BioRand.RE7.Items
{
    public readonly struct Item(ItemID id, int count)
    {
        public ItemID Id { get; } = id;
        public int Count { get; } = count;

        public Item(ItemID id) : this(id, -1) { }
        public Item(string id) : this(Enum.Parse<ItemID>(id), -1) { }
    }
}
