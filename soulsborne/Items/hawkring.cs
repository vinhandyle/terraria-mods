using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class hawkring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hawk Ring");
            Tooltip.SetDefault("Increases arrow damage by 50% \nOne of the special rings granted to the four knights of Gwyn. \nThe Hawk Ring belonged to Hawkeye Gough, who led the Greatarchers. \nBoosts bow strength, so that arrows fly like they were shot by Gough's great bow, which took down high-flying dragons.");
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
            player.arrowDamage = 1.5f;
        }
    }
}