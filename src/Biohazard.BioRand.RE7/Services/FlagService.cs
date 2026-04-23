using IntelOrca.Biohazard.REE.Cryptography;
using IntelOrca.Biohazard.REE.Variables;

namespace Biohazard.BioRand.RE7.Services;

internal class FlagService
{
    private readonly List<Guid> _flagGuids = [];
    private readonly Dictionary<Guid, bool> _flagSets = [];
    private readonly Randomizer _randomizer;
    private UvarFile _uvarFile;
    private List<(string, List<UvarFile.Builder.Variable>)> _preRandoVariables = new();

    private const float FalseValue = 0;
    private const float TrueValue = 1.401298E-45f;
    private const string GlobalVariablesPath = "natives/stm/userdata/globalvariables.uvar.2";

    public FlagService(Randomizer randomizer)
    {
        var uvarBytes = randomizer.FileRepository.GetFile(GlobalVariablesPath)
            ?? throw new Exception("Invalid uvar path!");
        _uvarFile = new UvarFile(uvarBytes);
        _randomizer = randomizer;
        _preRandoVariables = GetVariablesByEmbeddedFile();
    }

    public List<(string, List<UvarFile.Builder.Variable>)> GetVariablesByEmbeddedFile()
    {
        var result = new List<(string, List<UvarFile.Builder.Variable>)>();
        for (int i = 0; i < _uvarFile.EmbeddedCount; i++)
        {
            var embeddedFile = _uvarFile.GetEmbedded(i);
            var variables = embeddedFile.ToBuilder().Variables;
            result.Add((embeddedFile.Name, variables));
        }

        return result;
    }

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

    private string GetReadableTypeVal(int typeVal)
        => ((Enums.via.userdata.TypeKind)typeVal).ToString();

    private string FormatValue(int typeVal, float value)
        => ((Enums.via.userdata.TypeKind)typeVal) switch
        {
            Enums.via.userdata.TypeKind.Boolean => (value != 0).ToString(),
            _ => value.ToString() // TODO Improve formatting
        };

    public void Save(RandomizerLogger logger)
    {
        if (_flagGuids.Count == 0 && _flagSets.Count == 0)
            return;

        logger.Push("Default variables");
        _preRandoVariables = _randomizer.FlagService.GetVariablesByEmbeddedFile();
        foreach (var (name, variables) in _preRandoVariables)
        {
            logger.Push(name);
            foreach (var variable in variables)
            {
                logger.LogLine($"[{variable.Guid}] {variable.Name} ({GetReadableTypeVal(variable.TypeVal)}): " +
                    $"{FormatValue(variable.TypeVal, variable.Value)}");
            }
            logger.Pop();
        }
        logger.Pop();

        var biorandGroup = new UvarFile.Builder(_uvarFile.GetEmbedded(0)) // TODO improve API
        {
            Name = "BioRand",
            Hash = MurMur3.HashData("BioRand")
        };
        biorandGroup.Children.Clear();
        biorandGroup.Variables.Clear();

        var flagIndex = 0;
        foreach (var flagGuid in _flagGuids)
        {
            var name = $"BioRand_{flagIndex:00000}";
            biorandGroup.Variables.Add(new UvarFile.Builder.Variable()
            {
                Guid = flagGuid,
                Name = name,
                TypeVal = 2,
                // ValueOffset/ValueData need to be present for newly added flags,
                // otherwise boolean values do not round-trip when the file is rebuilt.
                ValueOffset = 1,
                ValueData = BitConverter.GetBytes(FalseValue)
            });

            flagIndex++;
            if (flagIndex >= 100000)
                break;
        }

        var uvarBuilder = _uvarFile.ToBuilder();
        uvarBuilder.Children.RemoveAll(x => x.Name == "BioRand");
        uvarBuilder.Children.Add(biorandGroup);
        VisitUvar(uvarBuilder);
        _uvarFile = uvarBuilder.Build();
        _randomizer.FileRepository.SetFile(GlobalVariablesPath, _uvarFile.Data);

        logger.Push("Modded variables");
        var postRandoVariables = _randomizer.FlagService.GetVariablesByEmbeddedFile();
        for (int i = 0; i < postRandoVariables.Count - 1; i++) // Exclude BioRand file
        {
            var (preFile, preVars) = _preRandoVariables[i];
            var (_, postVars) = postRandoVariables[i];
            for (int j = 0; j < postVars.Count; j++)
            {
                if (preVars[j].Value != postVars[j].Value)
                {
                    logger.LogLine($"[{preVars[j].Guid}] {preVars[j].Name} changed from " +
                        $"{FormatValue(preVars[j].TypeVal, preVars[j].Value)} to " +
                        $"{FormatValue(postVars[j].TypeVal, postVars[j].Value)} ({preFile})");
                }
            }
        }
        logger.Pop();
    }

    private void VisitUvar(UvarFile.Builder builder)
    {
        foreach (var v in builder.Variables)
        {
            if (_flagSets.TryGetValue(v.Guid, out var value))
            {
                var serializedValue = value ? TrueValue : FalseValue;
                v.Value = serializedValue;
                v.ValueData = BitConverter.GetBytes(serializedValue);
                if (v.ValueOffset == 0)
                {
                    v.ValueOffset = 1;
                }
            }
        }

        foreach (var child in builder.Children)
        {
            VisitUvar(child);
        }
    }
}
