using ExampleMod.Content.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace prefixtest.Items.Tokens.tier1{
	public class TuningFork : ModItem{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Why are you using a tuning fork to fight? Hitting true melee charges up the fork, right click to release it!"); //The (English) text shown below your weapon's name.
			DisplayName.SetDefault("Tuning Fork");
		}

		public override void SetDefaults() {
			Item.width = 40; //The item texture's width.
			Item.height = 40; //The item texture's height.

			Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
			Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.
			Item.noMelee = false;

			Item.DamageType = DamageClass.Melee; //Whether your item is part of the melee class.
			Item.damage = 69; //The damage your item deals.
			Item.knockBack = 3; //The force of knockback of the weapon. Maximum is 20
			Item.crit = 28; //The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.

			Item.value = Item.buyPrice(gold: 35); //The value of the weapon in copper coins.
			Item.rare = ModContent.Yellow; // Give this item our custom rarity.
			Item.UseSound = SoundID.Item1; //The sound when the weapon is being used.
		}


	}
}
