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
        //Ai Slots
        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;
        private const int AI_Super_Slot = 2;

        //Ai States
        private const int State_Follow = 0;
        private const int State_Turret = 1;
        private const int State_Charge = 2;
        private const int State_Storm = 3;
        private const int State_Fade_Attack_1 = 4;
        private const int State_Fade_Attack_2 = 5;

        //Filling Ai Slots
        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        public float AI_Timer
        {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;
        }

        public float AI_Super
        {
            get => npc.ai[AI_Super_Slot];
            set => npc.ai[AI_Super_Slot] = value;
        }

        public const string superOrnHead = "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein_Head_Boss_Super";

        public override string Texture
        {
            get
            {
                //if (AI_Super > 0) { return "SoxarsMod/NPCs/Bosses/OnS/Smough/Smough"; }
                return "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein";
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "Dragonslayer Spear";
            mod.AddBossHeadTexture(superOrnHead);
            return base.Autoload(ref name);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragonslayer Spear");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1; 
            npc.width = 244;
            npc.height = 42;
            npc.damage = 142; //base 142
            npc.defense = 35; //base 349
            npc.lifeMax = 1348903; //base 1642 
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            animationType = 0;
            npc.knockBackResist = 0f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Ornstein&Smough");
            npc.buffImmune[30] = true;
            npc.lavaImmune = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        { //+50% hp per additional player
            npc.lifeMax = (int)((int)(npc.lifeMax * 0.874f * bossLifeScale) * (1 + (0.5 * (double)numPlayers)));
            npc.damage = (int)(npc.damage * 0.5f);
        }

        public override void AI()
        {
            //Targeting Player
            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
            if (player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.active = false;
            }

            //Despawn
            if (!npc.active)
            {
                SoxarsModWorld.downedOrnstein_2 = true;
                AI_Super = 0;
            }

            //Super Form
            if (SoxarsModWorld.downedSmough_2)
            {
                AI_Super++;
                if (AI_Super > 10) { AI_Super = 2; }          
            }

            if (AI_Super == 1)
            {
                npc.life = npc.lifeMax;
                npc.damage = (int)(npc.damage * 1.408); 
                npc.defense = (int)(npc.defense * 1.815);
            }

            //Begin with charging attack(s)
            if (AI_Timer == 0)
            {
                AI_State = State_Follow;
            }

            //Follows the player but stops if too close 
            if (AI_State == State_Follow)
            {
                npc.position.X = player.position.X;
                npc.position.Y = player.position.Y - 50;
            }

            //Performs a series of charges towards player
            if (AI_State == State_Charge)
            {
                AI_State = State_Follow;
            }
        }

        public override void BossHeadSlot(ref int index)
        {
            if (AI_Super > 0)
            {
                index = ModContent.GetModBossHeadSlot(superOrnHead);
            }
        }

        public virtual void FindFrame(int frameHeight)
        {
            
        }


        public override void NPCLoot()
        {
            if (SoxarsModWorld.downedSmough_2)
            { //Killed Ornstein last
                SoxarsModWorld.OnS_Alive = false;
                if (SoxarsModWorld.downedOrnstein_1)
                { //killed OnS 2+ times

                }
                if (!SoxarsModWorld.downedOnS)
                {
                    SoxarsModWorld.downedOnS = true;
                }
            }
            SoxarsModWorld.downedOrnstein_1 = true;
            SoxarsModWorld.downedOrnstein_2 = true;
        }
    }
}
