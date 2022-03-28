using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Accessories.DevAccessory
{
    [AutoloadEquip(EquipType.Wings)]
    public class DevSet : ModItem
    {
        public override bool CloneNewInstances => true; // For dynamic tooltip
        private string statSummary;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Master Catalyst");
            Tooltip.SetDefault(
                "Increases all damage x10\n" +
                "Increases defense, max life, and max mana x10\n" +
                "Life and mana regen are dynamically increased and always enabled\n" +
                "Grants infinite flight and permanent day brightness\n" +
                "Increases tile reach by 100\n" +
                "Equip in lower slot for higher efficacy\n"
                );
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 14));
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 38;
            item.rare = -12;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Intensity
            player.allDamage *= 10;
            player.meleeDamage *= 10;
            player.rangedDamage *= 10;
            player.magicDamage *= 10;
            player.minionDamage *= 10;
            player.thrownDamage *= 10;

            // Prowess
            player.statDefense *= 10;
            player.statLifeMax2 *= 10;
            player.statManaMax2 *= 10;

            player.lifeRegen += (int)(player.statLifeMax2 * 0.5);
            if (player.lifeRegenTime <= 1)
                player.statLife += player.lifeRegen / 120; // "Regen" while regen is disabled

            player.manaRegenBonus += (int)(player.statManaMax2 * 1.5);
            player.manaRegenDelay *= 0; // Regen while attacking

            // Contrast
            player.wingTime = 1; // Unlimited flight
            Player.tileRangeX += 100;
            Player.tileRangeY += 100;

            statSummary = "-------------------\n" +
                         "Current damage multipliers:\n" +
                         "All: x" + player.allDamage + "\n" +
                         "Melee: x" + player.meleeDamage + "\n" +
                         "Ranged: x" + player.rangedDamage + "\n" +
                         "Magic: x" + player.magicDamage + "\n" +
                         "Summon: x" + player.minionDamage + "\n" +
                         "Thrown: x" + player.thrownDamage + "\n" +
                         "-------------------\n" +
                         "Current base stats:\n" +
                         "Bonus life: " + (player.statLifeMax2 - player.statLifeMax) + "\n" +
                         "Bonus mana: " + (player.statManaMax2 - player.statManaMax) + "\n" +
                         "Life regen: " + player.lifeRegen + "\n" +
                         "Mana regen: " + player.manaRegen + "\n" +
                          "-------------------\n" +
                         "Horizontal Tile Reach: " + player.lastTileRangeX + " blocks\n" +
                         "Vertical Tile Reach: " + player.lastTileRangeY + " blocks";
            player.AddBuff(mod.BuffType("DevBuff"), 2);
            player.AddBuff(mod.BuffType("DevLightPet"), 2);
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

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DevRing"), 1);
            recipe.AddIngredient(mod.ItemType("DevBracelet"), 1);
            recipe.AddIngredient(mod.ItemType("DevNecklace"), 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        #region Wings
        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 1f;
            ascentWhenRising = 0.2f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 10f;
            acceleration *= 2f;
        }
        #endregion
    }
}
