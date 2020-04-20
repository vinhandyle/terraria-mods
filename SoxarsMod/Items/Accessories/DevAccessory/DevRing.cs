using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod.Items.Accessories.DevAccessory
{
    public class DevRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Intensity");
            Tooltip.SetDefault("Mysterious \nA bottomless well, what will you find?");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = -12;
            item.value = 1000000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.name != "Soxar")
            {
                player.magicDamage += 9f;
                player.meleeDamage += 9f;
                player.minionDamage += 9f;
                player.rangedDamage += 9f;
                player.thrownDamage += 9f;
            }
            else
            {
                player.magicDamage -= 0.9f;
                player.meleeDamage -= 0.9f;
                player.minionDamage -= 0.9f;
                player.rangedDamage -= 0.9f;
                player.thrownDamage -= 0.9f;
            }
        }
    }
}
