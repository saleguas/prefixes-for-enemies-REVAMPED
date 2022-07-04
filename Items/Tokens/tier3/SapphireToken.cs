using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier3.Accessories;
using prefixtest.Items.Tokens.tier3.Consumable;
using prefixtest.Items.Tokens.tier3.Weapons;
using System;
using System.Collections.Generic;
using prefixtest.Items.Tokens.tier4;
namespace prefixtest.Items.Tokens.tier3
{
    public class SapphireToken : ModItem
    {
        private List<Tuple<int, int>> possible_drops = new List<Tuple<int, int>>{
            new Tuple<int, int>(ModContent.ItemType<vitalitycharm>(), 1),
            new Tuple<int, int>(ModContent.ItemType<slug>(), 999),
            new Tuple<int, int>(ModContent.ItemType<brokenengine>(), 1),
            new Tuple<int, int>(ModContent.ItemType<ceaselesshunger>(), 1),
            new Tuple<int, int>(ModContent.ItemType<GhastlyKalis>(), 1),
            new Tuple<int, int>(ModContent.ItemType<hourglass>(), 1),
            new Tuple<int, int>(ModContent.ItemType<purifierresolve>(), 1),
            new Tuple<int, int>(ModContent.ItemType<seatofcommand>(), 1),
            new Tuple<int, int>(ModContent.ItemType<tuningfork>(), 1),
            new Tuple<int, int>(ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5)),
            new Tuple<int, int>(ModContent.ItemType<volleybow>(), 1),

        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphire Loot Token");
            Tooltip
                .SetDefault("Claim a special reward! \nDrops from rare post-Wall-of-Flesh Enemies ");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;

            Item.value = 10000;
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.
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
			recipe.AddIngredient<EmeraldToken>(1);
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
