using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace prefixtest.Items.Tokens.tier3.Weapons{
	public class tuningfork : ModItem{

    private int charges = 0;
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Why are you using a tuning fork to fight?\n Hitting true melee charges up the fork, right click to release it!"); //The (English) text shown below your weapon's name.
			DisplayName.SetDefault("Tuning Fork");
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.noMelee = false;

			Item.DamageType = DamageClass.Melee;
			Item.damage = 69;
			Item.knockBack = 3;
			Item.crit = 28;
			Item.value = Item.buyPrice(gold: 35);
			Item.UseSound = SoundID.Item1;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
         charges++;
    }

    public override bool AltFunctionUse(Player player) {
      return true;
    }

    public override bool CanUseItem(Player player) {
      if (player.altFunctionUse == 2 && charges > 0) {
  			Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
        Item.useTime = 20; // The item's use time in ticks (60 ticks == 1 second.)
        Item.useAnimation = 20; // The length of the item's use animation in ticks (60 ticks == 1 second.)
        Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
        Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
        Item.damage = 18;
        Item.shoot = 76;

      } else {
        Item.useStyle = ItemUseStyleID.Swing;
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
          Projectile.NewProjectile(source, position, angle1, 76, damage, knockback, player.whoAmI);
          Projectile.NewProjectile(source, position, angle2, 77, damage, knockback, player.whoAmI);
          Projectile.NewProjectile(source, position, angle3, 78, damage, knockback, player.whoAmI);
        }
        charges = 0;


      }

      return false;
      // 	int a = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);


    }
		//when right click fire music notes , amount depending on counter projectile name is "TiedEighthNote" fire like a shotgun

	}
}
