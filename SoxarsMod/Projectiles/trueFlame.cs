using SoxarsMod.Items.Weapons;
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

namespace SoxarsMod.Projectiles
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

            //Kill proj when invisible, proj lasts 8.5 sec
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
            Player projOwner = Main.player[projectile.owner];

            if (projectile.velocity.X < projectile.velocity.Y)
            { //horizontal spread
                if (projOwner.position.Y < projectile.position.Y)
                { //ground flame
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 15, 5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y + 15, -5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                }
                else if (projOwner.position.Y > projectile.position.Y)
                { //flame from above
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, -5, 0, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                }
            }
            else if (projectile.velocity.X > projectile.velocity.Y)
            { //vertical spread
                if (projOwner.position.X < projectile.position.X)
                { //right-facing
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y , 0, -5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                }
                else if (projOwner.position.X < projectile.position.X)
                { //left-facing
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, -5, mod.ProjectileType("groundFlame"), (int)(projectile.damage * 0.5), projectile.knockBack, Main.myPlayer);
                }
            }

            return true;
        }

        public override void Kill(int timeLeft)
        {

        }
    }
}
