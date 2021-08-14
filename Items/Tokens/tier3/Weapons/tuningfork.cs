using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;


namespace prefixtest.Items.Tokens.tier3.Weapons{
	public class tuningfork : ModItem{

    private int charges = 0;
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Why are you using a tuning fork to fight?\n Hitting true melee charges up the fork, right click to release all charges!"); //The (English) text shown below your weapon's name.
			DisplayName.SetDefault("Tuning Fork");
		}

		public override void SetDefaults() {
			Item.width = 52;
			Item.height = 52;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.noMelee = false;
			Item.scale *= 2f;

			Item.DamageType = DamageClass.Melee;
			Item.damage = 45;
			Item.knockBack = 3;
			Item.crit = 28;
			Item.value = Item.buyPrice(gold: 35);
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
         charges++;
    }

    public override bool AltFunctionUse(Player player) {
      return true;
    }

    public override bool CanUseItem(Player player) {
      if (player.altFunctionUse == 2) {
				if (charges  == 0){
					return false;
				}
  			Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
        Item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
        Item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
        Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
        Item.damage = 18;
        Item.shoot = 76;

      } else {
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.UseSound = SoundID.Item1;
        Item.damage = 19;
        Item.shoot = ProjectileID.None;




      }
      return base.CanUseItem(player);
    }

    public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
      // Vector2 perturbedSpeed = new Vector2(0, velocity.Y);
      // position.X += 200f;

      if (player.altFunctionUse == 2){
        for(int i = 0; i < charges; i++){
          Vector2 angle1 = new Vector2(velocity.X + Main.rand.NextFloat(-10f, 10f), velocity.Y + Main.rand.NextFloat(-10f, 10f));
          Vector2 angle2 = new Vector2(velocity.X + Main.rand.NextFloat(-10f, 10f), velocity.Y + Main.rand.NextFloat(-10f, 10f));
          Vector2 angle3 = new Vector2(velocity.X + Main.rand.NextFloat(-10f, 10f), velocity.Y + Main.rand.NextFloat(-10f, 10f));
          Projectile.NewProjectile(source, position, angle1, 76, (int)(damage * 1.5f * Math.Min(10,charges)), knockback, player.whoAmI);
          Projectile.NewProjectile(source, position, angle2, 77, (int)(damage * 1.5f * Math.Min(10,charges)), knockback, player.whoAmI);
          Projectile.NewProjectile(source, position, angle3, 78, (int)(damage * 1.5f * Math.Min(10,charges)), knockback, player.whoAmI);
        }
        charges = 0;


      }

      return false;
      // 	int a = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);


    }
		//when right click fire music notes , amount depending on counter projectile name is "TiedEighthNote" fire like a shotgun

	}
}
