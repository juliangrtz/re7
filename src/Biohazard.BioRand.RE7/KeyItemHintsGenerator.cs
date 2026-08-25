using System.Globalization;
using System.Net;

namespace Biohazard.BioRand.RE7;

internal sealed record KeyItemHint(
    int RouteOrder,
    string ItemName,
    string ItemId,
    int Count,
    string RegionName,
    string SceneFile,
    Guid Guid,
    float X,
    float Y,
    float Z);

internal static class KeyItemHintsGenerator {
    public static string RenderHtml(IEnumerable<KeyItemHint> hints, int seed) {
        var orderedHints = hints
            .OrderBy(hint => hint.RouteOrder)
            .ThenBy(hint => hint.RegionName, StringComparer.Ordinal)
            .ThenBy(hint => hint.ItemName, StringComparer.Ordinal)
            .ThenBy(hint => hint.SceneFile, StringComparer.Ordinal)
            .ThenBy(hint => hint.Guid)
            .ToArray();

        var builder = new StringBuilder();
        builder.Append("<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset=\"utf-8\">\n");
        builder.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n");
        builder.Append("<title>BioRand RE7 - Key Item Locations</title>\n<style>\n");
        builder.Append("body { font-family: Arial, Helvetica, sans-serif; margin: 2rem; background: #15151d; color: #eee; }\n");
        builder.Append("h1 { font-size: 1.4rem; margin-bottom: .25rem; }\n");
        builder.Append("p { color: #bbb; }\n");
        builder.Append("table { border-collapse: collapse; width: 100%; }\n");
        builder.Append("th, td { border: 1px solid #555; padding: .4rem .6rem; text-align: left; vertical-align: top; }\n");
        builder.Append("th { background: #28283d; }\n");
        builder.Append("tr:nth-child(even) { background: #20202d; }\n");
        builder.Append("code { color: #c9d1ff; overflow-wrap: anywhere; }\n");
        builder.Append("</style>\n</head>\n<body>\n");
        builder.Append($"<h1>BioRand RE7 &mdash; Key Item Locations (Seed {seed})</h1>\n");
        builder.Append("<p>Spoiler sheet ordered by the earliest route phase containing each randomized pickup.</p>\n");
        builder.Append("<table>\n<thead><tr>");
        builder.Append("<th>Order</th><th>Item</th><th>Region</th><th>Scene</th><th>Position</th><th>GUID</th>");
        builder.Append("</tr></thead>\n<tbody>\n");

        foreach (var hint in orderedHints) {
            var itemName = hint.Count == 1 ? hint.ItemName : $"{hint.ItemName} x{hint.Count}";
            var position = string.Join(", ",
                hint.X.ToString("0.###", CultureInfo.InvariantCulture),
                hint.Y.ToString("0.###", CultureInfo.InvariantCulture),
                hint.Z.ToString("0.###", CultureInfo.InvariantCulture));

            builder.Append("<tr>");
            builder.Append($"<td>{hint.RouteOrder}</td>");
            builder.Append($"<td>{Encode(itemName)}<br><code>{Encode(hint.ItemId)}</code></td>");
            builder.Append($"<td>{Encode(hint.RegionName)}</td>");
            builder.Append($"<td><code>{Encode(hint.SceneFile)}</code></td>");
            builder.Append($"<td>{position}</td>");
            builder.Append($"<td><code>{hint.Guid:D}</code></td>");
            builder.Append("</tr>\n");
        }

        builder.Append("</tbody>\n</table>\n</body>\n</html>\n");
        return builder.ToString();
    }

    private static string Encode(string value)
        => WebUtility.HtmlEncode(value);
}
