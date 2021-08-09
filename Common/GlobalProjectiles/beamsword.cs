using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace prefixtest.Common.GlobalProjectiles
{
	// Here is a class dedicated to showcasing projectile modifications
	public class beamsword : GlobalProjectile
	{
    public override bool AppliesToEntity(Projectile projectile, bool lateInstatiation) {
      return projectile.type == 116;
    }


      public override void SetDefaults(Projectile projectile) {
        projectile.penetrate = 3;
        projectile.tileCollide = false;
        			projectile.timeLeft = 180;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
  		}
}
}
