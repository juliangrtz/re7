using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Biohazard.BioRand.RE7.REEngine
{
    internal readonly struct SceneHierachyPath
    {
        public ImmutableArray<string> Hierachy { get; }

        public IReadOnlyList<string> Folders => Hierachy.SkipLast(1).ToImmutableArray();
        public string Name => Hierachy.Last();

        public SceneHierachyPath(string path)
        {
            Hierachy = path.Split('/').ToImmutableArray();
        }

        public override string ToString() => string.Join('/', Hierachy);

        public static implicit operator SceneHierachyPath(string path) => new(path);
    }
}