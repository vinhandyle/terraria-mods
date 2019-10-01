using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.Events;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Utilities;

namespace SoxarsMod.NPCs.Bosses.OnS.SuperOrnstein.SuperOrnstein
{
    [AutoloadBossHead]
    public class SuperOrnstein : ModNPC
    {
        //Int variables
        private int _timer = 0;

        public override string Texture
        {
            get { return "SoxarsMod/NPCs/Bosses/OnS/SuperOrnstein/SuperOrnstein"; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Super Ornstein";
            return base.Autoload(ref name);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Ornstein");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; 
            npc.width = 248;
            npc.height = 210;
            npc.damage = 142; //base 142
            npc.defense = 121801; //base 349
            npc.lifeMax = 2696164; //base 1642
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ornstein&Smough");
            npc.buffImmune[30] = true;
            npc.lavaImmune = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.5f);
        }

        public override void AI()
        {

            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction; 
            Player player = Main.player[npc.target];
            if (player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.active = false;
            }
            _timer++;

            //Charging Stab (Opening Move, Long-Ranged, Homing, Fast Dash, Avg Dmg)


            //Lunge (Close-Ranged, Straight, Fast Dash, Avg Dmg)


            //Lightning Lunge (Mid-Ranged, Straight, Fast Dash, High Dmg)


            //Homing Lightning Bolt (Mid-Ranged, Homing, Avg Speed, High Dmg)


            //Lightning Bolt (Mid-Ranged, Straight, Fast, Avg Dmg)


            //Lightning Stab (Close-Ranged, Straight, Fast, Heavy Dmg)


            //Electric Crash (Close-Ranged, Down and Out, Avg Speed Crash, Fast AoE, Heavy Dmg)
        }

        public override void NPCLoot()
        {
            SoxarsModWorld.DownedOnS = true;
        }
    }
}
