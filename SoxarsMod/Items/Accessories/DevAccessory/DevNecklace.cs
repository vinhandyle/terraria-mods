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
    public class DevNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contrast");
            Tooltip.SetDefault("Alluring \nAll seek light, yet none can become the source");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = -12;
            item.value = 1000000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(mod.BuffType("ContrastBuff"), 2); //add stuff
        }
    }
}
