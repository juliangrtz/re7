using Biohazard.BioRand.RE7.DataGen._Data;
using Biohazard.BioRand.RE7.Items;
using CsvHelper;
using Enums.app;
using IntelOrca.Biohazard.REE.Messages;
using IntelOrca.Biohazard.REE.Rsz;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biohazard.BioRand.RE7.DataGen.Generators
{
    internal class ItemDefinitionGenerator : ITextFileGenerator
    {
        public string Id => "items";

        private readonly JsonSerializerOptions serializationOptions = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        private readonly RszTypeRepository _rszRepository =
            RszRepositorySerializer.Default.FromJsonGz(EmbeddedResource.Get("rszre7rt.json.gz"));

        private app.ItemSettings ReadItemSettings(string filename)
        {
            var userFile = new UserFile(EmbeddedResource.Get(filename));
            return RszSerializer.Deserialize<app.ItemSettings>(userFile.GetObjects(_rszRepository)[0])
                ?? throw new ArgumentException("Illegal filename", filename);
        }

        private IEnumerable<ItemDefinition> GetItemDefinitions()
        {
            var result = new List<ItemDefinition>();
            // -------------------------
            // Main game items
            // -------------------------
            var uiItemMessagesFile = new MsgFile(EmbeddedResource.Get("ui_item_mes.msg.17"));
            var resourceItemSettings = ReadItemSettings("resourceitemsettings.user.2");
            var keyItemSettings = ReadItemSettings("keyitemsettings.user.2");
            var materialItemSettings = ReadItemSettings("materialitemsettings.user.2");
            List<app.ItemData> items = [.. resourceItemSettings._Settings, .. keyItemSettings._Settings, .. materialItemSettings._Settings];

            foreach (var item in items)
            {
                ItemID id;
                if (!Enum.TryParse(item.ItemDataID, out id))
                {
                    Console.WriteLine($"[!] Weird ItemDataID '{item.ItemDataID}' found, ignoring it...");
                    continue;
                }

                result.Add(new ItemDefinition
                {
                    Id = id,
                    Name = uiItemMessagesFile
                            .FindMessage(item.NameMsg)
                            ?.Values
                            .First(v => v.Language == LanguageId.English)
                            .Text
                            .Replace("\u0022", ""), // " character,
                    CategoryType = item.Category,
                    Size = item.SlotSize,
                    MaxStack = item.MaxStackNum,
                    WeaponId = null,
                    CanStoreInItemBox = item.CanStoreItembox,
                    DeveloperComment = item._Comment,
                    IsUnlockable = false
                });
            }

            // -------------------------
            // DLCs
            // -------------------------

            // TODO

            return result;
        }

        private string GetCsv(IEnumerable<ItemDefinition> itemDefinitions)
        {
            using var writer = new StringWriter();
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(itemDefinitions);
            return writer.ToString();
        }

        public string Generate(TextOutputFormat format)
        {
            var itemDefinitions = GetItemDefinitions();
            Console.WriteLine($"[+] Generated {itemDefinitions.Count()} item definitions!");
            Console.WriteLine($"[+] Please check whether the output is correct.");
            return format switch
            {
                TextOutputFormat.Json => JsonSerializer.Serialize(itemDefinitions, serializationOptions),
                TextOutputFormat.Csv => GetCsv(itemDefinitions),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
