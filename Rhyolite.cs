using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Rhyolite
{
	public class Rhyolite : Mod
	{
		public override void Load()
		{
			while (ModHook.RegisteredHooks.TryDequeue(out ModHook? hook))
			{
				hook.ApplyHook();
			}
		}
		public void BTitlesHook_SetupBiomeCheckers(out Func<Player, string> miniBiomeChecker, out Func<Player, string> biomeChecker)
		{
			miniBiomeChecker = player =>
			{


				return "";
			};
			biomeChecker = player =>
			{
				if (player.InModBiome<Biomes.Rhyolite>()) return "RhyoliteCave";

				return "";
			};
		}

		public string BTitlesHook_BiomeChecker(Player player)
		{
			if (player.InModBiome<Biomes.Rhyolite>()) return "RhyoliteCave";

			return "";
		}

		public IEnumerable<dynamic> BTitlesHook_GetBiomes()
		{
			yield return new
			{
				Key = "RhyoliteCave",
				Title = "Rhyolite Cave",
				SubTitle = "Rhyolite",
				//Icon = ModContent.Request<Texture2D>("Rhyolite/Biomes/Rhyolite_Icon").Value,
				TitleColor = new Color(150, 101, 93),
				TitleStroke = new Color(53, 40, 37),
			};
		}
	}
}
