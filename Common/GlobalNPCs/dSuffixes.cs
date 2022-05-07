using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using prefixtest.Common.GlobalNPCs;
using Terraria.Audio;
using System.Collections.Generic;
using System;

namespace prefixtest.Common.GlobalNPCs {
  public class dSuffixes: GlobalNPC {

    public override bool InstancePerEntity => true;
    private string suffix1 = "";
    private bool nameChanged = false;
    private int lives = 10;
    private int AITimer = 0;
    private int floatTimer = 0;
    private int explosionTimer = 0;
    private List<Player> floating = new List<Player>();

    public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
      if (npc.townNPC == true || npc.friendly == true)
        return false;

      Random random = new Random();
      double roll1 = random.NextDouble();
      npc.netUpdate = true;


      return roll1 <= (double) (ModContent.GetInstance<modconfig>().SuffixChance * 0.01);
    }

    public override void SetDefaults(NPC npc) {
      // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
      int upLimit = 4;
      if (Main.hardMode)
        upLimit = 7;
      Random random = new Random();
      int roll2 = random.Next(0,upLimit); // creates a number from 1 to n-1
      switch (roll2) {

        case 0:
          suffix1 = "The Immortal";
          break;
        case 1:
          suffix1 = "The Necromancer";
          break;
        case 2:
          suffix1 = "The Psyker";
          break;
        case 3:
          suffix1 = "The Soul Eater";
          break;
        case 4:
          suffix1 = "The Cultist";
          break;
        case 5:
          suffix1 = "The Sacrifice";
          break;
        case 6:
          suffix1 = "The Fireborn";
          break;


      }
      npc.value *= 4f;

    }

    public override void AI(NPC npc) {
      AITimer = (AITimer + 1) % 10000;
      //Make the guide giant and green.
      Player targetPlayer = Main.player[npc.target];
      Vector2 npcToPlayer = targetPlayer.position - npc.position;
      if(suffix1.Contains("The Necromancer") && npc.value != 0){

          if(AITimer % 300 == 0){

          int x =Main.rand.Next(1, 5);
            for (int i = 0; i < x; i++)
            {
                int summonType = Main.rand.Next(new int[] { 3, 21, 201, 202, 203, 449, 450, 451, 452 });

                int n = NPC.NewNPC(npc.GetSpawnSourceForNPCFromNPCAI(), (int)npc.position.X + Main.rand.Next(-300, 300), (int)npc.position.Y - 100, summonType);
                Main.npc[n].value = 0;
                npc.netUpdate = true;


            }


        }
      }

      if(suffix1.Contains("The Sacrifice")){


        if(AITimer % 600 == 0){
          int n = NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)npc.position.X, (int)npc.position.Y, 454);
          if(!NPC.downedPlantBoss){
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

        if(suffix1.Contains("The Cultist")){

          if(AITimer % 300 == 0){
            int a = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, npc.velocity, 464, npc.damage, 2f); //bullet

          }
          if(AITimer % 600 == 0){
            int a = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, npc.velocity, 465, npc.damage, 2f); //bullet

          }

          }


          if(suffix1.Contains("The Psyker")){
            if(floatTimer > 0){
              floatTimer -= 1;
              foreach(Player p in floating){
                p.velocity = new Vector2(0, -2f);
              }
              if (floatTimer == 1){
                foreach(Player p in floating){
                  p.velocity += new Vector2(50f, -2f);
                }
                floating.Clear();
                floatTimer = 0;
              }
            }

            else if(AITimer % 300 == 0){

              for (int k = 0; k < Main.maxPlayers; k++) {
                Player player = Main.player[k];
                float sqrDistanceToTarget = Vector2.DistanceSquared(player.Center, npc.Center);
                if(Math.Abs(sqrDistanceToTarget) < 1000000f){
                  floating.Add(player);
                  floatTimer = 180;

                }
              }

            }
          }

          if(suffix1.Contains("The Fireborn")){
            if(explosionTimer > 0){
              if(AITimer % 10 == 0){
                int a = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), new Vector2(npc.position.X - 200 - 100 *(10 - explosionTimer), npc.position.Y), new Vector2(0, 0), 686, npc.damage * 2, 2f); //bullet
                int b = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), new Vector2(npc.position.X + 200 + 100 *(10 - explosionTimer), npc.position.Y), new Vector2(0, 0), 686, npc.damage * 2, 2f); //bullet

                explosionTimer -= 1;
              }

            }
            if(AITimer % 180 == 0){
              int a = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 686, npc.damage * 2, 2f); //bullet

            }
            if(AITimer % 300 == 0){
              explosionTimer = 10;
            }

          }





      // npc.scale = 1.5f;
      // npc.color = Color.ForestGreen;
      if (!nameChanged) {
        npc.GetGlobalNPC < prefixString > ().suffix = npc.GetGlobalNPC < prefixString > ().suffix + " " + suffix1;
        nameChanged = true;
        npc.netUpdate = true;

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
