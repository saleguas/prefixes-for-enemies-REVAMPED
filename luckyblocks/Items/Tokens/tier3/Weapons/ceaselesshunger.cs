using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace luckyblocks.Items.Tokens.tier3.Weapons
{
    public class ceaselesshunger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ceaseless Hunger"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip
                .SetDefault("Consume your foes. \n Shoots a swarm of ravenous skulls.");
        }

        public override void SetDefaults()
        {
            Item.width = 32; //The item texture's width.
            Item.height = 32; //The item texture's height.

            Item.useStyle = 5; // How you use the item (swinging, holding out, etc.)
            Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.

            Item.DamageType = DamageClass.Magic; //Whether your item is part of the melee class.
            Item.damage = 45; //The damage your item deals.
            Item.knockBack = 20; //The force of knockback of the weapon. Maximum is 20
            Item.crit = 73; //The critical strike chance the weapon has. The player, by default, has a 4% critical strike chance.
            Item.scale = 1.0f;
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.

            Item.value = Item.buyPrice(gold: 1); //The value of the weapon in copper coins.
            Item.UseSound = SoundID.Item1; //The sound when the weapon is being used.

            Item.shoot = 270;
            Item.shootSpeed = 8f;
        }

        // This method gets called when firing your weapon/sword.
        // Item.useAmmo = ModContent.ItemType<blazereap4>();
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
            const int NumProjectiles = 5; //The humber of projectiles that this gun will shoot.

            for (int i = 0; i < NumProjectiles; i++)
            {
                // Rotate the velocity randomly by 30 degrees at max.
                Vector2 newVelocity =
                    velocity.RotatedByRandom(MathHelper.ToRadians(15));

                // Decrease velocity randomly for nicer visuals.
                newVelocity *= 1f - Main.rand.NextFloat(0.3f);

                //Create a projectile.
                int a =
                    Projectile
                        .NewProjectile(source,
                        position,
                        newVelocity,
                        type,
                        damage,
                        knockback,
                        player.whoAmI);
                Main.projectile[a].friendly = true;
                Main.projectile[a].hostile = false;
            }

            return false; // Return false because we don't want tModLoader to shoot projectile
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<soulofchance>(3);
            recipe.AddIngredient<SapphireToken>(1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
