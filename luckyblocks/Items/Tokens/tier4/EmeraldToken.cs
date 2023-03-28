using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.Items.Tokens.tier4.Weapons;
using luckyblocks.Items.Tokens.tier4.Consumable;
using Terraria.GameContent.ItemDropRules;
using System;
using System.Collections.Generic;
using luckyblocks.Items.Tokens.tier5;

namespace luckyblocks.Items.Tokens.tier4
{
    public class EmeraldToken : ModItem
    {
		private List<Tuple<int, int>> possible_drops = new List<Tuple<int, int>>{
            new Tuple<int, int>(ModContent.ItemType<blazereap4>(), 1),
            new Tuple<int, int>(ModContent.ItemType<starshot>(), 999),
            new Tuple<int, int>(ModContent.ItemType<dreamshatter>(), 1),
            new Tuple<int, int>(ModContent.ItemType<infinityedge>(), 1),
            new Tuple<int, int>(ModContent.ItemType<quazar>(), 1),
            new Tuple<int, int>(ModContent.ItemType<theecho>(), 1),
            new Tuple<int, int>(ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5)),

        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Loot Token");
            Tooltip.SetDefault("Claim a special reward! \nDrops from rare post-Plantera enemies ");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;

            Item.value = 10000;
            Item.rare = ItemRarityID.Lime; // The color that the item's name will be in-game.
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
			recipe.AddIngredient<DiamondToken>(1);
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
