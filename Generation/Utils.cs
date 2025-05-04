using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Rhyolite.Generation;

public class Utils
{
	public static bool IsInsideEllipse(int x, int y, Vector2 center, int xRadius, int yRadius)
	{
		float dx = x - center.X;
		float dy = y - center.Y;
		return (dx * dx) / (xRadius * xRadius) + (dy * dy) / (yRadius * yRadius) <= 1;
	}
	public static void MakeCircleNormal(int x, int y, int r, ushort tileType, ushort wallType = 0)
	{
		for (int k = x - r; k <= x + r; k++)
		{
			for (int l = y - r; l <= y + r; l++)
			{
				if (Vector2.Distance(new Vector2(k, l), new Vector2(x, y)) < r)
				{
					Tile t = Framing.GetTileSafely(k, l);
					t.HasTile = true;
					t.IsHalfBlock = false;
					t.Slope = SlopeType.Solid;
					Main.tile[k, l].TileType = tileType;
					WorldGen.SquareTileFrame(k, l);
				}
				if (wallType != 0 && k > 0 && l > 0)
				{
					Main.tile[k, l].WallType = wallType;
				}
			}
		}
	}
	public static void PlaceCustomTight(int x, int y, ushort type)
	{
		if (Main.tile[x, y].LiquidType != LiquidID.Shimmer)
		{
			PlaceUncheckedStalactite(x, y, WorldGen.genRand.NextBool(2), WorldGen.genRand.Next(3), type);
		}
	}

	public static void PlaceUncheckedStalactite(int x, int y, bool preferSmall, int variation, ushort type)
	{
		variation = Terraria.Utils.Clamp(variation, 0, 2);
		if (WorldGen.SolidTile(x, y - 1) && !Main.tile[x, y].HasTile && !Main.tile[x, y + 1].HasTile)
		{
			if (Main.tile[x, y - 1].TileType == ModContent.TileType<Tiles.Rhyolite>())
			{
				if (preferSmall)
				{
					int num12 = variation * 18;
					Tile t = Main.tile[x, y];
					WorldGen.PlaceTile(x, y, type);
					t.TileFrameX = (short)num12;
					t.TileFrameY = 72;
				}
				else
				{
					int num15 = variation * 18;
					Tile t = Main.tile[x, y];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num15;
					t.TileFrameY = 0;
					t = Main.tile[x, y + 1];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num15;
					t.TileFrameY = 18;
				}
			}
		}
		else if (WorldGen.SolidTile(x, y + 1) && !Main.tile[x, y].HasTile && !Main.tile[x, y - 1].HasTile)
		{
			if (Main.tile[x, y + 1].TileType == ModContent.TileType<Tiles.Rhyolite>())
			{
				if (preferSmall)
				{
					int num5 = variation * 18;
					Tile t = Main.tile[x, y];
					t.TileType = type;
					t.HasTile = true;
					t.TileFrameX = (short)num5;
					t.TileFrameY = 90;
				}
				else
				{
					int num6 = variation * 18;
					Tile t = Main.tile[x, y - 1];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num6;
					t.TileFrameY = 36;
					t = Main.tile[x, y];
					t.HasTile = true;
					t.TileType = type;
					t.TileFrameX = (short)num6;
					t.TileFrameY = 54;
				}
			}
		}
	}
}
