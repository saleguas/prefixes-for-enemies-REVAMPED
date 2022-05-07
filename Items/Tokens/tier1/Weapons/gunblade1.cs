using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using prefixtest.Items.Tokens;
using prefixtest.Items.Tokens.tier1;

namespace prefixtest.Items.Tokens.tier1.Weapons
{
    public class gunblade1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gun Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip
                .SetDefault("Left click to swing. Right click to fire a bullet. \nThe gun requires one use to switch between modes.");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.scale *= 1.5f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;
            Item.noMelee = false;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 14;
            Item.knockBack = 6;
            Item.crit = 12;

            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;

            Item.shoot = ProjectileID.Bullet; // ID of the projectiles the sword will shoot
            Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot
        }

        // This method gets called when firing your weapon/sword.
        public override bool CanBeConsumedAsAmmo(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<soulofchance>(3);
            recipe.AddIngredient<AmethystToken>(1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
