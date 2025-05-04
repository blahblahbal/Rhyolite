﻿using Terraria;
using Terraria.ModLoader;

namespace Rhyolite.Biomes;

public class Rhyolite : ModBiome
{
	public override string BackgroundPath => base.BackgroundPath;
	public override string MapBackground => BackgroundPath;
	public override int Music => Main.curMusic;
	public override string BestiaryIcon => base.BestiaryIcon;
	public override bool IsBiomeActive(Player player)
	{
		return Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<Walls.RhyoliteWallUnsafe>() || Framing.GetTileSafely(player.Center).WallType == ModContent.WallType<Walls.SmoothRhyoliteWallUnsafe>();
	}
}
