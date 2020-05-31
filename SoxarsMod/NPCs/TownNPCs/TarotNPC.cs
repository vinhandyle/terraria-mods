using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Utilities;

namespace SoxarsMod.NPCs.TownNPCs
{
    [AutoloadHead]
    public class TarotNPC : ModNPC
    {
        private int deathsBefore = 0;
        private int deathsChecked = 0;

        public override string Texture
        {
            get { return "SoxarsMod/NPCs/TownNPCs/TarotNPC"; }
        }

        public override bool Autoload(ref string name)
        {
            name = "The Fortuneteller";
            return base.Autoload(ref name);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Fortuneteller");
            Main.npcFrameCount[npc.type] = 16;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 26;
            npc.height = 46;
            npc.aiStyle = 7;
            npc.defense = 30;
            npc.lifeMax = 500;
            npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit8;
            npc.DeathSound = SoundID.NPCDeath5;
            animationType = NPCID.Guide;
        }

        public static bool TownSpawn()
        {
            return true;
        }

        public override string GetChat()
        {
            Random rnd = new Random();
            int rndChat = rnd.Next(4);
            string dialogue = "";

            if (Main.time == 0)
            {
                SoxarsModPlayer.readingsToday = 0;
            }

            if (SoxarsModPlayer.readingsToday == 0) { deathsBefore = SoxarsModPlayer.deathsToday; } else { deathsBefore = SoxarsModPlayer.deathsToday - deathsChecked; }

            if (deathsBefore == 0) { dialogue += " Welcome."; }
            else if (deathsBefore <= 5) { dialogue += " Sometimes, things just don't work out."; }
            else if (deathsBefore <= 10) { dialogue += " Are you having a bad day?"; }
            else if (deathsBefore <= 15) { dialogue += " Might just be an unlucky day."; }
            else { dialogue += " You've been having a streak of bad luck lately?"; }

            if (SoxarsModPlayer.readingsToday == 0)
            {
                return dialogue + " Why don't you come for a reading? You can't change fate, but you can do something to soothe your doubts and worries. In fact, I'll do you for free.";
            }

            if (rndChat == 0) { return dialogue + " May I interest you in some of my wares?"; }
            else if (rndChat == 1) { return dialogue + " "; }
            else if (rndChat == 2) { return dialogue + " "; }
            else if (rndChat == 3) { return dialogue + " "; }
            else { return dialogue + " "; }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Reading";
        }

        public override void OnChatButtonClicked(bool button, ref bool shop)
        {

            if (button)
            {
                shop = true;
            }
            else
            {
                SoxarsModPlayer.readingsToday++;
                deathsChecked += deathsBefore;
                deathsBefore = 0;

                Random rnd = new Random();
                int rndChat = rnd.Next(9);
                string dialogue = "";

                if (SoxarsModPlayer.readingsToday < 2)
                {
                    if (rndChat == 0) //neutral
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 1) //neutral
                    {
                        dialogue = " "; 
                    }
                    else if (rndChat == 2) //good
                    {
                        dialogue = " "; 
                    }
                    else if (rndChat == 3) //good
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 4) //good
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 5) //good
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 6) //bad
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 7) //bad
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 8) //bad
                    {
                        dialogue = " ";
                    }
                    else if (rndChat == 9) //bad
                    {
                        dialogue = " ";
                    }
                }
                else
                {
                    dialogue = "I can only read your fortune once a day.";
                }
                
                Main.npcChatText = dialogue;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("BlankCard"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType(""));
            nextSlot++;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            //projType = ;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}
