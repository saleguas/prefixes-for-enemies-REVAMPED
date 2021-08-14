using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
namespace prefixtest.Common.GlobalProjectiles
{
	// Here is a class dedicated to showcasing projectile modifications
	public class ludensecho : GlobalProjectile
	{


    public override bool AppliesToEntity(Projectile projectile, bool lateInstatiation) {
      return projectile.type == ModContent.ProjectileType<Projectiles.theechoproj>();
    }


      // public override void SetDefaults(Projectile projectile) {
      //   projectile.penetrate = 3;
      //   projectile.tileCollide = fa;
      //   projectile.timeLeft = 20;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
  		// }

      public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit) {
        // target.AddBuff(164, 500);
        Main.player[projectile.owner].AddBuff(164, 60);

      }


}
}
