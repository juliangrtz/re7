using Biohazard.BioRand.RE7.Serialization;
using System.Globalization;
using System.Net;

namespace Biohazard.BioRand.RE7;

internal sealed record KeyItemHint(
    int RouteOrder,
    string ItemName,
    string ItemId,
    int Count,
    string PickupName,
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
            .Select((hint, index) => new NumberedHint(index + 1, hint))
            .ToArray();

        var mappedHints = orderedHints
            .Select(numbered => KeyItemMapRepository.TryGetLocation(numbered.Hint.Guid, out var location)
                ? new MappedHint(numbered, location)
                : null)
            .Where(mapped => mapped != null)
            .Cast<MappedHint>()
            .ToArray();
        var unmappedHints = orderedHints
            .Where(numbered => !KeyItemMapRepository.TryGetLocation(numbered.Hint.Guid, out _))
            .ToArray();

        var builder = new StringBuilder();
        AppendDocumentStart(builder, seed, orderedHints.Length);

        foreach (var mapGroup in mappedHints
                     .GroupBy(mapped => mapped.Location.MapId, StringComparer.OrdinalIgnoreCase)
                     .Select(group => new{
                         Map = GetMap(group.Key),
                         Hints = group.OrderBy(mapped => mapped.Numbered.Number).ToArray(),
                     })
                     .OrderBy(group => group.Hints.Min(mapped => mapped.Numbered.Number))
                     .ThenBy(group => group.Map.Order)) {
            AppendMap(builder, mapGroup.Map, mapGroup.Hints);
        }

        if (unmappedHints.Length != 0)
            AppendUnmappedLocations(builder, unmappedHints);

        builder.Append("<footer>Floor-plan imagery: <a href=\"https://www.evilresource.com/resident-evil-7/maps\">Evil Resource</a>. Markers identify the pickup room; placement data remains available under each entry.</footer>\n");
        builder.Append("</main>\n</body>\n</html>\n");
        return builder.ToString();
    }

    private static void AppendDocumentStart(StringBuilder builder, int seed, int keyItemCount) {
        builder.Append("""
                       <!DOCTYPE html>
                       <html lang="en">
                       <head>
                       <meta charset="utf-8">
                       <meta name="viewport" content="width=device-width, initial-scale=1">
                       <title>BioRand RE7 - Key Item Spoiler Maps</title>
                       <style>
                       :root { color-scheme: dark; }
                       * { box-sizing: border-box; }
                       body { margin: 0; background: #101114; color: #ece8de; font-family: "Segoe UI", Arial, sans-serif; }
                       main { width: min(72rem, 100%); margin: 0 auto; padding: 2rem 1rem 4rem; }
                       header { margin-bottom: 2rem; }
                       h1 { margin: 0; font-size: clamp(1.6rem, 4vw, 2.4rem); font-weight: 600; }
                       h2 { margin: 0 0 1rem; font-size: 1.35rem; font-weight: 600; }
                       p { color: #b9b4a9; }
                       .map-section { margin: 0 0 2rem; padding: 1rem; background: #191b20; border: 1px solid #34363d; border-radius: .55rem; }
                       .map-frame { position: relative; margin: 0 auto 1rem; background: #f8f8f5; overflow: hidden; border-radius: .3rem; }
                       .map-frame img { display: block; width: 100%; height: auto; }
                       .map-marker { position: absolute; display: grid; place-items: center; width: 2rem; height: 2rem; transform: translate(-50%, -50%); border: 2px solid #fff; border-radius: 50%; background: #b8191f; color: #fff; font-size: .92rem; font-weight: 700; text-decoration: none; box-shadow: 0 2px 7px #000b; }
                       .map-marker:hover, .map-marker:focus-visible { z-index: 2; background: #e52b32; outline: 3px solid #f4c451; outline-offset: 2px; }
                       .legend { display: grid; grid-template-columns: repeat(auto-fit, minmax(min(100%, 20rem), 1fr)); gap: .75rem; margin: 0; padding: 0; list-style: none; }
                       .legend li { display: grid; grid-template-columns: 2rem 1fr; gap: .65rem; align-items: start; padding: .75rem; background: #22242a; border-radius: .35rem; }
                       .legend-number { display: grid; place-items: center; width: 2rem; height: 2rem; border-radius: 50%; background: #b8191f; color: #fff; font-weight: 700; }
                       .item-name { display: block; font-weight: 600; }
                       .room-name { display: block; margin-top: .15rem; color: #ddd6c8; }
                       .pickup-name, .route-order { display: block; margin-top: .15rem; color: #aaa599; font-size: .9rem; }
                       .approximate { display: inline-block; margin-top: .35rem; padding: .1rem .4rem; border-radius: .2rem; background: #5b451e; color: #ffe1a3; font-size: .8rem; }
                       details { margin-top: .45rem; color: #aaa599; font-size: .82rem; }
                       details div { margin-top: .35rem; overflow-wrap: anywhere; }
                       code { color: #c9d1ff; }
                       .map-credit { margin: .8rem 0 0; font-size: .8rem; text-align: right; }
                       a { color: #e4bd70; }
                       .route-fallback { display: grid; gap: .65rem; }
                       .route-region { position: relative; padding: .8rem .8rem .8rem 3rem; background: #22242a; border-radius: .35rem; }
                       .route-region::before { content: ""; position: absolute; left: 1.25rem; top: 0; bottom: 0; width: 2px; background: #63656d; }
                       .route-region::after { content: ""; position: absolute; left: .87rem; top: 1.05rem; width: .8rem; height: .8rem; border-radius: 50%; background: #b8191f; border: 2px solid #fff; }
                       footer { margin-top: 2.5rem; color: #88857e; font-size: .82rem; text-align: center; }
                       @media print {
                           body { background: #fff; color: #111; }
                           main { width: 100%; padding: 0; }
                           .map-section { break-inside: avoid; background: #fff; border-color: #bbb; }
                           .legend li, .route-region { background: #f2f2f2; }
                           .item-name, .room-name { color: #111; }
                           .pickup-name, .route-order, details, p, footer { color: #444; }
                       }
                       </style>
                       </head>
                       <body>
                       <main>
                       """);
        builder.Append($"<header><h1>BioRand RE7 &mdash; Key Item Spoiler Maps (Seed {seed})</h1>");
        builder.Append($"<p>{keyItemCount} randomized progression pickups, ordered by route sphere and plotted by pickup room.</p></header>\n");
    }

    private static void AppendMap(
        StringBuilder builder,
        KeyItemMapDefinition map,
        IReadOnlyList<MappedHint> hints) {
        var imageData = Convert.ToBase64String(EmbeddedData.GetFile($"key_item_maps/{map.FileName}"));
        builder.Append("<section class=\"map-section\">\n");
        builder.Append($"<h2>{Encode(map.Title)}</h2>\n");
        builder.Append($"<div class=\"map-frame\" style=\"width:min(100%, {map.Width}px)\">\n");
        builder.Append($"<img src=\"data:image/gif;base64,{imageData}\" width=\"{map.Width}\" height=\"{map.Height}\" alt=\"{Encode(map.Title)} floor plan\">\n");

        foreach (var markerGroup in hints.GroupBy(hint => (hint.Location.X, hint.Location.Y))) {
            var markers = markerGroup.ToArray();
            for (var index = 0; index < markers.Length; index++) {
                var mapped = markers[index];
                var (offsetX, offsetY) = GetMarkerOffset(index, markers.Length);
                var left = (mapped.Location.X / map.Width * 100).ToString("0.###", CultureInfo.InvariantCulture);
                var top = (mapped.Location.Y / map.Height * 100).ToString("0.###", CultureInfo.InvariantCulture);
                var itemName = FormatItemName(mapped.Numbered.Hint);
                builder.Append($"<a class=\"map-marker\" href=\"#key-{mapped.Numbered.Number}\" ");
                builder.Append($"style=\"left:calc({left}% + {offsetX}px);top:calc({top}% + {offsetY}px)\" ");
                builder.Append($"aria-label=\"{Encode(itemName)} in {Encode(mapped.Location.RoomName)}\">{mapped.Numbered.Number}</a>\n");
            }
        }

        builder.Append("</div>\n<ol class=\"legend\">\n");
        foreach (var mapped in hints)
            AppendLegendItem(builder, mapped.Numbered, mapped.Location);
        builder.Append("</ol>\n");
        builder.Append($"<p class=\"map-credit\"><a href=\"{Encode(map.SourceUrl)}\">Floor-plan source</a></p>\n");
        builder.Append("</section>\n");
    }

    private static void AppendLegendItem(
        StringBuilder builder,
        NumberedHint numbered,
        KeyItemMapLocation location) {
        var hint = numbered.Hint;
        var position = FormatPosition(hint);
        builder.Append($"<li id=\"key-{numbered.Number}\"><span class=\"legend-number\">{numbered.Number}</span><div>");
        builder.Append($"<span class=\"item-name\">{Encode(FormatItemName(hint))}</span>");
        builder.Append($"<span class=\"room-name\">{Encode(location.RoomName)}</span>");
        builder.Append($"<span class=\"pickup-name\">Pickup: {Encode(hint.PickupName)}</span>");
        builder.Append($"<span class=\"route-order\">Route sphere {hint.RouteOrder}</span>");
        if (location.IsApproximate)
            builder.Append("<span class=\"approximate\">Approximate floor; exact room unavailable</span>");
        builder.Append("<details><summary>Placement data</summary><div>");
        builder.Append($"<code>{Encode(hint.SceneFile)}</code><br>");
        builder.Append($"World position: {position}<br><code>{hint.Guid:D}</code>");
        builder.Append("</div></details></div></li>\n");
    }

    private static void AppendUnmappedLocations(StringBuilder builder, IReadOnlyList<NumberedHint> hints) {
        builder.Append("<section class=\"map-section\">\n<h2>Other route locations</h2>\n");
        builder.Append("<p>No calibrated floor plan is available for these pickup scenes. They remain plotted along the route so the spoiler never omits a key item.</p>\n");
        builder.Append("<div class=\"route-fallback\">\n");
        foreach (var numbered in hints) {
            var hint = numbered.Hint;
            builder.Append("<div class=\"route-region\">");
            builder.Append($"<span class=\"item-name\">{numbered.Number}. {Encode(FormatItemName(hint))}</span>");
            builder.Append($"<span class=\"room-name\">{Encode(hint.RegionName)}</span>");
            builder.Append($"<span class=\"pickup-name\">Pickup: {Encode(hint.PickupName)}</span>");
            builder.Append($"<details><summary>Placement data</summary><div><code>{Encode(hint.SceneFile)}</code><br>");
            builder.Append($"World position: {FormatPosition(hint)}<br><code>{hint.Guid:D}</code></div></details>");
            builder.Append("</div>\n");
        }

        builder.Append("</div>\n</section>\n");
    }

    private static KeyItemMapDefinition GetMap(string mapId) {
        if (!KeyItemMapRepository.TryGetMap(mapId, out var map))
            throw new InvalidOperationException($"Key item map '{mapId}' is not defined.");
        return map;
    }

    private static (int X, int Y) GetMarkerOffset(int index, int count) {
        if (count <= 1)
            return (0, 0);

        const double radius = 17;
        var angle = (Math.PI * 2 * index / count) - (Math.PI / 2);
        return ((int)Math.Round(Math.Cos(angle) * radius), (int)Math.Round(Math.Sin(angle) * radius));
    }

    private static string FormatItemName(KeyItemHint hint)
        => hint.Count == 1 ? hint.ItemName : $"{hint.ItemName} x{hint.Count}";

    private static string FormatPosition(KeyItemHint hint)
        => string.Join(", ",
            hint.X.ToString("0.###", CultureInfo.InvariantCulture),
            hint.Y.ToString("0.###", CultureInfo.InvariantCulture),
            hint.Z.ToString("0.###", CultureInfo.InvariantCulture));

    private static string Encode(string value)
        => WebUtility.HtmlEncode(value);

    private sealed record NumberedHint(int Number, KeyItemHint Hint);

    private sealed record MappedHint(NumberedHint Numbered, KeyItemMapLocation Location);
}
