
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using prefixtest;
using prefixtest.Items.Tokens.tier1.Consumable;
using prefixtest.Items.Tokens.tier1;
using prefixtest.Items.Tokens;
using prefixtest.Items.Tokens.tier2.Consumable;
using prefixtest.Items.Tokens.tier2;
using prefixtest.Items.Tokens.tier3.Consumable;
using prefixtest.Items.Tokens.tier3;
using prefixtest.Items.Tokens.tier4.Consumable;
using prefixtest.Items.Tokens.tier4;
namespace prefixtest.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class chanceseller : ModNPC
	{
		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			DisplayName.SetDefault("The Chancellor");

			Main.npcFrameCount[Type] = 23; // The amount of frames the NPC has

			NPCID.Sets.ExtraFramesCount[Type] = 5; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 3;
			NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 0;
			NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 30;
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

			// Influences how the NPC looks in the Bestiary
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
				// Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
				// If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
		}

		public override void SetDefaults() {
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("A collector obsessed with rare creatures."),

			});
		}

		// The PreDraw hook is useful for drawing things before our sprite is drawn or running code before the sprite is drawn
		// Returning false will allow you to manually draw your NPC
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
			//This code slowly rotates the NPC in the bestiary
			//(simply checking NPC.IsABestiaryIconDummy and incrementing NPC.Rotation won't work here as it gets overridden by drawModifiers.Rotation each tick)
			if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers)) {
                drawModifiers.Rotation += 0.001f;

				// Replace the existing NPCBestiaryDrawModifiers with our new one with an adjusted rotation
				NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			}

			return true;
		}



		public override bool CanTownNPCSpawn(int numTownNPCs, int money) { // Requirements for the town NPC to spawn.
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				// Player has to have either an ExampleItem or an ExampleBlock in order for the NPC to spawn
				if (player.inventory.Any(item => item.type == ModContent.ItemType<soulofchance>() || item.type == ModContent.ItemType<soulshard>())) {
					return true;
				}
			}

			return false;
		}

		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.


		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0: // The cases are potential names for the NPC.
					return "Otto von Bismarck";

				case 1:
					return "Leo von Caprivi";

				case 2:
					return "Julie";

				default:
					return "Arctophile";
			}
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int wizard = NPC.FindFirstNPC(NPCID.Wizard);
			if (wizard >= 0 && Main.rand.NextBool(4)) {
				chat.Add("Can you please tell " + Main.npc[wizard].GivenName + " to get some new clothes? He's totally copying me.");
			}
			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add("You know, if everything was rare, then nothing is rare.");
			chat.Add("Smash your Chance Souls into Soul Shards to buy ammunition from me.");
			chat.Add("Are the Chance Souls the actual souls of organisms? Depends if you'll still give them to me.");
			chat.Add("I love the color gold. And the Material Gold. And the name Gold.", 2);
			chat.Add("Stop whining, monsters are monsters.", 1);
			chat.Add("I was banned from all villages for hunting the other NPCs.");
			chat.Add("Why does the Wizard stay away from me? Where do you think I got my clothes from?.");
			chat.Add("I'm not allowed into Warlock Villages anymore.");

			return chat; // chat is implicitly cast to a string.
		}

		public override void SetChatButtons(ref string button, ref string button2) { // What the chat buttons are when you open up the chat UI
			button = Language.GetTextValue("LegacyInterface.28");

		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.


				shop = true;
			}
		}

		// Not completely finished, but below is what the NPC will sell

		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ModContent.ItemType<hookshot>());
			shop.item[nextSlot].shopCustomPrice = new int?(1);
			shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulShardCurrencyID;
			nextSlot++;


			if (NPC.downedBoss3 || NPC.downedQueenBee)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<shotgunshot>());
				shop.item[nextSlot].shopCustomPrice = new int?(1);
				shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulShardCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<AmethystToken>());
				shop.item[nextSlot].shopCustomPrice = new int?(3);
				shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulCurrencyID;
				nextSlot++;
				}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<slug>());
				shop.item[nextSlot].shopCustomPrice = new int?(1);
				shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulShardCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<TopazToken>());
				shop.item[nextSlot].shopCustomPrice = new int?(3);
				shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulCurrencyID;
				nextSlot++;
			}
			 if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<starshot>());
				shop.item[nextSlot].shopCustomPrice = new int?(1);
				shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulShardCurrencyID;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<SapphireToken>());
				shop.item[nextSlot].shopCustomPrice = new int?(3);
				shop.item[nextSlot].shopSpecialCurrency = prefixtest.soulCurrencyID;
				nextSlot++;
			}



			//prefixtest.soulShardCurrencyID
			//prefixtest.soulCurrencyID

			// if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
				// shop.item[nextSlot++].SetDefaults(ItemType<ExampleHealingPotion>());
			// }

			// if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !GetInstance<ExampleConfigServer>().DisableExampleWings) {
			// 	shop.item[nextSlot].SetDefaults(ItemType<ExampleWings>());
			// 	nextSlot++;
			// }

			// if (Main.moonPhase < 2) {
			// 	shop.item[nextSlot++].SetDefaults(ItemType<ExampleSword>());
			// }
			// else if (Main.moonPhase < 4) {
			// 	// shop.item[nextSlot++].SetDefaults(ItemType<ExampleGun>());
			// 	shop.item[nextSlot].SetDefaults(ItemType<ExampleBullet>());
			// }
			// else if (Main.moonPhase < 6) {
			// 	// shop.item[nextSlot++].SetDefaults(ItemType<ExampleStaff>());
			// }

			// todo: Here is an example of how your npc can sell items from other mods.
			// var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
			// if (modSummonersAssociation != null) {
			// 	shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
			// 	nextSlot++;
			// }

			// if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList != null) {
			// 	foreach (var item in GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList) {
			// 		if (Item.IsUnloaded) continue;
			// 		shop.item[nextSlot].SetDefaults(Item.Type);
			// 		shop.item[nextSlot].shopCustomPrice = 0;
			// 		shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
			// 		nextSlot++;
			// 		// TODO: Have tModLoader handle index issues.
			// 	}
			// }
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot) {
			// Readd this once ExampleCostume is implemented.
			// npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ExampleCostume>(), 1));
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) => true;

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.


		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}

			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		// todo: implement
		// public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
		// 	projType = ProjectileType<SparklingBall>();
		// 	attackDelay = 1;
		// }

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
