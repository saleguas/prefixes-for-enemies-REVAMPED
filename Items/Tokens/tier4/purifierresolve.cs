using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using prefixtest.buffs;
using prefixtest.Projectiles;

namespace prefixtest.Items.Tokens.tier4 {
  public class purifierresolve: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Purifier's Resolve"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.

      Tooltip.SetDefault("Right click to dash towards your cursor every five seconds.\nThe distance traveled is based upon how far your cursor is from your character.\nHit an enemy to reset the cooldown on the dash.\n\"Keep movin' on.\"");
    }

    private bool used = false;

    public override void SetDefaults() {
      // Common Properties
      Item.width = 62; // Hitbox width of the item.
      Item.height = 32; // Hitbox height of the item.
      Item.scale = 0.75f;
      Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

      // Use Properties
      Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
      Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
      Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
      Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
      Item.UseSound = SoundID.Item11; // The sound that this item plays when used.

      // Weapon Properties
      Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
      Item.damage = 20; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
      Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
      Item.noMelee = false; // So the item's animation doesn't do damage.
      Item.shoot = ModContent.ProjectileType<Projectiles.purifierproj>(); // For some reason, all the guns in the vanilla source have this.
      Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)

      // Gun Properties

    }

    public override bool AltFunctionUse(Player player) {
      return true;
    }




    public override bool CanUseItem(Player player) {
      var player2 = player.GetModPlayer<DashPlayer>();

      if (player.altFunctionUse == 2 && player2.DashTimer == 0) {
        player2.PurifierDash();
        Item.shoot = ProjectileID.None;
      }
      else if(player.altFunctionUse == 2 && player2.DashTimer != 0){
        Item.shoot = ProjectileID.None;
      }
      else{
        Item.shoot = ModContent.ProjectileType<Projectiles.purifierproj>(); // For some reason, all the guns in the vanilla source have this.

      }
      return base.CanUseItem(player);
    }


  }

  public class DashPlayer : ModPlayer
	{
    public int DashTimer = 0;
    public const int DashCooldown = 300;


    public override void PreUpdateMovement() {
      if (DashTimer > 0){
        DashTimer -= 1;
        Player.armorEffectDrawShadowEOCShield = false;
      }

    }

    public void PurifierDash() {
        Vector2 target = Main.MouseWorld - Player.Center;
        Vector2 dashGo = new Vector2(target.X * .05f, target.Y * .05f);
        Player.velocity = dashGo;
        DashTimer = DashCooldown;
        Player.eocDash = DashTimer;
				Player.armorEffectDrawShadowEOCShield = true;
    }

    public override void OnHitNPCWithProj (Projectile proj, NPC target, int damage, float knockback, bool crit){
      if(proj.type ==  ModContent.ProjectileType<Projectiles.purifierproj>())
      {
        if (DashTimer > 0){
          DashTimer = 0;
        }
      }
    }


  }


}
