using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace prefixtest.Projectiles
{
	// This file showcases the concept of piercing.

	public class blazereap3proj : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Example Piercing Projectile"); //The name of the Projectile(it can be appeared in chat)
		}

    public override void SetDefaults()
    {
        Projectile.width = 14;
        Projectile.height = 18;
        Projectile.aiStyle = 16;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 0;
    }
    public override void Kill(int timeLeft)
    {
        Vector2 position = Projectile.Center;
        SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

        int radius = 150;
        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                int xPosition = (int)(x + position.X / 16.0f);
                int yPosition = (int)(y + position.Y / 16.0f);

                if (Math.Sqrt(x * x + y * y) <= radius + 0.5)
                {
                    Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);
                }
            }
        }
    }
}
}
