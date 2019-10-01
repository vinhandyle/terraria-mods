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

namespace SoxarsMod.NPCs.Bosses.OnS.Ornstein.Ornstein
{
    [AutoloadBossHead]
    public class Ornstein : ModNPC
    {
        //Int variables
        private int ai;
        private int aiSecond = 0;
        private int baseMoveSpeed = 5;

        //Bool variables
        private bool lunge = false;
        private bool lLunge = false;
        private bool hominglunge = false;
        private bool lBolt = false;
        private bool homingLBolt = false;

        public override string Texture
        {
            get { return "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein"; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Dragonslayer Ornstein";
            return base.Autoload(ref name);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragonslayer Ornstein");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; 
            npc.width = 124;
            npc.height = 113;
            npc.damage = 142; //base 142
            npc.defense = 349; //base 349
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
            if (numPlayers > 1)
            {
                npc.lifeMax = (int)((int)(npc.lifeMax * 0.5f * bossLifeScale) * (1 + (0.5 * ((double)numPlayers) - 1.0)));
            }
            else
            {
                npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
            }
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

            npc.velocity.X = baseMoveSpeed;
            if ((double)player.position.X >= (double)npc.position.X - 50.0)
            {
                npc.spriteDirection = 1;
                if (npc.velocity.X < 0)
                {
                    npc.velocity.X *= -1;
                }
            }
            else if ((double)player.position.X < (double)npc.position.X - 50.0)
            {
                npc.spriteDirection = -1;
                if (npc.velocity.X > 0)
                {
                    npc.velocity.X *= -1;
                }
            }

            if (aiSecond == 0) //Opening Move
            {
                hominglunge = true;
            }

            aiSecond++;
            if (aiSecond >= 3000) //Cycle Reset
            {
                aiSecond = 0;
            }


            //Charging Stab (Long-Ranged, Homing, Fast Dash, Avg Dmg)
            if (hominglunge == true)
            {
                npc.noGravity = true;
                //npc.velocity.X *= 10;
                npc.noGravity = false;
                hominglunge = false;
            }

            //Lunge (Close-Ranged, Straight, Fast Dash, Avg Dmg)


            //Lightning Lunge (Mid-Ranged, Straight, Fast Dash, High Dmg)


            //Homing Lightning Bolt (Mid-Ranged, Homing, Avg Speed, High Dmg)


            //Lightning Bolt (Mid-Ranged, Straight, Fast, Avg Dmg)




        }

        public override void NPCLoot()
        {
            SoxarsModWorld.DownedOrnstein = true;
        }
    }
}
