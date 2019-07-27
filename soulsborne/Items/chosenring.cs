using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class chosenring : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Chosen Ring");
            Tooltip.SetDefault("Increases magic and arrow damage by 50% \nReduces mana costs by 50% \nIncreases maximum life, mana, and movespeed by 20% \nIncreases thorns damage by 500% \nReduces damage taken by 20% \nIncreases critical strike chance by 30% \nGrants immunity to lava, the ability to freely move through liquids, and the Lucky Coins effect \nGrants the Ninja Master Gear Dash \nReduces dashing cooldown by 50% \nIncreases damage and defense by 50% when under 20% life");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 5000000;
            item.rare = 8;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.5f;
            player.manaCost /= 2f;
            player.statLifeMax2 *= 12;
            player.statLifeMax2 /= 10;
            player.statManaMax2 *= 12;
            player.statManaMax2 /= 10;
            player.moveSpeed += 0.5f;
            if (player.statLife <= 0.2 * player.statLifeMax2)
            {
                player.statDefense *= 15;
                player.statDefense /= 10;
                player.arrowDamage += 0.5f;
                player.bulletDamage += 0.5f;
                player.magicDamage += 0.5f;
                player.meleeDamage += 0.5f;
                player.minionDamage += 0.5f;
                player.rangedDamage += 0.5f;
                player.rocketDamage += 0.5f;
                player.thrownDamage += 0.5f;
            }
            player.thorns += 5f;
            player.endurance += 0.2f;
            player.arrowDamage += 0.5f;
            player.magicCrit += 30;
            player.meleeCrit += 30;
            player.rangedCrit += 30;
            player.thrownCrit += 30;
            player.lavaImmune = true;
            player.dash = 4;
            player.dashDelay /= 2;
            player.ignoreWater = true;
            player.coins = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "bellowing");
            recipe.AddIngredient(null, "lingering");
            recipe.AddIngredient(null, "fapring");
            recipe.AddIngredient(null, "bluetsr");
            recipe.AddIngredient(null, "redtsr");
            recipe.AddIngredient(null, "leoring");
            recipe.AddIngredient(null, "wolfring");
            recipe.AddIngredient(null, "hawkring");
            recipe.AddIngredient(null, "hornetring");
            recipe.AddIngredient(null, "charring"); 
            recipe.AddIngredient(null, "darkwoodgrain");
            recipe.AddIngredient(null, "rustediron");
            recipe.AddIngredient(null, "covetousserpent");
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}