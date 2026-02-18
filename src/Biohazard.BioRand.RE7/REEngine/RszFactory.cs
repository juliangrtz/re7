using IntelOrca.Biohazard.REE.Rsz;
using System;
using System.Collections.Immutable;
using System.Numerics;

namespace Biohazard.BioRand.RE7.REEngine {
    internal static class RszFactory {
        public static RszTypeRepository Repository = FileRepository.RszRepository;

        public static RszGameObject CreateGameObject(string name, string prefab, ImmutableArray<RszObjectNode> components) {
            return new RszGameObject(
                Guid.NewGuid(),
                prefab,
                Repository.Create("via.GameObject")
                    .Set("Name", name)
                    .Set("UpdateSelf", true)
                    .Set("DrawSelf", true)
                    .Set("Timescale", -1),
                components,
                []);
        }

        public static RszObjectNode CreateTransform(Vector3? position = null, Quaternion? rotation = null, Vector3? scale = null) {
            return Repository.Create("via.Transform")
                .Set("Position", position ?? Vector3.Zero)
                .Set("Rotation", rotation ?? Quaternion.Identity)
                .Set("Scale", scale ?? Vector3.One);
        }

        public static RszGameObject CreateSpawnController(string name) {
            var transform = CreateTransform();
            var characterSpawnControllerComponent = Repository
                .Create("chainsaw.CharacterSpawnController")
                    .Set("Enabled", true)
                    .Set("_DifficutyParam", 63U)
                    .Set("_GUID", Guid.NewGuid());

            return CreateGameObject(
                name,
                "_Chainsaw/AppSystem/Prefab/CharacterSpawnController.pfb",
                [transform, characterSpawnControllerComponent]);
        }
    }
}
