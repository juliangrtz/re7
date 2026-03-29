using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Messages;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class MessageModifier : Modifier
{
    private const string RandomizerKey = "modifier/messages";

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        if (!randomizer.GetConfigOption<bool>("randomized-messages"))
            return;

        var data = randomizer.DynamicData.GetData(DynamicDataName.Messages)!;
        var csv = Csv.Deserialize<TextReplacementModel>(data);

        var rng = randomizer.GetRng(RandomizerKey);

        string? currentFile = null;
        string? currentName = null;

        var normalized = new List<TextReplacementModel>();

        foreach (var row in csv)
        {
            if (!string.IsNullOrWhiteSpace(row.MsgFileName))
                currentFile = row.MsgFileName;

            if (!string.IsNullOrWhiteSpace(row.TextName))
                currentName = row.TextName;

            if (currentFile == null || currentName == null)
                continue;

            normalized.Add(new TextReplacementModel() {
                MsgFileName = currentFile,
                TextName = currentName,
                OriginalText = row.OriginalText,
                Replacement = row.Replacement
            });
        }

        var groups = normalized.GroupBy(x => (x.MsgFileName, x.TextName));

        string ReplaceVariables(string input)
        {
            input = input.Replace("${seed}", randomizer.Seed.ToString());
            input = input.Replace("${user.name}", randomizer.User);
            input = input.Replace("${profile.name}", randomizer.Input.ProfileName);
            input = input.Replace("${profile.author}", randomizer.Input.ProfileAuthor);
            input = input.Replace("${profile.description}", randomizer.Input.ProfileDescription);
            return input;
        }

        foreach (var group in groups)
        {
            var replacements = group
                .Select(x => x.Replacement)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (replacements.Count == 0)
                continue;

            var chosen = rng.Next(replacements);

            randomizer.FileRepository.ModifyMsgFile(PakPath.MessageFile($"message/{group.Key.MsgFileName}"), message =>
            {
                var msg = message.FindMessage(group.Key.TextName);
                if (msg == null)
                {
                    logger.LogLine($"Message \"{group.Key.TextName}\" in {group.Key.MsgFileName} not found!");
                    return;
                }

                message.SetString(msg.Guid, LanguageId.English, ReplaceVariables(chosen));
                logger.LogLine($"Replaced message \"{group.Key.TextName}\" with \"{chosen.Truncate(100)}\" in {group.Key.MsgFileName}");
            });
        }
    }

    internal sealed class TextReplacementModel
    {
        public string MsgFileName { get; init; } = "";
        public string TextName { get; init; } = "";
        public string OriginalText { get; init; } = "";
        public string Replacement { get; init; } = "";
    }
}
