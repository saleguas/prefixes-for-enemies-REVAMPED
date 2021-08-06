using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace prefixtest.Common.GlobalNPCs
{
	public class specialEffects : GlobalNPC
	{

		public bool nameChanged = false;
		public override bool InstancePerEntity => true;
    private string prefix;


		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			if (npc.townNPC == true)
				return false;

      Random random = new Random();
      double roll1 = random.NextDouble();

      return roll1 <= 1;
		}


		public override void SetDefaults(NPC npc)
		{
				// Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
        Random random = new Random();
        int roll2 = random.Next(24, 26); // creates a number from 1 to n-1
        switch (roll2){

          case 1:
            prefix = "Burning";
            break;
          case 2:
            prefix = "Hellfire";
            break;
          case 3:
            prefix = "Frozen";
            break;
          case 4:
            prefix = "Electrified";
            break;
          case 5:
            prefix = "Breaker";
            break;
          case 6:
            prefix = "Dark";
            break;
          case 7:
            prefix = "Trickster";
            break;
          case 8:
            prefix = "Hexing";
            break;
          case 9:
            prefix = "Slowing";
            break;
          case 10:
            prefix = "Venomous";
            break;
          case 11:
            prefix = "Petrifying";
            break;
          case 12:
            prefix = "Martyr";
            break;
          case 13:
            prefix = "Vampiric";
            break;
          case 14:
            prefix = "Magebane";
            break;
          case 15:
            prefix = "Voodoo";
            break;
          case 16:
            prefix = "Vengeful";
            break;
          case 17:
            prefix = "Mutilator";
            break;
          case 18:
            prefix = "Executioner";
            break;
          case 19:
            prefix = "Splitter";
            break;
          case 20:
            prefix = "Stealthy";
            break;
          case 21:
            prefix = "Forceful";
            break;
          case 22:
            prefix = "Launcher";
            break;
          case 23:
            prefix = "Halting";
            break;
          case 24:
            prefix = "Wing Clipper";
            break;
          case 25:
            prefix = "Cutpurse";
            break;
        }
        npc.value *= 4f;
		}

    public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit){
        if (prefix.Contains("Burning")){
          target.AddBuff(BuffID.OnFire, 300);
        }

        if (prefix.Contains("Hellfire"))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }

          if (prefix.Contains("Frozen"))
          {
              target.AddBuff(BuffID.Frostburn, 300);
              if (Main.rand.Next(1, 12) == 1)
              {
                  target.AddBuff(BuffID.Frozen, 120);
              }
          }
          if (prefix.Contains("Electrified"))
          {
              target.AddBuff(BuffID.Electrified, 300);
          }
          if (prefix.Contains("Breaker"))
          {
              target.AddBuff(BuffID.BrokenArmor, 600);
          }
          if (prefix.Contains("Dark"))
          {
              target.AddBuff(BuffID.Darkness, 300);
          }
          if (prefix.Contains("Trickster"))
          {
              target.AddBuff(BuffID.Confused, 120);
          }
          if (prefix.Contains("Hexing"))
          {
              if (Main.rand.Next(0, 3) == 0)
              {
                  target.AddBuff(BuffID.Cursed, 180);
              }
          }
          if (prefix.Contains("Slowing"))
          {
              target.AddBuff(BuffID.Slow, 300);
          }
          if (prefix.Contains("Venomous"))
          {
              target.AddBuff(BuffID.Venom, 300);
          }
          if (prefix.Contains("Petrifying"))
          {
              if (Main.rand.Next(0, 3) == 0 && target.FindBuffIndex(BuffID.Stoned) == -1)
              {
                  target.AddBuff(BuffID.Stoned, 180);
              }
          }
          if (prefix.Contains("Forceful"))
          {
              if (npc.Center.X <= target.Center.X)
              {
                  target.velocity.X += 15;
              }
              else target.velocity.X -= 15;
          }
          if (prefix.Contains("Launching"))
          {
              target.velocity.Y -= 25;
          }
          if (prefix.Contains("Halting"))
          {
              target.velocity = Vector2.Zero;
          }
          if (prefix.Contains("Wing Clipper"))
          {
              target.wingTime = 0;
              target.rocketTime = 0;
          }
          if (prefix.Contains("Vampiric"))
          {
              npc.life += damage;
              CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y - 50, npc.width, npc.height), new Color(20, 120, 20, 200), "" + damage);
              if (npc.life > npc.lifeMax)
              {
                  npc.life = npc.lifeMax;
              }
          }
          if (prefix.Contains("Cutpurse"))
            {
                for (int i = 0; i < 59; i++)
                {
                    if (target.inventory[i].type >= 71 && target.inventory[i].type <= 74)
                    {
                        int num2 = Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, target.inventory[i].type, 1, false, 0, false, false);
                        int num3 = (int)(target.inventory[i].stack * .9);
                        num3 = target.inventory[i].stack - num3;
                        target.inventory[i].stack -= num3;
                        if (target.inventory[i].stack <= 0)
                        {
                            target.inventory[i] = new Item();
                        }
                        Main.item[num2].stack = num3;
                        Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                        Main.item[num2].noGrabDelay = 100;
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(21, -1, -1, null, num2, 0f, 0f, 0f, 0, 0, 0);
                        }
                        if (i == 58)
                        {
                            Main.mouseItem = target.inventory[i].Clone();
                        }
                    }
                }
              }

    }


    public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            if (prefix.Contains("Magebane"))
            {
                damage += target.statMana / 4;
                target.statMana /= 2;
                CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y - 50, target.width, target.height), new Color(20, 20, 120, 200), "" + target.statMana);
            }
            if (prefix.Contains("Mutilator"))
            {
                if (target.statLife == target.statLifeMax2)
                {
                    damage *= 2;
                }
            }
            if (prefix.Contains("Executioner"))
            {
                if (target.statLife <= target.statLifeMax2 / 5)
                {
                    damage *= 2;
                }
            }
            if (prefix.Contains("Vengeful"))
            {
                damage += (int)((npc.life / (npc.life + npc.lifeMax)) * damage);
            }
        }

    public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            //base.AI(npc); why is this here?
            if (prefix.Contains("Burning"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(20) == 0)
                {
                    int dust = Dust.NewDust(npc.position, npc.width + 4, npc.height + 4, 127, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2f);
                }
            }
          }
		public override void AI(NPC npc) {
			//Make the guide giant and green.
			if (!nameChanged){
				npc.GivenName = prefix + " " + npc.FullName;
				nameChanged = true;
			}
			// npc.scale = 1.5f;
			// npc.color = Color.ForestGreen;

		}

		public override void OnKill(NPC npc) {

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);

			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
