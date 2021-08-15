using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using prefixtest.Common.GlobalNPCs;
using Terraria.Audio;

namespace prefixtest.Common.GlobalNPCs {
  public class dSuffixes: GlobalNPC {

    public override bool InstancePerEntity => true;
    private string suffix1 = "";
    private bool nameChanged = false;
    private int lives = 10;
    private int AITimer = 0;

    public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
      if (npc.townNPC == true || npc.friendly == true)
        return false;

      Random random = new Random();
      double roll1 = random.NextDouble();

      return roll1 <= 1.00;
    }

    public override void SetDefaults(NPC npc) {
      // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
      Random random = new Random();
      int roll2 = random.Next(3, 4); // creates a number from 1 to n-1
      switch (roll2) {

        case 0:
          suffix1 = "The Immortal";
          break;
        case 1:
          suffix1 = "The Necromancer";
          break;
        case 2:
          suffix1 = "The Sacrifice";
          break;
        case 3:
          suffix1 = "The Soul Eater";
          break;
        


      }

    }

    public override void AI(NPC npc) {
      AITimer = (AITimer + 1) % 10000;
      //Make the guide giant and green.
      if(suffix1.Contains("The Necromancer") && npc.value != 0){

          if(AITimer % 300 == 0){

          int x =Main.rand.Next(1, 5);
            for (int i = 0; i < x; i++)
            {
                int summonType = Main.rand.Next(new int[] { 3, 21, 201, 202, 203, 449, 450, 451, 452 });

                int n = NPC.NewNPC((int)npc.position.X + Main.rand.Next(-300, 300), (int)npc.position.Y - 100, summonType);
                Main.npc[n].value = 0;

            }


        }
      }
      if(suffix1.Contains("The Sacrifice")){


        if(AITimer % 600 == 0){
          int n = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, 454);
          if(!Main.hardMode){
            Main.npc[n].life /= 2;
            Main.npc[n].defense = 0;

          }
          npc.life = 0;
          SoundEngine.PlaySound(15, npc.position, 0);


        }
      }
      if(suffix1.Contains("The Soul Eater")){


        for (int k = 0; k < Main.maxPlayers; k++) {
          Player player = Main.player[k];
          float sqrDistanceToTarget = Vector2.DistanceSquared(player.Center, npc.Center);
          if(Math.Abs(sqrDistanceToTarget) < 1000000f){
            player.AddBuff(BuffID.OnFire, 30);
            player.AddBuff(BuffID.Bleeding, 30);
            player.AddBuff(BuffID.Slow, 30);
            player.AddBuff(BuffID.Horrified, 30);

          }
        }


        }




      // npc.scale = 1.5f;
      // npc.color = Color.ForestGreen;
      if (!nameChanged) {
        npc.GetGlobalNPC < prefixString > ().suffix = npc.GetGlobalNPC < prefixString > ().suffix + " " + suffix1;
        nameChanged = true;
      }
      npc.netUpdate = true;

    }

    public override bool CheckDead(NPC npc)
   {
       if (lives > 0 && suffix1.Contains("The Immortal"))
       {
           lives--;
           npc.damage = (int)(npc.damage * 1.2);
           npc.life = npc.lifeMax;
           SoundEngine.PlaySound(15, npc.position, 0);
           return false;
       }
       return true;
   }

    // public override void OnKill(NPC npc) {
    //
    // 	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
    //
    // 	//TODO: Add the rest of the vanilla drop rules!!
    // }

  }
}
