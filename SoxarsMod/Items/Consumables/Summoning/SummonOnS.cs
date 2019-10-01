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
            DisplayName.SetDefault("Golden Plate");
            Tooltip.SetDefault("Summons OnS");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 40;
            item.rare = 1;
            item.value = 500;
            item.maxStack = 999;
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
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Ornstein"));
            }
            return true;
        }
    }
}
