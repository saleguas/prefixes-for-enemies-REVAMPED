using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier1;
using prefixtest.Items.Tokens.tier2;
using prefixtest.Items.Tokens.tier3;
using prefixtest.Items.Tokens.tier4;
using prefixtest.Items.Tokens.tier5;

namespace prefixtest.Common.GlobalNPCs
{
    public class xRare : GlobalNPC
    {
        public bool nameChanged = false;

        public override bool InstancePerEntity => true;

        private string prefix;

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

            Random random = new Random();
            double roll1 = random.NextDouble();

            npc.netUpdate = true;

            return roll1 <=
            (double)(ModContent.GetInstance<modconfig>().RareChance * 0.01);
        }

        public override void SetDefaults(NPC npc)
        {
            // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
            prefix = "Rare";
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (Main.rand.Next(3) == 1)
            {
                Lighting.AddLight(npc.position, 0.410f, 0.340f, 0.100f);
                int dust =
                    Dust
                        .NewDust(npc.position,
                        npc.width + 5,
                        npc.height + 5,
                        204,
                        npc.velocity.X * 0.4f,
                        npc.velocity.Y * 0.4f,
                        100,
                        default(Color),
                        1.89f);
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (prefix.Contains("Rare") && npc.value == 0f && npc.npcSlots == 0f
            )
            {
                prefix = "";
            }
            return base.PreAI(npc);
        }

        public override void AI(NPC npc)
        {
            //Make the guide giant and green.
            if (!nameChanged)
            {
                npc.GetGlobalNPC<prefixString>().prefix =
                    prefix + " " + npc.GetGlobalNPC<prefixString>().prefix;
                nameChanged = true;
                npc.netUpdate = true;
            }

            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
        }

        public override void OnKill(NPC npc)
        {
            if (NPC.downedMoonlord)
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DiamondToken>());
                // new CommonDrop(ModContent.ItemType<DiamondToken>(), 1, 1, 1, 1);
            }
            else if (NPC.downedPlantBoss)
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EmeraldToken>());
                // new CommonDrop(ModContent.ItemType<EmeraldToken>(), 1, 1, 1, 1);
            }
            else if (Main.hardMode)
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SapphireToken>());
                // new CommonDrop(ModContent.ItemType<SapphireToken>(),
                // 1,
                // 1,
                // 1,
                // 1);
            }
            else if (NPC.downedBoss3 || NPC.downedQueenBee)
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TopazToken>());
                // new CommonDrop(ModContent.ItemType<TopazToken>(), 1, 1, 1, 1);
            }
            else
            {
                Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AmethystToken>());
                // new CommonDrop(ModContent.ItemType<AmethystToken>(),
                // 1,
                // 1,
                // 1,
                // 1);
            }
            //TODO: Add the rest of the vanilla drop rules!!
        }
    }
}
