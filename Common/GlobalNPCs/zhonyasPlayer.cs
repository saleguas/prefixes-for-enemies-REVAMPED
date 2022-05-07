using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Projectiles;
using prefixtest.buffs;

namespace prefixtest.Common.GlobalNPCs
{
    public class zhonyasPlayer : ModPlayer
    {
        public int zhonyasDuration = 300;

        public int zhonyasTimer = 0;

        public int zhonyasCooldown = 0;

        public override void PreUpdate()
        {
            if (zhonyasCooldown > 0)
            {
                zhonyasCooldown -= 1;
            }
            else if (zhonyasTimer > 0)
            {
                zhonyasTimer -= 1;
                Player.AddBuff(BuffID.Stoned, 5);
                Player.AddBuff(BuffID.ShadowDodge, 5);
                if (zhonyasTimer == 1)
                {
                    zhonyasCooldown = 3000;
                    zhonyasTimer = 0;
                }
            }
        }
    }
}
