using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod.Items.Consumables.Summoning
{
    public class SummonOnS : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bells of Awakening");
            Tooltip.SetDefault("The tolling of bells alerts the protectors of \"Light\"");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 44;
            item.maxStack = 999;
            item.rare = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = true;

        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (SoxarsModWorld.OnS_Alive == false)
            {
                SoxarsModWorld.OnS_Alive = true;
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Dragonslayer Spear"));
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Executioner's Hammer"));
                Main.PlaySound(SoundID.Roar, player.position, 0);
                SoxarsModWorld.DownedOrnstein_2 = false;
                SoxarsModWorld.DownedSmough_2 = false;
            }
            else
            {
                //add something here
            }
            return true;
        }
    }
}
