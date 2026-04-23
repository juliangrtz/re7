using System.Reflection;

using Biohazard.BioRand.RE7.Services;
using IntelOrca.Biohazard.BioRand;

namespace Biohazard.BioRand.RE7.Tests;

[Collection("FlagService serial")]
public class FlagServiceTests
{
    private static readonly (Guid Guid, string Name)[] RecipeUnlockFlags =
    [
        (new("38208fea-638c-4d54-ac9c-8d05a31436dd"), "cmb_releasable_RemedyS"),
        (new("d5c61cc1-5fc3-42bd-a247-a0673c3dc1b8"), "cmb_enable_RemedyS"),
        (new("d8e59fe1-a257-4a78-8574-d20f5ad35e1d"), "cmb_enable_Eye"),
        (new("66203bf4-f916-42bc-af44-05990479f5e6"), "cmb_enable_Fuel"),
        (new("5135aae4-9684-45b3-bd37-9edfbceaf054"), "cmb_enable_Gunpowder"),
        (new("c4256fad-6e47-44e7-9736-54868dfd4214"), "cmb_enable_Strength"),
        (new("2d37e99b-b701-4f78-b0a7-1c7c7bc3df68"), "cmb_enable_Sparekey"),
        (new("79aba106-1ebe-44ca-93f3-9ee34b118137"), "cmb_enable_Plasticexplosive"),
        (new("eab670f7-4475-4258-b900-cbe91664c9a3"), "cmb_enable_DybbukMedicine"),
        (new("b92f584f-c686-480c-9ca5-27048348efa5"), "EnableCombine"),
        (new("0ab3a430-7183-4863-b8e3-5b8f4bdee557"), "RecipeGetCnt"),
        (new("419a0691-1219-4447-b927-e31ac6e35486"), "UnlockedDictionaryCombine"),
    ];

    [Fact]
    public void Save_WithoutPendingFlags_DoesNotModifyGlobalVariables()
    {
        using var context = CreateContext();

        context.FlagService.Save(new RandomizerLogger());

        Assert.False(context.Randomizer.FileRepository.GetOutputFilesSnapshot().ContainsKey(RandomizerTestPaths.GlobalVariablesPath));
    }

    [Fact]
    public void Save_WithAllocatedFlags_PersistsBioRandVariablesAndValues()
    {
        using var context = CreateContext();
        Assert.DoesNotContain(
            RandomizerTestHelpers.ReadGlobalVariableGroups(
                context.Randomizer.FileRepository.GetFile(RandomizerTestPaths.GlobalVariablesPath)!),
            group => group.Name == "BioRand");

        var enabledFlag = context.FlagService.AllocateFlag();
        var disabledFlag = context.FlagService.AllocateFlag();
        context.FlagService.SetFlag(enabledFlag, true);
        context.FlagService.SetFlag(disabledFlag, false);

        context.FlagService.Save(new RandomizerLogger());

        var afterGroups = RandomizerTestHelpers.ReadGlobalVariableGroups(
            context.Randomizer.FileRepository.GetFile(RandomizerTestPaths.GlobalVariablesPath)!);
        var biorandGroup = Assert.Single(afterGroups, group => group.Name == "BioRand");

        var firstFlag = Assert.Single(biorandGroup.Variables, variable => variable.Name == "BioRand_00000");
        var secondFlag = Assert.Single(biorandGroup.Variables, variable => variable.Name == "BioRand_00001");

        Assert.Equal(enabledFlag, firstFlag.Guid);
        Assert.True(firstFlag.BooleanValue);
        Assert.Equal(disabledFlag, secondFlag.Guid);
        Assert.False(secondFlag.BooleanValue);
    }

    [Fact]
    public void Randomizer_WithRecipesUnlockFromStart_EnablesExpectedGlobalVariables()
    {
        using var result = RandomizerTest.RunState(config =>
        {
            config["recipes-unlock-from-start"] = true;
        });

        var beforeVariables = RandomizerTestHelpers.ReadGlobalVariableGroups(result, before: true)
            .SelectMany(group => group.Variables)
            .ToDictionary(variable => variable.Guid);
        var afterVariables = RandomizerTestHelpers.ReadGlobalVariableGroups(result, before: false)
            .SelectMany(group => group.Variables)
            .ToDictionary(variable => variable.Guid);

        Assert.True(result.WasFileModified(RandomizerTestPaths.GlobalVariablesPath));

        foreach (var (guid, name) in RecipeUnlockFlags)
        {
            Assert.True(beforeVariables.TryGetValue(guid, out var before), $"Missing baseline flag {name} ({guid}).");
            Assert.True(afterVariables.TryGetValue(guid, out var after), $"Missing modded flag {name} ({guid}).");

            Assert.Equal(name, before.Name);
            Assert.Equal(name, after.Name);
            Assert.True(
                after.BooleanValue,
                $"{name} ({guid}) remained disabled: before={before.Value} after={after.Value} type={after.TypeVal}.");
        }

        Assert.Contains(
            RecipeUnlockFlags,
            flag => !beforeVariables[flag.Guid].BooleanValue && afterVariables[flag.Guid].BooleanValue);
    }

    private static FlagServiceTestContext CreateContext(Action<RandomizerConfiguration>? configure = null)
    {
        var configuration = RandomizerTest.CreateFeatureTestConfiguration(configure);
        var input = new RandomizerInput()
        {
            Seed = 0x42424242,
            UserName = "flag-service-tests",
            ProfileName = "Flag Service Tests",
            ProfileAuthor = "xUnit",
            ProfileDescription = "FlagService regression tests.",
            Configuration = configuration
        };

        var randomizer = new Randomizer(input, RandomizerTest.InputPakPath, new EmptyReporter());
        var repository = new FileRepository(randomizer, RandomizerTest.InputPakPath, randomizer.DynamicData);
        typeof(Randomizer)
            .GetField("_fileRepository", BindingFlags.Instance | BindingFlags.NonPublic)!
            .SetValue(randomizer, repository);

        return new FlagServiceTestContext(randomizer, randomizer.FlagService);
    }

    private sealed class FlagServiceTestContext(Randomizer randomizer, FlagService flagService) : IDisposable
    {
        public Randomizer Randomizer { get; } = randomizer;
        public FlagService FlagService { get; } = flagService;

        public void Dispose()
        {
            Randomizer.Dispose();
        }
    }
}

[CollectionDefinition("FlagService serial", DisableParallelization = true)]
public sealed class FlagServiceSerialCollection;
