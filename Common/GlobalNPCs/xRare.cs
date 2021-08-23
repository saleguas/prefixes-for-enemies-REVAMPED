using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Graphics.Shaders;
using prefixtest.Items.Tokens.tier1;
using prefixtest.Items.Tokens.tier2;
using prefixtest.Items.Tokens.tier3;
using prefixtest.Items.Tokens.tier4;
using prefixtest.Items.Tokens.tier5;

namespace prefixtest.Common.GlobalNPCs
{
	public class xRare : GlobalNPC
	{

		public bool nameChanged = false;
		public override bool InstancePerEntity => true;
    private string prefix;


		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			if (npc.townNPC == true || npc.friendly == true)
				return false;

      Random random = new Random();
      double roll1 = random.NextDouble();

			npc.netUpdate = true;


			return roll1 <= (double) (ModContent.GetInstance<modconfig>().RareChance * 0.01);
		}


		public override void SetDefaults(NPC npc)
		{
				// Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
				prefix = "Rare";



		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
				if(Main.rand.Next(5) == 1){
					Lighting.AddLight(npc.position, 0.410f, 0.340f, 0.100f);
					int dust = Dust.NewDust(npc.position, npc.width+5, npc.height+5, 204, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.89f);
			}

		}
		public override bool PreAI(NPC npc){
			if (prefix.Contains("Rare") && npc.value == 0f && npc.npcSlots == 0f)
			{
									prefix = "";

			}
			return base.PreAI(npc);
		}
		public override void AI(NPC npc) {
			//Make the guide giant and green.
			if(!nameChanged){
				npc.GetGlobalNPC<prefixString>().prefix = prefix + " " +npc.GetGlobalNPC<prefixString>().prefix;
				nameChanged = true;
				npc.netUpdate = true;

		}


			// npc.scale = 1.5f;
			// npc.color = Color.ForestGreen;

		}

		public override void OnKill(NPC npc) {


			if (NPC.downedMoonlord){
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DiamondToken>());
			}
			else if (NPC.downedPlantBoss)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EmeraldToken>());

			}
			else if (Main.hardMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SapphireToken>());

			}
			else if (NPC.downedBoss3 || NPC.downedQueenBee)
			{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TopazToken>());
			}
			else{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AmethystToken>());
			}
			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
