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
    public class Tarot9 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("9 - Hermit Purple");
            Tooltip.SetDefault("5% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = 3;
            item.value = 1000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicCrit += 5;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5; //The Hermit
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlankCard"));
            recipe.AddIngredient(ItemID.Vine, 9);
            recipe.AddIngredient(ItemID.Stinger, 9);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
