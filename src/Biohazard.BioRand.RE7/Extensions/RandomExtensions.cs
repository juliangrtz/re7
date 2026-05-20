namespace Biohazard.BioRand.RE7.Extensions;

public static class RandomExtensions {
    public static T NextOf<T>(this Rng rng, IEnumerable<T> items) {
        var count = items.Count();
        var index = rng.Next(0, count);
        return items.ElementAt(index);
    }

    public static T[] Shuffle<T>(this IEnumerable<T> items, Rng rng) {
        var array = items.ToArray();
        for (int i = 0; i < array.Length - 1; i++) {
            var ri = rng.Next(i, array.Length);
            var tmp = array[ri];
            array[ri] = array[i];
            array[i] = tmp;
        }

        return array;
    }
}