using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier4.Weapons;
using prefixtest.Items.Tokens.tier4.Consumable;

namespace prefixtest.Items.Tokens.tier4
{
	public class EmeraldToken : ModItem
	{
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
		int x = Main.rand.Next(0, 7);
		switch (x)
		{
				case 0:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<blazereap4>(), 1);
						break;
				case 1:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<starshot>(), 999);
						break;
				case 2:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<dreamshatter>(), 1);
						break;
				case 3:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<infinityedge>(), 1);
						break;
				case 4:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<quazar>(), 1);
						break;
				case 5:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<theecho>(), 1);
						break;
				case 6:
						Item.NewItem( (int)  player.position.X,  (int) player.position.Y, player.width, player.height, ModContent.ItemType<soulofchance>(), Main.rand.Next(2, 5));
						break;
		}
		return true;
}


	}
}
