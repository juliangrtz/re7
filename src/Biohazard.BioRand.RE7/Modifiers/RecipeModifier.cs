using System;

namespace Biohazard.BioRand.RE7.Modifiers {
    internal class RecipeModifier : Modifier {
        private const string DictionaryCombineDataPath = "natives/stm/prefab/item/dictionarycombinedata.user.2";
        private const string ItemCombineDataPath = "natives/stm/prefab/item/itemcombinedata.user.2";

        public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger) {
            var itemCombineData = randomizer.FileRepository.DeserializeUserFile<app.ItemCombineData>(ItemCombineDataPath);
            logger.Push("Vanilla crafting recipes");
            foreach (var item in itemCombineData._Datas) {
                logger.LogLine($"{item.SrcItemNum1}x {item.SrcItemID1} + {item.SrcItemNum2}x {item.SrcItemID2} -> {item.ResultItemNum}x {item.ResultItemID}");
            }
            logger.Pop();
        }

        public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger) {
            if (!randomizer.GetConfigOption<bool>("random-recipes"))
                return;

            randomizer.FileRepository.ModifyUserFile<app.DictionaryCombineData>(DictionaryCombineDataPath, root => {
                root._Datas.Add(new app.DictionaryCombineData.Data {
                    ItemDataID = "Handgun_Albert"
                });

                return root;
            });

            randomizer.FileRepository.ModifyUserFile<app.ItemCombineData>(ItemCombineDataPath, root => {
                root._Datas.Add(new app.ItemCombineData.Data() {
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
