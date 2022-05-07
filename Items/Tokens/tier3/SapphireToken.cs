using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier3.Accessories;
using prefixtest.Items.Tokens.tier3.Consumable;
using prefixtest.Items.Tokens.tier3.Weapons;

namespace prefixtest.Items.Tokens.tier3
{
    public class SapphireToken : ModItem
    {
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

        public override bool? UseItem(Player player)
        {
            //tier 1 loot
            int x = Main.rand.Next(0, 10);
            switch (x)
            {
                case 0:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<vitalitycharm>(), 1);
                    // new CommonDrop(ModContent.ItemType<vitalitycharm>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 1:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<slug>(), 999);
                    // new CommonDrop(ModContent.ItemType<slug>(), 1, 1, 999, 999);
                    break;
                case 2:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<brokenengine>(), 1);
                    // new CommonDrop(ModContent.ItemType<brokenengine>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 3:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<ceaselesshunger>(), 1);
                    // new CommonDrop(ModContent.ItemType<ceaselesshunger>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 4:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<GhastlyKalis>(), 1);
                    // new CommonDrop(ModContent.ItemType<GhastlyKalis>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 5:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<hourglass>(), 1);
                    // new CommonDrop(ModContent.ItemType<hourglass>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 6:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<purifierresolve>(), 1);
                    // new CommonDrop(ModContent.ItemType<purifierresolve>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 7:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<seatofcommand>(), 1);
                    // new CommonDrop(ModContent.ItemType<seatofcommand>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 8:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<tuningfork>(), 1);
                    // new CommonDrop(ModContent.ItemType<tuningfork>(),
                    //     1,
                    //     1,
                    //     1,
                    //     1);
                    break;
                case 9:
                    Item.NewItem(player.GetSource_Misc("PlayerDropItemCheck"),  (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5));
                    // new CommonDrop(ModContent.ItemType<soulofchance>(),
                    //     1,
                    //     1,
                    //     2,
                    //     5);
                    break;
            }
            return true;
        }
    }
}
