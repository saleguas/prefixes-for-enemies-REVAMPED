using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using prefixtest.Common;
using prefixtest.Items.Tokens;
namespace prefixtest
{
	public class prefixtest : Mod
	{

				public static int soulCurrencyID;
				public override void Load() {
			// Will show up in client.log under the ExampleMod name

					soulCurrencyID = CustomCurrencyManager.RegisterCurrency(new soulCurrencyData(ModContent.ItemType<soulshard>(), 999L));
				}
		}
	}
