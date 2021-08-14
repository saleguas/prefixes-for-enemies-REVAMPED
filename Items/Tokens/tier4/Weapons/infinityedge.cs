using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using prefixtest.buffs;

namespace prefixtest.Items.Tokens.tier4.Weapons
{
	public class infinityedge : ModItem
	{
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Infinite Edge"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

			Tooltip.SetDefault("Crits are cool right? The right click agrees!");
		}

		public override void SetDefaults() {
			// Common Properties
			Item.width = 45; // Hitbox width of the item.
			Item.height = 28; // Hitbox height of the item.
			Item.scale = 0.75f;
			Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item11; // The sound that this item plays when used.

			// Weapon Properties
			Item.DamageType = DamageClass.Melee; // Sets the damage type to ranged.
			Item.damage = 84; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
      Item.shoot = 116; // For some reason, all the guns in the vanilla source have this.
      Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
			Item.crit = 100;

			// Gun Properties

		}

    public override bool AltFunctionUse(Player player) {
      return true;
    }

    public override bool CanUseItem(Player player) {
      if (player.altFunctionUse == 2) {
        Item.shoot = 116; // For some reason, all the guns in the vanilla source have this.
  			Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
        Item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
        Item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
        Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
        Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
        Item.scale = 1.5f;
        Item.damage = 250;
				Item.crit = 100;

      } else {
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;
        Item.scale = 2.5f;
        Item.damage = 19;



      }
      return base.CanUseItem(player);
    }


    public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
      // Vector2 perturbedSpeed = new Vector2(0, velocity.Y);
      // position.X += 200f;

      if (player.altFunctionUse == 2){
        for(int i = 0; i < 50; i++){
          Vector2 upLeftSword = new Vector2(position.X - 50f - (30f * i), position.Y + 600f + (30f * i));
          Vector2 downLeftSword = new Vector2(position.X - 50f - (30f * i), position.Y -600f - (30f * i));
          Vector2 upRightSword = new Vector2(position.X + 50f + (30f * i), position.Y + 600f + (30f * i));
          Vector2 downRightSword = new Vector2(position.X + 50f + (30f * i), position.Y -600f - (30f * i));
          Vector2 goingUp = new Vector2(0, -25f);
          Vector2 goingDown = new Vector2(0, 25f);

          Projectile.NewProjectile(source, upLeftSword, goingUp, type, damage, knockback, player.whoAmI);
          Projectile.NewProjectile(source, upRightSword, goingUp, type, damage, knockback, player.whoAmI);
          Projectile.NewProjectile(source, downLeftSword, goingDown, type, damage, knockback, player.whoAmI);
          Projectile.NewProjectile(source, downRightSword, goingDown, type, damage, knockback, player.whoAmI);

        }
        return false;

      }
      else{
        return true;
      }
      // 	int a = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);


    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
         player.AddBuff(ModContent.BuffType<buffs.infinitymight>(), 300);
    }


		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		// public override Vector2? HoldoutOffset() {
		// 	return new Vector2(2f, -2f);
		// }

		/*
		* Feel free to uncomment any of the examples below to see what they do
		*/

		// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
		// Uzi/Molten Fury style: Replace normal Bullets with High Velocity
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.Bullet) { // or ProjectileID.WoodenArrowFriendly
				type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
			}
		}*/

		// What if I wanted multiple projectiles in a even spread? (Vampire Knives)
		// Even Arc style: Multiple Projectile, Even Spread
		/*public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(45);

			position += Vector2.Normalize(velocity) * 45f;

			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}

			return false; // return false to stop vanilla from calling Projectile.NewProjectile.
		}*/

		// How can I make the shots appear out of the muzzle exactly?
		// Also, when I do this, how do I prevent shooting through tiles?
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}*/

		// How can I get a "Clockwork Assault Rifle" effect?
		// 3 round burst, only consume 1 ammo for burst. Delay between bursts, use reuseDelay
		/*	The following changes to SetDefaults()
			item.useAnimation = 12;
			item.useTime = 4; // one third of useAnimation
			item.reuseDelay = 14;
		public override bool ConsumeAmmo(Player player)	{
			// Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (useAnimation - 1, then - useTime until less than 0.)
			// We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
			return !(player.itemAnimation < item.useAnimation - 2);
		}*/

		// How can I shoot 2 different projectiles at the same time?
		/*public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(source, position, velocity, ProjectileID.GrenadeI, damage, knockback, player.whoAmI);

			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}*/

		// How can I choose between several projectiles randomly?
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			type = Main.rand.Next(new int[] { type, ProjectileID.GoldenBullet, ProjectileType<Projectiles.ExampleBullet>() });
		}*/
	}
}
