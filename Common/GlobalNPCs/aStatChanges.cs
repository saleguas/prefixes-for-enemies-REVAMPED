using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using prefixtest;
using prefixtest.Common.GlobalNPCs;

namespace prefixtest.Common.GlobalNPCs
{
    public class aStatChanges : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        private string prefix1 = "";

        private bool nameChanged = false;


        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            if (npc.townNPC == true || npc.friendly == true) return false;

            Random random = new Random();
            double roll1 = random.NextDouble();
            npc.netUpdate = true;

            return roll1 <=
            (
            double
            )(ModContent.GetInstance<modconfig>().StatChangeChance * 0.01);
        }

        public override void SetDefaults(NPC npc)
        {
            // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
            int upLimit = 12;
            if (Main.hardMode) upLimit = 20;
            Random random = new Random();
            int roll2 = random.Next(1, upLimit); // creates a number from 1 to n-1
            switch (roll2)
            {
                case 1:
                    prefix1 = "Tough";
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;
                case 2:
                    prefix1 = "Dangerous";
                    npc.damage = (int)(npc.damage * 1.4);
                    break;
                case 3:
                    prefix1 = "Armored";
                    npc.defense = (int)(npc.defense * 1.5 + 4);
                    break;
                case 4:
                    prefix1 = "Small";
                    float sizeRoll = random.Next(5, 8) * 0.1f;
                    npc.scale *= sizeRoll;
                    npc.damage = (int)(npc.damage * sizeRoll);
                    break;
                case 5:
                    prefix1 = "Large";
                    sizeRoll = random.Next(11, 15) * 0.1f;
                    npc.scale *= sizeRoll;
                    npc.damage = (int)(npc.damage * sizeRoll);
                    break;
                case 6:
                    prefix1 = "Miniature";
                    sizeRoll = random.Next(1, 5) * 0.1f;
                    npc.scale *= sizeRoll;
                    npc.damage = (int)(npc.damage * sizeRoll);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * sizeRoll);
                    break;
                case 7:
                    prefix1 = "Colossal";
                    sizeRoll = random.Next(16, 25) * 0.1f;
                    npc.scale *= sizeRoll;
                    npc.damage = (int)(npc.damage * sizeRoll);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * sizeRoll);
                    break;
                case 8:
                    prefix1 = "Toughened";
                    npc.defense = (int)(npc.defense * 2.5);
                    break;
                case 9:
                    prefix1 = "Enduring";
                    npc.takenDamageMultiplier *= .8f;
                    break;
                case 10:
                    prefix1 = "Steadfast";
                    npc.knockBackResist = 0f;
                    break;
                case 11:
                    prefix1 = "Wealthy";
                    npc.value *= 10f;
                    break;
                case 12:
                    prefix1 = "Mythical";
                    npc.takenDamageMultiplier *= .75f;
                    npc.value *= 4f;
                    npc.damage = (int)(npc.damage * 1.5);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    npc.defense = (int)(npc.defense * 1.5);
                    npc.knockBackResist = .9f;
                    break;
                case 13:
                    prefix1 = "Cool";
                    npc.value *= 5f;
                    break;
                case 14:
                    prefix1 = "Sus";
                    sizeRoll = random.Next(1, 8) * 0.1f;
                    npc.scale *= sizeRoll;
                    npc.damage = (int)(npc.damage * 1.4);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * .6);
                    npc.value *= 1.5f;
                    npc.knockBackResist = 1.5f;
                    break;
                case 15:
                    prefix1 = "Sluggish";
                    npc.takenDamageMultiplier *= 1.2f;
                    npc.damage = (int)(npc.damage * .8);
                    npc.knockBackResist = 1.3f;
                    break;
                case 16:
                    prefix1 = "Juggernaut";
                    npc.takenDamageMultiplier *= .6f;
                    npc.damage = (int)(npc.damage * .3);
                    npc.knockBackResist = 0f;
                    npc.value *= 2.2f;
                    npc.defense = (int)(npc.defense * 1.5);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    npc.scale *= 1.9f;
                    break;
                case 17:
                    prefix1 = "Deranged";
                    npc.knockBackResist = 0.2f;
                    npc.damage = (int)(npc.damage * 1.3);
                    npc.defense = (int)(npc.defense * .6);
                    break;
                case 18:
                    prefix1 = "Placid";
                    npc.damage = (int)(npc.damage * .2);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * 2.5);
                    break;
                case 19:
                    prefix1 = "???";
                    float roll3 = random.Next(1, 19) * .1f;
                    npc.takenDamageMultiplier *= roll3;
                    npc.value *= roll3;
                    npc.damage = (int)(npc.damage * roll3);
                    npc.life = npc.lifeMax = (int)(npc.lifeMax * roll3);
                    npc.defense = (int)(npc.defense * roll3);
                    npc.knockBackResist = roll3;
                    npc.scale *= roll3;
                    break;
            }
            npc.netUpdate = true;
            npc.value *= 2f;
        }

        public override void AI(NPC npc)
        {
            //Make the guide giant and green.
            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
            if (!nameChanged)
            {
                npc.GetGlobalNPC<prefixString>().prefix =
                    npc.GetGlobalNPC<prefixString>().prefix + " " + prefix1;
                nameChanged = true;
                npc.netUpdate = true;
            }
        }

        // public override void OnKill(NPC npc) {
        //
        // 	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
        //
        // 	//TODO: Add the rest of the vanilla drop rules!!
        // }
    }
}
