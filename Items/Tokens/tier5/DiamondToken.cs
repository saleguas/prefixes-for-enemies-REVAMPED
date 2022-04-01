using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens.tier5;


namespace prefixtest.Items.Tokens.tier5
{
	public class DiamondToken : ModItem
	{
		public override void SetStaticDefaults()
		{
      DisplayName.SetDefault("Diamond Loot Token");
			Tooltip.SetDefault("Claim a special reward! \nDrops from rare early-game enemies ");
		}

		public override void SetDefaults()
		{
      Item.width = 22;
      Item.height = 26;

      Item.value = 10000;
			Item.rare = -12; // The color that the item's name will be in-game.
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
		int x = Main.rand.Next(0, 1);
		switch (x)
		{
				case 0:
						Item.NewItem( player.position.X,  player.position.Y, player.width, player.height, ModContent.ItemType<unstableelement>(), 1);
						break;
		}
		return true;
}


	}
}
