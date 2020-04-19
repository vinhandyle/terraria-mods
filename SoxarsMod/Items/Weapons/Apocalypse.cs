using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod.Items.Weapons
{
	public class Apocalypse : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apocalypse");
			Tooltip.SetDefault("Imbued with the power of a long forgotten Great One \nIts hunger unable to be sated, it devours all life that it touches \nAttacks summon a cascade of explosions");
		}
		public override void SetDefaults()
		{
			item.damage = 1025; // (neutralMax + fireMax + neutralMin + fire Min) / 2
            item.useStyle = 5;
            item.useAnimation = 20; 
            item.useTime = 20;
            item.shootSpeed = 5f;
			item.knockBack = 10;
            item.width = 154;
            item.height = 148;
            item.rare = 11;
            item.value = 1000000;

            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;


            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ApocProjectile1");
        }

        public override bool CanUseItem(Player player)
        {
            // Ensures no more than one spear can be thrown out, use this when using autoReuse
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX / 2, speedY / 2, mod.ProjectileType("ApocProjectile2"), damage * 2, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX * 5, speedY * 5, mod.ProjectileType("ApocProjectile3"), damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position.X, position.Y, speedX * 4, speedY * 4, 696, damage * 5, knockBack, player.whoAmI);
            return true;
        }

        public override void HoldItem(Player player)
        {
            if (player.FindBuffIndex(mod.BuffType("ContrastBuff")) > 0)
            {
                if (player.name != "Soxar") //Change to == later
                {
                    player.AddBuff(mod.BuffType("ApocBuff"), 1);
                }
            }
            else
            {
                if (player.name != "Soxar")
                {
                    player.AddBuff(mod.BuffType("ApocDebuff"), 1);
                }
            }
        }      
	}
}
