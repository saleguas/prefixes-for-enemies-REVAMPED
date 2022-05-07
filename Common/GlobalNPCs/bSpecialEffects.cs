using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using prefixtest.Common.GlobalNPCs;

namespace prefixtest.Common.GlobalNPCs
{
	public class bSpecialEffects : GlobalNPC
	{

		public override bool InstancePerEntity => true;
    private string prefix2 = "";
		private int AITimer = 0;
		private bool nameChanged = false;



		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			if (npc.townNPC == true)
				return false;

      Random random = new Random();
      double roll1 = random.NextDouble();
			npc.netUpdate = true;


      return roll1 <= (double) (ModContent.GetInstance<modconfig>().SpecialEffectChance * 0.01);
		}


		public override void SetDefaults(NPC npc)
		{
				// Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
        Random random = new Random();
        int roll2 = random.Next(1, 26); // creates a number from 1 to n-1
        switch (roll2){

          case 1:
            prefix2 = "Burning";
            break;
          case 2:
            prefix2 = "Hellfire";
            break;
          case 3:
            prefix2 = "Frozen";
            break;
          case 4:
            prefix2 = "Electrified";
            break;
          case 5:
            prefix2 = "Breaker";
            npc.scale = 1.5f;
            npc.color = new Color(156, 133, 132, 50);
            break;
          case 6:
            prefix2 = "Dark";
            break;
          case 7:
            prefix2 = "Trickster";
            break;
          case 8:
            prefix2 = "Hexing";
            break;
          case 9:
            prefix2 = "Slowing";
            break;
          case 10:
            prefix2 = "Venomous";
            break;
          case 11:
            prefix2 = "Petrifying";
            npc.color = new Color(173, 168, 168, 100);
            break;
          case 12:
            prefix2 = "Martyr";
            break;
          case 13:
            prefix2 = "Vampiric";
            npc.color = new Color(194, 29, 29, 30);
            break;
          case 14:
            prefix2 = "Magebane";
            break;
          case 15:
            prefix2 = "Voodoo";
            break;
          case 16:
            prefix2 = "Vengeful";
            break;
          case 17:
            prefix2 = "Mutilator";
            break;
          case 18:
            prefix2 = "Executioner";
            break;
          case 19:
            prefix2 = "Splitter";
            break;
          case 20:
            prefix2 = "Stealthy";
            break;
          case 21:
            prefix2 = "Forceful";
            break;
          case 22:
            prefix2 = "Launcher";
            break;
          case 23:
            prefix2 = "Halting";
            break;
          case 24:
            prefix2 = "Wing Clipper";
            break;
          case 25:
            prefix2 = "Cutpurse";
            break;

					// case 26:
					// 	prefix2 = "Teleporting";
					// 	break;
        }
				npc.netUpdate = true;
        npc.value *= 4f;
		}

    public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit){
        if (prefix2.Contains("Burning")){
          target.AddBuff(BuffID.OnFire, 300);
        }

        if (prefix2.Contains("Hellfire"))
          {
              target.AddBuff(BuffID.CursedInferno, 300);
          }

          if (prefix2.Contains("Frozen"))
          {
            target.AddBuff(BuffID.Frostburn, 300);
            if (Main.rand.Next(1, 12) == 1)
              {
                  target.AddBuff(BuffID.Frozen, 120);
              }
          }
					if (prefix2.Contains("Breaker"))
					{
							target.AddBuff(BuffID.BrokenArmor, 600);
					}
					if (prefix2.Contains("Dark"))
					{
							target.AddBuff(BuffID.Darkness, 300);
					}
          if (prefix2.Contains("Electrified"))
          {
              target.AddBuff(BuffID.Electrified, 300);
          }

          if (prefix2.Contains("Trickster"))
          {
              target.AddBuff(BuffID.Confused, 120);
          }
					if (prefix2.Contains("Forceful"))
					{
							if (npc.Center.X <= target.Center.X)
							{
									target.velocity.X += 25;
							}
							else target.velocity.X -= 25;
					}
          if (prefix2.Contains("Hexing"))
          {
              if (Main.rand.Next(0, 3) == 0)
              {
                  target.AddBuff(BuffID.Cursed, 180);
              }
          }
          if (prefix2.Contains("Slowing"))
          {
              target.AddBuff(BuffID.Slow, 300);
          }
          if (prefix2.Contains("Venomous"))
          {
              target.AddBuff(BuffID.Venom, 300);
          }
          if (prefix2.Contains("Petrifying"))
          {
            target.AddBuff(BuffID.Stoned, 180);
          }

          if (prefix2.Contains("Launching"))
          {
              target.velocity.Y -= 45;
          }
					if (prefix2.Contains("Vampiric"))
					{
							npc.life += damage;
							CombatText.NewText(new Rectangle(npc.position.X, npc.position.Y - 50, npc.width, npc.height), new Color(20, 120, 20, 200), "" + damage);
							if (npc.life > npc.lifeMax)
							{
									npc.life = npc.lifeMax;
							}
					}
          if (prefix2.Contains("Halting"))
          {
              target.velocity = Vector2.Zero;
          }
          if (prefix2.Contains("Wing Clipper"))
          {
              target.wingTime = 0;
              target.rocketTime = 0;
          }

          // if (prefix2.Contains("Cutpurse"))
          //   {
          //       for (int i = 0; i < 59; i++)
          //       {
          //           if (target.inventory[i].type >= 71 && target.inventory[i].type <= 74)
          //           {
          //               int num2 = Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, target.inventory[i].type, 1, false, 0, false, false);
          //               int num3 = (int)(target.inventory[i].stack * .9);
          //               num3 = target.inventory[i].stack - num3;
          //               target.inventory[i].stack -= num3;
          //               if (target.inventory[i].stack <= 0)
          //               {
          //                   target.inventory[i] = new Item();
          //               }
          //               Main.item[num2].stack = num3;
          //               Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
          //               Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
          //               Main.item[num2].noGrabDelay = 100;
          //               if (Main.netMode == 1)
          //               {
          //                   NetMessage.SendData(21, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
          //               }
          //               if (i == 58)
          //               {
          //                   Main.mouseItem = target.inventory[i].Clone();
          //               }

          //           }
          //       }
          //     }
							npc.netUpdate = true;

    }


    public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (prefix2.Contains("Magebane"))
            {
                damage += target.statMana / 4;
                target.statMana /= 2;
                CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y - 50, target.width, target.height), new Color(20, 20, 120, 200), "" + target.statMana);
            }
            if (prefix2.Contains("Mutilator"))
            {
                if (target.statLife == target.statLifeMax2)
                {
                    damage *= 2;
                }
            }
            if (prefix2.Contains("Executioner"))
            {
                if (target.statLife <= target.statLifeMax2 / 5)
                {
                    damage *= 2;
                }
            }
            if (prefix2.Contains("Vengeful"))
            {
                damage += (int)((npc.life / (npc.life + npc.lifeMax)) * damage);
            }
        }
		public override void AI(NPC npc) {
			//Make the guide giant and green.
			 AITimer = (AITimer + 1) % 10000;
//if(Main.tile[npc.position.X, npc.position.Y].active()){ do stuff }

			// if (prefix2.Contains("Teleporting"))
			// {
			// 	Player targetPlayer = Main.player[npc.target];
			// 	if (AITimer % 60 == 0){
			// 		int xBound = 10;
			// 		int yBound = 10;
			// 		Vector2 newPos = new Vector2(targetPlayer.position.X + Main.rand.Next(-xBound, xBound), targetPlayer.position.Y + Main.rand.Next(-yBound, yBound));
			// 		Main.NewText($"{npc.position.X}  {npc.position.Y}");
			//
			// 		while (Main.tile[(int)newPos.X, (int)newPos.Y].IsActiveUnactuated && xBound > 0 && yBound > 0){
			// 			xBound -= 1;
			// 			yBound -= 1;
			// 			newPos = new Vector2(targetPlayer.position.X + Main.rand.Next(-xBound, xBound), targetPlayer.position.Y + Main.rand.Next(-yBound, yBound));
			// 		}
			// 		Main.NewText($"{npc.position.X}  {npc.position.Y}");
			// 		npc.position = newPos;
			// 		targetPlayer.position = newPos;
			//
			//
			// 	}
			// }
			if(!nameChanged){
			npc.GetGlobalNPC<prefixString>().prefix = npc.GetGlobalNPC<prefixString>().prefix + " " + prefix2;
			nameChanged = true;
			npc.netUpdate = true;

		}


			// if (!nameChanged){
			// 	string[] names = npc.GivenName.Split(" ");
			// 	npc.GivenName = prefix2 + " " + String.Join(" ", names);
			// 	nameChanged = true;
			// }
			// npc.scale = 1.5f;
			// npc.color = Color.ForestGreen;

		}

		public override void OnKill(NPC npc) {

			if (prefix2.Contains("Splitter"))
            {
                int x = 2 + Main.rand.Next(0, 9);
                for (int i = 0; i < x; i++)
                {
                    int n = NPC.NewNPC(npc.position.X, npc.position.Y, npc.type);
                    Main.npc[n].velocity.X = Main.rand.Next(-3, 4);
                    Main.npc[n].velocity.Y = Main.rand.Next(-3, 4);
                    Main.npc[n].life /= 2;
                    Main.npc[n].scale *= .85f;
                    Main.npc[n].lifeMax /= 2;
                    Main.npc[n].damage = (int)(Main.npc[n].damage * .8);
                }
            }
			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
