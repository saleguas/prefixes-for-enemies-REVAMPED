using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace luckyblocks.Buffs
{

    public class hellFireTinctureBurn : ModBuff
    {
        private int firetimer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Tincture");
            Description.SetDefault("Your soul is ablaze");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // make a for loop that gets n points on a circle around the player
            for (int i = 0; i < 360; i += 5)
            {
                // calculate the x and y of the point
                float x = player.position.X + (float)Math.Cos(i) * 500f;
                float y = player.position.Y + (float)Math.Sin(i) * 500f;
                Vector2 dustPos = new Vector2(x, y);
                // spawn a firework at that point
                Dust dust = Dust.NewDustDirect(dustPos, player.width, player.height, 59);
            }
            if (firetimer % 20 == 0)
            {
                for (int k = 0; k < Main.maxPlayers; k++)
                {
                    Player nearestPlayer = Main.player[k];
                    float sqrDistanceToTarget =
                        Vector2.DistanceSquared(nearestPlayer.Center, player.Center);
                    if (Math.Abs(sqrDistanceToTarget) < 250000f)
                    {
                        int damageAmt = ((int)Math.Ceiling(nearestPlayer.statLifeMax2 * 0.01f));

                        nearestPlayer.statLife -= damageAmt;
                        if (nearestPlayer.statLife <= 0)
                        {
                            nearestPlayer.KillMe(PlayerDeathReason.ByCustomReason(nearestPlayer.name + " succumbed to the affliction of the Tonic"), 0, 0);
                        }
                    }
                }
            }
            for (int k = 0; k < Main.npc.Length; k++)
            {
                NPC nearestNPC = Main.npc[k];
                float sqrDistanceToTarget =
                    Vector2.DistanceSquared(nearestNPC.Center, player.Center);
                if (Math.Abs(sqrDistanceToTarget) < 250000f)
                {
                    int damageAmt = ((int)Math.Ceiling(nearestNPC.lifeMax * 0.01f / 20f));
                    if (nearestNPC.life >= damageAmt * 2)
                        nearestNPC.life -= damageAmt;
                }

            }

            firetimer = (firetimer + 1) % 90000;
        }
        // draw dust
    }
}
