using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;


namespace prefixtest.Projectiles
{

class ludensechoproj : ModProjectile
	{

    private List<NPC> list = new List<NPC>();
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
      Projectile.timeLeft = 300; //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
    }

		// Note, this Texture is actually just a blank texture, FYI.



    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
			if (list.Contains(target))
        return;
      else{
        list.Add(target);
        Vector2 upProj = new Vector2(Projectile.velocity.X, Projectile.velocity.Y + 12f);
        Vector2 downProj = new Vector2(Projectile.velocity.X, Projectile.velocity.Y - 12f);
        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, upProj, Projectile.type, damage, knockback, Projectile.owner);
        Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), Projectile.position, downProj, Projectile.type, damage, knockback, Projectile.owner);
      }
		}



	}
}
