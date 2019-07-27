using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class fapring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ring of Favor and Protection");
            Tooltip.SetDefault("Increases maximum health by 20% \nIncreases maximum mana by 20% \nIncreases movespeed by 20% \nA ring symbolizing the favor and protection of the goddess Fina, known in legend to possess fateful beauty.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 200000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 *= 12;
            player.statLifeMax2 /= 10;
            player.statManaMax2 *= 12;
            player.statManaMax2 /= 10;
            player.moveSpeed = 1.2f;
        }
    }
}