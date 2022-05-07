using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace prefixtest.Common.GlobalNPCs
{
    public class prefixString : GlobalNPC
    {
        public string prefix = "";

        public string suffix = "";

        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(NPC npc, bool lateInstatiation)
        {
            if (npc.townNPC == true || npc.friendly == true) return false;
            return true;
        }

        public override void SetDefaults(NPC npc)
        {
            // Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
            // npc.life = npc.lifeMax = 2000;
        }

        public override void AI(NPC npc)
        {
            //Make the guide giant and green.
            // if (!nameChanged){
            // 	nameChanged = true;
            // }
            // npc.scale = 1.5f;
            // npc.color = Color.ForestGreen;
        }

        // public override void OnKill(NPC npc) {
        //
        // 	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
        //
        // 	//TODO: Add the rest of the vanilla drop rules!!
        // }
    }
}
