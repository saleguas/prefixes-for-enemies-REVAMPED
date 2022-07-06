using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace prefixtest.Common.GlobalNPCs
{
    public class cProjectiles : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        private string prefix3 = "";

        private int AITimer = 0;

        private bool nameChanged = false;

        private int npcProjectile = 0;

        private List<string> pre_skeletron_prefixes = new List<string>{
            "Gunner",
            "Webbing",
            "Vampire Hunter",
            "Cyborg",
            "Grassy",
            "Boomerang",
            "Peddler",
            "Demonic",
            "Fungal",
            "Fishy",
            "Ballistician",
            "Hemomancer",
            "Ninja",
        };
        private List<string> pre_wof_prefixes = new List<string>
        {
            "Grave Robber",
            "Volcanic",
            "Dweller"
        };
        private List<string> pre_golem_prefixes = new List<string>{
            "Umbra",
            "Floral",
            "Electric",
            "Rioting",
            "Pirate",
            "Night Hunter",
            "Infinite",
            "Infernal",
            "Hellish",
            "Shotgunning",
            "Machine Gunning",
            "Sniper",
            "Rich",
        };
        private List<string> pre_moonlord_prefixes = new List<string>
        {
        };
        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            if (npc.townNPC == true || npc.friendly == true) return false;

            Random random = new Random();
            double roll1 = random.NextDouble();

            return roll1 <= (double)(ModContent.GetInstance<modconfig>().ProjectileChance * 0.01);
        }

        public override void SetDefaults(NPC npc)
        {
            // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
            List<string> prefixes = new List<string>();
            prefixes.AddRange(pre_skeletron_prefixes);
            if (NPC.downedBoss3)
            {
                prefixes.AddRange(pre_wof_prefixes);
            }
            if (Main.hardMode)
            {
                prefixes.AddRange(pre_golem_prefixes);
            }
            if (NPC.downedGolemBoss)
            {
                prefixes.AddRange(pre_moonlord_prefixes);
            }

            Random random = new Random();
            // make a List of all the prefixes

            prefix3 = prefixes[random.Next(prefixes.Count)];

            npc.value *= 2f;
        }

        public override void AI(NPC npc)
        {
            AITimer = (AITimer + 1) % 10000;
            Player targetPlayer = Main.player[npc.target];
            Vector2 npcToPlayer =
                Vector2.Normalize(targetPlayer.position - npc.position);
            npcToPlayer *= 10f;

            // int distance = (int)Math.Sqrt(Math.pow(targetPlayer.X - npc.X, 2) + Math.pow(targetPlayer.Y - npc.Y, 2));
            //Make the guide giant and green.
            if (prefix3.Contains("Gunner"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            npcToPlayer,
                            14,
                            (int) (npc.damage*0.8),
                            2f); //bullet
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                }
            }
            if (prefix3.Contains("Shotgunning"))
            {
                const int NumProjectiles = 4; //The humber of projectiles that this gun will shoot.

                if (AITimer % 180 == 0)
                {
                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        // Rotate the velocity randomly by 30 degrees at max.
                        Vector2 newVelocity =
                            npcToPlayer
                                .RotatedByRandom(MathHelper.ToRadians(15));

                        // Decrease velocity randomly for nicer visuals.
                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                        //Create a projectile.
                        npcProjectile =
                            Projectile
                                .NewProjectile(npc.GetSource_FromAI(),
                                npc.position,
                                newVelocity,
                                14,
                                (int)(npc.damage * 0.4),
                                2f); //bullet
                        Main.projectile[npcProjectile].friendly = false;
                        Main.projectile[npcProjectile].hostile = true;
                        Main.projectile[npcProjectile].netUpdate = true;
                    }
                }
            }
            if (prefix3.Contains("Machine Gunning"))
            {
                const int NumProjectiles = 4; //The humber of projectiles that this gun will shoot.

                if (AITimer % 30 == 0)
                {
                    Vector2 newVelocity =
                        npcToPlayer.RotatedByRandom(MathHelper.ToRadians(15));

                    // Decrease velocity randomly for nicer visuals.
                    newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                    //Create a projectile.
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            newVelocity,
                            14,
                            (int)(npc.damage * 0.7),
                            2f); //bullet
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                }
            }
            if (prefix3.Contains("Sniper"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            npcToPlayer,
                            242,
                            (int)(npc.damage * 1.4),
                            2f); //bullet high velocity
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                    npcToPlayer *= 50f;
                }
            }
            if (prefix3.Contains("Volcanic"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            467,
                            (int)(npc.damage * 1.2),
                            2f);
                }
            }
            if (prefix3.Contains("Umbra"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            468,
                            (int)(npc.damage * 1.2),
                            2f);
                }
            }
            if (prefix3.Contains("Webbing"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            472,
                            npc.damage,
                            2f); //bullet
                }
            }
            if (prefix3.Contains("Electric"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            435,
                            (int)(npc.damage * 0.4),
                            2f);
                }
            }
            if (prefix3.Contains("Rioting"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            399,
                            (int)(npc.damage * 0.9),
                            2f);
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].netUpdate = true;
                }
            }
            if (prefix3.Contains("Pirate"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            240,
                            (int)(npc.damage * 1.2),
                            2f); //bullet
                }
            }
            if (prefix3.Contains("Night Hunter"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            246,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                }
            }
            if (prefix3.Contains("Infinite"))
            {
                if (AITimer % 240 == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 source2 =
                            new Vector2(targetPlayer.position.X - 50 + (i * 50),
                                targetPlayer.position.Y + 800f);
                        Vector2 newVelocity = new Vector2(0, -25f);
                        npcProjectile =
                            Projectile
                                .NewProjectile(npc.GetSource_FromAI(),
                                source2,
                                newVelocity,
                                116,
                                npc.damage,
                                2f); //bullet
                        Main.projectile[npcProjectile].friendly = false;
                        Main.projectile[npcProjectile].hostile = true;
                        Main.projectile[npcProjectile].netUpdate = true;
                    }
                }
            }
            if (prefix3.Contains("Infernal"))
            {
                if (AITimer % 240 == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Vector2 newVelocity =
                            new Vector2(Main.rand.NextFloat(-15f, 15f),
                                Main.rand.NextFloat(0f, -3f));
                        npcProjectile =
                            Projectile
                                .NewProjectile(npc.GetSource_FromAI(),
                                npc.position,
                                newVelocity,
                                668,
                                npc.damage,
                                2f); //bullet
                        Main.projectile[npcProjectile].friendly = false;
                        Main.projectile[npcProjectile].hostile = true;
                        Main.projectile[npcProjectile].netUpdate = true;
                    }
                }
            }
            if (prefix3.Contains("Hellish"))
            {
                if (AITimer % 240 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            291,
                            npc.damage,
                            2f); //bullet
                }
            }
            if (prefix3.Contains("Vampire Hunter"))
            {
                if (AITimer % 30 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            304,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                }
            }
            if (prefix3.Contains("Cyborg"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            466,
                            npc.damage,
                            2f); //bullet
                }
            }

            if (prefix3.Contains("Grave Robber"))
            {
                if (AITimer % 120 == 0)
                {
                    int type =
                        Main.rand.Next(new int[] { 201, 202, 203, 204, 205 });
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            type,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].friendly = false;
                    Main.projectile[npcProjectile].hostile = true;
                }
            }
            if (prefix3.Contains("Grassy"))
            {
                if (AITimer % 120 == 0)
                {
                    float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
                    float rotation = MathHelper.ToRadians(45);
                    Vector2 velocity = npc.velocity;

                    // position += Vector2.Normalize(velocity) * 45f;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed =
                            velocity
                                .RotatedBy(MathHelper
                                    .Lerp(-rotation,
                                    rotation,
                                    i / (numberProjectiles - 1))) *
                            .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                        npcProjectile =
                            Projectile
                                .NewProjectile(npc.GetSource_FromAI(),
                                npc.position,
                                perturbedSpeed,
                                206,
                                npc.damage,
                                2f); //
                        Main.projectile[npcProjectile].friendly = false;
                        Main.projectile[npcProjectile].hostile = true;
                        Main.projectile[npcProjectile].netUpdate = true;
                    }
                }
            }
            if (prefix3.Contains("Boomerang"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            6,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Peddler"))
            {
                if (AITimer % 40 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            158,
                            (int)(npc.damage * 0.4),
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Demonic"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            44,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Fungal"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            131,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Fishy"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            190,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Floral"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            221,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Ballistician"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            680,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Hemomancer"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            756,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Ninja"))
            {
                if (AITimer % 120 == 0)
                {
                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            new Vector2(npcToPlayer.X, npcToPlayer.Y),
                            3,
                            npc.damage,
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }
            }
            if (prefix3.Contains("Dweller"))
            {
                if (AITimer % 20 == 0)
                {

                    Vector2 velocity = new Vector2(npcToPlayer.X + Main.rand.NextFloat(-5f, 5f), npcToPlayer.Y + Main.rand.NextFloat(-5f, 5f));
                    // multiply the normalized value by a random velocity
                    velocity = Vector2.Normalize(velocity) * 3f;

                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            velocity,
                            159,
                            (int)(npc.damage * 0.65),
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;


                }
            }
            if (prefix3.Contains("Rich"))
            {
                if (AITimer % 10 == 0)
                {

                    Vector2 velocity = new Vector2(npcToPlayer.X + Main.rand.NextFloat(-5f, 5f), npcToPlayer.Y + Main.rand.NextFloat(-5f, 5f));
                    // multiply the normalized value by a random velocity
                    velocity = Vector2.Normalize(velocity) * 5f;

                    npcProjectile =
                        Projectile
                            .NewProjectile(npc.GetSource_FromAI(),
                            npc.position,
                            velocity,
                            160,
                            (int)(npc.damage),
                            2f); //bullet
                    Main.projectile[npcProjectile].hostile = true;
                    Main.projectile[npcProjectile].friendly = false;
                }

                if (AITimer % 5 == 0)
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
            }
            if (!nameChanged)
            {
                npc.GetGlobalNPC<prefixString>().prefix =
                    npc.GetGlobalNPC<prefixString>().prefix + " " + prefix3;
                nameChanged = true;
            }
            Main.projectile[npcProjectile].netUpdate = true;
            npc.netUpdate = true;

            // 				Projectile.NewProjectile(NPC.GetSource_FromAI(), position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);

            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
        }

        // public override void SendExtraAI(BinaryWriter writer) {
        //   writer.Write(prefix3);
        //   writer.Write(AITimer);
        //   writer.Write(nameChanged);
        //   writer.Write(npcProjectile);
        //
        // }
        //
        // public override void ReceiveExtraAI(BinaryReader reader) {
        //   prefix3 = reader.ReadString();
        //   AITimer = reader.ReadInt();
        //   nameChanged = reader.ReadBoolean();
        //   npcProjectile = reader.ReadInt();
        // }

        // public override void OnKill(NPC npc) {
        //
        // 	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
        //
        // 	//TODO: Add the rest of the vanilla drop rules!!
        // }
    }
}
