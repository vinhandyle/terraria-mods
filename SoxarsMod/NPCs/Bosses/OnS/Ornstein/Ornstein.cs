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
        private bool super = false;

        //String variables
        public const string superOrnHead = "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein_Head_Boss_Super";

        public override string Texture
        {
            get { return "SoxarsMod/NPCs/Bosses/OnS/Ornstein/Ornstein"; }
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
            npc.noTileCollide = false;
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
