using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.Common.GlobalNPCs;

namespace luckyblocks.Items.Tokens.tier3.Weapons
{
    public class hourglass : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Hourglass"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip
                .SetDefault("Enter stasis for 5 seconds. \n You cannot take damage in stasis, but you are stunned.\n60 second cooldown.");
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 42; // Hitbox width of the item.
            Item.height = 60; // Hitbox height of the item.
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.HoldUp; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.UseSound = SoundID.Item37; // The sound that this item plays when used.
            Item.shoot = 1;
        }

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
            // Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
            var player2 = player.GetModPlayer<zhonyasPlayer>();
            player2.zhonyasTimer = player2.zhonyasDuration;

            // Main.NewText($"{player2.zhonyasTimer} {player2.zhonyasDuration} hello");
            return false;
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
