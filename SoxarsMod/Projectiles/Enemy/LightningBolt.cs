using Terraria.ModLoader;

namespace SoxarsMod.Projectiles.Enemy
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
