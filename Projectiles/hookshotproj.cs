using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace prefixtest.Projectiles
{

class hookshotproj : ModProjectile
	{

    public override void SetDefaults() {
      Projectile.width = 8; // The width of projectile hitbox
      Projectile.height = 8; // The height of projectile hitbox

      Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
      Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
      Projectile.friendly = true; // Can the projectile deal damage to enemies?
      Projectile.hostile = false; // Can the projectile deal damage to the player?
      Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
      Projectile.light = 1f; // How much light emit around the projectile
      Projectile.tileCollide = true; // Can the projectile collide with tiles?
      Projectile.timeLeft = 300; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
      Projectile.penetrate = 2;

    }

    public override void AI() {
			float maxDetectRadius = 800; // The maximum radius at which a projectile can detect a target
			float projSpeed = 10f; // The speed at which the projectile moves towards the target

			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

      if (Math.Abs(Projectile.position.X - closestNPC.position.X) <= 2f)
      {
        Vector2 newVelocity =  new Vector2(0, 25f);
        Projectile.velocity = newVelocity;
      }

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero

		}

    public NPC FindClosestNPC(float maxDetectDistance) {
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++) {
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy()) {
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance) {
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}

		// Note, this Texture is actually just a blank texture, FYI.



    // public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
		// 	if (list.Contains(target))
    //     return;
    //   else{
    //     list.Add(target);
    //     Vector2 upProj = new Vector2(Projectile.velocity.X, Projectile.velocity.Y + 12f);
    //     Vector2 downProj = new Vector2(Projectile.velocity.X, Projectile.velocity.Y - 12f);
    //     Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, upProj, Projectile.type, damage, knockback, Projectile.owner);
    //     Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, downProj, Projectile.type, damage, knockback, Projectile.owner);
    //   }
		// }



	}
}
