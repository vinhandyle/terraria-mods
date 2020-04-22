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

namespace SoxarsMod.Items.Accessories.DevAccessory
{
    public class DevBracelet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prowess");
            Tooltip.SetDefault("Cursed \nThe dull sharpen, the sharp break");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = -12;
            item.value = 1000000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.name != "Soxar")
            {
                //buff or nerf idk
                //str
                player.magicDamage += 0.5f;
                player.meleeDamage += 0.5f;
                player.minionDamage += 0.5f;
                player.rangedDamage += 0.5f;
                player.thrownDamage += 0.5f;
                //dex
                player.magicCrit += 50;
                player.meleeCrit += 50;
                player.rangedCrit += 50;
                player.thrownCrit += 50;
                //int
                player.maxMinions += 50;
                player.manaCost -= 0.5f;
                //def
                player.statDefense += 50;
                //agi
                player.GetModPlayer<SoxarsModPlayer>().trueProwessEquipped = true;
            }
            else
            {
                //str
                player.magicDamage += 0.05f;
                player.meleeDamage += 0.05f;
                player.minionDamage += 0.05f;
                player.rangedDamage += 0.05f;
                player.thrownDamage += 0.05f;
                //dex
                player.magicCrit += 5;
                player.meleeCrit += 5;
                player.rangedCrit += 5;
                player.thrownCrit += 5;
                //int
                player.maxMinions += 5;
                player.manaCost -= 0.05f;
                //def
                player.statDefense += 5;
                //agi
                player.GetModPlayer<SoxarsModPlayer>().prowessEquipped = true;
            }
        }
    }
}
