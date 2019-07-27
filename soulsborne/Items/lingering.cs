using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class lingering : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lingering Dragoncrest Ring");
            Tooltip.SetDefault("Reduces mana costs by 50% \nA special ring granted to only the most accomplished sorcerers at Vinheim Dragon School. \nThe ring is engraved with a lingering dragon, and boosts the length of sorceries.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 500000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost /= 2f;
        }
    }
}