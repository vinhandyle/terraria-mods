using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod
{
    class SoxarsModWorld : ModWorld
    {
        //boss
        public static bool OnS_Alive = false; //for only 1 OnS to be active at a time
        public static bool downedOrnstein_1 = false; //For first time kill
        public static bool downedOrnstein_2 = false; //For Smough super 2
        public static bool downedSmough_1 = false; //For first time kill
        public static bool downedSmough_2 = false; //For Ornstein super 2
        public static bool downedOnS = false; //For first time kill
    }
}
