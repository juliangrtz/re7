using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.Serialization;
using Enums.app;
using System.Collections.Immutable;
using System.Linq;

namespace Biohazard.BioRand.RE7.Items
{
    public class ItemDefinitionRepository
    {
        private static ItemDefinitionRepository? _default;

        public ItemDefinition[] Items { get; set; } = [];

        public ImmutableArray<string> Kinds { get; private set; }
        public ImmutableDictionary<string, ImmutableArray<ItemDefinition>> KindToItemMap { get; private set; } =
            ImmutableDictionary<string, ImmutableArray<ItemDefinition>>.Empty;
        public ImmutableDictionary<string, ImmutableArray<ItemDefinition>> DropKindToItemMap { get; private set; } =
            ImmutableDictionary<string, ImmutableArray<ItemDefinition>>.Empty;
        public ImmutableDictionary<string, ItemDefinition> IdToItemMap { get; private set; } =
            ImmutableDictionary<string, ItemDefinition>.Empty;
        public ImmutableDictionary<string, ItemDefinition> WeaponIdToItemMap { get; private set; } =
            ImmutableDictionary<string, ItemDefinition>.Empty;

        public static ItemDefinitionRepository Default
        {
            get
            {
                if (_default == null)
                {
                    _default ??= EmbeddedData.GetFile("items.json").DeserializeJson<ItemDefinitionRepository>();
                    _default.Initialize();
                }
                return _default;
            }
        }

        private void Initialize()
        {
            //var releventItems = Items
            //    .Where(x => !string.IsNullOrEmpty(x.Type))
            //    .ToArray();

            //Kinds = releventItems
            //    .Select(x => x.Category!)
            //    .Distinct()
            //    .ToImmutableArray();
            //KindToItemMap = releventItems
            //    .GroupBy(x => x.Category!)
            //    .ToImmutableDictionary(x => x.Key, x => x.ToImmutableArray());
            //DropKindToItemMap = releventItems
            //    .Where(x => x.DropKind != null)
            //    .GroupBy(x => x.DropKind!)
            //    .ToImmutableDictionary(x => x.Key, x => x.ToImmutableArray());
            //IdToItemMap = Items.ToImmutableDictionary(x => x.Id);
            //WeaponIdToItemMap = Items
            //    .Where(x => x.WeaponId != null)
            //    .ToImmutableDictionary(x => x.WeaponId!.Value);
        }

        public ItemDefinition? Find(string id)
        {
            IdToItemMap.TryGetValue(id, out var item);
            return item;
        }

        public string GetName(string id)
        {
            return Find(id)?.Name ?? id.ToString();
        }

        public ItemDefinition? FromWeaponId(string id)
        {
            WeaponIdToItemMap.TryGetValue(id, out var item);
            return item;
        }

        public ItemDefinition[] GetAll(string kind)
        {
            var items = KindToItemMap[kind].ToArray();
            return items;
        }

        public ImmutableArray<ItemDefinition> FromDropKind(string dropKind)
        {
            var result = DropKindToItemMap.GetValueOrDefault(dropKind);
            return result.IsDefault ? [] : result;
        }
    }

    public static class ItemKinds
    {
        public const string Ammo = "ammo";
        public const string Fish = "fish";
        public const string Viper = "viper";
        public const string Health = "health";
        public const string Egg = "egg";
        public const string Treasure = "treasure";
        public const string Attachment = "attachment";
        public const string Gunpowder = "gunpowder";
        public const string Resource = "resource";
        public const string Weapon = "weapon";
        public const string Knife = "knife";
        public const string Key = "key";
        public const string Token = "token";
        public const string Special = "special";
        public const string Money = "money";
        public const string Armor = "armor";
        public const string Map = "map";
        public const string CaseSize = "case-size";
        public const string CasePerk = "case-perk";
        public const string Recipe = "recipe";
        public const string Charm = "charm";
        public const string Grenade = "grenade";
        public const string SmallKey = "small-key";
    }
}
