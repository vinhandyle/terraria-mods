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
    public class LightningBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.aiStyle = 1;
            projectile.penetrate = 3;
            projectile.alpha = 0;
            projectile.timeLeft = 600;
            projectile.light = 1f;
            projectile.extraUpdates = 1;

            projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = false;
            projectile.hostile = true;
        }

        public override void AI()
        {
            
        }
    }
}
