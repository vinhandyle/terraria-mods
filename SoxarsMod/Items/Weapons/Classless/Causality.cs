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

namespace SoxarsMod.Items.Weapons.Classless
{
	public class Causality : ModItem
	{
        private int bossBonus = 0;
        private bool[] bossArr = new bool[13] //size must equal # of elements
            {
                NPC.downedBoss1, //Eye
                NPC.downedBoss2, //Eater or Brain
                NPC.downedBoss3, //Skeletron
                NPC.downedQueenBee,
                NPC.downedSlimeKing,
                NPC.downedPlantBoss,
                NPC.downedGolemBoss,
                NPC.downedFishron,
                NPC.downedAncientCultist,
                NPC.downedMoonlord,
                NPC.downedMechBossAny,
                Main.hardMode, //Wall -> 12

                SoxarsModWorld.downedOnS
            };

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Causality");
			Tooltip.SetDefault("Such a pitiful weapon \nAmass power through the defeat of strong enemies \nRelog for stats to update");
		}
        public override void SetDefaults()
        {
            foreach (bool boss in bossArr)
            {
                if (boss == true) { bossBonus++; }
            }

            if (Math.Pow(5, bossBonus) >= (double)Int32.MaxValue)
            {
                item.damage = Int32.MaxValue;
            }
            else
            {
                item.damage = (int)Math.Pow(5, bossBonus); //5
            }
            item.useStyle = 3;
            item.useAnimation = 13 - (int)Math.Floor(bossBonus / 2.0); //13
            item.useTime = 13 - (int)Math.Floor(bossBonus / 2.0); //13
			item.knockBack = 4;
            item.width = 32;
            item.height = 32;
            item.rare = 12; 
            item.value = Item.sellPrice((bossBonus / 10), (bossBonus * 10) % 100, 0, 0);
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }
    }
}
