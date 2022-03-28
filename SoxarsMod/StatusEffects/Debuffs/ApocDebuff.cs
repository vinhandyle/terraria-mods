using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.StatusEffects.Debuffs
{
    public class ApocDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Great One's Hunger");
            Description.SetDefault("Your attacks heal you, but at what cost..?");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 100;
        }
    }
}
