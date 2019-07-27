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
            Tooltip.SetDefault("A powerful ring which elevates its wearer's strength above all others \nIncreases all damage by 25% \nGrants immeasurable power to the One");
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
                player.magicDamage += 1f;
                player.meleeDamage += 1f;
                player.minionDamage += 1f;
                player.rangedDamage += 1f;
                player.thrownDamage += 1f;
            }
            else
            {
                player.magicDamage += 0.25f;
                player.meleeDamage += 0.25f;
                player.minionDamage += 0.25f;
                player.rangedDamage += 0.25f;
                player.thrownDamage += 0.25f;
            }
        }
    }
}
