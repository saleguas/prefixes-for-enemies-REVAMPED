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
            if (npc.townNPC == true || npc.friendly == true) return false;
            return true;
        }

        public override void AI(NPC npc)
        {
            //Make the guide giant and green.
            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
            prefix = npc.GetGlobalNPC<prefixString>().prefix;
            suffix = npc.GetGlobalNPC<prefixString>().suffix;
            if (prefix == "" && suffix=="") return;

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
            if (prefix == "") return;

            if (npc.value == 0f && npc.npcSlots == 0f)
            {
                return;
            }

            if (prefix.Contains("Burning"))
            {
                // Item.NewItem(npc.GetSource_Loot(), npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(1, 10));

                if (
                    Main.rand.Next(3) == 0 // 1 in 2 chance, 50% drop chance
                )
                    // don't touch any parameters besides the last 2
                    // ItemID.Hellstone means to drop Hellstone, find list of IDS here https://terraria.fandom.com/wiki/Item_IDs
                    // Math.rand.Next(1, 10) means that to drop 1-9 hellstne, Math.rand.Next gives a number between(n, n-1)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(1, 10));
                // new CommonDrop(ItemID.Hellstone, 1, 1, 1, 10);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaBucket, Main.rand.Next(1, 10));
                // new CommonDrop(ItemID.LavaBucket, 1, 1, 1, 10);
                if (Main.rand.Next(8) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LavaCharm, 1);
                // new CommonDrop(ItemID.LavaCharm, 1, 1, 1, 1);
            }
            if (prefix.Contains("Mythical"))
            {
                if (Main.rand.Next(8) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BrokenHeroSword, 1);
                // new CommonDrop(ItemID.BrokenHeroSword, 1, 1, 1, 1);
            }
            if (prefix.Contains("Steadfast"))
            {
                if (NPC.downedBoss3 || NPC.downedQueenBee)
                {
                    if (Main.rand.Next(8) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CobaltShield, 1);
                    // new CommonDrop(ItemID.CobaltShield, 1, 1, 1, 1);
                }
            }
            if (prefix.Contains("Juggernaut"))
            {
                if (NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(10) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.PaladinsShield, 1);
                    // new CommonDrop(ItemID.PaladinsShield, 1, 1, 1, 1);
                }
                if (Main.hardMode)
                {
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FleshKnuckles, 1);
                    // new CommonDrop(ItemID.FleshKnuckles, 1, 1, 1, 1);
                }
            }
            if (prefix.Contains("Tough"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shackle, 1);
                // new CommonDrop(ItemID.Shackle, 1, 1, 1, 1);
            }
            if (prefix.Contains("Sus"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WhoopieCushion, 1);
                // new CommonDrop(ItemID.WhoopieCushion, 1, 1, 1, 1);
            }
            if (prefix.Contains("Placid"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CalmingPotion, Main.rand.Next(1, 4));
                // new CommonDrop(ItemID.CalmingPotion, 1, 1, 1, 4);
            }
            if (prefix.Contains("Wealthy"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoneyTrough, 1);
                // new CommonDrop(ItemID.MoneyTrough, 1, 1, 1, 1);
            }
            if (prefix.Contains("Cool"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AviatorSunglasses, 1);
                // new CommonDrop(ItemID.AviatorSunglasses, 1, 1, 1, 1);
            }
            if (prefix.Contains("Frozen"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FrozenTurtleShell, 1);
                    // new CommonDrop(ItemID.FrozenTurtleShell, 1, 1, 1, 1);
                }
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WarmthPotion, Main.rand.Next(1, 4));
                // new CommonDrop(ItemID.WarmthPotion, 1, 1, 1, 4);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(20, 40));
                // new CommonDrop(ItemID.IceBlock, 1, 1, 20, 40);
            }
            if (prefix.Contains("Dangerous"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AvengerEmblem, 1);
                    // new CommonDrop(ItemID.AvengerEmblem, 1, 1, 1, 1);
                }
            }
            if (prefix.Contains("Wing Clipper"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(2) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFlight, Main.rand.Next(1, 10));
                    // new CommonDrop(ItemID.SoulofFlight, 1, 1, 1, 10);
                }
            }
            if (prefix.Contains("Venemous"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FlaskofVenom, Main.rand.Next(1, 4));
                // new CommonDrop(ItemID.FlaskofVenom, 1, 1, 1, 4);
            }
            if (prefix.Contains("Trickster"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(9) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RodofDiscord, 1);
                    // new CommonDrop(ItemID.RodofDiscord, 1, 1, 1, 1);
                }
            }
            if (prefix.Contains("Stealthy"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InvisibilityPotion, Main.rand.Next(1, 4));
                // new CommonDrop(ItemID.InvisibilityPotion, 1, 1, 1, 4);
            }
            if (prefix.Contains("Magebane"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonLordLegs, 1);
                // new CommonDrop(ItemID.MoonLordLegs, 1, 1, 1, 1);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ManaPotion, Main.rand.Next(4, 9));
                // new CommonDrop(ItemID.ManaPotion, 1, 1, 4, 9);
            }
            if (prefix.Contains("Voodoo"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GuideVoodooDoll, 1);
                // new CommonDrop(ItemID.GuideVoodooDoll, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClothierVoodooDoll, 1);
                // new CommonDrop(ItemID.ClothierVoodooDoll, 1, 1, 1, 1);
            }

            //
            if (prefix.Contains("Armored"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ArmorPolish, 1);
                // new CommonDrop(ItemID.ArmorPolish, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SharkToothNecklace, 1);
                // new CommonDrop(ItemID.SharkToothNecklace, 1, 1, 1, 1);
            }
            if (prefix.Contains("Colossal"))
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gladius, 1);
                // new CommonDrop(ItemID.Gladius, 1, 1, 1, 1);
                if (Main.rand.Next(10) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BreakerBlade, 1);
                // new CommonDrop(ItemID.BreakerBlade, 1, 1, 1, 1);
            }
            if (prefix.Contains("Enduring"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronskinPotion, 1);
                    // new CommonDrop(ItemID.IronskinPotion, 1, 1, 1, 4);
                }
            }
            if (prefix.Contains("Wing Clipper"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(2) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFlight, Main.rand.Next(1, 4));
                    // new CommonDrop(ItemID.SoulofFlight, 1, 1, 1, 4);
                }
            }

            if (prefix.Contains("Hellfire"))
            {
                if (Main.rand.Next(8) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InfernoFork, 1);
                // new CommonDrop(ItemID.InfernoFork, 1, 1, 1, 1);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InfernoPotion, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.InfernoPotion, 1, 1, 1, 3);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Hellstone, Main.rand.Next(10, 20));
                // new CommonDrop(ItemID.Hellstone, 1, 1, 10, 20);
            }
            if (prefix.Contains("Electrified"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wire, Main.rand.Next(10, 20));
                // new CommonDrop(ItemID.Wire, 1, 1, 10, 20);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MartianConduitPlating, Main.rand.Next(10, 20));
                // new CommonDrop(ItemID.MartianConduitPlating, 1, 1, 10, 20);
            }
            if (prefix.Contains("Dark"))
            {
                if (Main.rand.Next(10) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1);
                // new CommonDrop(ItemID.DemonScythe, 1, 1, 1, 1);
                if (
                    Main.rand.Next(10) == 0 &&
                    (NPC.downedBoss3 || NPC.downedQueenBee)
                )
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1);
                // new CommonDrop(ItemID.BookofSkulls, 1, 1, 1, 1);
                if (Main.rand.Next(10) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.UnholyTrident, 1);
                // new CommonDrop(ItemID.UnholyTrident, 1, 1, 1, 1);
            }
            if (prefix.Contains("Hexing"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(8) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.AncientBattleArmorMaterial, 1);
                    // new CommonDrop(ItemID.AncientBattleArmorMaterial,
                    // 1,
                    // 1,
                    // 1,
                    // 1);
                    if (Main.rand.Next(8) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkShard, 1);
                    // new CommonDrop(ItemID.DarkShard, 1, 1, 1, 1);
                    if (Main.rand.Next(8) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofStarpower, 1);
                    // new CommonDrop(ItemID.BandofStarpower, 1, 1, 1, 1);
                }
            }
            if (prefix.Contains("Slowing"))
            {
                if (Main.rand.Next(8) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SpikyBall, 1);
                // new CommonDrop(ItemID.SpikyBall, 1, 1, 10, 20);
                if (Main.rand.Next(8) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BallOHurt, 1);
                // new CommonDrop(ItemID.BallOHurt, 1, 1, 1, 1);
            }

            if (prefix.Contains("Petrifying"))
            {
                if (Main.rand.Next(6) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MedusaHead, 1);
                // new CommonDrop(ItemID.MedusaHead, 1, 1, 1, 1);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Marble, Main.rand.Next(10, 30));
                // new CommonDrop(ItemID.Marble, 1, 1, 10, 30);
            }
            if (prefix.Contains("Vampiric"))
            {
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BloodWater, Main.rand.Next(10, 20));
                // new CommonDrop(ItemID.BloodWater, 1, 1, 10, 20);
                if (Main.rand.Next(5) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonShell, 1);
                // new CommonDrop(ItemID.MoonShell, 1, 1, 1, 1);
                if (Main.rand.Next(5) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MoonStone, 1);
                // new CommonDrop(ItemID.MoonStone, 1, 1, 1, 1);
            }
            if (prefix.Contains("Forceful"))
            {
                if (Main.rand.Next(10) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SlapHand, 1);
                // new CommonDrop(ItemID.SlapHand, 1, 1, 1, 1);
                if (Main.rand.Next(10) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.KOCannon, 1);
                // new CommonDrop(ItemID.KOCannon, 1, 1, 1, 1);
                if (Main.rand.Next(4) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.KOCannon, 1, 1, 1, 3);
            }
            if (prefix.Contains("Launcher"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(4) == 0 && Main.hardMode)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TurtleShell, Main.rand.Next(1, 3));
                    // new CommonDrop(ItemID.TurtleShell, 1, 1, 1, 3);
                }
            }
            if (prefix.Contains("Cutpurse"))
            {
                if (Main.rand.Next(15) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1);
                // new CommonDrop(ItemID.DiscountCard, 1, 1, 1, 1);
                if (Main.rand.Next(15) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1);
                // new CommonDrop(ItemID.LuckyCoin, 1, 1, 1, 1);
            }
            if (prefix.Contains("Shotgunning"))
            {
                if (Main.rand.Next(9) == 0 && NPC.downedPlantBoss)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Shotgun, 1);
                // new CommonDrop(ItemID.Shotgun, 1, 1, 1, 1);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Boomstick, 1);
                // new CommonDrop(ItemID.Boomstick, 1, 1, 1, 1);
            }
            if (prefix.Contains("Volcanic"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Meteorite, Main.rand.Next(10, 20));
                // new CommonDrop(ItemID.Meteorite, 1, 1, 10, 20);
                if (
                    Main.rand.Next(6) == 0 && NPC.downedBoss3 ||
                    NPC.downedQueenBee
                )
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Flamelash, 1);
                // new CommonDrop(ItemID.Flamelash, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HellfireArrow, Main.rand.Next(10, 20));
                // new CommonDrop(ItemID.HellfireArrow, 1, 1, 10, 20);
            }
            if (prefix.Contains("Umbra"))
            {
                if (
                    Main.rand.Next(4) == 0 && NPC.downedBoss3 ||
                    NPC.downedQueenBee
                )
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DarkLance, 1);
                // new CommonDrop(ItemID.DarkLance, 1, 1, 1, 1);
                if (
                    Main.rand.Next(8) == 0 && NPC.downedBoss3 ||
                    NPC.downedQueenBee
                )
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NightsEdge, 1);
                // new CommonDrop(ItemID.NightsEdge, 1, 1, 1, 1);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Deathweed, Main.rand.Next(1, 5));
                // new CommonDrop(ItemID.Deathweed, 1, 1, 1, 5);
            }
            if (prefix.Contains("Webbing"))
            {
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.WebSlinger, 1);
                // new CommonDrop(ItemID.WebSlinger, 1, 1, 1, 1);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cobweb, Main.rand.Next(10, 50));
                // new CommonDrop(ItemID.WebSlinger, 1, 1, 10, 50);
            }
            if (prefix.Contains("Rioting"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MolotovCocktail, Main.rand.Next(5, 22));
                // new CommonDrop(ItemID.MolotovCocktail, 1, 1, 5, 22);
            }
            if (prefix.Contains("Pirate"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cannonball, Main.rand.Next(10, 50));
                // new CommonDrop(ItemID.Cannonball, 1, 1, 10, 50);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Cannon, 1);
                // new CommonDrop(ItemID.Cannon, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.EyePatch, 1);
                // new CommonDrop(ItemID.EyePatch, 1, 1, 1, 1);
            }
            if (prefix.Contains("Night Hunter"))
            {
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.NightOwlPotion, 3);
                // new CommonDrop(ItemID.NightOwlPotion, 1, 1, 1, 3);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.StyngerBolt, 1);
                // new CommonDrop(ItemID.StyngerBolt, 1, 1, 1, 1);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BandofStarpower, 1);
            }
            if (prefix.Contains("Infinite"))
            {
                if (Main.rand.Next(3) == 0 && NPC.downedMechBossAny)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HallowedBar, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.HallowedBar, 1, 1, 2, 5);
                if (Main.rand.Next(3) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LightShard, 1);
                // new CommonDrop(ItemID.LightShard, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.SoulofLight, 1, 1, 2, 5);
            }
            if (prefix.Contains("Infernal"))
            {
                if (Main.rand.Next(10) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HellwingBow, 1);
                // new CommonDrop(ItemID.HellwingBow, 1, 1, 1, 1);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.InfernalWispDye, 1);
                // new CommonDrop(ItemID.InfernalWispDye, 1, 1, 1, 1);
            }
            if (prefix.Contains("Vampire Hunter"))
            {
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireBanner, 1);
                // new CommonDrop(ItemID.VampireBanner, 1, 1, 1, 1);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireMask, 1);
                // new CommonDrop(ItemID.VampireMask, 1, 1, 1, 1);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampireShirt, 1);
                // new CommonDrop(ItemID.VampireShirt, 1, 1, 1, 1);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.VampirePants, 1);
                // new CommonDrop(ItemID.VampirePants, 1, 1, 1, 1);
            }
            if (prefix.Contains("Grave Robber"))
            {
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone1, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.RichGravestone1, 1, 1, 2, 5);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone2, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.RichGravestone2, 1, 1, 2, 5);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone3, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.RichGravestone3, 1, 1, 2, 5);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone4, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.RichGravestone4, 1, 1, 2, 5);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.RichGravestone5, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.RichGravestone5, 1, 1, 2, 5);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1);
                // new CommonDrop(ItemID.Skull, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, Main.rand.Next(20, 50));
                // new CommonDrop(ItemID.Bone, 1, 1, 20, 50);
            }
            if (prefix.Contains("Grassy"))
            {
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CrimsonSeeds, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.CrimsonSeeds, 1, 1, 2, 5);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CorruptSeeds, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.CorruptSeeds, 1, 1, 2, 5);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GrassSeeds, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.GrassSeeds, 1, 1, 2, 5);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MushroomGrassSeeds, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.MushroomGrassSeeds, 1, 1, 2, 5);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JungleGrassSeeds, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.JungleGrassSeeds, 1, 1, 2, 5);
                if (Main.rand.Next(4) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HallowedSeeds, Main.rand.Next(2, 5));
                // new CommonDrop(ItemID.HallowedSeeds, 1, 1, 2, 5);
            }
            if (prefix.Contains("Peddler"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(1, 99));
                // new CommonDrop(ItemID.CopperCoin, 1, 1, 1, 99);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<peddlersplea>(), 1);
                // new CommonDrop(ModContent.ItemType<peddlersplea>(),
                // 1,
                // 1,
                // 1,
                // 1);
            }
            if (prefix.Contains("Demonic"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DemonScythe, 1);
                // new CommonDrop(ItemID.DemonScythe, 1, 1, 1, 1);
            }
            if (prefix.Contains("Fungal"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GlowingMushroom, Main.rand.Next(1, 8));
                // new CommonDrop(ItemID.GlowingMushroom, 1, 1, 1, 8);
                if (Main.rand.Next(7) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.TruffleWorm, 1);
                // new CommonDrop(ItemID.TruffleWorm, 1, 1, 1, 1);
            }
            if (prefix.Contains("Fishy"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MasterBait, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.MasterBait, 1, 1, 1, 3);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CratePotion, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.CratePotion, 1, 1, 1, 3);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SonarPotion, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.SonarPotion, 1, 1, 1, 3);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FishingPotion, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.FishingPotion, 1, 1, 1, 3);
            }
            if (prefix.Contains("Floral"))
            {
                if (Main.rand.Next(3) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.OrichalcumOre, Main.rand.Next(1, 19));
                // new CommonDrop(ItemID.OrichalcumOre, 1, 1, 1, 19);
            }
            if (prefix.Contains("Hemomancer"))
            {
                if (Main.rand.Next(3) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SharpTears, 1);
                // new CommonDrop(ItemID.SharpTears, 1, 1, 1, 1);
            }
            if (prefix.Contains("Ninja"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClimbingClaws, 1);
                // new CommonDrop(ItemID.ClimbingClaws, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ShoeSpikes, 1);
                // new CommonDrop(ItemID.ShoeSpikes, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Tabi, 1);
                // new CommonDrop(ItemID.Tabi, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackBelt, 1);
                // new CommonDrop(ItemID.BlackBelt, 1, 1, 1, 1);
            }

            if (prefix.Contains("Dweller"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(1, 99));
                // new CommonDrop(ItemID.CopperCoin, 1, 1, 1, 99);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<dwellerdelight>(), 1);
            }
            if (prefix.Contains("Rich"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(1, 10));
                // new CommonDrop(ItemID.CopperCoin, 1, 1, 1, 99);
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<wealthywilt>(), 1);
            }

            // SUFFIXES START *****************************************************
            if (suffix.Contains("The Immortal"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeCrystal, Main.rand.Next(1, 4));
                // new CommonDrop(ItemID.LifeCrystal, 1, 1, 1, 4);
                if (NPC.downedPlantBoss)
                    if (Main.rand.Next(2) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeFruit, Main.rand.Next(1, 2));
                // new CommonDrop(ItemID.LifeFruit, 1, 1, 1, 2);
                if (Main.hardMode)
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulDrain, 1);
                // new CommonDrop(ItemID.SoulDrain, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LifeforcePotion, Main.rand.Next(1, 3));
                // new CommonDrop(ItemID.LifeforcePotion, 1, 1, 1, 3);
            }
            if (suffix.Contains("The Necromancer"))
            {
                if (Main.rand.Next(2) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, Main.rand.Next(10, 40));
                // new CommonDrop(ItemID.Bone, 1, 1, 10, 40);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Skull, 1);
                // new CommonDrop(ItemID.Skull, 1, 1, 1, 1);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SkeletonBow, 1);
                // new CommonDrop(ItemID.SkeletonBow, 1, 1, 1, 1);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BookofSkulls, 1);
                // new CommonDrop(ItemID.BookofSkulls, 1, 1, 1, 1);
                if (Main.hardMode)
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MechanicalSkull, 1);
                // new CommonDrop(ItemID.MechanicalSkull, 1, 1, 1, 1);
            }
            if (suffix.Contains("The Sacrifice"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ClimbingClaws, 1);
            }
            if (suffix.Contains("The Soul Eater"))
            {
                if (Main.hardMode)
                {
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofLight, Main.rand.Next(1, 6));
                    // new CommonDrop(ItemID.SoulofLight, 1, 1, 1, 6);
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofNight, Main.rand.Next(1, 6));
                    // new CommonDrop(ItemID.SoulofNight, 1, 1, 1, 6);
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFlight, Main.rand.Next(1, 6));
                    // new CommonDrop(ItemID.SoulofFlight, 1, 1, 1, 6);
                    if (NPC.downedMechBossAny)
                    {
                        if (Main.rand.Next(5) == 0)
                            Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFright, Main.rand.Next(1, 6));
                        // new CommonDrop(ItemID.SoulofFright, 1, 1, 1, 6);
                        if (Main.rand.Next(5) == 0)
                            Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofMight, Main.rand.Next(1, 6));
                        // new CommonDrop(ItemID.SoulofMight, 1, 1, 1, 6);
                        if (Main.rand.Next(5) == 0)
                            Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofSight, Main.rand.Next(1, 6));
                        // new CommonDrop(ItemID.SoulofSight, 1, 1, 1, 6);
                    }
                }
            }
            if (suffix.Contains("The Cultist"))
            {
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IceBlock, Main.rand.Next(10, 60));
                // new CommonDrop(ItemID.IceBlock, 1, 1, 10, 60);
                if (Main.hardMode)
                {
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CursedFlames, Main.rand.Next(1, 6));
                    // new CommonDrop(ItemID.CursedFlames, 1, 1, 1, 6);
                    if (Main.rand.Next(4) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Ichor, Main.rand.Next(1, 6));
                    // new CommonDrop(ItemID.Ichor, 1, 1, 1, 6);
                }
                if (NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarTabletFragment, Main.rand.Next(1, 10));
                    // new CommonDrop(ItemID.LunarTabletFragment, 1, 1, 1, 10);
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarBlockSolar, Main.rand.Next(1, 10));
                    // new CommonDrop(ItemID.LunarBlockSolar, 1, 1, 1, 10);
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarBlockVortex, Main.rand.Next(1, 10));
                    // new CommonDrop(ItemID.LunarBlockVortex, 1, 1, 1, 10);
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarBlockNebula, Main.rand.Next(1, 10));
                    // new CommonDrop(ItemID.LunarBlockNebula, 1, 1, 1, 10);
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LunarBlockStardust, Main.rand.Next(1, 10));
                    // new CommonDrop(ItemID.LunarBlockStardust, 1, 1, 1, 10);
                }
            }
            if (suffix.Contains("The Psyker"))
            {
                if (Main.rand.Next(3) == 0 && NPC.downedPlantBoss)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Ectoplasm, Main.rand.Next(1, 10));
                // new CommonDrop(ItemID.Ectoplasm, 1, 1, 1, 10);
            }
            if (suffix.Contains("The Fireborn"))
            {
                if (Main.rand.Next(5) == 0 && Main.hardMode)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.FireFeather, 1);
                // new CommonDrop(ItemID.FireFeather, 1, 1, 1, 1);
                if (Main.rand.Next(3) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LivingFlameDye, Main.rand.Next(1, 2));
                // new CommonDrop(ItemID.LivingFlameDye, 1, 1, 1, 2);
                if (NPC.downedQueenBee)
                {
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Flamelash, Main.rand.Next(1, 2));
                    // new CommonDrop(ItemID.Flamelash, 1, 1, 1, 2);
                    if (Main.rand.Next(3) == 0)
                        Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.MagmaStone, Main.rand.Next(1, 2));
                    // new CommonDrop(ItemID.MagmaStone, 1, 1, 1, 2);
                }
            }
            // see if suffix contains "The Affluent" if so drop modded item "theaffluence"
            if (suffix.Contains("The Affluent"))
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<theaffluence>(), 1);
            }

            npc.netUpdate = true;

            // general loot
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
            // new CommonDrop(crateType, 1, 1, 1, 1);

            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<soulofchance>(), 1);
                // new CommonDrop(ModContent.ItemType<soulofchance>(), 1, 1, 1, 1);
            }
            npc.netUpdate = true;

            if (prefix.Contains("Rare"))
            {
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.DiscountCard, 1);
                if (Main.rand.Next(5) == 0)
                    Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LuckyCoin, 1);
            }

            //TODO: Add the rest of the vanilla drop rules!!
        }
    }
}
