using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace prefixtest.buffs
{
	public class infinitymight : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Infinity Might");
			Description.SetDefault("Grants +10 defense and 20% more damage.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
		}

		public override void Update(Player player, ref int buffIndex) {
			player.statDefense += 10; //Grant a +4 defense boost to the player while the buff is active.
      player.GetDamage(DamageClass.Generic) *= 1.20f;
		}
	}
}
