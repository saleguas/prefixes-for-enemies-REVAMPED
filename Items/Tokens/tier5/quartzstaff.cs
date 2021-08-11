using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace prefixtest.Items.Tokens.tier5 {
  public class quartzstaff: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Quart Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Shoots a heavy stynger bolt");
    }

    public override void SetDefaults() {
      Item.width = 50; //The item texture's width.
      Item.height = 46; //The item texture's height.

      Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
      Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
      Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
      Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

      Item.DamageType = DamageClass.Melee; //Whether your item is part of the melee class.
      Item.damage = 66; //The damage your item deals.
      Item.knockBack = 20; //The force of knockback of the weapon. Maximum is 20
      Item.crit = 73; //The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.
      Item.scale = 1.0f;

      Item.value = Item.buyPrice(gold: 1); //The value of the weapon in copper coins.
      Item.UseSound = SoundID.Item1; //The sound when the weapon is being used.

      Item.shoot = 356;
      Item.shootSpeed = 8f;
    }
    // This method gets called when firing your weapon/sword.
    // Item.useAmmo = ModContent.ItemType<blazereap4>();




  }
}
