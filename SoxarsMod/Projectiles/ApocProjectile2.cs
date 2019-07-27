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
    public class ApocProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Sphere");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = 1;
            projectile.penetrate = 1;
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
            projectile.type = 467;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player projOwner = Main.player[projectile.owner];
            Random rnd = new Random();
            int healAmount = rnd.Next(7, 31);
            int healChance = rnd.Next(0, 99);
            if (healChance < 79)
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
