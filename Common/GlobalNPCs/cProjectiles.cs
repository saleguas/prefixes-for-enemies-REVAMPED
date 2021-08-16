using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using prefixtest.Common.GlobalNPCs;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using System.IO;

namespace prefixtest.Common.GlobalNPCs {
  public class cProjectiles: GlobalNPC {

    public override bool InstancePerEntity => true;
    private string prefix3 = "";
    private int AITimer = 0;
    private bool nameChanged = false;
    private int npcProjectile = 0;

    public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
      if (npc.townNPC == true || npc.friendly == true)
        return false;

      Random random = new Random();
      double roll1 = random.NextDouble();

      return roll1 <= (double) (ModContent.GetInstance<modconfig>().ProjectileChance * 0.01);
    }

    public override void SetDefaults(NPC npc) {
      // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
      Random random = new Random();
      int roll2 = random.Next(1, 28); // creates a number from 1 to n-1
      switch (roll2) {

      case 1:
        prefix3 = "Gunner";
        break;
      case 2:
        prefix3 = "Shotgunning";
        break;
      case 3:
        prefix3 = "Machine Gunning";
        break;
      case 4:
        prefix3 = "Sniper";
        break;
      case 5:
        prefix3 = "Volcanic";
        break;
      case 6:
        prefix3 = "Umbra";
        break;
      case 7:
        prefix3 = "Webbing";
        break;
      case 8:
        prefix3 = "Electric";
        break;
      case 9:
        prefix3 = "Rioting";
        break;
      case 10:
        prefix3 = "Pirate";
        break;
      case 11:
        prefix3 = "Night Hunter";
        break;
      case 12:
        prefix3 = "Infinite";
        break;
      case 13:
        prefix3 = "Infernal";
        break;
      case 14:
        prefix3 = "Hellish";
        break;
      case 15:
        prefix3 = "Vampire Hunter";
        break;
      case 16:
        prefix3 = "Cyborg";
        break;
      case 17:
        prefix3 = "Grave Robber";
        break;
      case 18:
        prefix3 = "Grassy";
        break;
      case 19:
        prefix3 = "Boomerang";
        break;
      case 20:
        prefix3 = "Peddler";
        break;
      case 21:
        prefix3 = "Demonic";
        break;
      case 22:
        prefix3 = "Fungal";
        break;
      case 23:
        prefix3 = "Fishy";
        break;
      case 24:
        prefix3 = "Floral";
        break;
      case 25:
        prefix3 = "Ballistician";
        break;
      case 26:
        prefix3 = "Hemomancer";
        break;
      case 27:
        prefix3 = "Ninja";
        break;
      }

      npc.value *= 2f;

    }

    public override void AI(NPC npc) {
      AITimer = (AITimer + 1) % 10000;
      Player targetPlayer = Main.player[npc.target];
      Vector2 npcToPlayer = targetPlayer.position - npc.position;
      // int distance = (int)Math.Sqrt(Math.pow(targetPlayer.X - npc.X, 2) + Math.pow(targetPlayer.Y - npc.Y, 2));

      //Make the guide giant and green.

      if (prefix3.Contains("Gunner")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, npcToPlayer, 14, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;
        }
      }
      if (prefix3.Contains("Shotgunning")) {
        const int NumProjectiles = 4; //The humber of projectiles that this gun will shoot.

        if (AITimer % 180 == 0) {

          for (int i = 0; i < NumProjectiles; i++) {
            // Rotate the velocity randomly by 30 degrees at max.
            Vector2 newVelocity = npcToPlayer.RotatedByRandom(MathHelper.ToRadians(15));

            // Decrease velocity randomly for nicer visuals.
            newVelocity *= 1f - Main.rand.NextFloat(0.3f);

            //Create a projectile.
            npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, newVelocity, 14, (int)(npc.damage * 0.7), 2f); //bullet
            Main.projectile[npcProjectile].friendly = false;
            Main.projectile[npcProjectile].hostile = true;
          }
        }
      }
      if (prefix3.Contains("Machine Gunning")) {
        const int NumProjectiles = 4; //The humber of projectiles that this gun will shoot.

        if (AITimer % 30 == 0) {
          Vector2 newVelocity = npcToPlayer.RotatedByRandom(MathHelper.ToRadians(15));

          // Decrease velocity randomly for nicer visuals.
          newVelocity *= 1f - Main.rand.NextFloat(0.3f);

          //Create a projectile.
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, newVelocity, 14, (int)(npc.damage * 0.7), 2f); //bullet
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;

        }
      }
      if (prefix3.Contains("Sniper")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, npcToPlayer, 242, (int)(npc.damage * 1.4), 2f); //bullet high velocity
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;
        }
      }
      if (prefix3.Contains("Volcanic")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.01f, npcToPlayer.Y * 0.01f), 467, (int)(npc.damage * 1.2), 2f);
        }
      }
      if (prefix3.Contains("Umbra")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.01f, npcToPlayer.Y * 0.01f), 468, (int)(npc.damage * 1.2), 2f);
        }
      }
      if (prefix3.Contains("Webbing")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.01f, npcToPlayer.Y * 0.01f), 472, npc.damage, 2f); //bullet

        }
      }
      if (prefix3.Contains("Electric")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 435, (int)(npc.damage * 0.4), 2f);
        }
      }
      if (prefix3.Contains("Rioting")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 399, (int)(npc.damage * 0.9), 2f);
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;
        }
      }
      if (prefix3.Contains("Pirate")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 240, (int)(npc.damage * 1.2), 2f); //bullet

        }
      }
      if (prefix3.Contains("Night Hunter")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 246, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;
        }
      }
      if (prefix3.Contains("Infinite")) {
        if (AITimer % 240 == 0) {
          for (int i = 0; i < 3; i++) {
            Vector2 source2 = new Vector2(targetPlayer.position.X - 50 + (i * 50), targetPlayer.position.Y + 800f);
            Vector2 newVelocity = new Vector2(0, -25f);
            npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), source2, newVelocity, 116, npc.damage, 2f); //bullet
            Main.projectile[npcProjectile].friendly = false;
            Main.projectile[npcProjectile].hostile = true;
          }
        }
      }
      if (prefix3.Contains("Infernal")) {
        if (AITimer % 240 == 0) {
          for (int i = 0; i < 3; i++) {
            Vector2 newVelocity = new Vector2(Main.rand.NextFloat(-15f, 15f), Main.rand.NextFloat(0f, -3f));
            npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, newVelocity, 668, npc.damage, 2f); //bullet
            Main.projectile[npcProjectile].friendly = false;
            Main.projectile[npcProjectile].hostile = true;
          }
        }
      }
      if (prefix3.Contains("Hellish")) {
        if (AITimer % 240 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.01f, npcToPlayer.Y * 0.01f), 291, npc.damage, 2f); //bullet

        }
      }
      if (prefix3.Contains("Vampire Hunter")) {
        if (AITimer % 30 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.05f, npcToPlayer.Y * 0.05f), 304, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;
        }
      }
      if (prefix3.Contains("Cyborg")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.01f, npcToPlayer.Y * 0.01f), 466, npc.damage, 2f); //bullet
        }
      }

      if (prefix3.Contains("Grave Robber")) {
        if (AITimer % 120 == 0) {
          int type = Main.rand.Next(new int[] {
            201,
            202,
            203,
            204,
            205
          });
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.05f, npcToPlayer.Y * 0.05f), type, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].friendly = false;
          Main.projectile[npcProjectile].hostile = true;

        }
      }
      if (prefix3.Contains("Grassy")) {
        if (AITimer % 120 == 0) {
          float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
          float rotation = MathHelper.ToRadians(45);
          Vector2 velocity = npc.velocity;
          // position += Vector2.Normalize(velocity) * 45f;

          for (int i = 0; i < numberProjectiles; i++) {
            Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
            npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, perturbedSpeed, 206, npc.damage, 2f); //
            Main.projectile[npcProjectile].friendly = false;
            Main.projectile[npcProjectile].hostile = true;
          }

        }
      }
      if (prefix3.Contains("Boomerang")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 6, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Peddler")) {
        if (AITimer % 40 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 158, (int) (npc.damage * 0.4), 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Demonic")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 44, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Fungal")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 131, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Fishy")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 190, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Floral")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 221, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Ballistician")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 680, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Hemomancer")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 756, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if (prefix3.Contains("Ninja")) {
        if (AITimer % 120 == 0) {
          npcProjectile = Projectile.NewProjectile(npc.GetProjectileSpawnSource(), npc.position, new Vector2(npcToPlayer.X * 0.1f, npcToPlayer.Y * 0.1f), 3, npc.damage, 2f); //bullet
          Main.projectile[npcProjectile].hostile = true;
          Main.projectile[npcProjectile].friendly = false;

        }
      }
      if(!nameChanged){
        npc.GetGlobalNPC<prefixString>().prefix = npc.GetGlobalNPC<prefixString>().prefix + " " + prefix3;
        nameChanged = true;
    }
    Main.projectile[npcProjectile].netUpdate = true;
    npc.netUpdate = true;




      // 				Projectile.NewProjectile(NPC.GetProjectileSpawnSource(), position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);

      // npc.scale = 1.5f;
      // npc.color = Color.ForestGreen;

    }

    // public override void SendExtraAI(BinaryWriter writer) {
    //   writer.Write(prefix3);
    //   writer.Write(AITimer);
    //   writer.Write(nameChanged);
    //   writer.Write(npcProjectile);
    //
    // }
    //
    // public override void ReceiveExtraAI(BinaryReader reader) {
    //   prefix3 = reader.ReadString();
    //   AITimer = reader.ReadInt();
    //   nameChanged = reader.ReadBoolean();
    //   npcProjectile = reader.ReadInt();
    // }


    // public override void OnKill(NPC npc) {
    //
    // 	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
    //
    // 	//TODO: Add the rest of the vanilla drop rules!!
    // }

  }
}
