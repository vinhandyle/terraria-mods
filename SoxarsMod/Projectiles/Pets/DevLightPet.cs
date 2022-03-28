using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Projectiles.Pets
{
	public class DevLightPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Sun");
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.LightPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.scale = 0.5f;

			projectile.netImportant = true;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 1000f;
			projectile.penetrate = -1;
		}

		public override void AI()
		{
			Terraria.Player player = Main.player[projectile.owner];

			if (!player.HasBuff(mod.BuffType("DevLightPet")))
			{
				projectile.active = false;
			}
			else
            {
				projectile.position.X = player.position.X - projectile.width / 1.5f;
				projectile.position.Y = player.position.Y - player.height * 1.5f;
			}			
		}
	}
}