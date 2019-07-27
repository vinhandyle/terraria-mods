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
    public class Tarot13 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("13 - Death Thirteen");
            Tooltip.SetDefault("You will survive fatal damage and will be healed 100 HP if an attack would have killed you \nTurn death into a dream and it will not happen");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = -12;
            item.value = 500000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyModPlayer>().tarot13Equipped = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BlankCard"));
            recipe.AddIngredient(ItemID.CrossNecklace, 1);
            recipe.AddIngredient(ItemID.Bed, 1);
            recipe.AddIngredient(ItemID.Cloud, 25);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
