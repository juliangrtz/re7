namespace Biohazard.BioRand.RE7.Modifiers
{
    internal class RecipeModifier : Modifier
    {
        private const string Path = "natives/stm/prefab/item/itemcombinedata.user.2";

        public override void LogState(RE7Randomizer randomizer, RandomizerLogger logger)
        {
            var itemCombineData = randomizer.FileRepository.DeserializeUserFile<app.ItemCombineData>(Path);
            foreach (var item in itemCombineData._Datas)
            {
                logger.LogLine(item.DataID, item.ResultItemID, item.ResultItemNum);
            }
        }

        public override void Apply(RE7Randomizer randomizer, RandomizerLogger logger)
        {
            if (!randomizer.GetConfigOption<bool>("random-recipes"))
                return;

            randomizer.FileRepository.ModifyUserFile<app.ItemCombineData>(Path, root =>
            {
                return root;
            });
        }
    }
}
