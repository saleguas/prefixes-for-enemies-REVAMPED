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

      if(prefix.Contains("Burning")){
        if(Main.rand.Next(3) == 0) // 1 in 2 chance, 50% drop chance
          // don't touch any parameters besides the last 2
          // ItemID.Hellstone means to drop Hellstone, find list of IDS here https://terraria.fandom.com/wiki/Item_IDs
          // Math.rand.Next(1, 10) means that to drop 1-9 hellstne, Math.rand.Next gives a number between(n, n-1)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(1, 10));
      }
			if(prefix.Contains("Mythical")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenHeroSword, 1);
      }
			if(prefix.Contains("Steadfast")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CobaltShield, 1);
      }
			if(prefix.Contains("Juggernaut")){
        if(Main.rand.Next(4) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1);
				if(Main.rand.Next(4) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1);
      }
			if(prefix.Contains("Tough")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1);
      }
			if(prefix.Contains("Sus")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1);
      }
			if(prefix.Contains("Placid")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CalmingPotion, Main.rand.Next(1, 4));
      }
			if(prefix.Contains("Wealthy")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1);
      }
			if(prefix.Contains("Cool")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AviatorSunglasses, 1);
      }
			if(prefix.Contains("Frozen")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1);
				if(Main.rand.Next(2) == 0)
	        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WarmthPotion, Main.rand.Next(1, 4));
      }
			if(prefix.Contains("Dangerous")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AvengerEmblem, 1);
      }
			if(prefix.Contains("Dangerous")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AvengerEmblem, 1);
      }
			if(prefix.Contains("Wing Clipper")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFlight, Main.rand.Next(1, 10));
      }
			if(prefix.Contains("Venemous")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlaskofVenom, Main.rand.Next(1, 4));
      }


			


			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
