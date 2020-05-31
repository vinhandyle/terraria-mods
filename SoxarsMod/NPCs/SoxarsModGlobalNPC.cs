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
    public class SoxarsModGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next((int)Math.Pow(10, 6)) == 0) //1 in a million chance
            {
                //add something here
            }

            if (Main.rand.Next(100) == 0) //1% drop rates
            {
                if (npc.type == NPCID.BoneSerpentHead)
                {
                    //Item.MewItem(npc.getRect(), SoxarsMod.ItemType(DemonSpear), 1);
                }
            }
        }
    }
}
