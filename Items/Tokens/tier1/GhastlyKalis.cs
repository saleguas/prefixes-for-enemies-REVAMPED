using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;


namespace prefixtest.Items.Tokens.tier1 {
  public class GhastlyKalis: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("GhastlyKalis"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Grants extra invincibility frames on hit!");
    }

    public override void SetDefaults() {
      Item.width = 24;
      Item.height = 12;
      Item.scale *= 1.5f;

      Item.useStyle = ItemUseStyleID.Stab;
      Item.useTime = 13;
      Item.useAnimation = 20;
      Item.autoReuse = true;
      Item.noMelee = false;

      Item.DamageType = DamageClass.Melee;
      Item.damage = 35;
      Item.knockBack = 0;
      Item.crit = 45;

    }
    // This method gets called when firing your weapon/sword.
    public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
         player.AddBuff(BuffID.Regenerating, 60);
    }





  }
}
