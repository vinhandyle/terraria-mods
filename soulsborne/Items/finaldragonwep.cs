using Terraria.ID;
using Terraria.ModLoader;

namespace soulsborne.Items
{
    public class finaldragonwep : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Everlasting Dragon's Blade");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.damage = 1000;
            item.melee = true;
            item.width = 100;
            item.height = 100;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = 10000000;
            item.rare = 11;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "drakesword");
            recipe.AddIngredient(null, "dragonkgaxe");
            recipe.AddIngredient(null, "dragongs");
            recipe.AddIngredient(null, "priscidagger");
            recipe.AddIngredient(null, "moonlightgs");
            recipe.AddIngredient(null, "obsidiangs");
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}