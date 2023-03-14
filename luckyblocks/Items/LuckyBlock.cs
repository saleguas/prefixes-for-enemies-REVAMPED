using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;
using luckyblocks.Dusts;
using luckyblocks.Buffs;

namespace luckyblocks.Items
{
    public class LuckyBlock : ModItem
    {
        private int timer = 300; // 300 frames = 5 seconds
        private bool start_timer = false;

        public override void SetStaticDefaults()
        {
            // add [c/ffffff:some text] to your tooltip, with #f9f909 being the colours hex code and some text being the text you want coloured 

            Tooltip.SetDefault("[c/f9f909:Try your Luck.]\n[c/FF0000:WARNING: This item can destroy blocks and cause mass destruction!]");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
                new Color(240, 240, 240),
                new Color(200, 200, 200),
                new Color(140, 140, 140)
            };
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 320;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(gold: 1);
			Item.buffType = ModContent.BuffType<LuckyBuff>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 600; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }

        public override bool CanUseItem(Player player)
        {
            // If you decide to use the below UseItem code, you have to include !NPC.AnyNPCs(id), as this is also the check the server does when receiving MessageID.SpawnBoss
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                // If the player using the item is the client
                // (explicitely excluded serverside here)
                SoundEngine.PlaySound(SoundID.MaxMana, player.position);

                // spawn a dust
                Vector2 above_position = new Vector2(player.position.X, player.position.Y - 50f);
                Dust d = Dust.NewDustPerfect(above_position, ModContent.DustType<LuckySpawn>());

				// apply modbuff LuckyBuff
            }
            return true;
        }



    }

}
