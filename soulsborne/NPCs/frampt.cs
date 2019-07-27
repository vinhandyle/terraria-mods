using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.NPCs
{
    public class frampt : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kingseeker Frampt");
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 90;
            npc.height = 270;
            npc.aiStyle = 7;
            npc.defense = 100;
            npc.lifeMax = 11120;
            npc.HitSound = SoundID.NPCHit8;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.knockBackResist = 0f;
        }

        public static bool TownSpawn()
        {
            return true;
        }

        public override string GetChat()
        {
            return "What is it you need, mortal?";
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Lore";
        }

        public override void OnChatButtonClicked(bool button, ref bool shop)
        {
            if (button)
            {
                shop = true;
            }
            else
            {
                Main.npcChatText = "This world was once ruled by dragons. Then, the Four Lords brang about the age of Fire. The Flame now dwindles, beckoning the rise of the Dark.";
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("bellowing"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("lingering"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("darkwoodgrain"));
            nextSlot++;
        }
    }
}