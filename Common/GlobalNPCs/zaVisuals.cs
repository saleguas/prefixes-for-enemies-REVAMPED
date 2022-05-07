using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

// I have "random" letters appended to the beginning of each of these files b/c the game reads them in alphabetical order.
// statchanges first, then spceial effects, then projecitles
namespace prefixtest.Common.GlobalNPCs
{
    // 			npc.GetGlobalNPC<aStatChanges>().prefix = npc.GetGlobalNPC<aStatChanges>().prefix + " " + prefix;
    public class zaVisuals : GlobalNPC
    {
        public bool nameChanged = false;

        public override bool InstancePerEntity => true;

        private string prefix = "";

        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            if (npc.townNPC == true || npc.friendly == true) return false;
            return true;
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            prefix = npc.GetGlobalNPC<prefixString>().prefix;
            if (prefix == "") return;

            //base.AI(npc); why is this here?
            if (prefix.Contains("Burning"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            6,
                            0,
                            0,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Hellfire"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            75,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Frozen"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            201,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Electrified"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            226,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Dark"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            249,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            } // 1
            if (prefix.Contains("Trickster"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            217,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Hexing"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            272,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Slowing"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            37,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Venomous"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            46,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Regenerating"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            243,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Martyr"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            43,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Magebane"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            42,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Voodoo"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            70,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Vengeful"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            14,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Mutilator"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            38,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            100,
                            default(Color),
                            2f);
                }
            }
            if (prefix.Contains("Cutpurse"))
            {
                Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
                if (Main.rand.Next(10) == 0)
                {
                    int dust =
                        Dust
                            .NewDust(npc.position,
                            npc.width + 4,
                            npc.height + 4,
                            43,
                            npc.velocity.X * 0.4f,
                            npc.velocity.Y * 0.4f,
                            228,
                            default(Color),
                            2f);
                }
            }
            npc.netUpdate = true;
        }

        // public override void OnKill(NPC npc) {
        //
        // 	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
        //
        // 	//TODO: Add the rest of the vanilla drop rules!!
        // }
    }
}
