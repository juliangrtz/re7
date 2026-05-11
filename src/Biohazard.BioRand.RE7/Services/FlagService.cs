using IntelOrca.Biohazard.REE.Cryptography;
using IntelOrca.Biohazard.REE.Variables;
using System.Globalization;

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

    // TODO: Move into reeutils
    private static string FormatValue(UvarFile.Builder.Variable variable)
    {
        var data = variable.ValueData;
        return ((Enums.via.userdata.TypeKind)variable.TypeVal) switch
        {
            Enums.via.userdata.TypeKind.Boolean => (variable.Value != 0).ToString(),
            Enums.via.userdata.TypeKind.Int8 when data.Length >= sizeof(byte) =>
                ((sbyte)data[0]).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Uint8 when data.Length >= sizeof(byte) =>
                data[0].ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Int16 when data.Length >= sizeof(short) =>
                BitConverter.ToInt16(data).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Uint16 when data.Length >= sizeof(ushort) =>
                BitConverter.ToUInt16(data).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Int32 when data.Length >= sizeof(int) =>
                BitConverter.ToInt32(data).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Uint32 when data.Length >= sizeof(uint) =>
                BitConverter.ToUInt32(data).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Int64 when data.Length >= sizeof(long) =>
                BitConverter.ToInt64(data).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Uint64 when data.Length >= sizeof(ulong) =>
                BitConverter.ToUInt64(data).ToString(CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Single =>
                variable.Value.ToString("G9", CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.Double when data.Length >= sizeof(double) =>
                BitConverter.ToDouble(data).ToString("G17", CultureInfo.InvariantCulture),
            Enums.via.userdata.TypeKind.C8 =>
                FormatNullTerminatedString(data, Encoding.UTF8),
            Enums.via.userdata.TypeKind.C16 or Enums.via.userdata.TypeKind.String =>
                FormatNullTerminatedString(data, Encoding.Unicode),
            Enums.via.userdata.TypeKind.GUID when data.Length >= 16 =>
                new Guid(data.AsSpan(0, 16)).ToString(),
            _ => FormatRawValue(variable)
        };
    }

    private static string FormatNullTerminatedString(byte[] data, Encoding encoding)
    {
        if (data.Length == 0)
            return "";

        var value = encoding.GetString(data);
        var nullTerminator = value.IndexOf('\0');
        if (nullTerminator != -1)
        {
            value = value[..nullTerminator];
        }
        return value;
    }

    private static string FormatRawValue(UvarFile.Builder.Variable variable)
    {
        var value = variable.Value.ToString("G9", CultureInfo.InvariantCulture);
        return variable.ValueData.Length == 0
            ? value
            : $"{value} (0x{Convert.ToHexString(variable.ValueData)})";
    }

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
                    $"{FormatValue(variable)}");
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
                        $"{FormatValue(preVars[j])} to " +
                        $"{FormatValue(postVars[j])} ({preFile})");
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
