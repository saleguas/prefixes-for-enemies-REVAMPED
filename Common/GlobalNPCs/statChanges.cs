using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace prefixtest.Common.GlobalNPCs
{
	public class statChanges : GlobalNPC
	{

		public bool nameChanged = false;
		public override bool InstancePerEntity => true;
    private string prefix;


		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			if (npc.townNPC == true)
				return false;

      Random random = new Random();
      double roll1 = random.NextDouble();

      return roll1 <= 0.25;
		}


		public override void SetDefaults(NPC npc)
		{
				// Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
        Random random = new Random();
        int roll2 = random.Next(11, 12); // creates a number from 1 to n-1
        switch (roll2){

          case 1:
            prefix = "Tough";
            npc.life = npc.lifeMax = (int) (npc.lifeMax * 1.5);
            break;
          case 2:
            prefix = "Dangerous";
            npc.damage = (int) (npc.damage * 1.4);
            break;
          case 3:
            prefix = "Armored";
            npc.defense = (int) (npc.defense * 1.5 + 4);
            break;
          case 4:
            prefix = "Small";
            float sizeRoll = random.Next(5, 8) * 0.1f;
            npc.scale *= sizeRoll;
            npc.damage = (int) (npc.damage * sizeRoll);
            break;
          case 5:
            prefix = "Large";
            sizeRoll = random.Next(11, 15) * 0.1f;
            npc.scale *= sizeRoll;
            npc.damage = (int) (npc.damage * sizeRoll);
            break;
          case 6:
            prefix = "Miniature";
            sizeRoll = random.Next(1, 5) * 0.1f;
            npc.scale *= sizeRoll;
            npc.damage = (int) (npc.damage * sizeRoll);
            npc.life = npc.lifeMax = (int) (npc.lifeMax * sizeRoll);

            break;
          case 7:
            prefix = "Colossal";
            sizeRoll = random.Next(16, 25) * 0.1f;
            npc.scale *= sizeRoll;
            npc.damage = (int) (npc.damage * sizeRoll);
            npc.life = npc.lifeMax = (int) (npc.lifeMax * sizeRoll);
            break;
          case 8:
            prefix = "Toughened";
            npc.defense = (int) (npc.defense * 2.5);
            break;
          case 9:
            prefix = "Enduring";
            npc.takenDamageMultiplier *= .8f;
            break;
          case 10:
            prefix = "Steadfast";
            npc.knockBackResist = 0f;
            break;
          case 11:
            prefix = "Wealthy";
            npc.value *= 10f;
            break;
        }
        npc.value *= 2f;


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
