using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace prefixtest.Items.Tokens
{
	public class soulshard : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul Shard");
			Tooltip.SetDefault("A shard of pure chance.\nUse to buy consumables from The Chancellor");

			// Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
			// Reminder, (4, 6) is an example of an item that draws a new frame every 6 ticks
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 28;
			Item.maxStack = 999;
			Item.value = 1000; // Makes the item worth 1 gold.
			Item.rare = ItemRarityID.Orange;
		}

    public override void AddRecipes()
    {
      Recipe recipe = CreateRecipe(333);
      recipe.AddIngredient<soulofchance>(1);
      recipe.AddTile(TileID.WorkBenches);
      recipe.Register();
    }




		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

	// todo: implement
	// public class SoulGlobalNPC : GlobalNPC
	// {
	// 	public override void NPCLoot(NPC npc) {
	// 		if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<ExamplePlayer>().ZoneExample) { // Drop this item only in the ExampleBiome.
	// 			Item.NewItem(npc.getRect(), ItemType<ExampleSoul>()); // get the npc's hitbox rectangle and spawn an item of choice
	// 		}
	// 	}
	// }
}
}
