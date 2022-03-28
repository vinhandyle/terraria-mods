using MonoMod.Cil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        public override void Load()
        {
            IL.Terraria.Player.Update += Player_Update;
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

        #region Uncap Max Mana
        private void Player_Update(ILContext il)
        {
            ILCursor cursor = new ILCursor(il);

            if (!cursor.TryGotoNext(MoveType.Before,
                                    i => i.MatchLdfld("Terraria.Player", "statManaMax2"),
                                    i => i.MatchLdcI4(400)))
            {
                Logger.Fatal("Could not find instruction to patch");
                return;
            }

            cursor.Next.Next.Operand = int.MaxValue;
        }

        #endregion

    }
}
