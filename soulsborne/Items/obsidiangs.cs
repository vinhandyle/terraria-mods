using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
	public class obsidiangs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Obsidian Greatsword");
			Tooltip.SetDefault("This greataxe, one of the rare dragon weapons, is formed by the tail of the one-eyed black dragon Kalameet, the last of the ancient dragons. \nThe mystical power of its obsidian blade will be released when [Right-Clicked].");
		}

		public override void SetDefaults()
		{
			item.damage = 320;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 3500000;
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}