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
			Item.scale = 2.5f;

    }
    // This method gets called when firing your weapon/sword.
    public override bool AltFunctionUse(Player player) {
      return true;
    }


    public override bool ConsumeAmmo(Player player) {
      if (player.altFunctionUse == 2) {
        return true;
      }
      return false;
    }


  }
}
