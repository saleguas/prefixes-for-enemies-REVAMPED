using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace prefixtest.Projectiles
{

class theechoproj : ModProjectile
	{

		private static List<NPC> hitAlready = new List<NPC>();
		private int AITimer = 0;


    public override void SetDefaults() {
      Projectile.width = 36; // The width of projectile hitbox
      Projectile.height = 80; // The height of projectile hitbox

      Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
      Projectile.DamageType = DamageClass.Ranged; // What type of damage does this projectile affect?
      Projectile.friendly = true; // Can the projectile deal damage to enemies?
      Projectile.hostile = false; // Can the projectile deal damage to the player?
      Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
      Projectile.light = 1f; // How much light emit around the projectile
      Projectile.tileCollide = false; // Can the projectile collide with tiles?
      Projectile.timeLeft = 300; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.penetrate = 4;
    }

		// Note, this Texture is actually just a blank texture, FYI.


		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {

			if (hitAlready.Contains(target))
				return;
			else{
				hitAlready.Add(target);
				Vector2 upProj = new Vector2(Projectile.velocity.X, Projectile.velocity.Y + 12f);
				Vector2 downProj = new Vector2(Projectile.velocity.X, Projectile.velocity.Y - 12f);
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, upProj, Projectile.type, damage, knockback, Projectile.owner);
				Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, downProj, Projectile.type, damage, knockback, Projectile.owner);
			}
		}

		public override void AI()
			{
			Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
			AITimer = (AITimer + 1) % 10000;
			if (AITimer % 1000 == 0){
				hitAlready.Clear();
			}
			}



	}
}
