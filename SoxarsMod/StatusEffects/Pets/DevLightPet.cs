using Terraria;
using Terraria.ModLoader;

namespace SoxarsMod.StatusEffects.Pets
{
	public class DevLightPet : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("The Sun");
			Description.SetDefault("Let there be light");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("DevLightPet")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(
					player.position.X, 
					player.position.Y, 
					0f, 0f, 
					mod.ProjectileType("DevLightPet"), 
					0, 0f, 
					player.whoAmI, 
					0f, 0f
					);
			}			
		}
	}
}