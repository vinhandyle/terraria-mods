using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Projectiles
{
    public class moonlightgsprojectile : ModProjectile
    {
        public override void SetDefaults()
        {
            //projectile.name = "moonlightgsprojectile";
            projectile.width = 100;
            projectile.height = 100;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.friendly = true; 
            projectile.hostile = false; 
            projectile.tileCollide = true; 
            projectile.ignoreWater = true; 
            projectile.magic = true; 
            projectile.aiStyle = 0; 
        }
    }
}