using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
	public class priscidagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Priscilla's Dagger");
			Tooltip.SetDefault("This sword, one of the rare dragon weapons, came from the tail of Priscilla, the Dragon Crossbreed in the painted world of Ariamis. \nPossessing the power of lifehunt, it dances about when wielded, in a fashion reminiscent of the white-robed painting guardians.");
		}

		public override void SetDefaults()
		{
			item.damage = 80;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 2000000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}