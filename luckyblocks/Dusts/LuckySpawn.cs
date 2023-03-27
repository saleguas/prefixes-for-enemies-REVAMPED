using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace luckyblocks.Dusts
{
    public class LuckySpawn : ModDust
    {

        private int timer = 300; // 300 frames = 5 seconds

        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.frame = new Rectangle(0, 0, 30, 30);
            dust.scale = 1f;
        }

        public override bool Update(Dust dust)
        {
            if (dust.active)
            {

                dust.position.Y -= 0.2f; // Move the dust upwards by 0.2 pixels per frame
                
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                // the dust is drawn as a rectangle starting at 0,0 with a width and height of 30,30
                // we need to offset the position by half the width and height to center the dust 
                Vector2 dust_pos = dust.position + new Vector2(15, 15);
                Dust d = Dust.NewDustPerfect(dust_pos + speed * 100, DustID.IchorTorch, speed * 2, Scale: 1.5f);
                d.noGravity = true;
                // GemTopaz
                

                timer--;
                if (timer <= 0)
                {
                    dust.active = false;
                    timer = 300; // Reset the timer to 300 when the dust is inactive
                }


            }

            return false;
        }
    }
}
