using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class bluetsr : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Tearstone Ring");
            Tooltip.SetDefault("Increases defense by 50% when under 20% life \nThe rare gem called tearstone has the uncanny ability to sense imminent death. \nThis blue tearstone from Catarina boosts the defence of its wearer when in danger.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 150000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= 0.2 * player.statLifeMax2)
            {
                player.statDefense *= 15;
                player.statDefense /= 10;
            }
        }
    }
}