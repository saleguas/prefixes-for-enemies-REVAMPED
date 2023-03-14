using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace luckyblocks.Buffs
{
	public class LuckyBuff : ModBuff
	{

        private int timer = 300; // 300 frames = 5 seconds

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Lucky?");
			Description.SetDefault("Something is about to happen...");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
            timer --;

            if (timer <= 0)
            {
                timer = 300; // Reset the timer to 300 when the dust is inactive
                int type = NPCID.Plantera;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // If the player is not in multiplayer, spawn directly
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                else
                {
                    // If the player is in multiplayer, request a spawn
                    // This will only work if NPCID.Sets.MPAllowedEnemies[type] is true, which we set in this class above
                    NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                }

                player.ClearBuff(ModContent.BuffType<LuckyBuff>());

            }
		}
	}
}
