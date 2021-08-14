using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;


namespace prefixtest.Items.Testing {
  public class shotgunblade: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Hybrid Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Left click to swing. Right click to fire a bullet. \nThe gun requires one use to switch between modes.");
    }

    public override void SetDefaults() {
      Item.width = 30;
      Item.height = 30;

      Item.useStyle = ItemUseStyleID.Swing;
      Item.useTime = 20;
      Item.useAnimation = 20;
      Item.UseSound = SoundID.Item1;
      Item.shoot = ProjectileID.None;

      Item.DamageType = DamageClass.Melee;
      Item.damage = 19;
      Item.knockBack = 6;
      Item.crit = 6;
      Item.autoReuse = true;

      Item.value = Item.buyPrice(gold: 5);
      Item.rare = ItemRarityID.Pink;
      Item.staff[Item.type] = true;
			Item.scale = 1.5f;

    }
    // This method gets called when firing your weapon/sword.
    public override bool AltFunctionUse(Player player) {
      return true;
    }

    public override bool CanUseItem(Player player) {
      if (player.altFunctionUse == 2) {
        Item.useAmmo = AmmoID.Bullet;
        Item.shoot = ProjectileID.Bullet; // ID of the projectiles the sword will shoot
        Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot
        Item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
        Item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
        Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
        Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
        Item.DamageType = DamageClass.Ranged;
				Item.scale = 1.5f;
				Item.damage = 18;

      } else {
				Item.useAmmo = -1;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ProjectileID.None;
        Item.DamageType = DamageClass.Melee;
				Item.scale = 2.5f;
				Item.damage = 19;



      }
      return base.CanUseItem(player);
    }

    public override bool ConsumeAmmo(Player player) {
      if (player.altFunctionUse == 2) {
        return true;
      }
      return false;
    }


  }
}
