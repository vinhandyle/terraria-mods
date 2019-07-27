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
    public class Tarot7 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("7 - Silver Chariot");
            Tooltip.SetDefault("10% increased melee speed");
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
            player.meleeSpeed = 1.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlankCard"));
            recipe.AddIngredient(ItemID.SilverBar, 5);
            recipe.AddIngredient(ItemID.JungleSpores, 6);
            recipe.AddIngredient(ItemID.Vine, 12);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(mod.ItemType("BlankCard"));
            recipe1.AddIngredient(ItemID.TungstenBar, 5);
            recipe1.AddIngredient(ItemID.JungleSpores, 6);
            recipe1.AddIngredient(ItemID.Vine, 12);
            recipe1.AddTile(TileID.CrystalBall);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
