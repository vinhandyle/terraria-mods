using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace SoxarsMod.Items.Accessories.Tarot
{
    public class TarotCards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Major Arcana");
            Tooltip.SetDefault("+5 defense, +25 max life, +50 max Mana, +10% damage and melee speed \n+5% critical strike chance, +1 max minions, +50% max run speed, and +60 max wing time \n+50 max mana while in the Desert \n+5 defense and your attacks inflict On Fire! during the night \nYour attacks inflict Cursed Inferno during the day \nNegates fall damage, grants immunity to knockback, and reduces mana costs by 5% \nAttackers take 50% damage received \nReduces the cooldown of healing potions \nYou will survive fatal damage and will be healed 100 HP if an attack would have killed you \nYou will restore some HP upon entering Chaos State");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
            item.rare = -12;
            item.value = 1000000;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<SoxarsModPlayer>().tarotCardsEquipped = true;

            if (player.ZoneDesert == true)
            {
                player.statManaMax2 += 100;
            }
            else
            {
                player.statManaMax2 += 50;
            } //The Fool
            player.magicDamage = 1.1f; //The Magician
            player.statLifeMax2 += 25; //The High Priestess
            player.minionDamage += 0.1f; //The Empress
            player.rangedDamage += 0.1f; //The Emperor
            player.thrownDamage += 0.1f; //The Hierophant
            player.potionDelayTime -= 900; //The Lovers
            player.meleeSpeed += 0.1f; //The Chariot
            player.meleeDamage += 0.1f; //Strength
            player.magicCrit += 5;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5; //The Hermit
            player.maxRunSpeed += 0.5f; //Wheel of Fortune
            player.wingTimeMax += 60; //Justice
            player.noFallDmg = true; //The Hanged Man
            //Death
            player.thorns = 0.5f; //Temperance
            player.minionDamage += 0.1f; //The Devil
            player.noKnockback = true; //The Tower
            player.manaCost -= 0.05f; //The Star
            if (Main.dayTime == false)
            {
                player.statDefense += 10;
            }
            else
            {
                player.statDefense += 5;
            } //The Moon
            //The Sun
            player.maxMinions += 1;//Judgement
            //The World
        }

        //public override void AddRecipes()
        //{
        //    ModRecipe recipe = new ModRecipe(mod);
        //    recipe.AddIngredient(mod.ItemType("BlankCard"));
        //    recipe.AddIngredient(null, "Tarot13", 1);
        //    recipe.AddIngredient(null, "Tarot21", 1);
        //    //recipe.AddIngredient(ItemID.HeroCard, 1); 6
        //    //recipe.AddIngredient(ItemID.ColorCard, 1); 4
        //    //recipe.AddIngredient(ItemID.PureCard, 1); 10
        //    recipe.AddTile(TileID.CrystalBall);
        //    recipe.SetResult(this);
        //    recipe.AddRecipe();
        //}
    }
}
