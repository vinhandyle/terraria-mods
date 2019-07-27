using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class redtsr : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Tearstone Ring");
            Tooltip.SetDefault("Increases damage by 50% when under 20% life \nThe rare gem called tearstone has the uncanny ability to sense imminent death. \nThis red tearstone from Carim boosts the attack of its wearer when in danger.");
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
            if (player.statLife <= 0.2 * player.statLifeMax2)
            {
                player.arrowDamage += 0.5f;
                player.bulletDamage += 0.5f;
                player.magicDamage += 0.5f;
                player.meleeDamage += 0.5f;
                player.minionDamage += 0.5f;
                player.rangedDamage += 0.5f;
                player.rocketDamage += 0.5f;
                player.thrownDamage += 0.5f;
            }
        }
    }
}