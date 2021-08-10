using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace prefixtest.Items.Tokens.tier5
{
	public class elementscharm : ModItem
	{
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Elements Charm"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("+5 Life Regen \n+60 Max Life\n5% Increased Magic Damage\n+60 Mana\nGives various regen buffs");
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			// GetDamage returns a reference to the specified damage class' damage StatModifier.
			// Since it doesn't return a value, but a reference to it, you can freely modify it with +-*/ operators.
			// Modifier is a structure that separately holds float additive and multiplicative modifiers.
			// When Modifier is applied to a value, its additive modifiers are applied before multiplicative ones.

			// In this case, we're multiplying by 1.20f, which will mean a 20% damage increase after every additive modifier (and a number of multiplicative modifiers) are applied.
			// Since we're using DamageClass.Generic, this bonus applies to ALL damage the player deals.
			player.statLifeMax2 += 60;
      player.lifeRegen += 5;
      player.statManaMax2 += 60;
      player.GetDamage(DamageClass.Magic) *= 1.05f;

      // GetCrit, similarly to GetDamage, returns a reference to the specified damage class' crit chance.
      // In this case, we're adding 10% crit chance, but only for the melee DamageClass (as such, only melee weapons will receive this bonus).
      player.GetCritChance(DamageClass.Melee) += 10;
      player.AddBuff(87, 5); // campfire
      player.AddBuff(89, 5); // heart lantern
      player.AddBuff(48, 5); // honey
      // player.AddBuff(BuffID.ShadowDodge, 5);


			// GetCrit, similarly to GetDamage, returns a reference to the specified damage class' crit chance.
			// In this case, we're adding 10% crit chance, but only for the melee DamageClass (as such, only melee weapons will receive this bonus).
      // player.GetDamage(DamageClass.Generic) *= 1.20f;
			// GetKnockback is functionally identical to GetDamage, but for the knockback stat instead.
			// In this case, we're adding 100% knockback additively, but only for our custom example DamageClass (as such, only our example class weapons will receive this bonus).
		}


	}
}
