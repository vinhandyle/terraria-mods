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

namespace SoxarsMod.Items.Weapons
{
	public class GigaShark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Megalodon");
			Tooltip.SetDefault("50% chance to not consume ammo \nMegashark's resurrected ancestor");
		}
		public override void SetDefaults()
		{
			item.damage = 44;
            item.useStyle = 5;
            item.useAnimation = 6; 
            item.useTime = 6;
            item.shootSpeed = 13f;
			item.knockBack = 1;
            item.width = 86;
            item.height = 28;
            item.rare = 11;
            item.value = 100000;

            item.ranged = true;
            item.autoReuse = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= 0.5f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Megashark, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}
