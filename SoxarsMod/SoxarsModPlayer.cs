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
        //Sin
        public static int sin = 0;
        public static int sinTier = 0;
        public static int deathsToday = 0;

        //Covenants
        public static int dragonTier = 0;
        public static int readingsToday = 0;
        public static int occultTier = 0;

        //Speed
        public static int max_Speed = 25;
        public static float speed_Mult = 1f;

        //Tarot
        public static bool tarot13Equipped = false; //Death
        public static bool tarot19Equipped = false; //The Sun
        public static bool tarot21Equipped = false; //The World
        public static bool tarotCardsEquipped = false; //Major Arcana

        //Dev Bracelet
        public static bool prowessEquipped; 
        public static bool trueProwessEquipped;

        int tarot21Heal = 0;

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            deathsToday++;
            if (sin > 4) { sin -= 5; } else { sin = 0; }        
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (tarotCardsEquipped || tarot19Equipped)
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
            if (tarotCardsEquipped || tarot19Equipped)
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
            if ((tarotCardsEquipped || tarot13Equipped) && player.FindBuffIndex(mod.BuffType("Death13")) < 0)
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
            if (tarotCardsEquipped || tarot21Equipped)
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

        public override void PostUpdate()
        {
            if (Main.time == 0) { deathsToday = 0; }
            sin++;
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
            tarot13Equipped = false; 
            tarot19Equipped = false; 
            tarot21Equipped = false;
            tarotCardsEquipped = false;

            speed_Mult = 1f;
        }
    }
}
