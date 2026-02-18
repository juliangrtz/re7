using Biohazard.BioRand.RE7.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Biohazard.BioRand.RE7.Chapters {
    public class AreaDefinitionRepository {
        private static AreaDefinitionRepository? _Ethan;
        private static AreaDefinitionRepository? _ada;

        public AreaDefinition[] General { get; set; } = [];
        public AreaDefinition[] Items { get; set; } = [];
        public AreaDefinition[] Gimmicks { get; set; } = [];

        public IEnumerable<AreaDefinition> All {
            get {
                foreach (var d in General)
                    d.Kind = AreaKind.General;
                foreach (var d in Items)
                    d.Kind = AreaKind.Items;
                foreach (var d in Gimmicks)
                    d.Kind = AreaKind.Gimmicks;
                return General.Concat(Items).Concat(Gimmicks);
            }
        }

        public static AreaDefinitionRepository GetRepository(Campaign campaign) {
            return campaign == Campaign.Ethan ? Ethan : Mia;
        }

        private static AreaDefinitionRepository Ethan {
            get {
                _Ethan ??= EmbeddedData.GetFile("areas.json").DeserializeJson<AreaDefinitionRepository>();
                return _Ethan;
            }
        }

        private static AreaDefinitionRepository Mia {
            get {
                _ada ??= EmbeddedData.GetFile("areas_sw.json").DeserializeJson<AreaDefinitionRepository>();
                return _ada;
            }
        }
    }
}
