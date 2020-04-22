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
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.IO;

namespace Terraria.ModLoader
{
    public class SoxarsModPlayer : ModPlayer
    {
        //Speed
        public int max_Speed = 25;
        public float speed_Mult = 1f;

        //Tarot
        public bool tarot13Equipped; //Death
        public bool tarot19Equipped; //The Sun
        public bool tarot21Equipped; //The World
        public bool tarotCardsEquipped; //Major Arcana

        //Dev Bracelet
        public bool prowessEquipped; 
        public bool trueProwessEquipped;

        int tarot21Heal = 0;

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (this.tarotCardsEquipped || this.tarot19Equipped)
            {
                if (Main.dayTime == true)
                {
                    target.AddBuff(39, 300);
                }
                else
                {
                    target.AddBuff(24, 300);
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (this.tarotCardsEquipped || this.tarot19Equipped)
            {
                if (Main.dayTime == true)
                {
                    target.AddBuff(39, 300);
                }
                else
                {
                    target.AddBuff(24, 300);
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            return true;
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if ((this.tarotCardsEquipped || this.tarot13Equipped) && player.FindBuffIndex(mod.BuffType("Death13")) < 0)
            {
                player.statLife = 100;
                player.AddBuff(mod.BuffType("Death13"), 3600);
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void PreUpdateBuffs()
        {
            if (this.tarotCardsEquipped || this.tarot21Equipped)
            {
                if (player.FindBuffIndex(88) >= 0 && tarot21Heal != 0)
                {
                    player.statLife += 0;
                }
                else if (player.FindBuffIndex(88) >= 0 && tarot21Heal == 0)
                {
                    tarot21Heal++;
                    player.statLife += player.statLifeMax2 / 7;
                }
                else if (player.FindBuffIndex(88) < 0)
                {
                    tarot21Heal = 0;
                }
            }
        }

        public override void PostUpdateEquips()
        {
            player.accRunSpeed += speed_Mult;
            if (player.velocity.X > max_Speed || player.velocity.X < -max_Speed)
            {
                player.velocity.X = player.direction * max_Speed;
            }
        }

        public override void ResetEffects()
        {
            this.tarot13Equipped = false; 
            this.tarot19Equipped = false; 
            this.tarot21Equipped = false;
            this.tarotCardsEquipped = false;

            speed_Mult = 1f;
        }

        public void UpdatePlayer(int i)
        {
            
        }
    }
}
