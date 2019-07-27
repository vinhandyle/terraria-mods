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
    public class StratiProjectile1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Winds");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
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
            
        }

        public override void Kill(int timeLeft)
        {
            Player projOwner = Main.player[projectile.owner];
            Random rnd = new Random();
            int nadoChance = rnd.Next(0,99);
            if (nadoChance < 4) {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, 656, (int)(projectile.damage * 1.5), projectile.knockBack, Main.myPlayer); //Spawn projectile on projectile death
            }
        }
    }
}
