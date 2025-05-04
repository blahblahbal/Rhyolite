using Microsoft.Xna.Framework;
using Rhyolite.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Tiles;

public class SmoothRhyolite : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(134, 85, 77));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        DustType = ModContent.DustType<RhyoliteDust>();
		HitSound = SoundID.Tink;
		TileID.Sets.GeneralPlacementTiles[Type] = false;
	}
}
