using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
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

        private string suffix = "";

        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            if (npc.townNPC == true)
                return false;
            if (npc.friendly == true)
                return false;
            if (npc.boss == true)
                return false;
            if (npc.CountsAsACritter)
                return false;
            return true;
        }

        public override void AI(NPC npc)
        {
            //Make the guide giant and green.
            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
            prefix = npc.GetGlobalNPC<prefixString>().prefix;
            suffix = npc.GetGlobalNPC<prefixString>().suffix;
            if (prefix == "" && suffix == "") return;

            if (!nameChanged)
            {
                npc.GivenName =
                        prefix +
                        " " +
                        npc.FullName +
                        "" +
                        suffix;
                nameChanged = true;
                npc.netUpdate = true;

            }
        }

        public override void OnKill(NPC npc)
        {
            prefix = npc.GetGlobalNPC<prefixString>().prefix;
            suffix = npc.GetGlobalNPC<prefixString>().suffix;
            if (prefix == "")
                return;
            if (npc.value == 0f && npc.npcSlots == 0f)
                return;

            Action<int, int, int> dropItem = (itemId, amount, probability) =>
            {
                if (Main.rand.Next(probability) == 0)
                {
                    // don't touch any parameters besides the last 2
                    // ItemID.Hellstone means to drop Hellstone, find list of IDS here https://terraria.fandom.com/wiki/Item_IDs
                    // Math.rand.Next(1, 10) means that to drop 1-9 hellstne, Math.rand.Next gives a number between(n, n-1)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, itemId, Main.rand.Next(amount, amount + 1));
                }
            };

            // make another anonymous function to calculate a random number between min and max (inclusive)
            Func<int, int, int> randnum = (min, max) =>
            {
                return Main.rand.Next(min, max + 1);
            };

            if (prefix.Contains("Burning"))
            {
                // Item.NewItem(npc.GetSource_Loot(), npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(1, 10));

                dropItem(ItemID.Hellstone, randnum(2, 10), 3);
                dropItem(ItemID.LavaBucket, 1, 3);
                dropItem(ItemID.LavaCharm, 1, 6);
            }
            if (prefix.Contains("Mythical"))
            {
                dropItem(ItemID.BrokenHeroSword, 1, 8);
            }

            if (prefix.Contains("Steadfast"))
            {
                if (NPC.downedBoss3 || NPC.downedQueenBee)
                {
                    dropItem(ItemID.CobaltShield, 1, 8);
                }
            }

            if (prefix.Contains("Juggernaut"))
            {
                if (NPC.downedPlantBoss)
                {
                    dropItem(ItemID.PaladinsShield, 1, 10);
                }
                if (Main.hardMode)
                {
                    dropItem(ItemID.FleshKnuckles, 1, 4);
                }
            }

            if (prefix.Contains("Tough"))
            {
                dropItem(ItemID.Shackle, 1, 3);
            }

            if (prefix.Contains("Sus"))
            {
                dropItem(ItemID.WhoopieCushion, 1, 3);
            }

            if (prefix.Contains("Placid"))
            {
                dropItem(ItemID.CalmingPotion, randnum(1, 4), 2);
            }

            if (prefix.Contains("Wealthy"))
            {
                dropItem(ItemID.MoneyTrough, 1, 2);
            }

            if (prefix.Contains("Cool"))
            {
                dropItem(ItemID.AviatorSunglasses, 1, 2);
            }

            if (prefix.Contains("Frozen"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.FrozenTurtleShell, 1, 3);
                }
                dropItem(ItemID.WarmthPotion, randnum(1, 4), 2);
                dropItem(ItemID.IceBlock, randnum(20, 40), 2);
            }

            if (prefix.Contains("Dangerous"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.AvengerEmblem, 1, 3);
                }
            }

            if (prefix.Contains("Wing Clipper"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.SoulofFlight, randnum(1, 10), 2);
                }
            }

            if (prefix.Contains("Venemous"))
            {
                dropItem(ItemID.FlaskofVenom, randnum(1, 4), 2);
            }
            if (prefix.Contains("Trickster"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.RodofDiscord, 1, 9);
                }
            }

            if (prefix.Contains("Stealthy"))
            {
                dropItem(ItemID.InvisibilityPotion, randnum(1, 4), 2);
            }

            if (prefix.Contains("Magebane"))
            {
                if (Main.rand.Next(3) == 0)
                    dropItem(ItemID.MoonLordLegs, 1, 1);

                dropItem(ItemID.ManaPotion, randnum(4, 9), 2);
            }

            if (prefix.Contains("Voodoo"))
            {
                if (Main.rand.Next(3) == 0)
                    dropItem(ItemID.GuideVoodooDoll, 1, 1);

                if (Main.rand.Next(3) == 0)
                    dropItem(ItemID.ClothierVoodooDoll, 1, 1);
            }

            if (prefix.Contains("Armored"))
            {
                if (Main.rand.Next(3) == 0)
                    dropItem(ItemID.ArmorPolish, 1, 1);

                if (Main.rand.Next(3) == 0)
                    dropItem(ItemID.SharkToothNecklace, 1, 1);
            }

            if (prefix.Contains("Colossal"))
            {
                if (Main.rand.Next(10) == 0)
                    dropItem(ItemID.Gladius, 1, 1);

                if (Main.rand.Next(10) == 0 && Main.hardMode)
                    dropItem(ItemID.BreakerBlade, 1, 1);
            }

            if (prefix.Contains("Enduring"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.IronskinPotion, 1, 3);
                }
            }
            if (prefix.Contains("Wing Clipper"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.SoulofFlight, randnum(1, 4), 2);
                }
            }

            if (prefix.Contains("Hellfire"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.InfernoFork, 1, 8);
                    dropItem(ItemID.InfernoPotion, randnum(1, 3), 4);
                    dropItem(ItemID.Hellstone, randnum(10, 20), 4);
                }
            }
            if (prefix.Contains("Electrified"))
            {
                dropItem(ItemID.Wire, randnum(10, 20), 3);
                dropItem(ItemID.MartianConduitPlating, randnum(10, 20), 3);
            }
            if (prefix.Contains("Dark"))
            {
                dropItem(ItemID.DemonScythe, 1, 10);
                if (Main.hardMode && (NPC.downedBoss3 || NPC.downedQueenBee))
                {
                    dropItem(ItemID.BookofSkulls, 1, 10);
                }
                if (Main.hardMode)
                {
                    dropItem(ItemID.UnholyTrident, 1, 10);
                }
            }

            if (prefix.Contains("Hexing"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.AncientBattleArmorMaterial, 1, 8);
                    dropItem(ItemID.DarkShard, 1, 8);
                    dropItem(ItemID.BandofStarpower, 1, 8);
                }
            }

            if (prefix.Contains("Slowing"))
            {
                dropItem(ItemID.SpikyBall, 1, 8);
                dropItem(ItemID.BallOHurt, 1, 8);
            }

            if (prefix.Contains("Petrifying"))
            {
                dropItem(ItemID.MedusaHead, 1, 6);
                dropItem(ItemID.Marble, randnum(10, 30), 2);
            }

            if (prefix.Contains("Vampiric"))
            {
                dropItem(ItemID.BloodWater, randnum(10, 20), 5);
                if (Main.hardMode)
                {
                    dropItem(ItemID.MoonShell, 1, 5);
                    dropItem(ItemID.MoonStone, 1, 5);
                }
            }

            if (prefix.Contains("Forceful"))
            {
                if (Main.hardMode){
                    dropItem(ItemID.SlapHand, 1, 10); // item, amount, chance
                    dropItem(ItemID.KOCannon, 1, 10);
                    dropItem(ItemID.TurtleShell, randnum(1, 3), 10);
                }
            }
            if (prefix.Contains("Launcher"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.TurtleShell, randnum(1, 3), 4); 
                }
            }
            if (prefix.Contains("Cutpurse"))
            {
                dropItem(ItemID.DiscountCard, 1, 15);
                dropItem(ItemID.LuckyCoin, 1, 15);
            }
            if (prefix.Contains("Shotgunning"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.Shotgun, 1, 10);
                }
                dropItem(ItemID.Boomstick, 1, 4);
            }

            if (prefix.Contains("Volcanic"))
            {
                dropItem(ItemID.Meteorite, randnum(10, 20), 3);

                if (NPC.downedBoss3 || NPC.downedQueenBee)
                {
                    dropItem(ItemID.Flamelash, 1, 6);
                }
                dropItem(ItemID.HellfireArrow, randnum(10, 20), 3);
            }
            if (prefix.Contains("Umbra"))
            {
                if (NPC.downedBoss3 || NPC.downedQueenBee)
                {
                    dropItem(ItemID.DarkLance, 1, 4);
                    dropItem(ItemID.NightsEdge, 1, 8);
                }
                dropItem(ItemID.Deathweed, randnum(1, 5), 2);
            }
            if (prefix.Contains("Webbing"))
            {
                dropItem(ItemID.WebSlinger, 1, 4);
                dropItem(ItemID.Cobweb, randnum(10, 50), 4);
            }
            if (prefix.Contains("Rioting"))
            {
                dropItem(ItemID.MolotovCocktail, randnum(5, 22), 2);
            }
            if (prefix.Contains("Pirate"))
            {
                dropItem(ItemID.Cannonball, randnum(10, 50), 2);
                dropItem(ItemID.Cannon, 1, 5);
                dropItem(ItemID.EyePatch, 1, 3);
            }
            if (prefix.Contains("Night Hunter"))
            {
                dropItem(ItemID.NightOwlPotion, randnum(1, 3), 4);
                dropItem(ItemID.StyngerBolt, 1, 4);
                dropItem(ItemID.BandofStarpower, 1, 4);
            }
            if (prefix.Contains("Infinite"))
            {
                if (NPC.downedMechBossAny)
                    dropItem(ItemID.HallowedBar, randnum(2, 5), 3);

                if (Main.hardMode)
                {
                    dropItem(ItemID.LightShard, 1, 3);
                    dropItem(ItemID.SoulofLight, randnum(2, 5), 3);
                }
            }
            if (prefix.Contains("Infernal"))
            {
                if (Main.hardMode)
                    dropItem(ItemID.HellwingBow, 1, 10);

                dropItem(ItemID.InfernalWispDye, 1, 4);

            }
            if (prefix.Contains("Vampire Hunter"))
            {

                dropItem(ItemID.VampireBanner, 1, 5);
                dropItem(ItemID.VampireMask, 1, 5);
                dropItem(ItemID.VampireShirt, 1, 5);
                dropItem(ItemID.VampirePants, 1, 5);

            }
            if (prefix.Contains("Grave Robber"))
            {
                dropItem(ItemID.RichGravestone1, randnum(2, 5), 5);
                dropItem(ItemID.RichGravestone2, randnum(2, 5), 5);
                dropItem(ItemID.RichGravestone3, randnum(2, 5), 5);
                dropItem(ItemID.RichGravestone4, randnum(2, 5), 5);
                dropItem(ItemID.RichGravestone5, randnum(2, 5), 5);
                dropItem(ItemID.Skull, 1, 5);
                if (Main.hardMode)
                    dropItem(ItemID.Bone, randnum(20, 50), 3);
            }
            if (prefix.Contains("Grassy"))
            {
                dropItem(ItemID.CrimsonSeeds, randnum(2, 5), 4);
                dropItem(ItemID.CorruptSeeds, randnum(2, 5), 4);
                dropItem(ItemID.GrassSeeds, randnum(2, 5), 4);
                dropItem(ItemID.MushroomGrassSeeds, randnum(2, 5), 4);
                dropItem(ItemID.JungleGrassSeeds, randnum(2, 5), 4);
                dropItem(ItemID.HallowedSeeds, randnum(2, 5), 4);

            }
            if (prefix.Contains("Peddler"))
            {
                dropItem(ItemID.CopperCoin, randnum(1, 99), 3);
                dropItem(ModContent.ItemType<peddlersplea>(), 1, 2);

            }
            if (prefix.Contains("Demonic"))
            {
                dropItem(ItemID.DemonScythe, 1, 3);

            }
            if (prefix.Contains("Fungal"))
            {
                dropItem(ItemID.GlowingMushroom, randnum(1, 8), 3);
                if (Main.hardMode)
                    dropItem(ItemID.TruffleWorm, 1, 7); 
            }
            if (prefix.Contains("Fishy"))
            {
                dropItem(ItemID.MasterBait, randnum(1, 3), 3);
                dropItem(ItemID.CratePotion, randnum(1, 3), 3);
                dropItem(ItemID.SonarPotion, randnum(1, 3), 3);
                dropItem(ItemID.FishingPotion, randnum(1, 3), 3);
            }
            if (prefix.Contains("Floral"))
            {
                if (Main.hardMode)
                    dropItem(ItemID.OrichalcumOre, randnum(1, 19), 3);

                    
            }
            if (prefix.Contains("Hemomancer"))
            {
                if (Main.hardMode)
                    dropItem(ItemID.SharpTears, 1, 3);

            }
            if (prefix.Contains("Ninja"))
            {

                dropItem(ItemID.ClimbingClaws, 1, 3);
                dropItem(ItemID.ShoeSpikes, 1, 3);
                dropItem(ItemID.Tabi, 1, 3);
                dropItem(ItemID.BlackBelt, 1, 3);

            }

            if (prefix.Contains("Dweller"))
            {
                dropItem(ItemID.SilverCoin, randnum(1, 99), 3);
                dropItem(ModContent.ItemType<dwellerdelight>(), 1, 2);
            }
            if (prefix.Contains("Rich"))
            {
                dropItem(ItemID.SilverCoin, randnum(1, 10), 3);
                dropItem(ModContent.ItemType<wealthywilt>(), 1, 2);
            }

            /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            /*                                       SUFFIXES START                                                                                             */
            /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            if (suffix.Contains("The Immortal"))
            {
                dropItem(ItemID.LifeCrystal, randnum(1, 4), 3);
                if (NPC.downedPlantBoss)
                    dropItem(ItemID.LifeFruit, randnum(1, 2), 3);
                if (Main.hardMode)
                    dropItem(ItemID.SoulDrain, 1, 3);
                dropItem(ItemID.LifeforcePotion, randnum(1, 3), 3);

            }
            if (suffix.Contains("The Necromancer"))
            {
                dropItem(ItemID.Bone, randnum(10, 40), 3);
                dropItem(ItemID.Skull, 1, 3);
                dropItem(ItemID.SkeletonBow, 1, 3);
                dropItem(ItemID.BookofSkulls, 1, 3);
                if (Main.hardMode)
                    dropItem(ItemID.MechanicalSkull, 1, 3);

            }
            if (suffix.Contains("The Sacrifice"))
            {
                dropItem(ItemID.ClimbingClaws, 1, 3);
            }
            if (suffix.Contains("The Soul Eater"))
            {
                if (Main.hardMode)
                {
                    dropItem(ItemID.SoulofLight, randnum(1, 6), 3);
                    dropItem(ItemID.SoulofNight, randnum(1, 6), 3);
                    dropItem(ItemID.SoulofFlight, randnum(1, 6), 3);
                    if (NPC.downedMechBossAny)
                    {
                        dropItem(ItemID.SoulofFright, randnum(1, 6), 3);
                        dropItem(ItemID.SoulofMight, randnum(1, 6), 3);
                        dropItem(ItemID.SoulofSight, randnum(1, 6), 3);
                    }
                }
            }
            if (suffix.Contains("The Cultist"))
            {

                dropItem(ItemID.IceBlock, randnum(10, 60), 3);
                if (Main.hardMode)
                {
                    dropItem(ItemID.CursedFlames, randnum(1, 6), 3);
                    dropItem(ItemID.Ichor, randnum(1, 6), 3);
                }

                if (NPC.downedPlantBoss)
                {
                    dropItem(ItemID.LunarTabletFragment, randnum(1, 10), 3);
                    dropItem(ItemID.LunarBlockSolar, randnum(1, 10), 3);
                    dropItem(ItemID.LunarBlockVortex, randnum(1, 10), 3);
                    dropItem(ItemID.LunarBlockNebula, randnum(1, 10), 3);
                    dropItem(ItemID.LunarBlockStardust, randnum(1, 10), 3);
                }
            }
            if (suffix.Contains("The Psyker"))
            {
                if (NPC.downedPlantBoss)
                    dropItem(ItemID.Ectoplasm, randnum(1, 10), 3);
            }
            if (suffix.Contains("The Fireborn"))
            {
                if (Main.hardMode)
                    dropItem(ItemID.FireFeather, 1, 3);

                dropItem(ItemID.LivingFlameDye, randnum(1, 2), 3);

                if (NPC.downedQueenBee)
                {
                    dropItem(ItemID.Flamelash, randnum(1, 2), 3);
                    dropItem(ItemID.MagmaStone, randnum(1, 2), 3);
                }

            }
            // see if suffix contains "The Affluent" if so drop modded item "theaffluence"
            if (suffix.Contains("The Affluent"))
            {
                dropItem(ModContent.ItemType<theaffluence>(), 1, 2);
            }

            npc.netUpdate = true;

            /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
            /*                                                                   GENERAL LOOT                                                                   */
            /* ------------------------------------------------------------------------------------------------------------------------------------------------ */

            
            double roll4 = Main.rand.NextDouble();
            int crateType = ItemID.WoodenCrate;
            if (roll4 <= 0.01)
            {
                crateType = ItemID.GoldenCrate;
            }
            else if (roll4 <= 0.15)
            {
                crateType =
                    Main
                        .rand
                        .Next(new int[] {
                            ItemID.JungleFishingCrate,
                            ItemID.FloatingIslandFishingCrate,
                            ItemID.CorruptFishingCrate,
                            ItemID.CrimsonFishingCrate,
                            ItemID.HallowedFishingCrate,
                            ItemID.DungeonFishingCrate,
                            ItemID.FrozenCrate,
                            ItemID.OasisCrate,
                            ItemID.OceanCrate,
                            ItemID.LavaCrate
                        });
            }
            else if (roll4 <= 0.50)
            {
                crateType = ItemID.IronCrate;
            }

            if (Main.hardMode)
            {
                double roll5 = Main.rand.NextDouble();
                int crateTypeHardmode = ItemID.WoodenCrateHard;

                if (roll5 <= 0.01)
                {
                    crateTypeHardmode = ItemID.GoldenCrateHard;
                }
                else if (roll5 <= 0.15)
                {
                    crateTypeHardmode =
                        Main
                            .rand
                            .Next(new int[] {
                                ItemID.JungleFishingCrateHard,
                                ItemID.FloatingIslandFishingCrateHard,
                                ItemID.CorruptFishingCrateHard,
                                ItemID.CrimsonFishingCrateHard,
                                ItemID.HallowedFishingCrateHard,
                                ItemID.DungeonFishingCrateHard,
                                ItemID.FrozenCrateHard,
                                ItemID.OasisCrateHard,
                                ItemID.OceanCrateHard,
                                ItemID.LavaCrateHard
                            });
                }
                else if (roll5 <= 0.50)
                {
                    crateTypeHardmode = ItemID.IronCrateHard;
                }
                crateType =
                    Main.rand.Next(new int[] { crateType, crateTypeHardmode });
            }

            if (Main.rand.Next(11) == 0)
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, crateType, 1);

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<soulofchance>(), 1);
            }
            npc.netUpdate = true;

            if (prefix.Contains("Rare"))
            {
                dropItem(ItemID.DiscountCard, 1, 5);
                dropItem(ItemID.LuckyCoin, 1, 5);
            }

            //TODO: Add the rest of the vanilla drop rules!!
        }
    }
}
