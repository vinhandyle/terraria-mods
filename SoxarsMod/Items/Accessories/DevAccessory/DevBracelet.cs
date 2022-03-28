using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Accessories.DevAccessory
{
    public class DevBracelet : ModItem
    {
        public override bool CloneNewInstances => true; // For dynamic tooltip
        private string statSummary;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prowess");
            Tooltip.SetDefault(
                "Increases defense, max life, and max mana x10\n" +
                "Life and mana regen are dynamically increased and always enabled\n" +
                "Equip in lower slot for higher efficacy\n"
                );

            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 20;
            item.rare = -12;
            item.defense = 10;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense *= 10;
            player.statLifeMax2 *= 10;
            player.statManaMax2 *= 10;

            player.lifeRegen += (int)(player.statLifeMax2 * 0.5);
            if (player.lifeRegenTime <= 1)
                player.statLife += player.lifeRegen / 120; // "Regen" while regen is disabled

            player.manaRegenBonus += (int)(player.statManaMax2 * 1.5);
            player.manaRegenDelay *= 0; // Regen while attacking

            statSummary = "-------------------\n" +
                         "Current base stats:\n" +
                         "Bonus life: " + (player.statLifeMax2 - player.statLifeMax) + "\n" +
                         "Bonus mana: " + (player.statManaMax2 - player.statManaMax) + "\n" +
                         "Life regen: " + player.lifeRegen + "\n" +
                         "Mana regen: " + player.manaRegen + "\n";
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
