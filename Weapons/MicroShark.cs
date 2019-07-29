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
	public class MicroShark : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fish Shooter");
			Tooltip.SetDefault("20% chance to not consume ammo \nIt strives to be like Minishark");
		}
		public override void SetDefaults()
		{
			item.damage = 4;
            item.useStyle = 5;
            item.useAnimation = 15; 
            item.useTime = 15;
            item.shootSpeed = 5f;
			item.knockBack = 1;
            item.width = 30;
            item.height = 22;
            item.rare = 1;
            item.value = 100;

            item.ranged = true;
            item.autoReuse = true;
            item.noMelee = true;
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= 0.2f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Goldfish, 1);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(ItemID.IronAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.Goldfish, 1);
            recipe1.AddIngredient(ItemID.LeadBar, 5);
            recipe1.AddTile(ItemID.LeadAnvil);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
	}
}
