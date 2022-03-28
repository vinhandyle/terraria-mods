using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Consumables.Summoning
{
    public class SummonOnS : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bells of Awakening");
            Tooltip.SetDefault("The tolling of bells alerts the protectors of \"Light\" \nNot consumable");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 44;
            item.maxStack = 1;
            item.rare = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;

        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (!SoxarsModWorld.OnS_Alive)
            {
                SoxarsModWorld.OnS_Alive = true;
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Dragonslayer Spear"));
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Executioner's Hammer"));
                Main.PlaySound(SoundID.Roar, player.position, 0);
                SoxarsModWorld.downedOrnstein_2 = false;
                SoxarsModWorld.downedSmough_2 = false;
            }
            else
            {
                //add something here
            }
            return true;
        }
    }
}
