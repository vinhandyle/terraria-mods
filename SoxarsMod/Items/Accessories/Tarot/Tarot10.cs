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

namespace SoxarsMod.Items.Accessories.Tarot
{
    public class Tarot10 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("10 - Wheel of Fortune");
            Tooltip.SetDefault("+25% maximum run speed");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = 1;
            item.value = 1000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxRunSpeed = 1.25f;
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(mod.ItemType("BlankCard"));
        //    recipe.AddIngredient(ItemID.HermesBoots, 1);
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}
