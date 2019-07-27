using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class bellowing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bellowing Dragoncrest Ring");
            Tooltip.SetDefault("Increases magic damage dealth by 50% \nA special ring granted to only the most accomplished sorcerers at Vinheim Dragon School. \nThe ring is engraved with an everlasting dragon, and boosts the strength of sorceries.");
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
            player.magicDamage += 0.5f;
        }
    }
}