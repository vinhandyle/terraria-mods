using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.StatusEffects.Buffs
{
    public class StratiBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Unshackled");
            Description.SetDefault("Your steps have become lighter...");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<SoxarsModPlayer>().max_Speed = 50;
            player.GetModPlayer<SoxarsModPlayer>().speed_Mult += 199f;
            player.statDefense /= 2;      
        }
    }
}
