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
                AutoloadSounds = true
            };
        }

        public override void UpdateMusic(ref int music)
        {
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
                int[] noOverride =
                {
                    MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
                    MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
                    MusicID.Eclipse, MusicID.MartianMadness, MusicID.PirateInvasion,
                    GetSoundSlot(SoundType.Music, "Sounds/Music/Ornstein&Smough")
                };

                int m = music;
                bool playMusic =
                    !noOverride.Any(song => song == m)
                    || !Main.npc.Any(npc => npc.boss);

                Player player = Main.LocalPlayer;

                if (player.active && NPC.AnyNPCs(NPCType("Ornstein")))
                {
                    music = GetSoundSlot(SoundType.Music, "Sounds/Music/Ornstein&Smough");
                }
            }
        }
    }
}
