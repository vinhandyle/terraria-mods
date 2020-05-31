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

namespace SoxarsMod.Items.Accessories.Covenants
{
    public class dragonPath : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Eye");
            Tooltip.SetDefault("Grants access to the dragon arts \nYou feel it squirm in your head");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.rare = 4;
            item.value = Item.sellPrice(0, 2, 40, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //add visual to player model 
        }
    }
}
