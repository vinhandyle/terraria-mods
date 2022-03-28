using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.StatusEffects.Buffs
{
    public class DevBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Supreme");
            Description.SetDefault("There can only be one");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;          
        }
    }
}
