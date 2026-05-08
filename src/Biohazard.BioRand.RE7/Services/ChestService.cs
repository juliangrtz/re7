using Biohazard.BioRand.RE7.Items;
using Biohazard.BioRand.RE7.Extensions;
using IntelOrca.Biohazard.REE.Rsz;
using System.Numerics;

namespace Biohazard.BioRand.RE7.Services;

internal class ChestService(Randomizer randomizer)
{
    private readonly RszGameObject _chestTemplate = randomizer.TemplateService.GetObject("Chest");
    private readonly Dictionary<string, RszGameObject> _weaponCache = new();
    private readonly Rng _rng = randomizer.GetRng("drops/weapon-chests");
    private readonly Rng _templateRng = randomizer.GetRng("drops/weapon-chests/template-instances");

    private RszGameObject GetCachedWeaponOrCreate(string weaponId)
    {
        if (!_weaponCache.ContainsKey(weaponId))
            _weaponCache[weaponId] = randomizer.TemplateService.GetItemTemplate(weaponId);
        return _weaponCache[weaponId];
    }

    public RszScene PlaceWeaponChest(RandomizerLogger logger, RszScene scene, ItemPlacement placement)
    {
        var weaponDrop = randomizer.ItemRandomizer.GetRandomGun(_rng, allowReoccurance: false);
        if (weaponDrop == null)
        {
            // Should never happen given correct weapon definitions
            logger.LogLine("Failed to get random weapon! Empty weapon pool.");
            return scene;
        }

        var transform = new GeneratedViaTransform()
        {
            Position = new Vector3(placement.PosX, placement.PosY, placement.PosZ),
            Rotation = new Quaternion(placement.RotX, placement.RotY, placement.RotZ, placement.RotW),
            Scale = Vector3.One,
            ParentJoint = "",
            SameJointsContraint = false,
            AbsoluteScaling = false,
            JointFastLockScene = false,
            JointSegmentScale = false
        };

        // Create weapon from template
        var weaponGuid = _rng.NextGuid();
        var weapon = GetCachedWeaponOrCreate(weaponDrop.Id)
            .CloneWithNewGuids(_templateRng, weaponGuid);

        // Prevent weapon pickup without using the lock pick
        weapon = weapon.WithSettings(
            weapon.Settings
                .Set("Update", false)
                .Set("Draw", false)
        );

        weapon = weapon.AddOrUpdateComponent(transform);

        // Prepare chest
        var chest = _chestTemplate.CloneWithNewGuids(_templateRng);
        chest = chest.AddOrUpdateComponent(transform);
        var interactDrawer = chest.Children.Single(c => c.Name == "InteractDrawer");
        var interactDrawerComponent = interactDrawer.FindComponent<app.InteractDrawer>()!;
        interactDrawerComponent.SaveGUID = _templateRng.NextGuid();
        interactDrawerComponent.IsDirectGameObjectSet = true;
        interactDrawerComponent.DirectSetGameObject = weaponGuid;
        interactDrawer = interactDrawer.AddOrUpdateComponent(interactDrawerComponent);
        chest = chest.AddOrUpdateChild(interactDrawer);

        scene = scene.Add(weapon);
        scene = scene.Add(chest);

        logger.LogLine($"[EXTRA] Chest at {transform.Position} in {placement.SceneFile} containing {weapon.Name}");
        return scene;
    }
}
