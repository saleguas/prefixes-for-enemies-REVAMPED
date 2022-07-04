using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier1.Accessories;
using prefixtest.Items.Tokens.tier1.Consumable;
using prefixtest.Items.Tokens.tier1.Weapons;
using System.Collections.Generic;
using System;
using prefixtest.Items.Tokens.tier2;
namespace prefixtest.Items.Tokens.tier1
{
    public class AmethystToken : ModItem
    {
        // make a list of all the items to be dropped by the token:
        private List<Tuple<int, int>> possible_drops = new List<Tuple<int, int>>{
            new Tuple<int, int>(ModContent.ItemType<starcharm>(), 1),
            new Tuple<int, int>(ModContent.ItemType<hookshot>(), 999),
            new Tuple<int, int>(ModContent.ItemType<anchorage>(), 1),
            new Tuple<int, int>(ModContent.ItemType<equalizer>(), 1),
            new Tuple<int, int>(ModContent.ItemType<gunblade1>(), 1),
            new Tuple<int, int>(ModContent.ItemType<hybridblade1>(), 1),
            new Tuple<int, int>(ModContent.ItemType<omnirang>(), 1),
            new Tuple<int, int>(ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5)),

        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amethyst Loot Token");
            Tooltip
                .SetDefault("Claim a special reward! \nDrops from rare early-game enemies ");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;

            Item.value = 10000;
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.maxStack = 1;
            Item.consumable = true;
            Item.UseSound = SoundID.Item4;
            Item.useStyle = 4;
            Item.useAnimation = 40;
            Item.useTime = 40;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<TopazToken>(1);
			recipe.Register();
		}

        public override bool? UseItem(Player player)
        {
            
            // drop a random item from the list:
            int chosen_item = Main.rand.Next(possible_drops.Count);
            int item_type = possible_drops[chosen_item].Item1;
            int item_stack = possible_drops[chosen_item].Item2;
            Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, item_type, item_stack);
            return true;
        }
    }
}
