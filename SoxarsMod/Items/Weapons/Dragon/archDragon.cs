using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Weapons.Dragon
{
	public class archDragon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archdragon");
			Tooltip.SetDefault("Harness the powers of old \nLeft-click: Spew forth true flames \nRight-click: Call down the claws of a dragon");
		}
		public override void SetDefaults()
		{
			item.damage = 50;
            item.useStyle = 5;
            item.useTime = 8; 
            item.useAnimation = 8;  
            item.shootSpeed = 8f; //
			item.knockBack = 1; //
            item.scale = 2f;
            item.width = 148; 
            item.height = 96; 
            item.rare = -11; 
            item.value = Item.sellPrice(0, 24, 0, 0); 
            item.shoot = mod.ProjectileType("trueFlame");

            item.melee = true;
            item.autoReuse = true;
            item.noMelee = true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                //slam
                item.useStyle = 5;
                item.useTime = 56;
                item.useAnimation = 56;
                item.damage = 1000;
                item.magic = false;
                item.melee = true;
                //item.shoot = 0;
                item.UseSound = SoundID.Item8;
            }
            else
            { //fire-breath
                item.useStyle = 5;
                item.useTime = 8;
                item.useAnimation = 8;
                item.damage = 50;
                item.melee = false;
                item.magic = true;
                item.shoot = mod.ProjectileType("trueFlame");
                item.UseSound = SoundID.Item74;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            { //slam

            }
            else
            { //fire-breath
                Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 100f;
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }

                Random rnd = new Random();
                int numProjectiles = rnd.Next(1, 9);
                for (int i = 0; i < numProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(50 / (numProjectiles + 1)));
                    speedX = perturbedSpeed.X;
                    speedY = perturbedSpeed.Y;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("trueFlame"), damage, knockBack, player.whoAmI);
                }
            }           
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-25, -10);
        }

        public override void AddRecipes()
		{
            //ModRecipe recipe1 = new ModRecipe(mod);
            //recipe1.AddIngredient(ItemID.Goldfish, 1);
            //recipe1.AddIngredient(ItemID.LeadBar, 5);
            //recipe1.AddTile(ItemID.LeadAnvil);
            //recipe1.SetResult(this);
            //recipe1.AddRecipe();
        }
	}
}
