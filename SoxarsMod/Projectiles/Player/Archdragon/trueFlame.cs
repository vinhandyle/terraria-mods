using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.Projectiles.Player.Archdragon
{
    public class trueFlame : ModProjectile
    {
        private int aiSecond;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Flame");
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 30;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.alpha = 0;
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

            //Becomes more transparent every 2 ticks
            if (aiSecond % 2 == 0)
            {
                projectile.alpha += 1;
            }

            //Kill proj when invisible, proj lasts ~8.25 sec
            if (projectile.alpha >= 255)
            {
                projectile.Kill();
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
            Terraria.Player projOwner = Main.player[projectile.owner];

            if (projectile.oldVelocity.X > projectile.velocity.X)
            { //spreads along right wall
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
            }

            if (projectile.oldVelocity.X < projectile.velocity.X)
            { //spreads along left wall
                Projectile.NewProjectile(projectile.position.X + 15, projectile.position.Y, 0, 5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X + 15, projectile.position.Y, 0, -5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
            }

            if (projectile.oldVelocity.Y > projectile.velocity.Y)
            { //spreads along floor
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 15, 5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 15, -5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
            }

            if (projectile.oldVelocity.Y < projectile.velocity.Y)
            { //spreads along ceiling
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 15, 5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 15, -5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
            }

            return true;
        }

        public override void Kill(int timeLeft)
        {

        }
    }
}
