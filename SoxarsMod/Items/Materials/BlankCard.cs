using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod.Items.Materials
{
    public class BlankCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blank Card");
            Tooltip.SetDefault("There is nothing on it \nWhat can it be used for?");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = 1;
            item.value = 500;
            item.maxStack = 999;
        }
    }
}
