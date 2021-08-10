using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace prefixtest.Items.Tokens.tier5 {
  public class enchantedrune: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Enchanted Rune"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Uses explosive powder as ammunition");
    }

    public override void SetDefaults() {
      Item.width = 50; //The item texture's width.
      Item.height = 46; //The item texture's height.

      Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
      Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
      Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
      Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

      Item.DamageType = DamageClass.Melee; //Whether your item is part of the melee class.
      Item.damage = 66; //The damage your item deals.
      Item.knockBack = 20; //The force of knockback of the weapon. Maximum is 20
      Item.crit = 73; //The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.
      Item.scale = 2.0f;

      Item.value = Item.buyPrice(gold: 1); //The value of the weapon in copper coins.
      Item.UseSound = SoundID.Item1; //The sound when the weapon is being used.

      Item.shoot = 668;
      Item.shootSpeed = 8f;
      Item.useAmmo = ItemID.ExplosivePowder;
    }
    // This method gets called when firing your weapon/sword.
    // Item.useAmmo = ModContent.ItemType<blazereap4>();


    public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots

			position += Vector2.Normalize(velocity) * 45f;
      for(int i = 0; i < numberProjectiles; i++){
        Vector2 position2 = new Vector2(position.X + Main.rand.NextFloat(-25f, 25f), position.Y + Main.rand.NextFloat(25f, 50f));

      }


      return false;
    }


  }
}
