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

namespace SoxarsMod.Buffs
{
    public class StratiBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Unshackled");
            Description.SetDefault("Your steps have become lighter...");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            SoxarsModPlayer.max_Speed = 50;
            SoxarsModPlayer.speed_Mult += 199f;
            if (player.FindBuffIndex(mod.BuffType("ContrastBuff")) > 0)
            {
                if (player.name != "Soxar") //Change to == later
                {
                    player.statDefense *= 2;
                }
            }
            else
            {
                if (player.name != "Soxar")
                {
                    player.statDefense /= 2;
                }
            }
        }
    }
}
