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
    public class MyModPlayer : ModPlayer
    {
        public bool tarot13Equipped; //Death
        public bool tarot19Equipped; //The Sun
        public bool tarot21Equipped; //The World
        public bool tarotCardsEquipped; //Major Arcana

        public bool prowessEquipped;
        public bool trueProwessEquipped;

        int tarot21Heal = 0;

        public override void ResetEffects()
        {
            this.tarotCardsEquipped = false;
        }

        public void UpdatePlayer(int i)
        {      
            
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

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            Random rnd = new Random();
            int dodgeChance = rnd.Next(0, 99);

            if (this.prowessEquipped || this.trueProwessEquipped)
            {
                if (player.whoAmI == Main.myPlayer && ((this.prowessEquipped && dodgeChance < 5) || (this.trueProwessEquipped && dodgeChance < 40)))
                {
                    player.immuneTime = 60;
                    if (player.longInvince)
                    {
                        player.immuneTime += 40;
                    }
                    for (int i = 0; i < 100; i++)
                    {
                        int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 2f);
                        Dust expr_82_cp_0 = Main.dust[num];
                        expr_82_cp_0.position.X = expr_82_cp_0.position.X + (float)Main.rand.Next(-20, 21);
                        Dust expr_A9_cp_0 = Main.dust[num];
                        expr_A9_cp_0.position.Y = expr_A9_cp_0.position.Y + (float)Main.rand.Next(-20, 21);
                        Main.dust[num].velocity *= 0.4f;
                        Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num].scale *= 1f + (float)Main.rand.Next(40) * 0.01f;
                            Main.dust[num].noGravity = true;
                        }
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
