using Terraria;
using Terraria.ModLoader;


namespace SoxarsMod.Items.Materials
{
    public class BlankCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blank Card");
            Tooltip.SetDefault("There is nothing on it \nWhat can it be used for?");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = 1;
            item.value = 500;
            item.maxStack = 999;
        }
    }
}
