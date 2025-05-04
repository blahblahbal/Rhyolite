using Microsoft.Xna.Framework;
using Rhyolite.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Walls;

public class SmoothRhyoliteWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(50, 30, 27));
        DustType = ModContent.DustType<RhyoliteDust>();
    }
}
