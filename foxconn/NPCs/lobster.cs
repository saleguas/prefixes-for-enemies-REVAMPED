using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace foxconn.NPCs
{
    // Party BlueSlime is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class lobster : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;
            DisplayName.SetDefault("FOXCONN 2019 WORKER");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 360;
            NPC.height = 560;
            NPC.scale = 0.05f;
            NPC.damage = 1;
            NPC.defense = 6;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 1; // Fighter AI, important to choose the aiStyle that matches the NPCID that we want to mimic

            AIType = NPCID.BlueSlime; // Use vanilla BlueSlime's type when executing AI code. (This also means it will try to despawn during daytime)
            Banner = Item.NPCtoBanner(NPCID.BlueSlime); // Makes this NPC get affected by the normal BlueSlime banner.
            BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Since Party BlueSlime is essentially just another variation of BlueSlime, we'd like to mimic the BlueSlime drops.
            // To do this, we can either (1) copy the drops from the BlueSlime directly or (2) just recreate the drops in our code.
            // (1) Copying the drops directly means that if Terraria updates and changes the BlueSlime drops, your ModNPC will also inherit the changes automatically.
            // (2) Recreating the drops can give you more control if desired but requires consulting the wiki, bestiary, or source code and then writing drop code.

            // (1) This example shows copying the drops directly. For consistency and mod compatibility, we suggest using the smallest positive NPCID when dealing with npcs with many variants and shared drop pools.
            var BlueSlimeDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.BlueSlime, false); // false is important here
            foreach (var BlueSlimeDropRule in BlueSlimeDropRules)
            {
                // In this foreach loop, we simple add each drop to the PartyBlueSlime drop pool. 
                npcLoot.Add(BlueSlimeDropRule);
            }

            // (2) This example shows recreating the drops. This code is commented out because we are using the previous method instead.
            // npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50)); // Drop shackles with a 1 out of 50 chance.
            // npcLoot.Add(ItemDropRule.Common(ItemID.BlueSlimeArm, 250)); // Drop BlueSlime arm with a 1 out of 250 chance.

            // Finally, we can add additional drops. Many BlueSlime variants have their own unique drops: https://terraria.fandom.com/wiki/BlueSlime
            npcLoot.Add(ItemDropRule.Common(ItemID.Confetti, 100)); // 1% chance to drop Confetti
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.8f; // Spawn with 4/5th the chance of a regular BlueSlime.
        }

        public override void AI()
        {
            // shoot a projectile at the player
            // make velocity player position - npc position normalized * 10

			if (NPC.life < NPC.lifeMax){
				Vector2 velocity = Main.player[NPC.target].position - NPC.position;
				velocity.Normalize();

				// Add randomness to the velocity vector
				float randomMultiplier = Main.rand.NextFloat(0.8f, 1.2f);
				velocity *= randomMultiplier;

				velocity *= 10;

				int a = Projectile.NewProjectile(
					NPC.GetSource_FromAI(), // source
					NPC.position, // position
					velocity, // velocity
					ProjectileID.UnholyTridentHostile, // type
					200, // damage
					10 // knockback
				);
        	}
		}


        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("This type of BlueSlime for some reason really likes to spread confetti around. Otherwise, it behaves just like a normal BlueSlime."),

				// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
				// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
				// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
			});
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            // Spawn confetti when this BlueSlime is hit.

            for (int i = 0; i < 10; i++)
            {
                int dustType = Main.rand.Next(139, 143);
                var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

                dust.velocity.X += Main.rand.NextFloat(-0.05f, 0.05f);
                dust.velocity.Y += Main.rand.NextFloat(-0.05f, 0.05f);

                dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
            }
        }
    }
}
