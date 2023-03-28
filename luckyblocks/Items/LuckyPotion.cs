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
    public class LuckyPotion : ModItem
    {
        private int timer = 300; // 300 frames = 5 seconds
        private bool start_timer = false;

        public override void SetStaticDefaults()
        {
            // add [c/ffffff:some text] to your tooltip, with #f9f909 being the colours hex code and some text being the text you want coloured 

            Tooltip.SetDefault("[c/f9f909:A lucky potion?.]");

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
                int maxBuffId = 337;
                int minBuffId = 1;

                // pick a random buff inclusive
                int randomBuff = Main.rand.Next(minBuffId, maxBuffId + 1);

                // pick a random time for the buff, 1 second to 5 minutes

                int randomTime = Main.rand.Next(600, 36000);

                player.AddBuff(randomBuff, randomTime);
            }
            return true;
        }



    }

}
