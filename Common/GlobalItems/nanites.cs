using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier4;
using prefixtest.Projectiles;
namespace prefixtest.Common.GlobalItems
{
	// This file shows a very simple example of a GlobalItem class. GlobalItem hooks are called on all items in the game and are suitable for sweeping changes like
	// adding additional data to all items in the game. Here we simply adjust the damage of the Copper Shortsword item, as it is simple to understand.
	// See other GlobalItem classes in ExampleMod to see other ways that GlobalItem can be used.
	public class nanites : GlobalItem
	{
		public override bool AppliesToEntity(Item item, bool lateInstatiation) {
			return item.type == ItemID.Nanites;
		}

		public override void SetDefaults(Item item) {
			item.ammo = ItemID.Nanites;
      item.shoot = ModContent.ProjectileType<Projectiles.quazarproj>();
      item.consumable = true;
			item.maxStack = 999;
		}

		public override bool CanBeConsumedAsAmmo(Item item, Player player){
      return true;
    }



	}
}
