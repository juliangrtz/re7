using System;

namespace Biohazard.BioRand.RE7.Modifiers
{
    /// <summary>
    /// TODO
    /// </summary>
    internal class RecipeModifier : Modifier
    {
        /**
         * TODO: Construct these types of strings in a better way
         * Especially to improve testability and reusability
         */

        private const string DictionaryCombineDataPath = "natives/stm/prefab/item/dictionarycombinedata.user.2";
        private const string ItemCombineDataPath = "natives/stm/prefab/item/itemcombinedata.user.2";
        private const string ItemCombineDataBedroomDlcPath = "natives/stm/prefab/item/itemcombinedata_c07_1.user.2";
        private const string ItemCombineDataBirthdayDlcPath = "natives/stm/prefab/item/itemcombinedata_birthday.user.2";
        // TODO: Add other DLCs

        public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
        {
            var itemCombineData = randomizer.FileRepository.DeserializeUserFile<app.ItemCombineData>(ItemCombineDataPath);
            logger.Push("Vanilla crafting recipes");
            foreach (var item in itemCombineData._Datas)
            {
                logger.LogLine($"{item.SrcItemNum1}x {item.SrcItemID1} + {item.SrcItemNum2}x {item.SrcItemID2} -> {item.ResultItemNum}x {item.ResultItemID}");
            }
            logger.Pop();
        }

        public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
        {
            var randomizationMode = randomizer.GetConfigOption<string>("recipe-randomization-mode");
            switch (randomizationMode)
            {
                case "off":
                    return;

                case "shuffle_outputs":
                    HandleShuffleOutputsMode(randomizer);
                    break;

                case "shuffle_inputs":
                    HandleShuffleInputsMode(randomizer);
                    break;

                case "full_random":
                    HandleFullRandomMode(randomizer);
                    break;

                case "chaos":
                    HandleChaosMode(randomizer);
                    break;

                default:
                    logger.LogLine($"Unknown recipe randomization mode '{randomizationMode}' supplied!");
                    logger.LogLine("Not randomizing recipes.");
                    break;
            }
        }

        private void HandleShuffleOutputsMode(RE7Randomizer randomizer)
        {
            throw new NotImplementedException();
        }

        private void HandleShuffleInputsMode(RE7Randomizer randomizer)
        {
            throw new NotImplementedException();
        }

        private void HandleFullRandomMode(RE7Randomizer randomizer)
        {
            throw new NotImplementedException();
        }

        private void HandleChaosMode(RE7Randomizer randomizer)
        {
            var onlyAdd = randomizer.GetConfigOption<bool>("recipe-only-add");

            if (onlyAdd)
            {
                var min = randomizer.GetConfigOption<int>("recipe-new-entries-min");
                var max = randomizer.GetConfigOption<int>("recipe-new-entries-max");
                var amount = randomizer.GetRng("recipe").Next(min, max);

                for (int i = 0; i < amount; i++)
                {
                    // TODO
                }
            }
            else
            {
            }

            randomizer.FileRepository.ModifyUserFile<app.DictionaryCombineData>(DictionaryCombineDataPath, root =>
            {
                root._Datas.Add(new app.DictionaryCombineData.Data
                {
                    ItemDataID = "Handgun_Albert"
                });

                return root;
            });

            randomizer.FileRepository.ModifyUserFile<app.ItemCombineData>(ItemCombineDataPath, root =>
            {
                root._Datas.Add(new app.ItemCombineData.Data()
                {
                    _Comment = "Test",
                    DataID = "ChemicalM",
                    SrcItemID1 = "Herb",
                    SrcItemNum1 = 1,
                    SrcItemID2 = "Herb",
                    SrcItemNum2 = 1,
                    ResultItemID = "Handgun_Albert",
                    ResultItemNum = 10,
                    EnableFlag = Guid.Empty,
                    IsTrophyTarget = false,
                    IsTutorialTarget = false,
                });

                return root;
            });
        }
    }
}