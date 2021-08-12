using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using prefixtest.Common.GlobalNPCs;

// I have "random" letters appended to the beginning of each of these files b/c the game reads them in alphabetical order.
// statchanges first, then spceial effects, then projecitles
namespace prefixtest.Common.GlobalNPCs
{
	public class zbLoot : GlobalNPC
	{

		public bool nameChanged = false;
		public override bool InstancePerEntity => true;
    private string prefix = "";


		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
      if (npc.townNPC == true)
        return false;
      return true;
		}



		public override void AI(NPC npc) {
			//Make the guide giant and green.

			// npc.scale = 1.5f;
			// npc.color = Color.ForestGreen;
      prefix = npc.GetGlobalNPC<prefixString>().prefix;
      if (prefix == "")
        return;


      if (!nameChanged){
				npc.GivenName = npc.GetGlobalNPC<prefixString>().prefix = npc.GetGlobalNPC<prefixString>().prefix + " " + npc.FullName;
				nameChanged = true;
			}
		}

		public override void OnKill(NPC npc) {

      prefix = npc.GetGlobalNPC<prefixString>().prefix;
      if (prefix == "")
        return;

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);

			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
