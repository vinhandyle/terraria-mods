using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class leoring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leo Ring");
            Tooltip.SetDefault("Increases thorns damage by 500% \nOne of the special rings granted to the four knights of Gwyn. \nThe Leo Ring belonged to Ornstein the Dragonslayer. \nThis ring strengthens the wearer's counterattacks. \nHis lugged spear is said to have sliced a boulder in two.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 150000;
            item.rare = 7;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thorns += 5f;
        }
    }
}