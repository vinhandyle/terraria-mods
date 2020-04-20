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
    public class Tarot0 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("0 - The Fool");
            Tooltip.SetDefault("+25 max mana \n+25 max mana while in the Desert \nThe shifting sands calm your mind.");
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
            if (player.ZoneDesert == true)
            {
                player.statManaMax2 += 50;
            }
            else
            {
                player.statManaMax2 += 25;
            }
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(mod.ItemType("BlankCard"));
        //    recipe.AddIngredient(ItemID.BandofStarpower, 1);
        //    recipe.AddIngredient(ItemID.AntlionMandible, 5);
        //    recipe.AddIngredient(ItemID.Cactus, 20);
        //    recipe.AddIngredient(ItemID.SandBlock, 100);
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}
