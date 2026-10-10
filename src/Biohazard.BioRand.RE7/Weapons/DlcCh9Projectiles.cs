using Biohazard.BioRand.RE7.Extensions;
using Biohazard.BioRand.RE7.REEngine;
using Biohazard.BioRand.RE7.Serialization;
using IntelOrca.Biohazard.REE.Rsz;
using System.Collections.Immutable;

namespace Biohazard.BioRand.RE7.Weapons;

// Explicit research export only. These projectiles are not campaign weapon candidates yet.
internal static class DlcCh9Projectiles {
    internal static ImmutableArray<(string Name, string ManagerField, string Component, string Collision)> Sources { get; } = [
        ("NailKnifeBulletS", "ThrowingWp1500Prefab", "app.CH9ThrowingWp1500", "NailKnifeBulletS"),
        ("HarpoonBulletS", "ThrowingWp1800Prefab", "app.CH9ThrowingWp1800", "HarpoonBulletS"),
        ("JoeLiquidbomb", "LiquidBombPrefab", "app.CH9InstallationWp1900", "wp1900/wp1900"),
        ("KnuckleBulletS", "ThrowingWp0000Prefab", "app.CH9KnuckleBullet", "KnuckleBulletS"),
    ];

    internal static string ManagerPrefab(string root) => $"{root}/CH9ShellManager.pfb";

    internal static void ExportShellManager(IPatchContext context, string root) {
        var source = context.GetScnFile("ch9/scenes/chapter/chapter9.scn".SceneFile()).ReadScene(context.TypeRepository);
        var original = source.GetGameObjects().Single(go => go.Components.Any(c => c.Type.Name == "app.CH9ShellManager"));
        var manager = original.WithName("BioRandCH9ShellManager").WithPrefab("").WithChildren([])
            .WithComponents([.. original.Components.Where(c => c.Type.Name is "via.Transform" or "app.CH9ShellManager")])
            .CloneWithNewGuids(new Rng(789214));
        var files = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        PfbFile.Builder? template = null;
        foreach (var (name, field, component, collisionName) in Sources) {
            var reference = $"{root}/{name}/Shell.pfb";
            var collision = $"CH9/Collision/Collider/Weapon/{collisionName}.rcol";
            var shell = context.GetPfbFile($"ch9/prefab/weapon/{name}.pfb".Of() + ".17")
                .ToBuilder(context.TypeRepository);
            if (!shell.Scene.GetGameObjects().SelectMany(go => go.Components).Any(c => c.Type.Name == component))
                throw new InvalidDataException($"Missing native CH9 projectile component: {name}");
            var rebound = false;
            shell.Scene = shell.Scene.Visit(node => {
                if (node is not RszResourceNode resource
                    || !string.Equals(resource.Value, collision, StringComparison.OrdinalIgnoreCase)) return node;
                rebound = true;
                return new RszResourceNode($"{root}/{name}/Attack.rcol");
            });
            if (!rebound) throw new InvalidDataException($"Missing CH9 projectile collision reference: {name}");
            files.Add(reference.Of() + ".17", shell.RebuildResources().Build().Data.ToArray());
            files.Add($"{root}/{name}/Attack.rcol".RcolFile(), context.GetFile(collision.RcolFile())
                ?? throw new InvalidDataException($"Missing CH9 projectile collision: {collision}"));
            manager = manager.WithComponents([.. manager.Components.Select(c => c.Type.Name != "app.CH9ShellManager" ? c
                : c.Set(field + ".Path", new RszResourceNode(reference)).Set(field + ".Standby", true))]);
            template ??= shell;
        }
        // Retain all four native pool slots, including the unused knuckle pool, without DLC system managers.
        template!.Scene = template.Scene.WithChildren([manager]);
        files.Add(ManagerPrefab(root).Of() + ".17", template.RebuildResources().Build().Data.ToArray());
        foreach (var (path, data) in files) context.SetFile(path, data);
    }
}
