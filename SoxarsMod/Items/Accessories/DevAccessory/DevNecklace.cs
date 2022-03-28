using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace SoxarsMod.Items.Accessories.DevAccessory
{
    [AutoloadEquip(EquipType.Wings)]
    public class DevNecklace : ModItem
    {
        public override bool CloneNewInstances => true; // For dynamic tooltip
        private string statSummary;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contrast");
            Tooltip.SetDefault(
                "Grants infinite flight and permanent day brightness\n" +
                "Increases tile reach by 100"
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
            player.wingTime = 1; // Unlimited flight
            Player.tileRangeX += 100;
            Player.tileRangeY += 100;

            statSummary = "-------------------\n" +
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
