using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.Generation;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod
{
    class SoxarsModWorld : ModWorld
    {
        //boss
        public static bool OnS_Alive = false; //for only 1 OnS to be active at a time
        public static bool DownedOrnstein_1 = false; //For first time kill
        public static bool DownedOrnstein_2 = false; //For Smough super 2
        public static bool DownedSmough_1 = false; //For first time kill
        public static bool DownedSmough_2 = false; //For Ornstein super 2
        public static bool DownedOnS = false; //For first time kill
    }
}
