using System;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using prefixtest.Common.GlobalNPCs;

namespace prefixtest.Common.GlobalNPCs
{
    public class dSuffixes : GlobalNPC
    {

        private List<string> pre_skeletron_suffixes = new List<string>{
                "The Immortal",
                "The Necromancer",
                "The Psyker",
                "The Soul Eater",
        };
        private List<string> pre_wof_suffixes = new List<string>
        {
        };
        private List<string> pre_golem_suffixes = new List<string>{
                "The Cultist",
                "The Sacrifice",
                "The Fireborn",
                "The Affluent"
        };
        private List<string> pre_moonlord_suffixes = new List<string>
        {
        };
        public override bool InstancePerEntity => true;

        private string suffix1 = "";

        private bool nameChanged = false;

        private int lives = 10;

        private int AITimer = 0;

        private int floatTimer = 0;

        private int explosionTimer = 0;

        private List<Player> floating = new List<Player>();

        private bool statsChanged = false;


        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            if (npc.townNPC == true || npc.friendly == true) return false;

            Random random = new Random();
            double roll1 = random.NextDouble();
            npc.netUpdate = true;
            

            return roll1 <=
            (double)(ModContent.GetInstance<modconfig>().SuffixChance * 0.01);
        }

        public override void SetDefaults(NPC npc)
        {
            // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
            List<string> suffixes = new List<string>();
            suffixes.AddRange(pre_skeletron_suffixes);
            if (NPC.downedBoss3)
            {
                suffixes.AddRange(pre_wof_suffixes);
            }
            if (Main.hardMode)
            {
                suffixes.AddRange(pre_golem_suffixes);
            }
            if (NPC.downedGolemBoss)
            {
                suffixes.AddRange(pre_moonlord_suffixes);
            }

            Random random = new Random();
            // make a List of all the prefixes

            suffix1 = suffixes[random.Next(suffixes.Count)];

            // suffix1 = "The Affluent";
            npc.value *= 4f;
        }

        public override void AI(NPC npc)
        {
            AITimer = (AITimer + 1) % 10000;

            //Make the guide giant and green.
            Player targetPlayer = Main.player[npc.target];
            Vector2 npcToPlayer = targetPlayer.position - npc.position;
            if (suffix1.Contains("The Necromancer") && npc.value != 0)
            {
                if (AITimer % 300 == 0)
                {
                    int x = Main.rand.Next(1, 5);
                    for (int i = 0; i < x; i++)
                    {
                        int summonType =
                            Main
                                .rand
                                .Next(new int[] {
                                    3,
                                    21,
                                    201,
                                    202,
                                    203,
                                    449,
                                    450,
                                    451,
                                    452
                                });

                        int n =
                            NPC
                                .NewNPC(npc.GetSource_FromAI(),
                                (int)npc.position.X +
                                Main.rand.Next(-300, 300),
                                (int)npc.position.Y - 100,
                                summonType,
                                npc.whoAmI);
                        Main.npc[n].value = 0;
                        npc.netUpdate = true;
                    }
                }
            }

            if (suffix1.Contains("The Sacrifice"))
            {
                if (AITimer % 1200 == 0)
                {
                    int n =
                        NPC
                            .NewNPC(npc.GetSource_FromAI(),
                            (int)npc.position.X,
                            (int)npc.position.Y,
                            454,
                            npc.whoAmI);
                    if (!NPC.downedPlantBoss)
                    {
                        Main.npc[n].life /= 2;
                        Main.npc[n].defense = 0;
                    }
                    npc.life = 0;
                    SoundEngine.PlaySound(SoundID.Roar, npc.position);
                    // SoundEngine.PlaySound(15, npc.position, 0);
                }
            }
            if (suffix1.Contains("The Soul Eater"))
            {
                for (int k = 0; k < Main.maxPlayers; k++)
                {
                    Player player = Main.player[k];
                    float sqrDistanceToTarget =
                        Vector2.DistanceSquared(player.Center, npc.Center);
                    if (Math.Abs(sqrDistanceToTarget) < 1000000f)
                    {
                        player.AddBuff(BuffID.OnFire, 30);
                        player.AddBuff(BuffID.Bleeding, 30);
                        player.AddBuff(BuffID.Slow, 30);
                        player.AddBuff(BuffID.Horrified, 30);
                    }
                }
            }

            if (suffix1.Contains("The Cultist"))
            {
                if (AITimer % 300 == 0)
                {
                    int a =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            npc.velocity,
                            464,
                            npc.damage,
                            2f); //bullet
                }
                if (AITimer % 600 == 0)
                {
                    int a =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            npc.velocity,
                            465,
                            npc.damage,
                            2f); //bullet
                }
            }

            if (suffix1.Contains("The Psyker"))
            {
                if (floatTimer > 0)
                {
                    floatTimer -= 1;
                    foreach (Player p in floating)
                    {
                        p.velocity = new Vector2(0, -2f);
                    }
                    if (floatTimer == 1)
                    {
                        foreach (Player p in floating)
                        {
                            p.velocity += new Vector2(50f, -2f);
                        }
                        floating.Clear();
                        floatTimer = 0;
                    }
                }
                else if (AITimer % 300 == 0)
                {
                    for (int k = 0; k < Main.maxPlayers; k++)
                    {
                        Player player = Main.player[k];
                        float sqrDistanceToTarget =
                            Vector2.DistanceSquared(player.Center, npc.Center);
                        if (Math.Abs(sqrDistanceToTarget) < 1000000f)
                        {
                            floating.Add(player);
                            floatTimer = 180;
                        }
                    }
                }
            }

            if (suffix1.Contains("The Fireborn"))
            {
                if (explosionTimer > 0)
                {
                    if (AITimer % 10 == 0)
                    {
                        int a =
                            Projectile
                                .NewProjectile(npc.GetSource_FromAI(),
                                new Vector2(npc.position.X -
                                    200 -
                                    100 * (10 - explosionTimer),
                                    npc.position.Y),
                                new Vector2(0, 0),
                                686,
                                npc.damage * 2,
                                2f); //bullet
                        int b =
                            Projectile
                                .NewProjectile(npc.GetSource_FromAI(),
                                new Vector2(npc.position.X +
                                    200 +
                                    100 * (10 - explosionTimer),
                                    npc.position.Y),
                                new Vector2(0, 0),
                                686,
                                npc.damage * 2,
                                2f); //bullet

                        explosionTimer -= 1;
                    }
                }
                if (AITimer % 180 == 0)
                {
                    int a =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X * 0.1f,
                                npcToPlayer.Y * 0.1f),
                            686,
                            npc.damage * 2,
                            2f); //bullet
                }
                if (AITimer % 300 == 0)
                {
                    explosionTimer = 10;
                }
            }

            if (suffix1.Contains("The Affluent"))
            {
                if (AITimer % 3 == 0)
                {
                    Vector2 coppercoin = new Vector2(npc.Center.X + Main.rand.NextFloat(-50f, 50f), npc.Center.Y + Main.rand.NextFloat(-50f, 50f));
                    Vector2 direction = new Vector2(Main.rand.NextFloat(-25f, 25f), Main.rand.NextFloat(-25f, 25f));
                    int a = Projectile.NewProjectile(npc.GetSource_FromAI(), coppercoin, direction, 158, npc.damage, 1f);
                    Main.projectile[a].friendly = false;
                    Main.projectile[a].hostile = true;
                    Main.projectile[a].tileCollide = false;
                    Main.projectile[a].timeLeft = 120;
                }

                if (AITimer % 100 == 0)
                {

                    Vector2 velocity = new Vector2(npcToPlayer.X + Main.rand.NextFloat(-5f, 5f), npcToPlayer.Y + Main.rand.NextFloat(-5f, 5f));
                    // multiply the normalized value by a random velocity
                    velocity = Vector2.Normalize(velocity) * 5f;

                    int b =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            velocity,
                            159,
                            (int)(npc.damage),
                            2f); //bullet
                    Main.projectile[b].hostile = true;
                    Main.projectile[b].friendly = false;


                }

                if (AITimer % 3 == 0)
                {
                    // Vector2 coppercoin = new Vector2(npc.Center.X + Main.rand.NextFloat(-50f, 50f), npc.Center.Y + Main.rand.NextFloat(-50f, 50f));
                    // Vector2 direction = new Vector2(Main.rand.NextFloat(-25f, 25f), Main.rand.NextFloat(-25f, 25f));
                    // int a = Projectile.NewProjectile(npc.GetSource_FromAI(), coppercoin, direction, 158, npc.damage, 1f);
                    // Main.projectile[a].friendly = false;
                    // Main.projectile[a].hostile = true;
                    // Main.projectile[a].tileCollide = false;
                    // Main.projectile[a].timeLeft = 120;

                    // make a projectile spawn in a random position with a radius of 100f from the npc
                    Vector2 position = new Vector2(npc.Center.X + Main.rand.NextFloat(-1000f, 1000f), npc.Center.Y + Main.rand.NextFloat(-1000f, 1000f));
                    // the velocity should be 0 and remain alive for 3 seconds
                    Vector2 velocity = new Vector2(0f, 0f);
                    int a = Projectile.NewProjectile(npc.GetSource_FromAI(), position, velocity, 160, npc.damage, 1f);
                    Main.projectile[a].hostile = true;
                    Main.projectile[a].friendly = false;
                    Main.projectile[a].timeLeft = 360;
                    Main.projectile[a].tileCollide = false;
                }
                // triple the health of the npc
                if (!statsChanged)
                {
                    Main.npc[npc.whoAmI].lifeMax *= 3;
                    Main.npc[npc.whoAmI].life *= 3;
                    Main.npc[npc.whoAmI].defense *= 2;

                    // 10x the value of the npc
                    npc.value *= 10f;
                    statsChanged = true;

                }

            }

            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
            if (!nameChanged)
            {
                npc.GetGlobalNPC<prefixString>().suffix =
                    npc.GetGlobalNPC<prefixString>().suffix + " " + suffix1;
                nameChanged = true;
                npc.netUpdate = true;
            }
            npc.netUpdate = true;
        }

        public override bool CheckDead(NPC npc)
        {
            if (lives > 0 && suffix1.Contains("The Immortal"))
            {
                lives--;
                npc.damage = (int)(npc.damage * 1.2);
                npc.life = npc.lifeMax;
                SoundEngine.PlaySound(SoundID.Roar, npc.position);
                return false;
            }
            return true;
        }

        // public override void OnKill(NPC npc) {
        //
        // 	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
        //
        // 	//TODO: Add the rest of the vanilla drop rules!!
        // }
    }
}
