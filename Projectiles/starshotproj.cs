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
	public class starshotproj : ModProjectile
	{
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Starshot"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

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

    public override void AI() {
			var player = Main.LocalPlayer;

			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f) {
				ceilingLimit = player.Center.Y - 200f;
			}
			// Loop these functions 3 times.
			for (int i = 0; i < 3; i++) {

				var position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f) {
					heading.Y *= -1f;
				}

				if (heading.Y < 20f) {
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= Projectile.velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				heading.X *= 2f;
				heading.Y *= 2f;
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), position, heading, 89, 40, 5, Projectile.owner, 0f, ceilingLimit);
			}
			Projectile.netUpdate = true;

        // Projectile.NewProjectileDirect(Projectile.GetProjectileSource_FromThis(), Projectile.position, newVelocity, 14, 13, 5, Projectile.owner); // 13 damage 5 knockback
      }


		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		// Here we create recipe for 999/ExampleCustomAmmo stack from 1/ExampleItem

	}
}
