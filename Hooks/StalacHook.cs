﻿using MonoMod.Cil;
using Rhyolite.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Hooks;

internal class StalacHook : ModHook
{
	protected override void Apply()
	{
		IL_WorldGen.PaintTheSand += IL_AddStalacCheck;
		IL_WorldGen.PlaceTile += IL_AddStalacCheck;
		IL_WorldGen.PlaceTight += IL_AddStalacCheck;
		IL_WorldGen.BlockBelowMakesSandFall += IL_AddStalacCheck;
		IL_WorldGen.TileFrame += IL_AddStalacCheck;
		IL_WorldGen.UpdateWorld_OvergroundTile += IL_AddStalacCheck;
		IL_WorldGen.UpdateWorld_UndergroundTile += IL_AddStalacCheck;
		IL_WorldGen.ReplaceTile_EliminateNaturalExtras += IL_AddStalacCheck;

		On_WorldGen.GetDesiredStalagtiteStyle += On_WorldGen_GetDesiredStalactiteStyle;
	}

	private static void IL_AddStalacCheck(ILContext il)
	{
		HookUtilities.AddAlternativeIdChecks(il, TileID.Stalactite, id => TileSets.Stalac.Contains(id));
	}

	private static void On_WorldGen_GetDesiredStalactiteStyle(On_WorldGen.orig_GetDesiredStalagtiteStyle orig, int x, int j, out bool fail, out int desiredStyle, out int height, out int y)
	{
		orig(x, j, out fail, out desiredStyle, out height, out y);
		switch (fail)
		{
			case true when desiredStyle == ModContent.TileType<Tiles.Rhyolite>():
				fail = false;
				desiredStyle = 7;
				for (var i = y; i < y + height; i++)
				{
					Main.tile[x, i].TileType = (ushort)ModContent.TileType<RhyoliteStalactgmites>();
				}
				break;

			case false when Main.tile[x, j].TileType == ModContent.TileType<RhyoliteStalactgmites>():
				for (var i = y; i < y + height; i++)
				{
					Main.tile[x, i].TileType = TileID.Stalactite;
				}
				break;
		}
	}
}
