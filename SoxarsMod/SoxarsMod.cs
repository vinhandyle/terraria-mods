using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod
{
    class SoxarsMod : Mod
    {
        public SoxarsMod()
        {
            Properties = new ModProperties
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup hardmodeBar1 = new RecipeGroup(() => "Cobalt or Palladium Bars", new int[]
                {
                    ItemID.CobaltBar,
                    ItemID.PalladiumBar
                });
            RecipeGroup.RegisterGroup("SoxarsMod:hardmodeBar1", hardmodeBar1);

            RecipeGroup hardmodeBar2 = new RecipeGroup(() => "Mythril or Orichalcum Bars", new int[]
                {
                    ItemID.MythrilBar,
                    ItemID.OrichalcumBar
                });
            RecipeGroup.RegisterGroup("SoxarsMod:hardmodeBar2", hardmodeBar2);

            RecipeGroup hardmodeBar3 = new RecipeGroup(() => "Adamantite or Titanium Bars", new int[]
                {
                    ItemID.AdamantiteBar,
                    ItemID.TitaniumBar
                });
            RecipeGroup.RegisterGroup("SoxarsMod:hardmodeBar3", hardmodeBar3);
        }

        public override void Unload()
        {

        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
            {
                
            }
        }
    }
}
