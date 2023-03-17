using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace luckyblocks.Buffs
{
    public class LuckyBuff : ModBuff
    {

        private int timer = 300; // 300 frames = 5 seconds

        private List<Tuple<Action<Player>, int>> weightedFunctions;

        public LuckyBuff()
        {
            weightedFunctions = new List<Tuple<Action<Player>, int>>{
                new Tuple<Action<Player>, int>(SpawnRichMan, 2),
                new Tuple<Action<Player>, int>(HealAllPlayers, 3),
                new Tuple<Action<Player>, int>(bunnySplosion, 2),
                new Tuple<Action<Player>, int>(MoneySpawn, 3),
                new Tuple<Action<Player>, int>(MakeItSlimeRain, 2),
                new Tuple<Action<Player>, int>(MakeItRain, 2),
                new Tuple<Action<Player>, int>(ChangeTime, 2),
                new Tuple<Action<Player>, int>(ScrambleAllLocation, 1),
                new Tuple<Action<Player>, int>(ScrambleLocation, 2),
                new Tuple<Action<Player>, int>(MassiveExplosion, 2),
                new Tuple<Action<Player>, int>(EveryoneDropMoney, 2),
                new Tuple<Action<Player>, int>(Everyone1hp, 1),
                new Tuple<Action<Player>, int>(EveryoneOnFire, 2),
                new Tuple<Action<Player>, int>(PlayerCombustion, 1),
                new Tuple<Action<Player>, int>(ArrowRain, 1),
                new Tuple<Action<Player>, int>(MakeInvasionHappen, 1),
                new Tuple<Action<Player>, int>(SpawnRandomBoss, 1),
                new Tuple<Action<Player>, int>(MassiveExplosion, 1),
                new Tuple<Action<Player>, int>(GiveAllRandomBuff, 1),
                new Tuple<Action<Player>, int>(GivePlayerRandomBuff, 2),
                new Tuple<Action<Player>, int>(SpawnRandomItem, 3),
                new Tuple<Action<Player>, int>(SpawnRandomEntity, 3),
                new Tuple<Action<Player>, int>(MissileBombardment, 1),
                new Tuple<Action<Player>, int>(SlowDeath, 3),


            };
        }

        public void ExecuteRandomFunction(Player player)
        {
            int totalWeight = 0;
            foreach (var weightedFunction in weightedFunctions)
            {
                totalWeight += weightedFunction.Item2;
            }

            int randomWeight = Main.rand.Next(totalWeight);
            int currentWeight = 0;

            foreach (var weightedFunction in weightedFunctions)
            {
                currentWeight += weightedFunction.Item2;
                if (randomWeight < currentWeight)
                {
                    weightedFunction.Item1(player);
                    break;
                }
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lucky?");
            Description.SetDefault("Something is about to happen...");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            timer--;

            if (timer <= 0)
            {
                timer = 300; // Reset the timer to 300 when the dust is inactive

                string test = "";
                if (test != "")
                {
                    MissileBombardment(player);
                }
                else
                {
                    ExecuteRandomFunction(player);
                }


                player.ClearBuff(ModContent.BuffType<LuckyBuff>());

            }


            // draw gold dust around the player

            for (int i = 0; i < 12; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                // the dust is drawn as a rectangle starting at 0,0 with a width and height of 30,30
                // we need to offset the position by half the width and height to center the dust 
                Vector2 dust_pos = player.position;
                Dust d = Dust.NewDustDirect(dust_pos, player.width, player.height, DustID.IchorTorch);
                d.noGravity = true;
                // GemTopaz
            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*                                                                    GOOD EVENTS                                                                   */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        public void SpawnRandomItem(Player player){
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
                int newX = Main.rand.Next(0, Main.maxTilesX - 200) * 16;
                int newY = Main.rand.Next(0, Main.maxTilesY - 200) * 16;
                p.Teleport(new Vector2(newX, newY));
            }
        }

        public void ScrambleLocation(Player player)
        {
            // Player has been teleported to a random location on the map.
            Main.NewText("You have been teleported to a random location on the map!", Color.Cyan);

            player.Teleport(new Vector2(Main.rand.Next(0, Main.maxTilesX) * 16, Main.rand.Next(0, Main.maxTilesY * 16) * 16));
        }

        public void GiveAllRandomBuff(Player player){
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

        public void GivePlayerRandomBuff(Player player){
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
            int randomEntity = Main.rand.Next(1,736 + 1);

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

        public void SlowDeath(Player player){
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
            foreach (int buff in badBuffs){
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
    }
}