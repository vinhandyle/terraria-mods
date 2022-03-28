using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.Projectiles.Player.Archdragon
{
    public class groundFlame : ModProjectile
    {
        private int aiSecond = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Flame");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 30;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.alpha = 127;
            projectile.light = 2f;

            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override void AI()
        {
            aiSecond++;

            //Becomes more transparent every tick
            if (aiSecond % 1 == 0)
            {
                projectile.alpha += 2;
            }

            //Kill proj when invisible, proj lasts 255 ticks or 2.15 sec
            if (projectile.alpha >= 255)
            {
                projectile.Kill();
            }

            //Slows down proj
            if (aiSecond % 30 == 0 && aiSecond > 0)
            {
                if (projectile.velocity.X > 0)
                {
                    projectile.velocity.X--;
                }
                else if (projectile.velocity.X < 0)
                {
                    projectile.velocity.X++;
                }
            }

            //Loop through 4 animation frames, spending 5 ticks on each.
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return true;
        }

        public override void Kill(int timeLeft)
        {

        }
    }
}
