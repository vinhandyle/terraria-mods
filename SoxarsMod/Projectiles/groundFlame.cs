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
    public class groundFlame : ModProjectile
    {
        private int aiSecond = 0;
        private string state;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flaming Pillar");
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
                projectile.alpha += 1;
            }

            //Kill proj when invisible, proj lasts 255 ticks or 4.25 sec
            if (projectile.alpha >= 255)
            {
                projectile.Kill();
            }

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
