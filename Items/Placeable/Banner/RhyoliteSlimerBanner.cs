﻿using Rhyolite.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Items.Placeable.Banner;

public class RhyoliteSlimerBanner : ModItem
{
	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<MonsterBanner>(), 0);
		Item.width = 10;
		Item.height = 24;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.buyPrice(silver: 10);
	}
}
