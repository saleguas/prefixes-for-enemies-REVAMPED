using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier3.Weapons;
using prefixtest.Items.Tokens.tier3.Accessories;
using prefixtest.Items.Tokens.tier3.Consumable;

namespace prefixtest.Items.Tokens.tier3
{
	public class SapphireToken : ModItem
	{
		public override void SetStaticDefaults()
		{
      DisplayName.SetDefault("Sapphire Loot Token");
			Tooltip.SetDefault("Claim a special reward! \nDrops from rare post-Wall-of-Flesh Enemies ");
		}

		public override void SetDefaults()
		{
      Item.width = 22;
      Item.height = 26;

      Item.value = 10000;
      Item.rare = 2;
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
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<vitalitycharm>(), 1);
						break;
				case 1:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<slug>(), 999);
						break;
				case 2:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<brokenengine>(), 1);
						break;
				case 3:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<ceaselesshunger>(), 1);
						break;
				case 4:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<GhastlyKalis>(), 1);
						break;
				case 5:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<hourglass>(), 1);
						break;
				case 6:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<purifierresolve>(), 1);
						break;
				case 7:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<seatofcommand>(), 1);
						break;
				case 8:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<tuningfork>(), 1);
						break;
				case 9:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5));
						break;
		}
		return true;
}


	}
}
