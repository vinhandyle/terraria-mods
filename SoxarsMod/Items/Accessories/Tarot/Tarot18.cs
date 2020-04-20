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
    public class Tarot18 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("18 - Dark Blue Moon");
            Tooltip.SetDefault("5 defense \n+5 defense during the night");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = 4;
            item.value = 1000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.dayTime == false)
            {
                player.statDefense += 10;
            }
            else
            {
                player.statDefense += 5;
            }
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(mod.ItemType("BlankCard"));
        //    recipe.AddIngredient(ItemID.Shackle, 5);
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}
