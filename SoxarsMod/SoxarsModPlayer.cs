using Terraria;
using Terraria.ModLoader;


namespace Terraria.ModLoader
{
    public class SoxarsModPlayer : ModPlayer
    {
        public int max_Speed = 25;
        public float speed_Mult = 1f;

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(item, target, damage, knockback, crit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
        }

        public override void PostUpdateEquips()
        {
            base.PostUpdateEquips();

            /*player.accRunSpeed += speed_Mult;
            if (player.velocity.X > max_Speed || player.velocity.X < -max_Speed)
            {
                player.velocity.X = player.direction * max_Speed;
            }*/
        }

        public override void ResetEffects()
        {
            base.ResetEffects();
        }

        public void UpdatePlayer(int i)
        {
            
        }
    }
}
