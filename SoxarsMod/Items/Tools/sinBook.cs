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

namespace SoxarsMod.Items.Tools
{
    public class sinBook : ModItem
    {
        private int sin = SoxarsModPlayer.sin;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Book of the Guilty");
            Tooltip.SetDefault("Records your crimes \nSin Count: " + sin); //does not update :(
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.maxStack = 1;
        }
    }
}
