using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rhyolite.NPCs;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.GameContent.Drawing.TileDrawing;

namespace Rhyolite.Tiles;

public class MonsterBanner : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.newTile.DrawYOffset = -2;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
        TileObjectData.newAlternate.DrawYOffset = -10;
        TileObjectData.addAlternate(0);
        TileObjectData.addTile(Type);
        DustType = -1;
        TileID.Sets.DisableSmartCursor[Type] = true;
        AddMapEntry(new Color(13, 88, 130));
    }
    public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
    {
        Tile tile = Main.tile[i, j];
        int topLeftX = i - tile.TileFrameX / 18 % 1;
        int topLeftY = j - tile.TileFrameY / 18 % 3;
        if (WorldGen.IsBelowANonHammeredPlatform(topLeftX, topLeftY))
        {
            offsetY -= -2;
        }
    }
    public override void NearbyEffects(int i, int j, bool closer)
    {
        if (closer)
        {
            Player player = Main.LocalPlayer;
            int style = Main.tile[i, j].TileFrameX / 18;
            int t = 1;
            switch (style)
            {
                case 0:
                    t = ModContent.NPCType<RhyoliteSlimer>();
                    break;
                case 1:
                    t = ModContent.NPCType<LavaWormHead>();
                    break;
                default:
                    t = 0;
                    return;
            }
            //Main.SceneMetrics.NPCBannerBuff[Mod.Find<ModNPC>(type).Type] = true;
            Main.SceneMetrics.NPCBannerBuff[t] = true;
            Main.SceneMetrics.hasBanner = true;
            //player.hasBannerBuff = true;
        }
    }

    public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
    {
        if (i % 2 == 1)
        {
            spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        bool intoRenderTargets = true;
        bool flag = intoRenderTargets || Main.LightingEveryFrame;

        if (Main.tile[i, j].TileFrameX % 18 == 0 && Main.tile[i, j].TileFrameY % 54 == 0 && flag)
        {
            Main.instance.TilesRenderer.AddSpecialPoint(i, j, TileCounterType.MultiTileVine);
        }

        return false;
    }
}
