using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace prefixtest.buffs
{

    public class spineltonicburn : ModBuff
    {
        private int firetimer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tonic Affliction");
            Description.SetDefault("Your soul is ablaze");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (firetimer % 20 == 0)
            {
                for (int k = 0; k < Main.maxPlayers; k++)
                {
                    Player nearestPlayer = Main.player[k];
                    float sqrDistanceToTarget =
                        Vector2.DistanceSquared(nearestPlayer.Center, player.Center);
                    if (Math.Abs(sqrDistanceToTarget) < 1000000f)
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
                if (Math.Abs(sqrDistanceToTarget) < 1000000f)
                {
                    int damageAmt = ((int)Math.Ceiling(nearestNPC.lifeMax * 0.01f / 20f));
                    if (nearestNPC.life >= damageAmt * 2)
                        nearestNPC.life -= damageAmt;
                }

            }

            firetimer = (firetimer + 1) % 90000;
        }
    }
}
