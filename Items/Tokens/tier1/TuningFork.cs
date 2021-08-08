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
			Item.width = 40;
			Item.height = 40;
			Counter = 0;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.noMelee = false;

			Item.DamageType = DamageClass.Melee;
			Item.damage = 69;
			Item.knockBack = 3;
			Item.crit = 28;
			Item.value = Item.buyPrice(gold: 35);
			Item.rare = ModContent.Yellow;
			Item.UseSound = SoundID.Item1;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
         Counter++;
    }
		//when right click fire music notes , amount depending on counter projectile name is "TiedEighthNote" fire like a shotgun

	}
}
