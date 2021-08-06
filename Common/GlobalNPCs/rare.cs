using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Graphics.Shaders;

namespace prefixtest.Common.GlobalNPCs
{
	public class rare : GlobalNPC
	{

		public bool nameChanged = false;
		public override bool InstancePerEntity => true;
    private string prefix;


		public override bool AppliesToEntity(NPC npc, bool lateInstatiation) {
			if (npc.townNPC == true)
				return false;

      Random random = new Random();
      double roll1 = random.NextDouble();

      return roll1 <= 1; // 0.02
		}


		public override void SetDefaults(NPC npc)
		{
				// Main.NewText($"{npc.GivenName}  {npc.FullName} {npc.getName()}");
				prefix = "Rare";
        // if (NPC.downedAncientCultist)
        // {
        //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmberToken"));
        // }
        // else if (NPC.downedPlantBoss)
        // {
        //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RubyToken"));
        // }
        // else if (NPC.downedMechBossAny)
        // {
        //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmeraldToken"));
        // }
        // else if (Main.hardMode)
        // {
        //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SapphireToken"));
        // }
        // else if (NPC.downedBoss3 || NPC.downedQueenBee)
        // {
        //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TopazToken"));
        // }
        // else
        // {
        //     Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmethystToken"));
        // }
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{

				Lighting.AddLight(npc.position, 0.415f, 0.343f, 0.108f);
				int dust = Dust.NewDust(npc.position, npc.width + 4, npc.height + 4, 10, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 2f);
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
			if (!nameChanged){
				npc.GivenName = prefix + " " + npc.FullName;
				nameChanged = true;
			}
			// npc.scale = 1.5f;
			// npc.color = Color.ForestGreen;

		}

		public override void OnKill(NPC npc) {

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronBar, 10);

			//TODO: Add the rest of the vanilla drop rules!!
		}


	}
}
