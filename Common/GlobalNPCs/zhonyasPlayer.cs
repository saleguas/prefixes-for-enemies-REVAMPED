using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using prefixtest.buffs;
using prefixtest.Projectiles;

namespace prefixtest.Common.GlobalNPCs {
  public class zhonyasPlayer : ModPlayer
	{
    public int zhonyasDuration = 300;
    public int zhonyasTimer = 0;

    public override void PreUpdate(){
      if(zhonyasTimer > 0){
        zhonyasTimer -= 1;
        Player.AddBuff(BuffID.Stoned, 5);
        Player.AddBuff(BuffID.ShadowDodge, 5);
      }
    }



    }




  }
