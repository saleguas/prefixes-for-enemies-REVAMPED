using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.Items.Tokens.tier2.Accessories;
using luckyblocks.Items.Tokens.tier2.Consumable;
using luckyblocks.Items.Tokens.tier2.Weapons;
using System;
using System.Collections.Generic;
using luckyblocks.Items.Tokens.tier3;

namespace luckyblocks.Items.Tokens.tier2
{
    public class TopazToken : ModItem
    {
        
        private List<Tuple<int, int>> possible_drops = new List<Tuple<int, int>>{
            new Tuple<int, int>(ModContent.ItemType<earthcharm>(), 1),
            new Tuple<int, int>(ModContent.ItemType<shotgunshot>(), 999),
            new Tuple<int, int>(ModContent.ItemType<gemstave>(), 1),
            new Tuple<int, int>(ModContent.ItemType<heavycrossbow>(), 1),
            new Tuple<int, int>(ModContent.ItemType<rimefrost>(), 1),
            new Tuple<int, int>(ModContent.ItemType<shotgunblade>(), 1),
            new Tuple<int, int>(ModContent.ItemType<vampireknife>(), 1),
            new Tuple<int, int>(ModContent.ItemType<shapedglass>(), 1),
            new Tuple<int, int>(ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5)),
            new Tuple<int, int>(ModContent.ItemType<hellFireTincture>(), Main.rand.Next(2, 5)),

        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Topaz Loot Token");
            Tooltip
                .SetDefault("Claim a special reward! \nDrops from rare post-skeleton enemies ");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 26;

            Item.value = 10000;
            Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.
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
			recipe.AddIngredient<SapphireToken>(1);
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
