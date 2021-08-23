using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier2.Weapons;
using prefixtest.Items.Tokens.tier2.Accessories;
using prefixtest.Items.Tokens.tier2.Consumable;

namespace prefixtest.Items.Tokens.tier2
{
	public class TopazToken : ModItem
	{
		public override void SetStaticDefaults()
		{
      DisplayName.SetDefault("Topaz Loot Token");
			Tooltip.SetDefault("Claim a special reward! \nDrops from rare post-skeleton enemies ");
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
		public override bool? UseItem(Player player)
{
		//tier 1 loot
		int x = Main.rand.Next(0, 8);
		switch (x)
		{
				case 0:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<earthcharm>(), 1);
						break;
				case 1:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<shotgunshot>(), 999);
						break;
				case 2:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<gemstave>(), 1);
						break;
				case 3:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<heavycrossbow>(), 1);
						break;
				case 4:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<rimefrost>(), 1);
						break;
				case 5:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<shotgunblade>(), 1);
						break;
				case 6:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<vampireknife>(), 1);
						break;
				case 7:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5));
						break;
		}
		return true;
}


	}
}
