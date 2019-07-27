using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class charring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orange Charred Ring");
            Tooltip.SetDefault("An orange ring enchanted by a witch \nGrants immunity to lava for 10 seconds \nSince his sores were inflamed by lava from birth, his witch sisters gave him this special ring. \nBut fool that he is, he readily dropped it, and from that spot, a terrible centipede demon was born.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 200000;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lavaMax += 580;
        }
    }
}