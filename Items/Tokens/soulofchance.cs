using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace prefixtest.Items.Tokens
{
	public class soulofchance : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul of Chance");
			Tooltip.SetDefault("'The essence of rare creatures'");

			// Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
			// Reminder, (4, 6) is an example of an item that draws a new frame every 6 ticks
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));

			ItemID.Sets.AnimatesAsSoul[Item.type] = true; // Makes the item have a 4-frame animation while in world (not held.)
			ItemID.Sets.ItemIconPulse[Item.type] = true; // The item pulses while in the player's inventory
			ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25; // Configure the amount of this item that's needed to research it in Journey mode.
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 28;
			Item.maxStack = 999;
			Item.value = 1000; // Makes the item worth 1 gold.
			Item.rare = ItemRarityID.Orange;
		}

		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 1.55f * Main.essScale); // Makes this item glow when thrown out of inventory.
			if(Main.rand.Next(10) == 1){
				Lighting.AddLight(Item.position, 0.410f, 0.340f, 0.100f);
				int dust = Dust.NewDust(Item.position, Item.width+5, Item.height+5, 204, Item.velocity.X * 0.4f, Item.velocity.Y * 0.4f, 100, default(Color), 1.89f);
		}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient<soulshard>(333);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

	// todo: implement
	// public class SoulGlobalNPC : GlobalNPC
	// {
	// 	public override void NPCLoot(NPC npc) {
	// 		if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>().ZoneExample) { // Drop this item only in the ExampleBiome.
	// 			Item.NewItem(npc.GetSource_Loot(), npc.getRect(), ItemType<ExampleSoul>()); // get the npc's hitbox rectangle and spawn an item of choice
	// 		}
	// 	}
	// }
}
}
