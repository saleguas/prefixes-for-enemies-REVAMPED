using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace prefixtest.Items.Tokens.tier1
{
	public class AmethystToken : ModItem
	{
		public override void SetStaticDefaults()
		{
      DisplayName.SetDefault("Tier 1 Loot Token");
			Tooltip.SetDefault("What will you get?");
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


	}
}
