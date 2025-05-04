using Microsoft.Xna.Framework;
using Terraria;

namespace Rhyolite;

public static class ClassExtensions
{
	public static Rectangle Expand(this Rectangle r, int xDist, int yDist)
	{
		r.X -= xDist;
		r.Y -= yDist;
		r.Width += xDist * 2;
		r.Height += yDist * 2;
		return r;
	}
	public static bool InPillarZone(this Player p)
	{
		if (!p.ZoneTowerStardust && !p.ZoneTowerVortex && !p.ZoneTowerSolar)
		{
			return p.ZoneTowerNebula;
		}

		return true;
	}

    public static bool DoublePressedReversedSetBonusActivateKey(this Player player)
    {
        return (player.doubleTapCardinalTimer[Main.ReversedUpDownArmorSetBonuses ? 0 : 1] < 15 && ((player.releaseDown && Main.ReversedUpDownArmorSetBonuses && player.controlDown) || (player.releaseUp && !Main.ReversedUpDownArmorSetBonuses && player.controlUp)));
    }

    public static bool DoublePressedDown(this Player player)
    {
        return player.doubleTapCardinalTimer[0] < 15 && player.releaseDown && player.controlDown;
    }

    public static bool IsOnGroundPrecise(this Player player)
    {
        for (int i = 0; i < 3; i++)
        {
            var tileX = Main.tile[(int)((player.position.X + (player.width * i / 2f)) / 16f), (int)((player.position.Y + (player.gravDir == 1 ? player.height + 1 : -1)) / 16f)];

            if (tileX.HasTile && (Main.tileSolid[tileX.TileType] || Main.tileSolidTop[tileX.TileType]) && player.velocity.Y == 0f)
            {
                return true;
            }
        }
        return false;
    }
    public static bool IsOnGround(this Player player)
    {
        for (int i = 0; i < 3; i++)
        {
            var tileX = Main.tile[(int)((player.position.X + (player.width * i / 2f)) / 16f), (int)(player.position.Y / 16f) + 1 + (int)(2 * player.gravDir)];

            if (tileX.HasTile && (Main.tileSolid[tileX.TileType] || Main.tileSolidTop[tileX.TileType]) && player.velocity.Y == 0f)
            {
                return true;
            }
        }
        return false;
    }
}
