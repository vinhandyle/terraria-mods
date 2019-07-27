using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class darkwoodgrain : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Wood Grain Ring");
            Tooltip.SetDefault("Grants the Ninja Master Gear Dash \nReduces dashing cooldown by 50% \nThis special ring crafted in an Eastern land is made of gold, but with a wood grain crest on its surface. \nAgents of subterfuge in this faraway land are particularly fond of the dark gold wood grain, \nwhich greatly alters its wearer's dashing action.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 500000;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.dash = 4;
            player.dashDelay /= 2;
        }
    }
}