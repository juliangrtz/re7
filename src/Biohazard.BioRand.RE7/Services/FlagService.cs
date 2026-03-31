using IntelOrca.Biohazard.REE.Cryptography;
using IntelOrca.Biohazard.REE.Variables;

namespace Biohazard.BioRand.RE7.Services;

internal class FlagService(Randomizer randomizer)
{
    private readonly List<Guid> _flagGuids = [];
    private readonly Dictionary<Guid, bool> _flagSets = [];

    private const float FalseValue = 0;
    private const float TrueValue = 1.401298E-45f;

    public Guid AllocateFlag()
    {
        var biorandFlagIndex = _flagGuids.Count;
        var guid = $"BioRand_{biorandFlagIndex:00000}".GetGuidHash();
        _flagGuids.Add(guid);
        return guid;
    }

    public void SetFlag(Guid guid, bool value)
    {
        _flagSets[guid] = value;
    }

    public void Save(RandomizerLogger logger)
    {
        // Not usable until version 2 is supported
        return;
        const string globalVariablesPath = "natives/stm/userdata/globalvariables.uvar.2";

        var fileRepository = randomizer.FileRepository;

        // uvar
        var uvarBytes = fileRepository.GetFile(globalVariablesPath) ?? throw new Exception();
        var uvar = new UvarFile(uvarBytes);

        var biorandGroup = new UvarFile.Builder(uvar.GetEmbedded(0)); // TODO improve API
        biorandGroup.Name = "BioRand";
        biorandGroup.Hash = MurMur3.HashData("BioRand");
        biorandGroup.Children.Clear();
        biorandGroup.Variables.Clear();

        var flagIndex = 0;
        foreach (var flagGuid in _flagGuids)
        {
            biorandGroup.Variables.Add(new UvarFile.Builder.Variable()
            {
                Guid = flagGuid,
                Name = $"BioRand_{flagIndex:00000}",
                TypeVal = 2
            });
            flagIndex++;
            if (flagIndex >= 100000)
                break;
        }

        var uvarBuilder = uvar.ToBuilder();
        uvarBuilder.Children.Add(biorandGroup);
        VisitUvar(uvarBuilder);
        fileRepository.SetFile(globalVariablesPath, uvarBuilder.Build().Data);
    }

    private void VisitUvar(UvarFile.Builder builder)
    {
        foreach (var v in builder.Variables)
        {
            if (_flagSets.TryGetValue(v.Guid, out var value))
            {
                v.Value = value ? TrueValue : FalseValue;
            }
        }

        foreach (var child in builder.Children)
        {
            VisitUvar(child);
        }
    }
}
