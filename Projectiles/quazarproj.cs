using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace prefixtest.Projectiles
{

class quazarproj : ModProjectile
	{

    private int AITimer = 0;
    private int i = 0;

		public override void SetStaticDefaults() {
			// Total count animation frames
			Main.projFrames[Projectile.type] = 4;
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
      Projectile.tileCollide = true; // Can the projectile collide with tiles?
      Projectile.timeLeft = 300; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
      Projectile.penetrate = -1;

    }

    public override void AI() {
      AITimer = (AITimer + 1) % 10000;
      double radius = 10;
      double angle = Math.PI / 4.0;

			if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}

      // if(AITimer % 50 == 0){
      //   for(double i = 0; i < 9; i++){
      //     float newX = (float)(Math.Cos(angle*i) * radius);
      //     float newY = (float)(Math.Sin(angle*i) * radius);
      //     Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, new Vector2(newX, newY), 207, Projectile.damage, 2f, Projectile.owner);
      //   }
      // }
      if(AITimer % 5 == 0){
        i += 35;
        float newX = (float)(Math.Cos(angle*i) * radius);
        float newY = (float)(Math.Sin(angle*i) * radius);
        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, new Vector2(newX, newY), 207, Projectile.damage, 2f, Projectile.owner);
      }

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero

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
