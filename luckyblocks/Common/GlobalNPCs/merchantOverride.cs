using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using luckyblocks.Items;
    // make function can_apply_to_npc(NPC npc) -> bool


namespace luckyblocks.gnpcs
{


    public class merchantOverride : GlobalNPC
    {


        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.TravellingMerchant)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.LuckyBlock>());
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;
            }
            
        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            shop[nextSlot] = ModContent.ItemType<Items.LuckyBlock>();
            nextSlot++;
        }





        // public override void OnKill(NPC npc) {
        //
        // 	Item.NewItem(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);
        //
        // 	//TODO: Add the rest of the vanilla drop rules!!
        // }
    }
}
