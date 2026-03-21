using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.REEngine;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Modifiers;

internal class ItemBoxModifier : Modifier
{
    private const string RandomizerKey = "modifier/item-boxes";
    private const string LongItemBoxGameObjectName = "BioRand_ItemBox_VLong";
    private const string OblongItemBoxGameObjectName = "BioRand_ItemBox_Oblong";
    private readonly static ItemDefinitionRepository _itemDefinitionRepository = ItemDefinitionRepository.Default;

    public override void LogState(Randomizer randomizer, RandomizerLogger logger)
    {
    }

    private Vector3 RandomizeScale(Rng rng)
    {
        float[] allowedScales = [0.5f, 0.75f, 1f, 1.25f, 1.5f];
        var chosen = rng.Next(allowedScales);
        return new Vector3(chosen, chosen, chosen);
    }

    public override void Apply(Randomizer randomizer, RandomizerLogger logger)
    {
        var templateService = randomizer.TemplateService;
        var itemService = randomizer.ItemService;
        var areaService = randomizer.AreaService;
        var rng = randomizer.GetRng(RandomizerKey);
        var itemBoxGameObjectName = rng.Next(0, 1) % 2 == 0 ? LongItemBoxGameObjectName : OblongItemBoxGameObjectName;
        var itemBoxGameObjectTemplate = templateService.GetObject(itemBoxGameObjectName);

        foreach (var itemPlacement in itemService.ItemPlacements)
        {
            var isKeyItem = _itemDefinitionRepository.FromId(itemPlacement.Id)!.IsStoryProgressionItem;
            if (!itemPlacement.IsExtra ||
                isKeyItem ||
                itemPlacement.Dlc != null ||
                !itemPlacement.Enabled ||
                itemPlacement.Chapter is <= 0 or >= 7)
            {
                continue;
            }

            var bestArea = areaService.FindBestArea(AreaKind.Item, itemPlacement.Chapter);
            if (bestArea == null)
            {
                continue;
            }

            var transform = new Transform()
            {
                Position = itemPlacement.Position,
                Rotation = itemPlacement.Rotation,
                Scale = RandomizeScale(rng)
            };

            var gameObject = itemBoxGameObjectTemplate.Clone();
            var name = _itemDefinitionRepository.FromId(itemPlacement.Id)!.Name;
            gameObject = gameObject.WithName($"BioRand_DropItem_{name}");
            gameObject = gameObject.WithGuid(itemPlacement.GuidOrAuto);
            gameObject = gameObject.AddOrUpdateComponent(transform.ToComponent());

            var itemDropDestruct = gameObject.FindComponent<app.ItemDropDestruct>()!;
            itemDropDestruct.Enabled = true;
            gameObject = gameObject.AddOrUpdateComponent(itemDropDestruct);

            bestArea.Scene = bestArea.Scene.Add(gameObject);

            areaService.AddGuidToArea(gameObject.Guid, bestArea);
        }
    }
}
