using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace prefixtest.Projectiles
{
	// This Example class demonstrates how to make your own weapon ammo.
	// Used by ExampleCustomAmmoGun
	public class divinefolleyproj : ModProjectile
	{
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Divine Folley"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

		}

		public override void SetDefaults() {
      Projectile.width = 8; // The width of projectile hitbox
      Projectile.height = 8; // The height of projectile hitbox

      Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
      Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
      Projectile.friendly = true; // Can the projectile deal damage to enemies?
      Projectile.hostile = false; // Can the projectile deal damage to the player?
      Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
      Projectile.light = 1f; // How much light emit around the projectile
      Projectile.tileCollide = false; // Can the projectile collide with tiles?
      Projectile.timeLeft = 2; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
      Projectile.penetrate = 2;
		}
		// Projectile.NewProjectile(source, startPos, newVelocity, type, damage, knockback, player.whoAmI);

    public override void AI() {
      const int NumProjectiles = 4; //The humber of projectiles that this gun will shoot.

      for (int i = 0; i < NumProjectiles; i++) {
        // Rotate the velocity randomly by 30 degrees at max.
				int type = Main.rand.Next(new int[] {ProjectileID.FireArrow, ProjectileID.UnholyArrow, ProjectileID.HolyArrow, ProjectileID.CursedArrow  });

        Vector2 newVelocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(15));

        // Decrease velocity randomly for nicer visuals.
        newVelocity *= 1f - Main.rand.NextFloat(0.3f);
        //Create a projectile.
        Projectile.NewProjectileDirect(Projectile.GetProjectileSource_FromThis(), Projectile.position, newVelocity, type, Projectile.damage , 5, Projectile.owner); // 13 damage 5 knockback
      }
			Projectile.netUpdate = true;


		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		// Here we create recipe for 999/ExampleCustomAmmo stack from 1/ExampleItem

	}
}
}
