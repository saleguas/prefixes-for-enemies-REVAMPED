using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.Items.Tokens.tier4;
namespace luckyblocks.Common.GlobalItems
{
    // This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
    // adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand.
    // See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
    public class explosivePowder : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.ExplosivePowder;
        }

        public override void SetDefaults(Item item)
        {
            item.ammo = ItemID.ExplosivePowder;
            item.shoot = 668;
            item.consumable = true;
            item.maxStack = 999;
        }

        public override bool CanBeConsumedAsAmmo(Item item, Item weapon, Player player)
        {
            return true;
        }





    }
}
