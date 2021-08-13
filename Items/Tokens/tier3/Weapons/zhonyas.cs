using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using prefixtest.Common.GlobalNPCs;
namespace prefixtest.Items.Tokens.tier3.Weapons
{
	public class zhonyas : ModItem
	{
    private int zhonyascounter = 6000;
		public override void SetStaticDefaults() {
      DisplayName.SetDefault("Zhonyas Hourglass"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Enter stasis for 5 seconds. \n You cannot take damage in stasis, but you are stunned.");
		}

		public override void SetDefaults() {
			// Common Properties
			Item.width = 16; // Hitbox width of the item.
			Item.height = 32; // Hitbox height of the item.
			Item.rare = ItemRarityID.Green; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 8; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 8; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			Item.shoot = ProjectileID.PurificationPowder;


		}



		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
      var player2 = player.GetModPlayer<zhonyasPlayer>();
			player2.zhonyasTimer = player2.zhonyasDuration;
      return false;
    }

    }

	}
