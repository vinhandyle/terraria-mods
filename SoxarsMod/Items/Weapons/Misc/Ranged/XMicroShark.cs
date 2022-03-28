using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Weapons.Misc.Ranged
{
	public class XMicroShark : ModItem
	{
        private int ammoConsumed = 0;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("School Sprayer");
			Tooltip.SetDefault("Fires a dense mass of bullets \nEveryone gangsta until...");
		}
		public override void SetDefaults()
		{
			item.damage = 8;
            item.useStyle = 5;
            item.useAnimation = 31; 
            item.useTime = 31;
            item.shootSpeed = 7f;
			item.knockBack = 1;
            item.width = 66;
            item.height = 34;
            item.rare = 5;
            item.value = Item.sellPrice(0, 7, 20, 0);
            item.ranged = true;
            item.autoReuse = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles = 10;
            for (int i = 0; i < numProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));                                                                                             
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("MicroShark"), 1);
            recipe.AddIngredient(ItemID.Goldfish, 9);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
