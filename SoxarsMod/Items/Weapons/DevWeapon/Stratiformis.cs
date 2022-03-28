using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Weapons.DevWeapon
{
	public class Stratiformis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stratiformis");
			Tooltip.SetDefault("An excellently crafted bow from a distant land \nAllows its wielder to command the winds \nBe wary when using bursts of speed");
		}
		public override void SetDefaults()
		{
			item.damage = 530;
            item.useStyle = 5;
            item.useAnimation = 6; 
            item.useTime = 6;
            item.shootSpeed = 1f;
			item.knockBack = 2;
            item.width = 50;
            item.height = 100;
            item.rare = 11;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.ranged = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.shoot = mod.ProjectileType("StratiProjectile1");
            item.useAmmo = mod.ItemType("StratiArrow");
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= 1f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(mod.BuffType("StratiBuff"), 1);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numProjectiles = 2;
            for (int i = 0; i < numProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            Random rnd = new Random();
            int bombChance = rnd.Next(0, 99);
            if (bombChance < 19)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("StratiProjectile2"), damage, knockBack, player.whoAmI);
            } 
            return true;
        }
    }
}
