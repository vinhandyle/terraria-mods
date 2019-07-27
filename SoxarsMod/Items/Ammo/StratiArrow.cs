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

namespace SoxarsMod.Items.Ammo
{
	public class StratiArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Violent Storm");
			Tooltip.SetDefault("A bundle of the world's strongest winds \nHow was such a thing created?");
		}
		public override void SetDefaults()
		{
            item.damage = 106;
            item.ranged = true;
            item.width = 14;
            item.height = 34;
            item.maxStack = 999;
            item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
            item.knockBack = 2f;
            item.value = 99000000;
            item.rare = 11;
            item.shoot = mod.ProjectileType("StratiProjectile1");   //The projectile shoot when your weapon using this ammo
            item.shootSpeed = 30f;                  //The speed of the projectile
            item.ammo = mod.ItemType("StratiArrow");
        }
    }
}
