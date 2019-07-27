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
    public class Tarot21 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("21 - The World");
            Tooltip.SetDefault("You will restore some HP upon entering Chaos State \nTime stops for a brief moment, allowing you to recover for a bit");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 32;
            item.rare = -12;
            item.value = 650000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyModPlayer>().tarot21Equipped = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlankCard"));
            recipe.AddIngredient(ItemID.RodofDiscord, 1);
            //recipe.AddIngredient(mod.ItemType(DIO));
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
