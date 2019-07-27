using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class dragonkgaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon King Greataxe");
            Tooltip.SetDefault("This axe, one of the rare dragon weapons, is formed by the tail of the Gaping Dragon, a distant, deformed descendant of the everlasting dragons. \nThe axe is imbued with a mystical power, to be released when [Right-Clicked.]");
        }

        public override void SetDefaults()
        {
            item.damage = 380;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 1000000;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = false;
        }
    }
}