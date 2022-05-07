using prefixtest.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace prefixtest.Items.Tokens.tier2.Weapons
{
	public class gemstave : ModItem
	{

    private int shootStyle = 0;
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Gem Stave"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Right click to switch modes. \nChannel the power of gems.");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun

			}

		public override void SetDefaults() {
			// Common Properties
			Item.width = 42; // Hitbox width of the item.
			Item.height = 40; // Hitbox height of the item.
			Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = 5;
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item11; // The sound that this item plays when used.

			// Weapon Properties
			Item.DamageType = DamageClass.Magic; // Sets the damage type to ranged.
			Item.damage = 20; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
			Item.crit = 8;

			// Gun Properties
			Item.shoot = 121; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
      Item.mana = 5;

		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<soulofchance>(3);
			recipe.AddIngredient<TopazToken>(1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		// public override Vector2? HoldoutOffset() {
		// 	return new Vector2(2f, -2f);
		// }



    public override bool AltFunctionUse(Player player) {
      return true;

    }
    public override bool CanUseItem(Player player) {
      if (player.altFunctionUse == 2) {
        shootStyle = (shootStyle + 1) % 6;
      }
      return base.CanUseItem(player);

    }

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
      if (player.altFunctionUse == 2){
        return false;
      }
			if (shootStyle == 0){
        Item.shoot = 121;
        Item.damage = 23;
        Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
        Item.mana = 5;
        Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
  			Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
        return true;
      }
      else if (shootStyle == 1){
        Item.shoot = 122;
        Item.damage = 25;
        Item.shootSpeed = 20f; // The speed of the projectile (measured in pixels per frame.)
        Item.mana = 10;

        float numberProjectiles = 3; // 3, 4, or 5 shots
  			float rotation = MathHelper.ToRadians(45);
        Vector2 newPosition = position + Vector2.Normalize(velocity) * 45f;

  			for (int i = 0; i < numberProjectiles; i++) {
  				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
  				Projectile.NewProjectile(source, newPosition, perturbedSpeed, Item.shoot, Item.damage, knockback, player.whoAmI);
  			}

      }
      else if (shootStyle == 2){
        Item.shoot = 123;
        Item.damage = 28;
        Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
        Item.mana = 10;

        float numberProjectiles = 5; // 3, 4, or 5 shots
        float rotation = MathHelper.ToRadians(45);
        Vector2 newPosition = position + Vector2.Normalize(velocity) * 45f;

        for (int i = 0; i < numberProjectiles; i++) {
          Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
          Projectile.NewProjectile(source, newPosition, perturbedSpeed, Item.shoot, Item.damage, knockback, player.whoAmI);
        }
      }
      else if (shootStyle == 3){
        Item.shoot = 124;
        Item.damage = 32;
        Item.shootSpeed = 20f; // The speed of the projectile (measured in pixels per frame.)
        Item.mana = 16;

        Vector2 spawnPos = new Vector2(Main.MouseWorld.X - 600, Main.MouseWorld.Y - 20);

        for (int i = 0; i<4; i++){
          Vector2 spawnPosProj = new Vector2(spawnPos.X, spawnPos.Y + (i * 10));
          Projectile.NewProjectile(source, spawnPosProj, new Vector2(Item.shootSpeed, 0f), Item.shoot, Item.damage, knockback, player.whoAmI);

        }
      }
      else if (shootStyle == 4){
        Item.shoot = 125;
        Item.damage = 35;
        Item.shootSpeed = 20f; //
        Item.mana = 20;
				Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
				Item.useAnimation = 45;

        for(int i = 0; i < 10; i++){
          Vector2 downLeftSword = new Vector2(position.X - 50f - (30f * i), position.Y -600f - (30f * i));
          Vector2 downRightSword = new Vector2(position.X + 50f + (30f * i), position.Y -600f - (30f * i));
          Vector2 goingDown = new Vector2(0, 25f);


          Projectile.NewProjectile(source, downLeftSword, goingDown, type, damage, knockback, player.whoAmI);
          Projectile.NewProjectile(source, downRightSword, goingDown, type, damage, knockback, player.whoAmI);

        }
      }
      else if (shootStyle == 5){
        Item.shootSpeed = 4f; // The speed of the projectile (measured in pixels per frame.)
        Item.mana = 2;
        Item.useTime = 2; // The item's use time in ticks (60 ticks == 1 second.)
  			Item.useAnimation = 2; // The length of the item's use animation in ticks (60 ticks == 1 second.)
        for(int i = 0; i < 3; i++){
          int type2 = Main.rand.Next(new int[] {121, 122, 123, 124, 125, 126});
          Vector2 summonPosition = new Vector2(position.X + Main.rand.NextFloat(-100, 100), position.Y - 50f - Main.rand.NextFloat(-50, 50));
          Vector2 target =  new Vector2(Main.rand.NextFloat(-50f, 50f), Main.rand.NextFloat(-50f, 50f));

          int a = Projectile.NewProjectile(source, summonPosition, target, type2, damage, knockback, player.whoAmI);


        }
      }
			return false;
		}

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
		/*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
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
		/*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
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
