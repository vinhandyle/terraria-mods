using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class wolfring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wolf Ring");
            Tooltip.SetDefault("Reduces damage taken by 20% \nOne of the special rings granted to the four knights of Gwyn. \nThe Wolf Ring belongs to Artorias the Abysswalker. \nArtorias had an unbendable will of steel, and was unmatched with a greatsword.");
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
            player.endurance += 0.2f;
        }
    }
}