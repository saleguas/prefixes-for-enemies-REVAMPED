using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace luckyblocks.Items.Tokens.tier2.Weapons {
  public class heavycrossbow: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Heavy Crossbow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Shoots a heavy stynger bolt");
    }

    public override void SetDefaults() {
      Item.width = 56; //The item texture's width.
      Item.height = 24; //The item texture's height.

      Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
      Item.useTime = 80; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
      Item.useAnimation = 80; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
      Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

      Item.DamageType = DamageClass.Ranged; //Whether your item is part of the melee class.
      Item.damage = 50; //The damage your item deals.
      Item.knockBack = 20; //The force of knockback of the weapon. Maximum is 20
      Item.crit = 73; //The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.
      Item.scale = 1.0f;
      Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.

      Item.value = Item.buyPrice(gold: 1); //The value of the weapon in copper coins.
      Item.UseSound = SoundID.Item11; //The sound when the weapon is being used.

      Item.shoot = 246;
      Item.shootSpeed = 8f;
    }

    public override void AddRecipes()
    {
      Recipe recipe = CreateRecipe();
      recipe.AddIngredient<soulofchance>(3);
      recipe.AddIngredient<TopazToken>(1);
      recipe.AddTile(TileID.WorkBenches);
      recipe.Register();
    }
    // This method gets called when firing your weapon/sword.
    // Item.useAmmo = ModContent.ItemType<blazereap4>();




  }
}
