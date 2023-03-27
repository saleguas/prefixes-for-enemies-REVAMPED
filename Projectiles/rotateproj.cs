using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace prefixtest.Projectiles
{

class rotateproj : ModProjectile
	{

    private  List<Projectile> projs = new List<Projectile>();
    private int timer = 0;

    public override void SetDefaults() {
      Projectile.width = 2; // The width of projectile hitbox
      Projectile.height = 20; // The height of projectile hitbox

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

    // Projectile.NewProjectile(source, startPos, newVelocity, type, damage, knockback, player.whoAmI);

    public override void AI() {
      if(timer % 20 == 0){
        int a = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.player[Projectile.owner].position + new Vector2(50f, 0f), new Vector2(0, 0), 3, 15, Projectile.owner);
        Main.projectile[a].timeLeft = 500;
        projs.Add(Main.projectile[a]);
      }
      foreach(Projectile a in projs){
        float angle = (float) (Math.PI / 180f);
        Vector2 tPos = Vector2.Normalize(a.position);
        Vector2 pxpy = a.position;
        Vector2 oxoy = Main.player[Projectile.owner].position;
        float newX = (float) (Math.Cos(angle) * (pxpy.X - oxoy.X) - Math.Sin(angle) * (pxpy.Y - oxoy.Y) + oxoy.X);
        float newY = (float) (Math.Sin(angle) * (pxpy.X - oxoy.X) + Math.Cos(angle) * (pxpy.Y - oxoy.Y) + oxoy.Y);

        a.position = new Vector2(newX, newY);
      }
      timer = (timer + 1) % 10000;

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
    //     Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, upProj, Projectile.type, damage, knockback, Projectile.owner);
    //     Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, downProj, Projectile.type, damage, knockback, Projectile.owner);
    //   }
		// }



	}
}
