using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Accessories.DevAccessory
{
    public class DevRing : ModItem
    {
        public override bool CloneNewInstances => true; // For dynamic tooltip
        private string statSummary;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Intensity");
            Tooltip.SetDefault(
                "Increases all damage x10\n" + 
                "Equip in lower slot for higher efficacy\n"
                );
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = -12;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage *= 10;
            player.meleeDamage *= 10;
            player.rangedDamage *= 10;
            player.magicDamage *= 10;
            player.minionDamage *= 10;
            player.thrownDamage *= 10;

            statSummary = "-------------------\n" +
                         "Current damage multipliers:\n" +
                         "All: x" + player.allDamage + "\n" +
                         "Melee: x" + player.meleeDamage + "\n" +
                         "Ranged: x" + player.rangedDamage + "\n" +
                         "Magic: x" + player.magicDamage + "\n" +
                         "Summon: x" + player.minionDamage + "\n" +
                         "Thrown: x" + player.thrownDamage + "\n";
            player.AddBuff(mod.BuffType("DevBuff"), 2);
        }

        public override void UpdateInventory(Player player)
        {
            item.accessory = !Main.player[item.owner].HasBuff(mod.BuffType("DevBuff"));
            statSummary = "";
        }
     
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var statTooltip = new TooltipLine(
                mod,
                Name,
                Main.player[item.owner].HasBuff(mod.BuffType("DevBuff")) ? statSummary : ""
                );
            tooltips.Add(statTooltip);
        }
    }
}
