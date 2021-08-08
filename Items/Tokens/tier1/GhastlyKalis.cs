using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;


namespace prefixtest.Items.Tokens.tier1 {
  public class GhastlyKalis: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Ghastly Kalis"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Grants invincibility on hit");
    }

    public override void SetDefaults() {
      Item.width = 32;
      Item.height = 32;
      Item.scale *= 1.5f;

      Item.useStyle = 3;
      Item.useTime = 4;
      Item.useAnimation = 5;
      Item.autoReuse = true;

      Item.DamageType = DamageClass.Melee;
      Item.damage = 35;
      Item.knockBack = 0;
      Item.crit = 45;

    }
    // This method gets called when firing your weapon/sword.
    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
         player.AddBuff(BuffID.Invisibility, 5);
         player.AddBuff(BuffID.ShadowDodge, 5);
    }





  }
}
