using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.BioRand.REE;
using IntelOrca.Biohazard.REE.Messages;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class MessageModifier : Modifier {
    private readonly Randomizer _randomizer;

    public MessageModifier(Randomizer randomizer) {
        _randomizer = randomizer;
    }

    private const string RandomizerKey = "modifier/messages";

    public override void Apply(RandomizerLogger logger) {
        var randomizer = _randomizer;
        if (!randomizer.GetConfigOption<bool>("randomized-messages"))
            return;

        var data = randomizer.DynamicData.GetData(DynamicDataName.Messages)!;
        var csv = Csv.Deserialize<TextReplacementModel>(data);

        var rng = randomizer.GetRng(RandomizerKey);

        string? currentFile = null;
        string? currentName = null;

        var normalized = new List<TextReplacementModel>();

        foreach (var row in csv) {
            if (!string.IsNullOrWhiteSpace(row.MsgFileName))
                currentFile = row.MsgFileName;

            if (!string.IsNullOrWhiteSpace(row.TextName))
                currentName = row.TextName;

            if (currentFile == null || currentName == null)
                continue;

            normalized.Add(new TextReplacementModel(){
                MsgFileName = currentFile,
                TextName = currentName,
                OriginalText = row.OriginalText,
                Replacement = row.Replacement
            });
        }

        var groups = normalized
            .GroupBy(x => (x.MsgFileName, x.TextName))
            .ToList();

        string ReplaceVariables(string input) {
            input = input.Replace("${seed}", randomizer.Seed.ToString());
            input = input.Replace("${user.name}", randomizer.User);
            input = input.Replace("${profile.name}", randomizer.Input.ProfileName);
            input = input.Replace("${profile.author}", randomizer.Input.ProfileAuthor);
            input = input.Replace("${profile.description}", randomizer.Input.ProfileDescription);
            return input;
        }

        var chosenReplacements = groups
            .Select(group => {
                var replacements = group
                    .Select(x => x.Replacement)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                return new{
                    group.Key.MsgFileName,
                    group.Key.TextName,
                    Chosen = replacements.Count == 0 ? null : rng.Next(replacements)
                };
            })
            .Where(x => x.Chosen != null)
            .ToList();

        foreach (var fileGroup in chosenReplacements.GroupBy(x => x.MsgFileName)) {
            randomizer.FileRepository.ModifyMsgFile($"message/{fileGroup.Key}".MessageFile(), message => {
                foreach (var replacement in fileGroup) {
                    var msg = message.FindMessage(replacement.TextName);
                    if (msg == null) {
                        logger.LogLine($"Message \"{replacement.TextName}\" in {replacement.MsgFileName} not found!");
                        continue;
                    }

                    var chosen = replacement.Chosen!;
                    message.SetString(msg.Guid, LanguageId.English, ReplaceVariables(chosen));
                    logger.LogLine(
                        $"Replaced message \"{replacement.TextName}\" with \"{chosen.Truncate(100)}\" in {replacement.MsgFileName}");
                }
            });
        }
    }

    internal sealed class TextReplacementModel {
        public string MsgFileName { get; init; } = "";
        public string TextName { get; init; } = "";
        public string OriginalText { get; init; } = "";
        public string Replacement { get; init; } = "";
    }
}