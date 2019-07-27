using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class covetousserpent : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Covetous Gold Serpent Ring");
            Tooltip.SetDefault("Grants the Lucky Coin effect \nThe serpent is an imperfect dragon and symbol of the Undead. \nIts habit of devouring preyeven larger than itself has led to an association with gluttony. \nThis gold ring, engraved with the serpent, boosts its wearer's item discovery, so that more items can be amassed.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 150000;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.coins = true;
        }
    }
}