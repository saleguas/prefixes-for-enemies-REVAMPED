using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace prefixtest.Items.Tokens.tier4.Weapons {
  public class blazereap4: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Blaze Reap"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Uses explosive powder as ammunition");
    }

    public override void SetDefaults() {
      Item.width = 50; //The item texture's width.
      Item.height = 46; //The item texture's height.

      Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
      Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
      Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
      Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

      Item.DamageType = DamageClass.Melee; //Whether your item is part of the melee class.
      Item.damage = 78; //The damage your item deals.
      Item.knockBack = 20; //The force of knockback of the weapon. Maximum is 20
      Item.crit = 40; //The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.
      Item.scale = 2.0f;
      Item.rare = ItemRarityID.Lime; // The color that the item's name will be in-game.

      Item.value = Item.buyPrice(gold: 1); //The value of the weapon in copper coins.
      Item.UseSound = SoundID.Item1; //The sound when the weapon is being used.

      Item.shoot = 668;
      Item.shootSpeed = 8f;
      Item.useAmmo = ItemID.ExplosivePowder;
    }
    // This method gets called when firing your weapon/sword.
    // Item.useAmmo = ModContent.ItemType<blazereap4>();
    public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<soulofchance>(3);
			recipe.AddIngredient<EmeraldToken>(1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

    public override bool CanBeConsumedAsAmmo(Player player) {
      return true;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			// Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
			// 60 frames = 1 second
			target.AddBuff(BuffID.OnFire, 60);
      // Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
		}

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);

			position += Vector2.Normalize(velocity) * 45f;

			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

      return false;
    }


  }
}
