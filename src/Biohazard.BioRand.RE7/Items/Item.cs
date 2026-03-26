using Enums.app;

namespace Biohazard.BioRand.RE7.Items;

public readonly struct Item(string id, int count)
{
    public string Id { get; init; } = id;
    public int CountEasy { get; init; } = count;
    public int CountNormal { get; init; } = count;
    public int CountMadhouse { get; init; } = count;

    public Item(ItemID id) : this(id.ToString(), -1)
    {
    }

    public Item(string id) : this(id, -1)
    {
    }
}