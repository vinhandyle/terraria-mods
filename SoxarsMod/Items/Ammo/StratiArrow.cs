using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Ammo
{
	public class StratiArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Violent Storm");
			Tooltip.SetDefault("A bundle of the world's strongest winds \nHow was such a thing created?");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 7));
        }
		public override void SetDefaults()
		{
            item.damage = 106;
            item.ranged = true;
            item.width = 34;
            item.height = 34;
            item.maxStack = 1;
            item.consumable = true;             
            item.knockBack = 2f;
            item.value = Item.sellPrice(20, 0, 0, 0);
            item.rare = 11;
            item.shoot = mod.ProjectileType("StratiProjectile1");  
            item.shootSpeed = 30f;                  
            item.ammo = mod.ItemType("StratiArrow");
        }
    }
}
