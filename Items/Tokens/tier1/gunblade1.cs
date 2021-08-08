using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;


namespace prefixtest.Items.Tokens.tier1 {
  public class gunblade1: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("GunBlade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Left click to swing. Right click to fire a bullet. \nThe gun requires one use to switch between modes.");
    }

    public override void SetDefaults() {
      Item.width = 48;
      Item.height = 48;
      Item.scale *= 1.5f;

      Item.useStyle = ItemUseStyleID.Swing;
      Item.useTime = 20;
      Item.useAnimation = 20;
      Item.autoReuse = true;
      Item.noMelee = false;

      Item.DamageType = DamageClass.Melee;
      Item.damage = 14;
      Item.knockBack = 6;
      Item.crit = 12;

      Item.value = Item.buyPrice(gold: 5);
      Item.rare = ItemRarityID.Pink;
      Item.UseSound = SoundID.Item11;
      Item.useAmmo = AmmoID.Bullet;


      Item.shoot = ProjectileID.Bullet; // ID of the projectiles the sword will shoot
      Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot
    }
    // This method gets called when firing your weapon/sword.


    public override bool ConsumeAmmo(Player player) {
      return true;
    }



  }
}
