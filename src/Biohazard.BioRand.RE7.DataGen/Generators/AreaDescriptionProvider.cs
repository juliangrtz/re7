using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Package;
using IntelOrca.Biohazard.REE.Rsz;
using System.Text.RegularExpressions;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal sealed class AreaDescriptionProvider(PakFile pakFile, PakList pakList, RszTypeRepository rszRepository) {
    private readonly Lazy<Dictionary<string, string>> _mapZoneDescriptions =
        new(() => LoadMapZoneDescriptions(pakFile, pakList, rszRepository));

    private static readonly Regex SceneVersionRegex =
        new(@"\.scn\.\d+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static readonly Regex LeadingChapterRegex =
        new(@"^(?:c|ch|chapter)\d+_?", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static readonly Regex WordRegex = new(@"b\d+f|\d+f|s\d+|[a-z]+|\d+",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static readonly (Regex Pattern, string Prefix, string Replacement)[] DescriptionRules =[
        (new Regex("^c08_shieldmachine", RegexOptions.IgnoreCase | RegexOptions.Compiled),
            "Not a Hero / Shield Machine", "shieldmachine"),
        (new Regex("^c08_storageunderlayer", RegexOptions.IgnoreCase | RegexOptions.Compiled),
            "Not a Hero / Storage Area S1", "storageunderlayer"),
        (new Regex("^c08_storage", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Storage Area",
            "storage"),
        (new Regex("^c08_labopassage", RegexOptions.IgnoreCase | RegexOptions.Compiled),
            "Not a Hero / Research Facility", "labopassage"),
        (new Regex("^c08_labo", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Research Facility",
            "labo"),
        (new Regex("^c08_mining", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Mining Work Area",
            "mining"),
        (new Regex("^c08_mine", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Central Cavern",
            "mine"),
        (new Regex("^c08_train", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Mine Cart Yard",
            "train"),
        (new Regex("^c08_caveev", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Elevator Hall",
            "caveev"),
        (new Regex("^c08_cave", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Not a Hero / Abandoned Mine",
            "cave"),

        (new Regex("^c09_joehouse", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Joe's House",
            "joehouse"),
        (new Regex("^c09_camp", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Base", "camp"),
        (new Regex("^c09_steamboat", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Paddle Boat",
            "steamboat"),
        (new Regex("^c09_moldswamp", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Quarantine Area",
            "moldswamp"),
        (new Regex("^c09_church", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Abandoned Church",
            "church"),
        (new Regex("^c09_cemetery", RegexOptions.IgnoreCase | RegexOptions.Compiled),
            "End of Zoe / Abandoned Church / Cemetery", "cemetery"),
        (new Regex("^c09_climbinghut", RegexOptions.IgnoreCase | RegexOptions.Compiled),
            "End of Zoe / Abandoned Church", "climbinghut"),
        (new Regex("^c09_bakerroad", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Swamp",
            "bakerroad"),
        (new Regex("^c09_alligatorswamp", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Swamp",
            "alligatorswamp"),
        (new Regex("^c09_waterway", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Base / Waterway",
            "waterway"),
        (new Regex("^c09_oldhouse", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Old House",
            "oldhouse"),
        (new Regex("^c09_mainhouse", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Main House",
            "mainhouse"),
        (new Regex("^c09_garden", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Yard", "garden"),
        (new Regex("^c09_ghoutside", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Old House",
            "ghoutside"),
        (new Regex("^c09_trailerhouse", RegexOptions.IgnoreCase | RegexOptions.Compiled), "End of Zoe / Yard / Trailer",
            "trailerhouse"),

        (new Regex("^c01_", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Guest House", ""),
        (new Regex("^c03_boat", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Boat House", "boat"),
        (new Regex("^c03_cow|^c03_leftarea", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Testing Area", ""),
        (new Regex("^c03_garden", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Yard", "garden"),
        (new Regex("^c03_gh", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Greenhouse", "gh"),
        (new Regex("^c03_mainhouse", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Main House", "mainhouse"),
        (new Regex("^c03_oldhouse", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Old House", "oldhouse"),
        (new Regex("^c04_ship", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Wrecked Ship", "ship"),
        (new Regex("^c04_cave", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Salt Mine", "cave"),
        (new Regex("^c04_c01", RegexOptions.IgnoreCase | RegexOptions.Compiled), "Guest House", "c01"),
    ];

    private static readonly Dictionary<string, string> WordReplacements = new(StringComparer.OrdinalIgnoreCase){
        ["ai"] = "AI",
        ["aimap"] = "AI Map",
        ["asset"] = "Asset",
        ["b1f"] = "B1",
        ["b2f"] = "B2",
        ["b3f"] = "B3",
        ["boss"] = "Boss",
        ["boathouse"] = "Boat House",
        ["cave"] = "Cave",
        ["corridor"] = "Corridor",
        ["cowshed"] = "Barn",
        ["cullingcollision"] = "Culling Collision",
        ["distantview"] = "Distant View",
        ["electricdistributionroom"] = "Control Room",
        ["electricdistributionroompast"] = "Control Room Past",
        ["enemyset"] = "Enemy Set",
        ["ev"] = "Elevator",
        ["floor"] = "Floor",
        ["fuseroom"] = "Fuse Room",
        ["garage"] = "Garage",
        ["gareden"] = "Garden",
        ["ground"] = "Ground",
        ["hall"] = "Hall",
        ["hallway"] = "Hallway",
        ["inside"] = "Inside",
        ["item"] = "Item",
        ["joehouse"] = "Joe's House",
        ["joehousearea"] = "Joe's House Area",
        ["joehouseground"] = "Joe's House Grounds",
        ["joehouseinside"] = "Joe's House Interior",
        ["itemresources"] = "Item Resources",
        ["itemset"] = "Item Set",
        ["labo"] = "Lab",
        ["labopassage"] = "Lab Passage",
        ["lastbattle"] = "Final Battle",
        ["levelprop"] = "Level Props",
        ["loadcollision"] = "Load Collision",
        ["loadcollistion"] = "Load Collision",
        ["loadtemp"] = "Load Temp",
        ["low"] = "Low Poly",
        ["lucasarea"] = "Testing Area",
        ["mainhouse"] = "Main House",
        ["mapzone"] = "Map Zone",
        ["mine"] = "Mine",
        ["mining"] = "Mining",
        ["moldedcreationroom"] = "Molded Creation Room",
        ["monitorroom"] = "Monitor Room",
        ["normal"] = "Normal",
        ["object"] = "Object",
        ["oldhouse"] = "Old House",
        ["openinghallway"] = "Opening Hallway",
        ["outside"] = "Outside",
        ["passage"] = "Passage",
        ["powerroom"] = "Power Room",
        ["prefab"] = "Prefab",
        ["quicknomove"] = "Quick No-Move",
        ["reference"] = "Reference",
        ["referenceroom"] = "Reference Room",
        ["resident"] = "Resident",
        ["rightarea"] = "Right Side",
        ["room"] = "Room",
        ["safe"] = "Safe",
        ["saferoom"] = "Safe Room",
        ["scene"] = "Scene",
        ["shield"] = "Shield",
        ["shieldmachine"] = "Shield Machine",
        ["slopearea"] = "Slope Area",
        ["soft"] = "Soft",
        ["souko"] = "Warehouse",
        ["stairs"] = "Stairs",
        ["steamboat"] = "Paddle Boat",
        ["steamboatdistantview"] = "Paddle Boat Distant View",
        ["steamboatoutside"] = "Paddle Boat Outside",
        ["steamboatoutsidelow"] = "Paddle Boat Outside Low Poly",
        ["storage"] = "Storage",
        ["storageroom"] = "Storage Room",
        ["storeroom"] = "Store Room",
        ["taxidermyroom"] = "Taxidermy Room",
        ["tree"] = "Tree",
        ["tunnel"] = "Tunnel",
        ["underlayer"] = "Underlayer",
        ["vfx"] = "VFX",
        ["wallinside"] = "Centipede Wall",
        ["water"] = "Water",
        ["workshop"] = "Workshop",
    };

    public string? Describe(string path, int? chapter, DlcType? dlc, AreaKind kind) {
        var sceneName = GetBestSceneName(path);
        var mapDescription = GetMapDescription(sceneName);
        if (!string.IsNullOrWhiteSpace(mapDescription))
            return mapDescription;

        foreach (var (pattern, prefix, replacement) in DescriptionRules) {
            if (!pattern.IsMatch(sceneName))
                continue;

            var detail = string.IsNullOrWhiteSpace(replacement)
                ? LeadingChapterRegex.Replace(sceneName, "")
                : pattern.Replace(sceneName, replacement, 1);

            detail = HumanizeIdentifier(detail);
            detail = TrimRepeatedDetail(prefix, detail);
            return string.IsNullOrWhiteSpace(detail) ? prefix : $"{prefix} / {detail}";
        }

        var fallbackPrefix = dlc switch{
            DlcType.NotAHero => "Not a Hero",
            DlcType.EndOfZoe => "End of Zoe",
            DlcType.Jacks55thBirthday => "Jack's 55th Birthday",
            DlcType.EthanMustDie => "Ethan Must Die",
            DlcType.Bedroom => "Bedroom",
            DlcType.Daughters => "Daughters",
            DlcType.Nightmare => "Nightmare",
            DlcType.TwentyOne => "21",
            _ => chapter == null ? null : $"Chapter {chapter}",
        };

        var fallbackDetail = HumanizeIdentifier(sceneName);
        if (string.IsNullOrWhiteSpace(fallbackPrefix))
            return fallbackDetail;
        if (string.IsNullOrWhiteSpace(fallbackDetail))
            return fallbackPrefix;
        fallbackDetail = TrimRepeatedDetail(fallbackPrefix, fallbackDetail);
        if (string.IsNullOrWhiteSpace(fallbackDetail))
            return fallbackPrefix;
        return $"{fallbackPrefix} / {fallbackDetail}";
    }

    private string? GetMapDescription(string sceneName) {
        if (_mapZoneDescriptions.Value.TryGetValue(sceneName, out var exact))
            return exact;

        foreach (var (prefix, description) in _mapZoneDescriptions.Value.OrderByDescending(x => x.Key.Length)) {
            if (!sceneName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                continue;

            var remainder = sceneName[prefix.Length..].Trim('_');
            var detail = HumanizeIdentifier(remainder);
            detail = TrimRepeatedDetail(description, detail);
            return string.IsNullOrWhiteSpace(detail) ? description : $"{description} / {detail}";
        }

        return null;
    }

    private static Dictionary<Guid, string> LoadMessageLabels(PakFile pakFile) {
        var result = new Dictionary<Guid, string>();
        AddMessageFile("natives/stm/message/ui_map_mes.msg.17");
        AddMessageFile("natives/stm/ch8/message/ch8_map_mes.msg.17");
        AddMessageFile("natives/stm/message/ch9_map_mes.msg.17");
        return result;

        void AddMessageFile(string path) {
            var data = pakFile.GetEntryData(path);
            if (data == null)
                return;

            var msgFile = new MsgFile(data).ToBuilder();
            foreach (var message in msgFile.Messages) {
                var text = message[LanguageId.English].Trim();
                if (text.Length != 0) {
                    result[message.Guid] = text;
                }
            }
        }
    }

    private static List<MapSheet> LoadMapSheets(PakFile pakFile, RszTypeRepository rszRepository) {
        var result = new List<MapSheet>();
        Add("natives/stm/prefab/gui/mapsheetsettings.user.2", AreaSource.MainGame);
        Add("natives/stm/ch8/prefab/gui/ch8mapsheetsettings.user.2", AreaSource.NotAHero);
        Add("natives/stm/ch9/prefab/gui/mapsheetsettings.user.2", AreaSource.EndOfZoe);
        return result;

        void Add(string path, AreaSource source) {
            var data = pakFile.GetEntryData(path);
            if (data == null)
                return;

            var root = new UserFile(data).GetObjects(rszRepository).SingleOrDefault();
            if (root?.Children.SingleOrDefault() is not RszArrayNode settings)
                return;

            foreach (var node in settings.Children.OfType<RszObjectNode>()
                         .Where(node => node.Type.Name == "app.MapSheetData")) {
                var ranges = GetArray(node, "FloorIdList")
                    .Children
                    .OfType<RszObjectNode>()
                    .Select(range => new RoomRange(GetUInt32(range, "FloorIDStart"), GetUInt32(range, "FloorIDEnd")))
                    .ToArray();

                result.Add(new MapSheet(
                    source,
                    GetString(node, "MapSheetName"),
                    GetGuid(node, "AreaName"),
                    GetString(node, "Category"),
                    ranges));
            }
        }
    }

    private static Dictionary<string, string> LoadMapZoneDescriptions(PakFile pakFile, PakList pakList,
        RszTypeRepository rszRepository) {
        var sheets = LoadMapSheets(pakFile, rszRepository);
        var labels = LoadMessageLabels(pakFile);
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var path in pakList.Entries.Where(IsMapZoneScene)) {
            var data = pakFile.GetEntryData(path);
            if (data == null)
                continue;

            var source = GetAreaSource(path);
            var sceneName = GetMapZoneSceneName(path);
            var roomIds = ReadRoomIds(data, rszRepository);
            var chapterHint = GetChapterHint(sceneName);
            var matches = sheets
                .Where(sheet => sheet.Source == source)
                .Where(sheet => chapterHint == null ||
                                sheet.MapSheetName.StartsWith(chapterHint, StringComparison.OrdinalIgnoreCase) ||
                                sheet.Category.StartsWith(chapterHint, StringComparison.OrdinalIgnoreCase))
                .Where(sheet => roomIds.Any(sheet.Contains))
                .Select(sheet => GetSheetDescription(sheet, labels))
                .Where(description => !string.IsNullOrWhiteSpace(description))
                .GroupBy(description => description, StringComparer.OrdinalIgnoreCase)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key, StringComparer.OrdinalIgnoreCase)
                .FirstOrDefault();

            if (matches != null) {
                result[sceneName] = matches.Key;
            }
        }

        return result;
    }

    private static bool IsMapZoneScene(string path) =>
        path.EndsWith($".scn.{FileVersions.SceneFileVersion}", StringComparison.OrdinalIgnoreCase) &&
        path.Contains("mapzone", StringComparison.OrdinalIgnoreCase);

    private static AreaSource GetAreaSource(string path) {
        if (path.Contains("/ch8/", StringComparison.OrdinalIgnoreCase))
            return AreaSource.NotAHero;
        if (path.Contains("/ch9/", StringComparison.OrdinalIgnoreCase))
            return AreaSource.EndOfZoe;
        return AreaSource.MainGame;
    }

    private static string? GetChapterHint(string sceneName) {
        if (sceneName.StartsWith("c01", StringComparison.OrdinalIgnoreCase))
            return "Chapter1";
        if (sceneName.StartsWith("c03", StringComparison.OrdinalIgnoreCase))
            return "Chapter3";
        if (sceneName.StartsWith("c04", StringComparison.OrdinalIgnoreCase))
            return "Chapter4";
        if (sceneName.StartsWith("c08", StringComparison.OrdinalIgnoreCase))
            return "Chapter8";
        if (sceneName.StartsWith("c09", StringComparison.OrdinalIgnoreCase) ||
            sceneName.StartsWith("mapzone_c09", StringComparison.OrdinalIgnoreCase))
            return "Chapter9";
        return null;
    }

    private static string GetSheetDescription(MapSheet sheet, Dictionary<Guid, string> labels) {
        var label = labels.TryGetValue(sheet.AreaName, out var value)
            ? value
            : GetMapSheetFallbackLabel(sheet.MapSheetName);

        return sheet.Source switch{
            AreaSource.NotAHero => $"Not a Hero / {label}",
            AreaSource.EndOfZoe => $"End of Zoe / {label}",
            _ => label,
        };
    }

    private static string GetMapSheetFallbackLabel(string mapSheetName) =>
        mapSheetName switch{
            "Chapter1_Out" => "Outside",
            _ => HumanizeIdentifier(mapSheetName),
        };

    private static int[] ReadRoomIds(byte[] data, RszTypeRepository rszRepository) {
        var scene = new ScnFile(FileVersions.SceneFileVersion, data).ReadScene(rszRepository);
        var result = new List<int>();
        scene.Visit(node => {
            if (node is RszObjectNode objectNode &&
                (objectNode.Type.Name == "app.cutin.MapZoneCollider" ||
                 objectNode.Type.Name == "app.CH8MapZoneCollider")) {
                result.Add(GetInt32(objectNode, "RoomId"));
            }
        });
        return [.. result];
    }

    private static string GetMapZoneSceneName(string path) {
        var sceneName = GetSceneName(path);
        if (sceneName.StartsWith("mapzone_", StringComparison.OrdinalIgnoreCase)) {
            sceneName = sceneName["mapzone_".Length..];
        }

        if (sceneName.EndsWith("_mapzone", StringComparison.OrdinalIgnoreCase)) {
            sceneName = sceneName[..^"_mapzone".Length];
        }

        return sceneName;
    }

    private static string GetBestSceneName(string path) {
        var sceneNames = path
            .Split(['/', '\\'], StringSplitOptions.RemoveEmptyEntries)
            .Select(GetSceneName)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .ToArray();

        return sceneNames
            .Reverse()
            .FirstOrDefault(IsSpecificSceneName) ?? GetFallbackSceneName(sceneNames);
    }

    private static string GetFallbackSceneName(string[] sceneNames) {
        if (sceneNames.Length == 0)
            return "";

        var last = sceneNames[^1];
        if (IsGenericSceneName(last) && sceneNames.Length >= 2) {
            return $"{sceneNames[^2]}_{last}";
        }

        return last;
    }

    private static string GetSceneName(string path) {
        var name = Path.GetFileName(path).ToLowerInvariant();
        return SceneVersionRegex.Replace(name, "");
    }

    private static bool IsSpecificSceneName(string name) {
        if (IsGenericSceneName(name))
            return false;
        if (name.StartsWith("resources_", StringComparison.OrdinalIgnoreCase))
            return false;
        if (name.StartsWith("chapter", StringComparison.OrdinalIgnoreCase) &&
            name.All(ch => char.IsAsciiLetterOrDigit(ch) || ch == '_'))
            return false;
        return name.StartsWith("c0", StringComparison.OrdinalIgnoreCase) ||
               name.StartsWith("ch", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsGenericSceneName(string name) =>
        name is "normal" or "hard" or "casual" or "easy";

    private static string HumanizeIdentifier(string identifier) {
        if (string.IsNullOrWhiteSpace(identifier))
            return "";

        var value = identifier
            .Replace('_', ' ')
            .Replace('-', ' ');
        value = LeadingChapterRegex.Replace(value, "");
        value = Regex.Replace(value, @"\b(?:c|ch)\d+\b", "", RegexOptions.IgnoreCase).Trim();
        value = value
            .Replace("cullingcollision", " cullingcollision ", StringComparison.OrdinalIgnoreCase)
            .Replace("loadcollision", " loadcollision ", StringComparison.OrdinalIgnoreCase)
            .Replace("loadcollistion", " loadcollistion ", StringComparison.OrdinalIgnoreCase)
            .Replace("b1f", " b1f ", StringComparison.OrdinalIgnoreCase)
            .Replace("b2f", " b2f ", StringComparison.OrdinalIgnoreCase)
            .Replace("b3f", " b3f ", StringComparison.OrdinalIgnoreCase)
            .Replace("1f", " 1f ", StringComparison.OrdinalIgnoreCase)
            .Replace("2f", " 2f ", StringComparison.OrdinalIgnoreCase)
            .Replace("3f", " 3f ", StringComparison.OrdinalIgnoreCase)
            .Replace("4f", " 4f ", StringComparison.OrdinalIgnoreCase);

        var words = WordRegex
            .Matches(value)
            .Select(match => HumanizeWord(match.Value))
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .ToArray();

        return string.Join(" ", words);
    }

    private static string TrimRepeatedDetail(string prefix, string detail) {
        if (string.IsNullOrWhiteSpace(detail))
            return "";

        var lastPrefixSegment = prefix
            .Split('/', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .LastOrDefault();
        if (string.IsNullOrWhiteSpace(lastPrefixSegment))
            return detail;

        if (string.Equals(detail, lastPrefixSegment, StringComparison.OrdinalIgnoreCase))
            return "";

        var repeatedStart = lastPrefixSegment + " ";
        if (detail.StartsWith(repeatedStart, StringComparison.OrdinalIgnoreCase))
            return detail[repeatedStart.Length..].Trim();

        return detail;
    }

    private static string HumanizeWord(string word) {
        if (WordReplacements.TryGetValue(word, out var replacement))
            return replacement;

        if (Regex.IsMatch(word, @"^\d+f$", RegexOptions.IgnoreCase))
            return word.ToUpperInvariant();
        if (Regex.IsMatch(word, @"^s\d+$", RegexOptions.IgnoreCase))
            return word.ToUpperInvariant();
        if (int.TryParse(word, out var number))
            return number.ToString("00");

        return char.ToUpperInvariant(word[0]) + word[1..].ToLowerInvariant();
    }

    private static RszArrayNode GetArray(RszObjectNode node, string field) => (RszArrayNode)node[field];
    private static string GetString(RszObjectNode node, string field) => ((RszStringNode)node[field]).Value;
    private static Guid GetGuid(RszObjectNode node, string field) => new(((RszValueNode)node[field]).Data.ToArray());

    private static int GetInt32(RszObjectNode node, string field) =>
        BitConverter.ToInt32(((RszValueNode)node[field]).Data.Span);

    private static uint GetUInt32(RszObjectNode node, string field) =>
        BitConverter.ToUInt32(((RszValueNode)node[field]).Data.Span);

    private sealed record MapSheet(
        AreaSource Source,
        string MapSheetName,
        Guid AreaName,
        string Category,
        RoomRange[] Ranges) {
        public bool Contains(int roomId) => Ranges.Any(range => roomId >= range.Start && roomId <= range.End);
    }

    private sealed record RoomRange(uint Start, uint End);

    private enum AreaSource {
        MainGame,
        NotAHero,
        EndOfZoe,
    }
}