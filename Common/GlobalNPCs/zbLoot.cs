using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using prefixtest.Common.GlobalNPCs;
using prefixtest.Items.MobDrops;
using prefixtest.Items.Tokens;
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
      if (npc.townNPC == true || npc.friendly == true)
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
				npc.GivenName = npc.GetGlobalNPC<prefixString>().prefix = npc.GetGlobalNPC<prefixString>().prefix + " " + npc.FullName + " " + npc.GetGlobalNPC<prefixString>().suffix;
				nameChanged = true;
			}
		}

		public override void OnKill(NPC npc) {

      prefix = npc.GetGlobalNPC<prefixString>().prefix;
      if (prefix == "")
        return;

			if(npc.value == 0f && npc.npcSlots == 0f){
				return;
			}

      if(prefix.Contains("Burning")){
        if(Main.rand.Next(3) == 0) // 1 in 2 chance, 50% drop chance
          // don't touch any parameters besides the last 2
          // ItemID.Hellstone means to drop Hellstone, find list of IDS here https://terraria.fandom.com/wiki/Item_IDs
          // Math.rand.Next(1, 10) means that to drop 1-9 hellstne, Math.rand.Next gives a number between(n, n-1)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(1, 10));
        if(Main.rand.Next(2) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaBucket, Main.rand.Next(1, 10));
        if(Main.rand.Next(8) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaCharm, 1);

      }
			if(prefix.Contains("Mythical")){
        if(Main.rand.Next(8) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenHeroSword, 1);
      }
			if(prefix.Contains("Steadfast")){
        if (NPC.downedBoss3 || NPC.downedQueenBee){
          if(Main.rand.Next(8) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CobaltShield, 1);
          }
      }
			if(prefix.Contains("Juggernaut")){
        if(NPC.downedPlantBoss){
        if(Main.rand.Next(10) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1);
        }
        if(Main.hardMode){
    				if(Main.rand.Next(4) == 0)
    					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1);
          }
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
        if(Main.hardMode){
          if(Main.rand.Next(3) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1);
          }
				if(Main.rand.Next(2) == 0)
	        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WarmthPotion, Main.rand.Next(1, 4));
        if(Main.rand.Next(2) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(20, 40));
      }
			if(prefix.Contains("Dangerous")){
        if(Main.hardMode){
          if(Main.rand.Next(3) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AvengerEmblem, 1);
          }
      }
			if(prefix.Contains("Wing Clipper")){
        if(Main.hardMode){
          if(Main.rand.Next(2) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFlight, Main.rand.Next(1, 10));
          }
      }
			if(prefix.Contains("Venemous")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlaskofVenom, Main.rand.Next(1, 4));
      }
			if(prefix.Contains("Trickster")){
        if(Main.hardMode){
          if(Main.rand.Next(9) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1);
          }
      }
			if(prefix.Contains("Stealthy")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InvisibilityPotion, Main.rand.Next(1, 4));
      }
			if(prefix.Contains("Magebane")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonLordLegs, 1);
        if(Main.rand.Next(2) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ManaPotion, Main.rand.Next(4, 9));
      }
			if(prefix.Contains("Voodoo")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GuideVoodooDoll, 1);
        if(Main.rand.Next(3) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1);
      }

      //

      if(prefix.Contains("Armored")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1);
        if(Main.rand.Next(3) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SharkToothNecklace, 1);

      }
			if(prefix.Contains("Colossal")){
        if(Main.rand.Next(10) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gladius, 1);
        if(Main.rand.Next(10) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BreakerBlade, 1);

      }
			if(prefix.Contains("Enduring")){
        if(Main.hardMode){
          if(Main.rand.Next(3) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronskinPotion, 1);
          }
      }
			if(prefix.Contains("Wing Clipper")){
        if(Main.hardMode){
          if(Main.rand.Next(2) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFlight, Main.rand.Next(1, 4));
          }
      }


			if(prefix.Contains("Hellfire")){
        if(Main.rand.Next(8) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InfernoFork, 1);
        if(Main.rand.Next(4) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InfernoPotion, Main.rand.Next(1, 3));
        if(Main.rand.Next(4) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(10, 20));

      }
			if(prefix.Contains("Electrified")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wire, Main.rand.Next(10, 20));
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MartianConduitPlating, Main.rand.Next(10, 20));

      }
			if(prefix.Contains("Dark")){
        if(Main.rand.Next(10) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1);
        if(Main.rand.Next(10) == 0 && (NPC.downedBoss3 || NPC.downedQueenBee))
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1);
        if(Main.rand.Next(10) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnholyTrident, 1);

      }
			if(prefix.Contains("Hexing")){
        if(Main.hardMode){
          if(Main.rand.Next(8) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientBattleArmorMaterial, 1);
          if(Main.rand.Next(8) == 0)
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1);
          if(Main.rand.Next(8) == 0)
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofStarpower, 1);
        }
      }
			if(prefix.Contains("Slowing")){
        if(Main.rand.Next(8) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SpikyBall, 1);
        if(Main.rand.Next(8) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BallOHurt, 1);
      }




      if(prefix.Contains("Petrifying")){
      	if(Main.rand.Next(6) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MedusaHead, 1);
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marble, Main.rand.Next(10, 30));

      }
			if(prefix.Contains("Vampiric")){
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodWater, Main.rand.Next(10, 20));
        if(Main.rand.Next(5) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonShell, 1);
        if(Main.rand.Next(5) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1);

      }
			if(prefix.Contains("Forceful")){
        if(Main.rand.Next(10) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlapHand, 1);
        if(Main.rand.Next(10) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1);
        if(Main.rand.Next(4) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, Main.rand.Next(1, 3));

      }
			if(prefix.Contains("Launcher")){
        if(Main.hardMode){
          if(Main.rand.Next(4) == 0 && Main.hardMode)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, Main.rand.Next(1, 3));
        }
      }
			if(prefix.Contains("Cutpurse")){
        if(Main.rand.Next(15) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1);
				if(Main.rand.Next(15) == 0)
	        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1);
      }
      if(prefix.Contains("Shotgunning")){
        if(Main.rand.Next(9) == 0 && NPC.downedPlantBoss)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shotgun, 1);
        if(Main.rand.Next(4) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Boomstick, 1);

      }
			if(prefix.Contains("Volcanic")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, Main.rand.Next(10, 20));
        if(Main.rand.Next(6) == 0 && NPC.downedBoss3 || NPC.downedQueenBee)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Flamelash, 1);
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HellfireArrow, Main.rand.Next(10, 20));

      }
			if(prefix.Contains("Umbra")){
        if(Main.rand.Next(4) == 0 && NPC.downedBoss3 || NPC.downedQueenBee)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkLance, 1);
        if(Main.rand.Next(8) == 0 && NPC.downedBoss3 || NPC.downedQueenBee)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NightsEdge, 1);
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Deathweed, Main.rand.Next(1, 5));

      }
			if(prefix.Contains("Webbing")){
          if(Main.rand.Next(4) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WebSlinger, 1);
          if(Main.rand.Next(4) == 0)
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cobweb, Main.rand.Next(10, 50));

      }
			if(prefix.Contains("Rioting")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MolotovCocktail, Main.rand.Next(5, 22));
      }
      if(prefix.Contains("Pirate")){
        if(Main.rand.Next(2) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cannonball, Main.rand.Next(10, 50));
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cannon, 1);
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyePatch, 1);

      }
			if(prefix.Contains("Night Hunter")){
          if(Main.rand.Next(4) == 0)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NightOwlPotion, 3);
          if(Main.rand.Next(4) == 0)
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StyngerBolt, 1);
          // if(Main.rand.Next(4) == 0)
          //   Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofStarpower, 1);
      }
			if(prefix.Contains("Infinite")){
        if(Main.rand.Next(3) == 0 && NPC.downedMechBossAny)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HallowedBar, Main.rand.Next(2, 5));
        if(Main.rand.Next(3) == 0 && Main.hardMode)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1);
        if(Main.rand.Next(3) == 0 && Main.hardMode)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, Main.rand.Next(2, 5));
      }
      if(prefix.Contains("Infernal")){
        if(Main.rand.Next(10) == 0 && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HellwingBow, 1);
        if(Main.rand.Next(4) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InfernalWispDye, 1);
      }
			if(prefix.Contains("Vampire Hunter")){
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireBanner, 1);
        if(Main.rand.Next(5) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireMask, 1);
        if(Main.rand.Next(5) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireShirt, 1);
        if(Main.rand.Next(5) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampirePants, 1);

      }
      if(prefix.Contains("Grave Robber")){
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone1, Main.rand.Next(2, 5));
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone2, Main.rand.Next(2, 5));
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone3, Main.rand.Next(2, 5));
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone4, Main.rand.Next(2, 5));
        if(Main.rand.Next(5) == 0 )
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone5, Main.rand.Next(2, 5));
        if(Main.rand.Next(5) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1);
        if(Main.rand.Next(3) == 0 && Main.hardMode)
          	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, Main.rand.Next(20, 50));

      }
			if(prefix.Contains("Grassy")){
        if(Main.rand.Next(4) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrimsonSeeds, Main.rand.Next(2, 5));
        if(Main.rand.Next(4) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CorruptSeeds, Main.rand.Next(2, 5));
        if(Main.rand.Next(4) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GrassSeeds, Main.rand.Next(2, 5));
        if(Main.rand.Next(4) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MushroomGrassSeeds, Main.rand.Next(2, 5));
        if(Main.rand.Next(4) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JungleGrassSeeds, Main.rand.Next(2, 5));
        if(Main.rand.Next(4) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HallowedSeeds, Main.rand.Next(2, 5));

      }
			if(prefix.Contains("Peddler")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(1, 99));
        if(Main.rand.Next(2) == 0)
          Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<peddlersplea>(), 1);
      }
			if(prefix.Contains("Demonic")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1);
      }
			if(prefix.Contains("Fungal")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GlowingMushroom, Main.rand.Next(1, 8));
				if(Main.rand.Next(7) == 0 && Main.hardMode)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TruffleWorm, 1);
      }
			if(prefix.Contains("Fishy")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MasterBait, Main.rand.Next(1,3));
				if(Main.rand.Next(3) == 0)
	       	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CratePotion, Main.rand.Next(1,3));
				if(Main.rand.Next(3) == 0)
	       	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SonarPotion, Main.rand.Next(1,3));
				if(Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishingPotion, Main.rand.Next(1,3));
      }
			if(prefix.Contains("Floral")){
        if(Main.rand.Next(3) == 0  && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.OrichalcumOre, Main.rand.Next(1,19));
      }
			if(prefix.Contains("Hemomancer")){
        if(Main.rand.Next(3) == 0  && Main.hardMode)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SharpTears, 1);
      }
			if(prefix.Contains("Ninja")){
        if(Main.rand.Next(3) == 0)
        	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClimbingClaws, 1);
				if(Main.rand.Next(3) == 0)
	       	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ShoeSpikes, 1);
				if(Main.rand.Next(3) == 0)
	       	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1);
				if(Main.rand.Next(3) == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1);
      }

      // general loot

      double roll4 = Main.rand.NextDouble();
      int crateType = ItemID.WoodenCrate;
      if (roll4 <= 0.01){
        crateType = ItemID.GoldenCrate;
      }
      else if(roll4 <= 0.15){
        crateType = Main.rand.Next(new int[] { ItemID.JungleFishingCrate, ItemID.FloatingIslandFishingCrate, ItemID.CorruptFishingCrate, ItemID.CrimsonFishingCrate, ItemID.HallowedFishingCrate, ItemID.DungeonFishingCrate, ItemID.FrozenCrate, ItemID.OasisCrate, ItemID.OceanCrate, ItemID.LavaCrate });
      }
      else if(roll4 <= 0.50){
        crateType = ItemID.IronCrate;
      }

      if(Main.hardMode){
        double roll5 = Main.rand.NextDouble();
        int crateTypeHardmode = ItemID.WoodenCrateHard;

        if (roll5 <= 0.01){
          crateTypeHardmode = ItemID.GoldenCrateHard;
        }
        else if(roll5 <= 0.15){
          crateTypeHardmode = Main.rand.Next(new int[] { ItemID.JungleFishingCrateHard, ItemID.FloatingIslandFishingCrateHard, ItemID.CorruptFishingCrateHard, ItemID.CrimsonFishingCrateHard, ItemID.HallowedFishingCrateHard, ItemID.DungeonFishingCrateHard, ItemID.FrozenCrateHard, ItemID.OasisCrateHard, ItemID.OceanCrateHard, ItemID.LavaCrateHard });
        }
        else if(roll5 <= 0.50){
          crateTypeHardmode = ItemID.IronCrateHard;
        }
        crateType = Main.rand.Next(new int[] { crateType, crateTypeHardmode });
      }

      if(Main.rand.Next(11) == 0)
        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, crateType, 1);

			if(Main.rand.Next(10) == 0){
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<soulofchance>(), 1);

			}
			npc.netUpdate = true;











			// if(prefix.Contains("Rare")){
      //   if(Main.rand.Next(5) == 0)
      //   	Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1);
			// 	if(Main.rand.Next(5) == 0)
	    //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1);
      // }




			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
