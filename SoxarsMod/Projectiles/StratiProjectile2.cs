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
    public class StratiProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Ball");
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
