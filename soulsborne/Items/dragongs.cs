using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
	public class dragongs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Greatsword");
			Tooltip.SetDefault("This sword, one of the rare dragon weapons, came from the tail of the stone dragon of Ash Lake, descendant of the ancient dragons. \nIts great mystical power will be unleashed when [Right-Clicked].");
		}

		public override void SetDefaults()
		{
			item.damage = 390;
			item.melee = true;
			item.width = 100;
			item.height = 100;
			item.useTime = 42;
			item.useAnimation = 42;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = 1000000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
	}
}