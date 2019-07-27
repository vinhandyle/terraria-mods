using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class rustediron : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rusted Iron Ring");
            Tooltip.SetDefault("Grants the ability to freely move through liquids \nThis iron ring was used to shackle the guilty. \nIt is terribly rusted, and faintly stained with blood. \nThose who find this strange ring to their liking will be pleased to find it easier to gain footing on poor ground such as swamps.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 150000;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.ignoreWater = true;
        }
    }
}