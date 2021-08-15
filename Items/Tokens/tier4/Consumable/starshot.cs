using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace prefixtest.Items.Tokens.tier4.Consumable
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class starshot : ModItem
	{
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Starshot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

			Tooltip.SetDefault("Rains crystal bullets from the sky."); // The item's description, can be set to whatever you want.
		}

		public override void SetDefaults() {
			Item.width = 14; // The width of item hitbox
			Item.height = 14; // The height of item hitbox

			Item.damage = 40; // The damage for projectiles isn't actually 8, it actually is the damage combined with the projectile and the item together
			Item.DamageType = DamageClass.Ranged; // What type of damage does this ammo affect?

			Item.maxStack = 999; // The maximum number of items that can be contained within a single stack
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
			Item.knockBack = 2f; // Sets the item's knockback. Ammunition's knockback added together with weapon and projectiles.
			Item.value = Item.sellPrice(0, 0, 1, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
			Item.shoot = ModContent.ProjectileType<Projectiles.starshotproj>(); // The projectile that weapons fire when using this item as ammunition.

      Item.ammo = AmmoID.Bullet;
      Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.

		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(999);
			recipe.AddIngredient<soulofchance>(3);
			recipe.AddIngredient<EmeraldToken>(1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}


		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		// Here we create recipe for 999/ExampleCustomAmmo stack from 1/ExampleItem

	}
}
