using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;


namespace prefixtest.Items.Tokens.tier2.Weapons {
  public class shotgunblade: ModItem {
    public override void SetStaticDefaults() {
      DisplayName.SetDefault("Shotgun Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
      Tooltip.SetDefault("Left click to swing. Right click to fire a spread of bullets. \nThe gun requires one use to switch between modes.");
    }

    public override void SetDefaults() {
      Item.width = 60;
      Item.height = 67;

      Item.useStyle = ItemUseStyleID.Swing;
      Item.useTime = 20;
      Item.useAnimation = 20;
      Item.UseSound = SoundID.Item1;
      Item.shoot = ProjectileID.None;

      Item.DamageType = DamageClass.Melee;
      Item.damage = 30;
      Item.knockBack = 6;
      Item.crit = 6;
      Item.autoReuse = true;

      Item.value = Item.buyPrice(gold: 5);
      Item.rare = ItemRarityID.Orange; // The color that the item's name will be in-game.

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
				Item.scale = 1.0f;
				Item.damage = 15;
        Item.staff[Item.type] = true;


      } else {
				Item.useAmmo = -1;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ProjectileID.None;
        Item.DamageType = DamageClass.Melee;
				Item.scale = 2.0f;
				Item.damage = 30;
        Item.staff[Item.type] = false;




      }
      return base.CanUseItem(player);
    }

    public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
      const int NumProjectiles = 4; //The humber of projectiles that this gun will shoot.

      for (int i = 0; i < NumProjectiles; i++) {
        // Rotate the velocity randomly by 30 degrees at max.
        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

        // Decrease velocity randomly for nicer visuals.
        newVelocity *= 1f - Main.rand.NextFloat(0.3f);

        //Create a projectile.
        Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
      }

      return false; // Return false because we don't want tModLoader to shoot projectile
    }

    public override bool ConsumeAmmo(Player player) {
      if (player.altFunctionUse == 2) {
        return true;
      }
      return false;
    }


  }
}
