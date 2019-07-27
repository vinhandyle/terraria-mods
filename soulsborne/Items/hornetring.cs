using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class hornetring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hornet Ring");
            Tooltip.SetDefault("Increases critical strike chance by 30% \nOne of the special rings granted to the four knights of Gwyn. \nThe Hornet Ring belonged to the Lord's Blade Ciaran. \nBy boosting critical attacks, its wearer can annihilate foes, as Ciaran's dagger laid waste to Lord Gwyn's enemies.");
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
            player.magicCrit += 30;
            player.meleeCrit += 30;
            player.rangedCrit += 30;
            player.thrownCrit += 30;
        }
    }
}