using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class moonlightgs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Moonlight Greatsword");
            Tooltip.SetDefault("This sword, one of the rare dragon weapons, came from the tail of Seath the Scaleless, the pale white dragon who betrayed his own. \nSeath is the grandfather of sorcery, and this sword is imbued with his magic, which shall be unleashed as a wave of moonlight.");
        }

        public override void SetDefaults()
        {
            item.damage = 198;
            item.magic = true;
            item.width = 94;
            item.height = 94;
            item.useTime = 20;
            item.useAnimation = 40;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 2000000;
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("moonlightgsprojectile");
            item.shootSpeed = 24f;

        }
    }
}