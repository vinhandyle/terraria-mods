using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.StatusEffects.Buffs
{
    public class ApocBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ascended (Great One)");
            Description.SetDefault("Your very presence drains the world's life force");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 100;
        }
    }
}
