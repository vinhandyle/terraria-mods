using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.NPCs.Bosses.OnS.Smough.Smough
{
    [AutoloadBossHead]
    public class Smough : ModNPC
    {
        //Ai Slots
        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;

        //Ai States
        private const int State_Follow = 0;
        private const int State_Spin = 1;
        private const int State_Charge = 2;
        private const int State_Swing = 3;

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


        //Super form
        private double superThreshold = 0.25;
        private bool super = false;

        public const string superSmoHead = "SoxarsMod/NPCs/Bosses/OnS/Smough/Smough_Head_Boss_Super";

        public override string Texture
        {
            get { return "SoxarsMod/NPCs/Bosses/OnS/Smough/Smough"; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Executioner's Hammer";
            mod.AddBossHeadTexture(superSmoHead);
            return base.Autoload(ref name);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Executioner's Hammer");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 142;
            npc.height = 88;
            npc.damage = 450; //base 450
            npc.defense = 35; //base 349
            npc.lifeMax = 4128501; //base 2873 
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
            superThreshold = 0.5;
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
                SoxarsModWorld.downedSmough_2 = true;
            }

            //Super Form
            if (SoxarsModWorld.downedOrnstein_2)
            {
                super = true;
            }

            if (super)
            {
                npc.damage = (int)(npc.damage * 1.408);
                npc.defense = (int)(npc.defense * 1.815);
            }

            //Begin with charging attack(s)
            if (AI_Timer == 0)
            {
                AI_State = State_Charge;
            }

            //Follows the player but stops if too close 
            if (AI_State == State_Follow)
            {

            }
        }

        public override void BossHeadSlot(ref int index)
        {
            if (super)
            {
                index = ModContent.GetModBossHeadSlot(superSmoHead);
            }
        }

        public virtual void FindFrame(int frameHeight)
        {

        }


        public override void NPCLoot()
        {
            if (SoxarsModWorld.downedOrnstein_2)
            { //Killed Ornstein last
                SoxarsModWorld.OnS_Alive = false;
                if (SoxarsModWorld.downedSmough_1)
                { //killed OnS 2+ times

                }
                if (!SoxarsModWorld.downedOnS)
                {
                    SoxarsModWorld.downedOnS = true;
                }
            }
            SoxarsModWorld.downedSmough_1 = true;
            SoxarsModWorld.downedSmough_2 = true;
        }
    }
}
