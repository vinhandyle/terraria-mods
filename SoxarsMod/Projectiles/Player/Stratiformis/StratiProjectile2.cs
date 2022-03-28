using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Projectiles.Player.Stratiformis
{
    public class StratiProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Ball");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.aiStyle = 14;
            projectile.penetrate = 5;
            projectile.alpha = 0;
            projectile.timeLeft = 600;
            projectile.light = 1f;
            projectile.extraUpdates = 1;

            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override void AI()
        {
            //Loop through 5 animation frames, spending 4 ticks on each.
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 5)
                {
                    projectile.frame = 0;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 695, (int)(projectile.damage * 12.5), projectile.knockBack, Main.myPlayer); //Spawn projectile on projectile death
                Main.PlaySound(SoundID.Item10, projectile.position);
                projectile.velocity.X = -projectile.velocity.X;
                projectile.velocity.Y = -projectile.velocity.Y;
                projectile.penetrate--;
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 696, (int)(projectile.damage * 25), projectile.knockBack, Main.myPlayer); //Spawn projectile on projectile death
        }
    }
}
