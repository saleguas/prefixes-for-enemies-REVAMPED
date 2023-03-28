using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.NPCs;
using luckyblocks.Items.Tokens.tier1;
using luckyblocks.Items.Tokens.tier2;
using luckyblocks.Items.Tokens.tier3;
using luckyblocks.Items.Tokens.tier4;
using luckyblocks.Items.Tokens.tier5;
namespace luckyblocks.Buffs
{
    public class EventFunctions
    {
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*                                                                    GOOD EVENTS                                                                   */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */

        // make function GetRandomArmor that returns a random armor piece
        public void GetLuckyPotion(Player player){
            Main.NewText("Whoop-dee-doo, a brew for you!", Color.Gold);
            // drop 5-10 LuckyPotion 
            int num = Main.rand.Next(5, 10);

            for (int i = 0; i < num; i++)
            {
                Item.NewItem
                (
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    ModContent.ItemType<Items.LuckyPotion>()
                );
            }
        }

        public void GetModdedItem(Player player){
            Main.NewText("An item just fell out of a rift in space and time!", Color.Gold);
            // drop based on the following
            // before skeletron tier1 amethyst token
            // before wall of flesh tier2 topaz token
            // before mechanical bosses tier3 sapphire token
            // before plantera tier4 emerald token
            // after defeating plantera tier5 diamond token
            
            if (NPC.downedPlantBoss){
                Item.NewItem
                (
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    ModContent.ItemType<DiamondToken>()
                );
            }
            else if (NPC.downedMechBossAny){
                Item.NewItem
                (
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    ModContent.ItemType<EmeraldToken>()
                );
            }
            else if (Main.hardMode){
                Item.NewItem
                (
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    ModContent.ItemType<SapphireToken>()
                );
            }
            else if (NPC.downedBoss3){
                Item.NewItem
                (
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    ModContent.ItemType<TopazToken>()
                );
            }
            else{
                Item.NewItem
                (
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    ModContent.ItemType<AmethystToken>()
                );
            }

        }


        public void ConcotionPackage(Player player)
        {
            Main.NewText("The alchemist's newest batch! What did you get?", Color.Gold);

            List<int> potion_ids = new List<int>{
                ItemID.LesserHealingPotion,
                ItemID.LesserManaPotion,
                ItemID.HealingPotion,
                ItemID.ManaPotion,
                ItemID.LesserRestorationPotion,
                ItemID.RestorationPotion,
                ItemID.LesserHealingPotion,
                //all potion buffs as ints
                288, 289, 290, 291, 292, 293, 294,
                295, 296, 297, 298, 299, 300, 301,
                302, 303, 304, 305, 2322, 2323,
                2324, 2325, 2326, 2327, 2328,
                2329, 2344, 2345, 2346, 2347,
                2348, 2349, 2350, 2351, 2352,
                2353, 2354, 2355, 2356, 2359,
                2756, 2997, 4870, 5211,
            
            };

            if (Main.hardMode)
            {
                potion_ids = new List<int>{
                //all potion buffs as ints
                288, 289, 290, 291, 292, 293, 294,
                295, 296, 297, 298, 299, 300, 301,
                302, 303, 304, 305, 2322, 2323,
                2324, 2325, 2326, 2327, 2328,
                2329, 2344, 2345, 2346, 2347,
                2348, 2349, 2350, 2351, 2352,
                2353, 2354, 2355, 2356, 2359,
                2756, 2997, 4870, 5211,
                ItemID.GreaterHealingPotion,
                ItemID.GreaterManaPotion,
                ItemID.SuperHealingPotion,
                };
            }

            int potionCount = Main.rand.Next(5, 11);
        
            for (int i = 0; i < potionCount; i++)
            {
                int randomPotion = Main.rand.Next(potion_ids.Count);
                int potionID = potion_ids[randomPotion];

                // Item.NewItem(
                //     new EntitySource_TileBreak(50, 50),
                //     (int)player.position.X,
                //     (int)player.position.Y,
                //     potionID
                // );
                int item = Item.NewItem(
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    potionID
                );

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item);
                }
            }
        }

        public void GetRandomArmor(Player player)
        {
            Main.NewText("ooh, new shiny!", Color.Green);

            List<int> armorList = new List<int>();

            // Add all the armor sets
            armorList.AddRange(misc_armor);
            armorList.AddRange(magic_armor);
            if (NPC.downedMechBossAny)
            {
                armorList.AddRange(pre_plantera_armor);
            }
            if (NPC.downedPlantBoss)
            {
                armorList.AddRange(post_plantera_armor);
            }
            if (Main.hardMode)
            {
                armorList.AddRange(hardmode_ore_wood_armor);
            }
            armorList.AddRange(pre_hardmode_armor);

            // Pick a random armor piece from the list
            int randomIndex = Main.rand.Next(armorList.Count);
            int randomArmor = armorList[randomIndex];

            int item = Item.NewItem(
                new EntitySource_TileBreak(50, 50),
                player.position,
                Vector2.One * 16,
                randomArmor,
                1,
                false,
                0,
                false,
                false
            );


            NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item);
        }


        public void SpawnRandomItem(Player player)
        {
            // make a list of tuples of all the ranges that are valid

            Main.NewText("It's dangerous to go alone! Take this.", Color.Yellow);

            List<Tuple<int, int>> prehardmode = new List<Tuple<int, int>>{
                new Tuple<int, int>(0, 362),
                new Tuple<int, int>(438, 480),
                // 562 to 669
                new Tuple<int, int>(562, 669),
                // 687 to 774
                new Tuple<int, int>(687, 774),
                // 863 to 896
                new Tuple<int, int>(863, 896),
                // 949 to 981
                new Tuple<int, int>(949, 981),
                // 994 to 1130
                new Tuple<int, int>(994, 1130),
                // 1575 to 1825
                new Tuple<int, int>(1575, 1825),
                // 1837 to 1907
                new Tuple<int, int>(1837, 1907),
            };

            // if it's not hardmode, pick an item from the list
            if (!Main.hardMode)
            {
                int randomIndex = Main.rand.Next(prehardmode.Count);
                Tuple<int, int> range = prehardmode[randomIndex];
                int randomItem = Main.rand.Next(range.Item1, range.Item2);
                // Item.NewItem(player.position, randomItem);
                Item.NewItem(
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    Vector2.One * 16,
                    randomItem,
                    1,
                    false,
                    0,
                    false,
                    false
                );
            }
            else
            {
                // if it's hardmode, pick a random item
                int randomItem = Main.rand.Next(1, 5173 + 1);
                Item.NewItem(
                    new EntitySource_TileBreak(50, 50),
                    player.position,
                    Vector2.One * 16,
                    randomItem,
                    1,
                    false,
                    0,
                    false,
                    false
                );
            }
        }

        //heals all by one
        public void HealByOne(Player player)
        {
            Main.NewText("Everyone is healed by, wait thats it?", Color.Green);

            foreach (Player p in Main.player)
            {
                p.HealEffect(1);
            }

        }

        public void SpawnRichMan(Player player)
        {
            // spawn an NPC that drops a lot of money
            // change it's value

            Main.NewText("A Rich Man is here, Take his money!", Color.Gold);


            int id = NPC.NewNPC(
                new EntitySource_TileBreak(50, 50),
                (int)player.position.X + Main.rand.Next(-1000, 1000),
                (int)player.position.Y - 300,
                NPCID.DemonTaxCollector);

            NPC npc = Main.npc[id];

            npc.value = Main.rand.Next(5000, 85000);

            // give him a permanent buff
            npc.AddBuff(BuffID.Midas, 999999);
        }

        public void HealAllPlayers(Player player)
        {
            Main.NewText("Everyone is healed!", Color.Green);

            foreach (Player p in Main.player)
            {
                p.statLife = p.statLifeMax2;
                p.HealEffect(p.statLifeMax2);
            }
        }

        public void goldenAnimalSplosion(Player player)
        {
            Main.NewText("Golden Animal Galore! Better have a net!", Color.Pink);

            List<int> goldAnimals = new List<int>{
                NPCID.GoldBunny,
                NPCID.GoldBird,
                NPCID.GoldButterfly,
                NPCID.GoldFrog,
                NPCID.GoldGrasshopper,
                NPCID.GoldMouse,
                NPCID.GoldWorm,
                NPCID.SquirrelGold,
                NPCID.GoldDragonfly,
                NPCID.GoldLadyBug,
                NPCID.GoldWaterStrider,
                NPCID.GoldSeahorse,
            };


            //loop to spawn
            for (int i = 0; i < 10; i++)
            {

                int randomGold = Main.rand.Next(goldAnimals.Count);
                int AnimalID = goldAnimals[randomGold];

                NPC.NewNPC(
                    new EntitySource_TileBreak(50, 50),
                     (int)player.position.X + Main.rand.Next(-100, 100),
                    (int)player.position.Y + Main.rand.Next(-200, 0),
                    AnimalID);
            }
        }

        public void bunnySplosion(Player player)
        {
            Main.NewText("Bunnies!", Color.Pink);

            List<int> bunnies = new List<int>{
                NPCID.Bunny,
                NPCID.BunnyXmas,
                NPCID.GemBunnyAmber,
                NPCID.GemBunnyAmethyst,
                NPCID.GemBunnyDiamond,
                NPCID.GemBunnyEmerald,
                NPCID.GemBunnyRuby,
                NPCID.GemBunnySapphire,
                NPCID.GemBunnyTopaz,
                NPCID.GoldBunny,
                NPCID.PartyBunny
            };

            // spawn 10 bunnies
            for (int i = 0; i < 10; i++)
            {
                // randomly pick a bunny from the list
                int randomBunny = Main.rand.Next(bunnies.Count);
                int bunnyID = bunnies[randomBunny];

                NPC.NewNPC(
                    new EntitySource_TileBreak(50, 50),
                     (int)player.position.X + Main.rand.Next(-100, 100),
                    (int)player.position.Y + Main.rand.Next(-200, 0),
                    bunnyID);
            }
        }

        public void MoneySpawn(Player player)
        {

            Main.NewText("Money!", Color.Gold);

            List<int> coin_ids = new List<int>{
                ItemID.CopperCoin,
                ItemID.SilverCoin,
                ItemID.GoldCoin,
            };

            // randomly spawn coins around the player.

            for (int i = 0; i < 100; i++)
            {
                int randomCoin = Main.rand.Next(coin_ids.Count);
                int coinID = coin_ids[randomCoin];

                Item.NewItem(
                    new EntitySource_TileBreak(50, 50),
                    (int)player.position.X + Main.rand.Next(-100, 100),
                    (int)player.position.Y + Main.rand.Next(-200, 0),
                    0,
                    0,
                    coinID
                );
            }
        }

        

        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*                                                                    MISC EVENTS                                                                   */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        public void MakeItSlimeRain(Player player)
        {
            Main.NewText("It's slime raining!", Color.Yellow);

            Main.StartSlimeRain();
        }

        public void MakeItRain(Player player)
        {
            Main.NewText("It's raining!", Color.Green);
            Main.StartRain();
        }

        public void ChangeTime(Player player)
        {
            Main.NewText("The time has changed!", Color.Cyan);

            // pick random number between 1 and 4
            int randomTime = Main.rand.Next(0, 54000);

            Main.time = randomTime;
        }

        public void ScrambleAllLocation(Player player)
        {
            // Everyone has been teleported to a random location on the map.
            Main.NewText("Everyone has been teleported to a random location on the map!", Color.Cyan);

            // make a set to track which players have been teleported
            HashSet<int> teleportedPlayers = new HashSet<int>();

            foreach (Player p in Main.player)
            {
                // make sure player hasnt been teleported yet
                if (teleportedPlayers.Contains(p.whoAmI)) continue;

                // add player to the set
                teleportedPlayers.Add(p.whoAmI);

                // teleport player
                int newX = Main.rand.Next(100, Main.maxTilesX - 200) * 16;
                int newY = Main.rand.Next(100, Main.maxTilesY - 200) * 16;
                p.Teleport(new Vector2(newX, newY));
            }
        }

        public void ScrambleLocation(Player player)
        {
            // Player has been teleported to a random location on the map.
            Main.NewText("You have been teleported to a random location on the map!", Color.Cyan);

            player.Teleport(new Vector2(Main.rand.Next(100, Main.maxTilesX - 200) * 16, Main.rand.Next(100, Main.maxTilesY - 200) * 16));
        }

        public void GiveAllRandomBuff(Player player)
        {
            int maxBuffId = 337;
            int minBuffId = 1;

            // pick a random buff inclusive
            int randomBuff = Main.rand.Next(minBuffId, maxBuffId + 1);

            // pick a random time for the buff, 1 second to 5 minutes

            int randomTime = Main.rand.Next(600, 36000);

            Main.NewText("Everyone has been given a random buff!", Color.Cyan);

            foreach (Player p in Main.player)
            {
                p.AddBuff(randomBuff, randomTime);
            }

        }

        public void GivePlayerRandomBuff(Player player)
        {
            int maxBuffId = 337;
            int minBuffId = 1;

            // pick a random buff inclusive
            int randomBuff = Main.rand.Next(minBuffId, maxBuffId + 1);

            // pick a random time for the buff, 1 second to 5 minutes

            int randomTime = Main.rand.Next(600, 36000);

            Main.NewText(player.name + " has been given a random buff!", Color.Cyan);

            player.AddBuff(randomBuff, randomTime);
        }

        public void SpawnRandomEntity(Player player)
        {
            // spawn a random entity
            int randomEntity = Main.rand.Next(1, 736 + 1);

            Main.NewText("Random Entity!", Color.Cyan);

            NPC.NewNPC(
                new EntitySource_TileBreak(50, 50),
                (int)player.position.X + Main.rand.Next(-100, 100),
                (int)player.position.Y + Main.rand.Next(-200, 0),
                randomEntity
            );
        }
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*                                                                BAD EVENTS                                                               */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */

        // make function SpawnLoser(Player player) which spawns a random modded enemy near the player
        // spawn either lobster, redslime, or zuck
        // ModContent.NPCType<NPCs.lobster
        public void SpawnLoser(Player player){
            Main.NewText("Bruh who invited this dude", Color.Red);

            List<int> loser_ids = new List<int>{
                ModContent.NPCType<NPCs.lobster>(),
                ModContent.NPCType<NPCs.redslime>(),
                ModContent.NPCType<NPCs.zuck>(),
            };

            int randomLoser = Main.rand.Next(loser_ids.Count);
            int loserID = loser_ids[randomLoser];

            NPC.NewNPC(
                new EntitySource_TileBreak(50, 50),
                (int)player.position.X + Main.rand.Next(-500, 500),
                (int)player.position.Y + Main.rand.Next(-200, 0),
                loserID
            );
        }
        public void BoulderfistOgre(Player player)
        {
            Main.NewText("ME HAS GOOD STATS FOR COST", Color.Red);

            NPC.NewNPC(
               new EntitySource_TileBreak(50, 50),
               (int)player.position.X + Main.rand.Next(-100, 100),
               (int)player.position.Y + Main.rand.Next(-50, 0),
               577);

        }

        public void MissileBombardment(Player player)
        {
            Main.NewText("Missiles incoming!", Color.Red);

            for (int i = 0; i < 500; i++)
            {
                Vector2 position = new Vector2(
                    player.position.X + Main.rand.Next(-1000, 1000),
                    player.position.Y + Main.rand.Next(-2000, -1000)
                );

                Vector2 target = player.Center;
                Vector2 heading = target - position;

                heading.Normalize();
                heading *= new Vector2(10f, 10f).Length();
                heading.Y += Main.rand.Next(-40, 41) * 1f;
                heading.X += Main.rand.Next(-5, 5) * 1f;

                int projID = ProjectileID.Celeb2RocketExplosiveLarge;
                int damage = 150;
                float knockback = 5f;

                int a = Projectile.NewProjectile(new EntitySource_TileBreak(50, 50), position, heading, projID, damage, knockback);

                Main.projectile[a].friendly = false;
                Main.projectile[a].hostile = true;
            }
        }

        public void SlowDeath(Player player)
        {
            Main.NewText(player.name + " has eaten the clam chowder from the Toyotathan December to Remember!", Color.Red);

            // give them BuffID.Silenced, Bleeding, Confused, Slow, Horrified, On Fire, Cursed, Darkness, Poisoned, Burning
            List<int> badBuffs = new List<int>{
                BuffID.Silenced,
                BuffID.Bleeding,
                BuffID.Confused,
                BuffID.Slow,
                BuffID.Horrified,
                BuffID.OnFire,
                BuffID.Cursed,
                BuffID.Darkness,
                BuffID.Poisoned,
                BuffID.Burning,
            };

            // add all the bad buffs to the player
            foreach (int buff in badBuffs)
            {
                player.AddBuff(buff, 36000);
            }
        }
        public void MassiveExplosion(Player player)
        {
            Main.NewText("Massive Explosion!", Color.Red);

            // spawn a massive explosion
            int explosionID = Projectile.NewProjectile(
                new EntitySource_TileBreak(50, 50),
                player.position,
                Vector2.One,
                ProjectileID.Explosives,
                100,
                15f
            );

            // get the projectile
            Projectile explosion = Main.projectile[explosionID];

            // set the explosion to be massive
            int radius = Main.rand.Next(50, 100);
            explosion.scale = radius;
            explosion.damage = 1000;
            explosion.knockBack = 100;
            explosion.timeLeft = 1;
            // void Projectile.ExplodeTiles(Vector2 compareSpot, int radius, int minI, int maxI, int minJ, int maxJ, bool wallSplode)

            explosion.ExplodeTiles(explosion.position, radius, 0, Main.maxTilesX, 0, Main.maxTilesY, true);
        }

        public void EveryoneDropMoney(Player player)
        {
            Main.NewText("Everyone has dropped their money!", Color.Gold);

            foreach (Player p in Main.player)
            {
                for (int i = 0; i < 59; i++)
                {
                    if (p.inventory[i].type >= 71 && p.inventory[i].type <= 74)
                    {
                        int num2 = Item.NewItem(p.GetSource_Loot(), (int)p.position.X, (int)p.position.Y, p.width, p.height, p.inventory[i].type, 1, false, 0, false, false);
                        int num3 = (int)(p.inventory[i].stack * .01);
                        num3 = p.inventory[i].stack - num3;
                        p.inventory[i].stack -= num3;
                        if (p.inventory[i].stack <= 0)
                        {
                            p.inventory[i] = new Item();
                        }

                        for (int j = 0; j < num3; j++)
                        {
                            int num4 = Item.NewItem(p.GetSource_Loot(), (int)p.position.X, (int)p.position.Y, p.width, p.height, p.inventory[i].type, 1, false, 0, false, false);
                            Main.item[num4].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.5f;
                            Main.item[num4].velocity.X = (float)Main.rand.Next(-20, 21) * 0.5f;
                            Main.item[num4].noGrabDelay = 100;
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(21, -1, -1, null, num4, 0f, 0f, 0f, 0, 0, 0);
                            }
                            if (i == 58)
                            {
                                Main.mouseItem = p.inventory[i].Clone();
                            }
                        }
                    }
                }
            }
        }

        public void Everyone1hp(Player player)
        {
            Main.NewText("Everyone is at 1 HP!", Color.Red);

            foreach (Player p in Main.player)
            {
                p.statLife = 1;
            }
        }

        public void EveryoneOnFire(Player player)
        {
            Main.NewText("Everyone is on fire!", Color.Red);

            foreach (Player p in Main.player)
            {
                p.AddBuff(BuffID.OnFire, 300);
            }
        }
        public void PlayerCombustion(Player player)
        {
            // player.name
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " has exploded!"), 5000, 0);
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }

            // Loop these functions 3 times.
            for (int i = 0; i < 500; i++)
            {
                Vector2 heading = player.position - new Vector2(0, 1000);

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= new Vector2(10f, 10f).Length();
                heading.Y += Main.rand.Next(-40, 41) * 1f;
                heading.X += Main.rand.Next(-40, 41) * 1f;
                int a =
                    Projectile
                        .NewProjectile(new EntitySource_TileBreak(50, 50),
                        player.position,
                        heading,
                        ProjectileID.CultistBossFireBall, // fire arrow
                        50, // damage
                        5f// knockback
                        );

                Main.projectile[a].friendly = false;
                Main.projectile[a].hostile = true;
            }
        }
        public void ArrowRain(Player player)
        {

            Main.NewText("You hear something in the distance...", Color.Red);
            Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }

            // Loop these functions 3 times.
            for (int i = 0; i < 1500; i++)
            {
                Vector2 position =
                    player.Center -
                    new Vector2(Main.rand.NextFloat(-1000, 1000),
                        Main.rand.NextFloat(500, 2500));
                Vector2 heading = target - position;

                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }

                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }

                heading.Normalize();
                heading *= new Vector2(10f, 10f).Length();
                heading.Y += Main.rand.Next(-40, 41) * 1f;
                heading.X += Main.rand.Next(-5, 5) * 1f;
                int a =
                    Projectile
                        .NewProjectile(new EntitySource_TileBreak(50, 50),
                        position,
                        heading,
                        2, // fire arrow
                        50, // damage
                        5f// knockback
                        );

                Main.projectile[a].friendly = false;
                Main.projectile[a].hostile = true;
            }
        }

        public void MakeInvasionHappen(Player player)
        {
            Main.NewText("You hear footsteps in the distance!", Color.Red);
            // Goblin army is 1
            // Frost legion is 2
            // Pirates is 3
            // Martian madness is 4

            // pick random number between 1 and 4
            int randomInvasion = Main.rand.Next(1, 5);

            Main.StartInvasion(randomInvasion);
        }

        public void SpawnRandomBoss(Player player)
        {
            Main.NewText("An ancient force has awoken!", Color.Red);

            // make a list of integer IDS for all bosses

            List<int> bossList = new List<int>{
                NPCID.KingSlime,
                NPCID.EyeofCthulhu,
                NPCID.EaterofWorldsHead,
                NPCID.BrainofCthulhu,
                NPCID.QueenBee,
                NPCID.SkeletronHead,
                // NPCID.WallofFlesh,
                NPCID.QueenSlimeBoss,
                NPCID.TheDestroyer,
                NPCID.SkeletronPrime,
                NPCID.Retinazer,
                NPCID.Spazmatism,
                NPCID.Deerclops,
                NPCID.Plantera,
                NPCID.Golem,
                NPCID.DukeFishron,
                NPCID.CultistBoss,
                NPCID.MoonLordCore,
            };

            // randomly select an item from the list
            int randomBoss = bossList[Main.rand.Next(bossList.Count)];


            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                // If the player is not in multiplayer, spawn directly
                NPC.SpawnOnPlayer(player.whoAmI, randomBoss);
            }
            else
            {
                // If the player is in multiplayer, request a spawn
                // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in this class above
                NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: randomBoss);
            }
        }


/* ------------------------------------------------------------------------------------------------------------------------------------------------ */
/*                                                               BEGIN LARGE CONSTANTS                                                              */
/* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        private List<int> misc_armor = new List<int>{
            ItemID.EmptyBucket,
            ItemID.Goggles,
            ItemID.DivingHelmet,
            ItemID.NightVisionHelmet,
            ItemID.VikingHelmet,
            ItemID.UltrabrightHelmet,
            ItemID.FlinxFurCoat,
            ItemID.Gi,
            ItemID.MoonLordLegs,
            ItemID.GreenCap
        };

        private List<int> magic_armor = new List<int>{
            ItemID.MagicHat,
            ItemID.WizardHat,
            ItemID.AmethystRobe,
            ItemID.TopazRobe,
            ItemID.SapphireRobe,
            ItemID.EmeraldRobe,
            ItemID.RubyRobe,
            ItemID.AmberRobe,
            ItemID.DiamondRobe,
        };

        private List<int> pre_plantera_armor = new List<int>{
            ItemID.SpiderMask,
            ItemID.SpiderBreastplate,
            ItemID.SpiderGreaves,
            ItemID.FrostHelmet,
            ItemID.FrostBreastplate,
            ItemID.FrostLeggings,
            ItemID.SquireGreatHelm,
            ItemID.SquirePlating,
            ItemID.SquireGreaves,
            ItemID.MonkBrows,
            ItemID.MonkShirt,
            ItemID.MonkPants,
            ItemID.HuntressWig,
            ItemID.HuntressJerkin,
            ItemID.HuntressPants,
            ItemID.ApprenticeHat,
            ItemID.ApprenticeRobe,
            ItemID.ApprenticeTrousers,
            // crystal assasin 4982-4984
            4982,
            4983,
            4984,
        };

        private List<int> post_plantera_armor = new List<int>{
            ItemID.BeetleHelmet,
            ItemID.BeetleScaleMail,
            ItemID.BeetleLeggings,
            ItemID.TikiMask,
            ItemID.TikiShirt,
            ItemID.TikiPants,
            ItemID.ShroomiteHelmet,
            ItemID.ShroomiteBreastplate,
            ItemID.ShroomiteLeggings,
            ItemID.SpectreHood,
            ItemID.SpectreRobe,
            ItemID.SpectrePants,
            ItemID.SpookyHelmet,
            ItemID.SpookyBreastplate,
            ItemID.SpookyLeggings,
        // valhalla 3871-3873
            3871,
            3872,
            3873,
            // shinobi 3880- 3882
            3880,
            3881,
            3882,
            // forbidden set 3776-3778
            3776,
            3777,
            3778,
            // dark artist set 3874-3876
            3874,
            3875,
            3876,
            ItemID.VortexHelmet,
            ItemID.VortexBreastplate,
            ItemID.VortexLeggings,
            ItemID.NebulaHelmet,
            ItemID.NebulaBreastplate,
            ItemID.NebulaLeggings,
            ItemID.StardustHelmet,
            ItemID.StardustBreastplate,
            ItemID.StardustLeggings,
            ItemID.SolarFlareHelmet,
            ItemID.SolarFlareBreastplate,
            ItemID.SolarFlareLeggings
        };


        private List<int> hardmode_ore_wood_armor = new List<int>{
            ItemID.PalladiumHelmet,
            ItemID.PalladiumBreastplate,
            ItemID.PalladiumLeggings,
            ItemID.CobaltHelmet,
            ItemID.CobaltBreastplate,
            ItemID.CobaltLeggings,
            ItemID.MythrilHelmet,
            ItemID.MythrilChainmail,
            ItemID.MythrilGreaves,
            ItemID.OrichalcumHelmet,
            ItemID.OrichalcumBreastplate,
            ItemID.OrichalcumLeggings,
            ItemID.AdamantiteHelmet,
            ItemID.AdamantiteBreastplate,
            ItemID.AdamantiteLeggings,
            ItemID.TitaniumHelmet,
            ItemID.TitaniumBreastplate,
            ItemID.TitaniumLeggings,
            ItemID.HallowedHelmet,
            ItemID.HallowedPlateMail,
            ItemID.HallowedGreaves,
            ItemID.AncientHallowedHelmet,
            ItemID.AncientHallowedPlateMail,
            ItemID.AncientHallowedGreaves,
            ItemID.ChlorophyteHelmet,
            ItemID.ChlorophytePlateMail,
            ItemID.ChlorophyteGreaves,
            ItemID.TurtleHelmet,
            ItemID.TurtleScaleMail,
            ItemID.TurtleLeggings,
            ItemID.PearlwoodHelmet,
            ItemID.PearlwoodBreastplate,
            ItemID.PearlwoodGreaves,
        };


        private List<int> pre_hardmode_armor = new List<int>{
            ItemID.MiningHelmet,
            ItemID.MiningShirt,
            ItemID.MiningPants,
            ItemID.WoodHelmet,
            ItemID.WoodBreastplate,
            ItemID.WoodGreaves,
            ItemID.RichMahoganyHelmet,
            ItemID.RichMahoganyBreastplate,
            ItemID.RichMahoganyGreaves,
            ItemID.BorealWoodHelmet,
            ItemID.BorealWoodBreastplate,
            ItemID.BorealWoodGreaves,
            ItemID.PalmWoodHelmet,
            ItemID.PalmWoodBreastplate,
            ItemID.PalmWoodGreaves,
            ItemID.EbonwoodHelmet,
            ItemID.EbonwoodBreastplate,
            ItemID.EbonwoodGreaves,
            ItemID.ShadewoodHelmet,
            ItemID.ShadewoodBreastplate,
            ItemID.ShadewoodGreaves,
            5279, // ash wood helmet
            5280, // ash wood breastplate
            5281, // ash wood greaves
            ItemID.RainHat,
            ItemID.RainCoat,
            803, // snow hood
            804, // snow coat
            805, // snow pants
            979, // pink snow hood
            980, // pink snow coat
            981, // pink snow pants
            ItemID.AnglerHat,
            ItemID.AnglerVest,
            ItemID.AnglerPants,
            ItemID.CactusHelmet,
            ItemID.CactusBreastplate,
            ItemID.CactusLeggings,
            ItemID.CopperHelmet,
            ItemID.CopperChainmail,
            ItemID.CopperGreaves,
            ItemID.TinHelmet,
            ItemID.TinChainmail,
            ItemID.TinGreaves,
            ItemID.PumpkinHelmet,
            ItemID.PumpkinBreastplate,
            ItemID.PumpkinLeggings,
            ItemID.NinjaHood,
            ItemID.NinjaShirt,
            ItemID.NinjaPants,
            ItemID.IronHelmet,
            ItemID.IronChainmail,
            ItemID.IronGreaves,
            ItemID.LeadHelmet,
            ItemID.LeadChainmail,
            ItemID.LeadGreaves,
            ItemID.SilverHelmet,
            ItemID.SilverChainmail,
            ItemID.SilverGreaves,
            ItemID.TungstenHelmet,
            ItemID.TungstenChainmail,
            ItemID.TungstenGreaves,
            ItemID.GoldHelmet,
            ItemID.GoldChainmail,
            ItemID.GoldGreaves,
            ItemID.PlatinumHelmet,
            ItemID.PlatinumChainmail,
            ItemID.PlatinumGreaves,
            ItemID.FossilHelm,
            ItemID.FossilShirt,
            ItemID.FossilPants,
            ItemID.BeeHeadgear,
            ItemID.BeeBreastplate,
            ItemID.BeeGreaves,
            ItemID.ObsidianHelm,
            ItemID.ObsidianShirt,
            ItemID.ObsidianPants,
            ItemID.GladiatorHelmet,
            ItemID.GladiatorBreastplate,
            ItemID.GladiatorLeggings,
            ItemID.MeteorHelmet,
            ItemID.MeteorSuit,
            ItemID.MeteorLeggings,
            ItemID.JungleHat,
            ItemID.JungleShirt,
            ItemID.JunglePants,
            ItemID.CobaltHelmet,
            ItemID.CobaltBreastplate,
            ItemID.CobaltLeggings,
            ItemID.NecroHelmet,
            ItemID.NecroBreastplate,
            ItemID.NecroGreaves,
            ItemID.ShadowHelmet,
            ItemID.ShadowScalemail,
            ItemID.ShadowGreaves,
            ItemID.AncientShadowHelmet,
            ItemID.AncientShadowScalemail,
            ItemID.AncientShadowGreaves,
            ItemID.CrimsonHelmet,
            ItemID.CrimsonScalemail,
            ItemID.CrimsonGreaves,
            ItemID.MoltenHelmet,
            ItemID.MoltenBreastplate,
            ItemID.MoltenGreaves
        };
    
    // misc_armor
    // magic_armor
    // pre_plantera_armor
    // post_plantera_armor
    // hardmode_ore_wood_armor
    // pre_hardmode_armor
    }
}