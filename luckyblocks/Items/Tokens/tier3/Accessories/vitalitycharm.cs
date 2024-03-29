using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace luckyblocks.Items.Tokens.tier3.Accessories
{
    public class vitalitycharm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vitality Charm"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip
                .SetDefault("Grants Honey, Campfire, and Heart Lantern buffs");
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink; // The color that the item's name will be in-game.
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // GetDamage returns a reference to the specified damage class' damage StatModifier.
            // Since it doesn't return a value, but a reference to it, you can freely modify it with +-*/ operators.
            // Modifier is a structure that separately holds float additive and multiplicative modifiers.
            // When Modifier is applied to a value, its additive modifiers are applied before multiplicative ones.
            // In this case, we're multiplying by 1.20f, which will mean a 20% damage increase after every additive modifier (and a number of multiplicative modifiers) are applied.
            // Since we're using DamageClass.Generic, this bonus applies to ALL damage the player deals.
            player.AddBuff(87, 5); // campfire
            player.AddBuff(89, 5); // heart lantern
            player.AddBuff(48, 5); // honey

            // GetCrit, similarly to GetDamage, returns a reference to the specified damage class' crit chance.
            // In this case, we're adding 10% crit chance, but only for the melee DamageClass (as such, only melee weapons will receive this bonus).
            // player.GetDamage(DamageClass.Generic) *= 1.20f;
            // GetKnockback is functionally identical to GetDamage, but for the knockback stat instead.
            // In this case, we're adding 100% knockback additively, but only for our custom example DamageClass (as such, only our example class weapons will receive this bonus).
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient<soulofchance>(3);
            recipe.AddIngredient<SapphireToken>(1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
