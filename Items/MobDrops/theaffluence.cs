using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace prefixtest.Items.MobDrops
{
    public class theaffluence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Affluence"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Money is power.");
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 16; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 2; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 2; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.UseSound = SoundID.Item11; // The sound that this item plays when used.

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 45; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            // Gun Properties
            Item.shoot = 158; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        // public override Vector2? HoldoutOffset() {
        // 	return new Vector2(2f, -2f);
        // }
        public override bool
        Shoot(
            Player player,
            EntitySource_ItemUse_WithAmmo source,
            Vector2 position,
            Vector2 velocity,
            int type,
            int damage,
            float knockback
        )
        {
            // Vector2 perturbedSpeed = new Vector2(0, velocity.Y);
            // position.X += 200f;
            Vector2 velocity2 =
                new Vector2(velocity.X + Main.rand.NextFloat(-10f, 10f),
                    velocity.Y + Main.rand.NextFloat(-10f, 10f));
            velocity2 = Vector2.Normalize(velocity2) * 3f;
            int a =
                Projectile
                    .NewProjectile(source,
                    position,
                    velocity2,
                    type,
                    damage,
                    knockback,
                    player.whoAmI);


            Vector2 velocity3 =
                new Vector2(velocity.X + Main.rand.NextFloat(-50f, 50f),
                    velocity.Y + Main.rand.NextFloat(-50f, 50f));

            velocity3 = Vector2.Normalize(velocity3) * 4f;
            int b =
                Projectile
                    .NewProjectile(source,
                    position,
                    velocity3,
                    159,
                    damage+10,
                    knockback,
                    player.whoAmI);

            Vector2 velocity4 =
                new Vector2(velocity.X + Main.rand.NextFloat(-5f, 5f),
                    velocity.Y + Main.rand.NextFloat(-5f, 5f));
            velocity4 = Vector2.Normalize(velocity4) * 6f;

            int c =
                Projectile
                    .NewProjectile(source,
                    position,
                    velocity4,
                    160,
                    damage+10,
                    knockback,
                    player.whoAmI);

            Vector2 velocity5 =
                new Vector2(velocity.X + Main.rand.NextFloat(-2f, 2f),
                    velocity.Y + Main.rand.NextFloat(-2f, 2f));

            velocity5 = Vector2.Normalize(velocity5) * 7f;
            int d =
                Projectile
                    .NewProjectile(source,
                    position,
                    velocity5,
                    160,
                    damage,
                    knockback,
                    player.whoAmI);

            return false;
        }

        // public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        // 	int a = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
        // 		Main.projectile[a].friendly = true;
        // 		Main.projectile[a].hostile = false;
        // 	return false;
        // }

        /*
     * Feel free to uncomment any of the examples below to see what they do
     */

        // What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
        // Uzi/Molten Fury style: Replace normal Bullets with High Velocity
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
    	if (type == ProjectileID.Bullet) { // or ProjectileID.WoodenArrowFriendly
    		type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
    	}
    }*/

        // What if I wanted multiple projectiles in a even spread? (Vampire Knives)
        // Even Arc style: Multiple Projectile, Even Spread
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
    	float numberProjectiles = 3 + Main.rand.Next(3); // 3, 4, or 5 shots
    	float rotation = MathHelper.ToRadians(45);

    	position += Vector2.Normalize(velocity) * 45f;

    	for (int i = 0; i < numberProjectiles; i++) {
    		Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
    		Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
    	}

    	return false; // return false to stop vanilla from calling Projectile.NewProjectile.
    }*/

        // How can I make the shots appear out of the muzzle exactly?
        // Also, when I do this, how do I prevent shooting through tiles?
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
    	Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

    	if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
    		position += muzzleOffset;
    	}
    }*/

        // How can I get a "Clockwork Assault Rifle" effect?
        // 3 round burst, only consume 1 ammo for burst. Delay between bursts, use reuseDelay
        /*	The following changes to SetDefaults()
    	item.useAnimation = 12;
    	item.useTime = 4; // one third of useAnimation
    	item.reuseDelay = 14;
    public override bool ConsumeAmmo(Player player)	{
    	// Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (useAnimation - 1, then - useTime until less than 0.)
    	// We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
    	return !(player.itemAnimation < item.useAnimation - 2);
    }*/

        // How can I shoot 2 different projectiles at the same time?
        /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo  source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
    	// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
    	Projectile.NewProjectile(source, position, velocity, ProjectileID.GrenadeI, damage, knockback, player.whoAmI);

    	// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
    	return true;
    }*/

        // How can I choose between several projectiles randomly?
        /*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
    	// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
    	type = Main.rand.Next(new int[] { type, ProjectileID.GoldenBullet, ProjectileType<Projectiles.ExampleBullet>() });
    }*/
    }
}
