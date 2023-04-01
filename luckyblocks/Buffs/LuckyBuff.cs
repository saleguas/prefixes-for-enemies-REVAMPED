using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using luckyblocks.NPCs;
using luckyblocks.Buffs;


namespace luckyblocks.Buffs
{
    public class LuckyBuff : ModBuff
    {

        private int timer = 300; // 300 frames = 5 seconds




        private List<Tuple<Action<Player>, int>> weightedFunctions;
        private EventFunctions eventFunctions = new EventFunctions();
        public LuckyBuff()
        {
            weightedFunctions = new List<Tuple<Action<Player>, int>>{
                new Tuple<Action<Player>, int>(eventFunctions.SpawnRichMan, 2),
                new Tuple<Action<Player>, int>(eventFunctions.HealAllPlayers, 1),
                new Tuple<Action<Player>, int>(eventFunctions.bunnySplosion, 2),
                new Tuple<Action<Player>, int>(eventFunctions.MoneySpawn, 3),
                new Tuple<Action<Player>, int>(eventFunctions.MakeItSlimeRain, 2),
                new Tuple<Action<Player>, int>(eventFunctions.MakeItRain, 2),
                new Tuple<Action<Player>, int>(eventFunctions.ChangeTime, 2),
                new Tuple<Action<Player>, int>(eventFunctions.ScrambleAllLocation, 1),
                new Tuple<Action<Player>, int>(eventFunctions.ScrambleLocation, 2),
                new Tuple<Action<Player>, int>(eventFunctions.MassiveExplosion, 2),
                new Tuple<Action<Player>, int>(eventFunctions.EveryoneDropMoney, 2),
                new Tuple<Action<Player>, int>(eventFunctions.Everyone1hp, 1),
                new Tuple<Action<Player>, int>(eventFunctions.EveryoneOnFire, 2),
                new Tuple<Action<Player>, int>(eventFunctions.PlayerCombustion, 1),
                new Tuple<Action<Player>, int>(eventFunctions.ArrowRain, 1),
                new Tuple<Action<Player>, int>(eventFunctions.MakeInvasionHappen, 1),
                new Tuple<Action<Player>, int>(eventFunctions.SpawnRandomBoss, 1),
                new Tuple<Action<Player>, int>(eventFunctions.MassiveExplosion, 1),
                new Tuple<Action<Player>, int>(eventFunctions.GiveAllRandomBuff, 1),
                new Tuple<Action<Player>, int>(eventFunctions.GivePlayerRandomBuff, 2),
                new Tuple<Action<Player>, int>(eventFunctions.SpawnRandomItem, 3),
                new Tuple<Action<Player>, int>(eventFunctions.SpawnRandomEntity, 3),
                new Tuple<Action<Player>, int>(eventFunctions.MissileBombardment, 1),
                new Tuple<Action<Player>, int>(eventFunctions.SlowDeath, 3),
                new Tuple<Action<Player>, int>(eventFunctions.HealByOne, 2),
                new Tuple<Action<Player>, int>(eventFunctions.goldenAnimalSplosion, 1),
                new Tuple<Action<Player>, int>(eventFunctions.BoulderfistOgre, 2),
                new Tuple<Action<Player>, int>(eventFunctions.GetRandomArmor, 3),
                new Tuple<Action<Player>, int>(eventFunctions.SpawnLoser, 1),
                new Tuple<Action<Player>, int>(eventFunctions.ConcotionPackage, 1),
                new Tuple<Action<Player>, int>(eventFunctions.GetModdedItem, 1),
                new Tuple<Action<Player>, int>(eventFunctions.GetLuckyPotion, 1),
                new Tuple<Action<Player>, int>(eventFunctions.GasLight, 1),

            };
        }

        public void ExecuteRandomFunction(Player player)
        {
            int totalWeight = 0;
            foreach (var weightedFunction in weightedFunctions)
            {
                totalWeight += weightedFunction.Item2;
            }

            int randomWeight = Main.rand.Next(totalWeight);
            int currentWeight = 0;

            foreach (var weightedFunction in weightedFunctions)
            {
                currentWeight += weightedFunction.Item2;
                if (randomWeight < currentWeight)
                {
                    weightedFunction.Item1(player);
                    break;
                }
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lucky?");
            Description.SetDefault("Something is about to happen...");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            timer--;

            if (timer <= 0)
            {
                timer = 300; // Reset the timer to 300 when the dust is inactive

                string test = "y";
                if (test != "")
                {
                    eventFunctions.GasLight(player);
                }
                else
                {
                    ExecuteRandomFunction(player);
                }


                player.ClearBuff(ModContent.BuffType<LuckyBuff>());

            }


            // draw gold dust around the player

            for (int i = 0; i < 12; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                // the dust is drawn as a rectangle starting at 0,0 with a width and height of 30,30
                // we need to offset the position by half the width and height to center the dust 
                Vector2 dust_pos = player.position;
                Dust d = Dust.NewDustDirect(dust_pos, player.width, player.height, DustID.IchorTorch);
                d.noGravity = true;
                // GemTopaz
            }
        }

        
    }
}
