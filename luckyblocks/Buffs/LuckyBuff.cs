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

                // SpawnRandomBoss(player);
                ArrowRain(player);
                bunnySplosion(player);

                player.ClearBuff(ModContent.BuffType<LuckyBuff>());

            }
        }

        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*                                                                    GOOD EVENTS                                                                   */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */

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
                
                NPC.NewNPC(new EntitySource_TileBreak(50, 50), (int)player.position.X, (int)player.position.Y, bunnyID);
            }
        }

        public void MoneyRain(Player player)
        {

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

        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */
        /*                                                                BAD EVENTS                                                               */
        /* ------------------------------------------------------------------------------------------------------------------------------------------------ */

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
            for (int i = 0; i < 1000; i++)
            {
                Vector2 position =
                    player.Center -
                    new Vector2(Main.rand.NextFloat(401) * player.direction,
                        600f);
                position.Y -= 100 * i;
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
                heading *= 1;
                heading.Y += Main.rand.Next(-40, 41) * 1f;
                heading.X += Main.rand.Next(-40, 41) * 1f;
                int a =
                    Projectile
                        .NewProjectile(new EntitySource_TileBreak(50, 50),
                        position,
                        heading,
                        2, // fire arrow
                        50, // damage
                        5f, // knockback
                        player.whoAmI,
                        0f,
                        ceilingLimit);

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
