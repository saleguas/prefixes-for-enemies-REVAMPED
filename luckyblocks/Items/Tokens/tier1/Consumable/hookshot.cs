using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.Items.Tokens;
using luckyblocks.Items.Tokens.tier1;

namespace luckyblocks.Items.Tokens.tier1.Consumable
{
    // This Example class demonstrates how to make your own weapon ammo.
    // Used by ExampleCustomAmmoGun
    public class hookshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip
                .SetDefault("If an enemy is directly below, this bullet will drop onto them."); // The item's description, can be set to whatever you want.
        }

        public override void SetDefaults()
        {
            Item.width = 14; // The width of item hitbox
            Item.height = 14; // The height of item hitbox

            Item.damage = 8; // The damage for projectiles isn't actually 8, it actually is the damage combined with the projectile and the item together
            Item.DamageType = DamageClass.Ranged; // What type of damage does this ammo affect?

            Item.maxStack = 999; // The maximum number of items that can be contained within a single stack
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible
            Item.knockBack = 2f; // Sets the item's knockback. Ammunition's knockback added together with weapon and projectiles.
            Item.value = Item.sellPrice(0, 0, 1, 0); // Item price in copper coins (can be converted with Item.sellPrice/Item.buyPrice)
            Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.
            Item.shoot = ModContent.ProjectileType<Projectiles.hookshotproj>(); // The projectile that weapons fire when using this item as ammunition.

            Item.ammo = AmmoID.Bullet;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.shootSpeed = 16f; // The speed of the projectile (measured in pixels per frame.)
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(999);
            recipe.AddIngredient<soulofchance>(1);
            recipe.AddIngredient<tier1.AmethystToken>(1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        // public override void AddRecipes() {
        // 	CreateRecipe()
        // 		.AddIngredient<ExampleItem>()
        // 		.AddTile<Tiles.Furniture.ExampleWorkbench>()
        // 		.Register();
        // }
        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        // Here we create recipe for 999/ExampleCustomAmmo stack from 1/ExampleItem
    }
}
