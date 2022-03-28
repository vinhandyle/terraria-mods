using System;
using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.Projectiles.Player.Apocalypse
{
    public class ApocProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Blaze");
        }

        public override void SetDefaults()
        {
            projectile.width = 150;
            projectile.height = 150;
            projectile.aiStyle = 50;
            projectile.penetrate = -1;
            projectile.alpha = 0;
            projectile.timeLeft = 600;
            projectile.light = 1f;
            projectile.extraUpdates = 1;

            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override void AI()
        {
            projectile.type = 296;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Terraria.Player projOwner = Main.player[projectile.owner];
            Random rnd = new Random();
            int healAmount = rnd.Next(1, 4);
            int healChance = rnd.Next(0, 99);
            if (healChance < 24)
            {
                projOwner.statLife += healAmount;
                projOwner.HealEffect(healAmount, true);
            }
            else
            {
                projOwner.statLife += 0;
            }
        }
    }
}
