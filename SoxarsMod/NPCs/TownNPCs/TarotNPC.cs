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
            int rndChat = rnd.Next(3);
            string dialogue = "";
            if (rndChat == 0)
            {
                dialogue = "Sometimes, things just don't work out.";
            }
            else if (rndChat == 1)
            {
                dialogue = "Are you having a bad day?";
            }
            else if (rndChat == 2)
            {
                dialogue = "Might just be an unlucky day.";
            }
            else if (rndChat == 3)
            {
                dialogue = "You've been having a streak of bad luck lately?";
            }
            return dialogue + " " + "Why don't you come for a reading? You can't change fate, but you can do something to soothe your doubts and worries. In fact, I'll do you for free.";
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
                Random rnd = new Random();
                int rndChat = rnd.Next(9);
                string dialogue = "";
                if (rndChat == 0)
                {
                    dialogue = "A thrilling time is in your immediate future.";
                }
                else if (rndChat == 1)
                {
                    dialogue = "Your everlasting presence will be rewarded sooner or later.";
                }
                else if (rndChat == 2)
                {
                    dialogue = "Something you lost will soon turn up.";
                }
                else if (rndChat == 3)
                {
                    dialogue = "A pleasant surprise is in store for you.";
                }
                else if (rndChat == 4)
                {
                    dialogue = "Be prepared to accept a wondrous opportunity in the days ahead!";
                }
                else if (rndChat == 5)
                {
                    dialogue = "Fame, riches and romance are yours for the asking.";
                }
                else if (rndChat == 6)
                {
                    dialogue = "Your life will be happy and peaceful.";
                }
                else if (rndChat == 7)
                {
                    dialogue = "Happy news is on its way to you.";
                }
                else if (rndChat == 8)
                {
                    dialogue = "Your past success will be overshadowed by your future success.";
                }
                else if (rndChat == 9)
                {
                    dialogue = "Any rough times are behind you.";
                }
                Main.npcChatText = dialogue;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.CrystalBall);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("BlankCard"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("StratiArrow"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType(""));
            nextSlot++;
        }
    }
}
