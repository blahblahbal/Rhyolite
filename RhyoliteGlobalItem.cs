using Rhyolite.Items.Placeable.Tile;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite;

public class RhyoliteGlobalItem : GlobalItem
{
	public override void SetStaticDefaults()
	{
		ItemID.Sets.ShimmerTransformToItem[ItemID.Marble] = ItemID.Granite;
		ItemID.Sets.ShimmerTransformToItem[ItemID.Granite] = ModContent.ItemType<RhyoliteBlock>();
		ItemID.Sets.ShimmerTransformToItem[ModContent.ItemType<RhyoliteBlock>()] = ItemID.Marble;
	}
}
