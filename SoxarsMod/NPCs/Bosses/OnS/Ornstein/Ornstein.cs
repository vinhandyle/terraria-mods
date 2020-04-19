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
using static Terraria.ModLoader.ModContent;
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
        private int baseMoveSpeed = 1;
        private int frame;

        //Double variables
        private double superThreshold = 0.25;

        //Bool variables
        private bool dash = false;
        private bool jump = false;
        private bool backStep = false;
        private bool drop = false;
        private bool dashL = false;
        private bool boltA = false;
        private bool boltB = false;
        private bool jumpA = false;
        private bool stormMini = false;
        private bool storm = false;
        private bool super = false;

        //String variables
        public const string superOrnHead = "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein_Head_Boss_Super";

        public override string Texture
        {
            get { return "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein"; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Dragonslayer Ornstein";
            mod.AddBossHeadTexture(superOrnHead);
            return base.Autoload(ref name);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragonslayer Ornstein");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; 
            npc.width = 30;
            npc.height = 30;
            npc.damage = 142; //base 142
            npc.defense = 35; //base 349
            npc.lifeMax = 1348903; //base 1642 
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = 0;
            npc.knockBackResist = 0f;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ornstein&Smough");
            npc.buffImmune[30] = true;
            npc.lavaImmune = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        { //+50% hp per additional player
            npc.lifeMax = (int)((int)(npc.lifeMax * 0.874f * bossLifeScale) * (1 + (0.5 * (double)numPlayers)));
            npc.damage = (int)(npc.damage * 0.5f);
            superThreshold = 0.5;
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
            if ((double)player.position.X > (double)npc.position.X)
            {
                npc.spriteDirection = 1;
            }
            else if ((double)player.position.X < (double)npc.position.X)
            {
                npc.spriteDirection = -1;
            }

            if ((npc.spriteDirection > 0 && npc.velocity.X < 0) || (npc.spriteDirection < 0 && npc.velocity.X > 0))
            {
                npc.velocity.X *= -1;
            }

            if (aiSecond == 0) //Opening Move
            {
                dashL = true;
            }

            aiSecond++;
            if (aiSecond >= 3000) //Cycle Reset
            {
                aiSecond = 0;
            }

            //Super Form
            if (npc.life <= superThreshold * npc.lifeMax)
            {
                super = true;
            }

            if (super == true)
            {
                npc.damage = (int)(npc.damage * 1.408); 
                npc.defense = (int)(npc.defense * 1.815); 
            }

            //Mobility
            if (dash == true) //stops for split sec then dashes in a straight line towards player
            {
                dash = false;
            }

            if (jump == true) //jumps in an arc towards player
            {
                jump = false;
            }

            if (backStep == true) //hops back behind Smough
            {
                //backstep => boltB
                boltB = true;
                backStep = false;
            }

            if (drop == true) //drops off things, like platforms, towards player
            {
                drop = false;
            }

            //Attacks
            if (dashL = true) //stops for a sec then dashes very quickly in a straight line towards player
            {
                dashL = false;
            }

            if (jumpA == true) //while midair spin towards player
            {
                jumpA = false;
            }

            if (boltA == true) //stops in place and creates 4 balls from its center and traveling out clockwise like shuriken
            {
                boltA = false;
            }

            if (boltB == true) //stops in place and shoots a ball towards player that bounces
            {
                boltB = false;
            }

            if (stormMini == true) //stops for split sec then summons 3 lightning bolts from above from it towards player
            {
                stormMini = false;
            }

            if (storm == true) //summons lightning from above moving from player side to its side, goes across one screen length 
            {
                storm = false;
            }
        }

        public override void BossHeadSlot(ref int index)
        {
            if (super == true)
            {
                index = ModContent.GetModBossHeadSlot(superOrnHead);
            }
        }

        public virtual void FindFrame(int frameHeight)
        {
            
        }


        public override void NPCLoot()
        {
            SoxarsModWorld.DownedOrnstein = true;
        }
    }
}
