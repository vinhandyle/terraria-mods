using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
	public class drakesword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drake Sword");
			Tooltip.SetDefault("This sword, one of the rare dragon weapons, is formed by a drake's tail. \nDrakes are seen as undeveloped imitators of the dragons, but they are likely their distant kin. \nThe sword is imbued with a mystical power, to be released when [Right-Clicked.]");
		}

		public override void SetDefaults()
		{
			item.damage = 132;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 250000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}
	}
}