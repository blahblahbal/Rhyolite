using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Items
{
	internal class WorldgenHelper : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
		{
			return false;
		}
		public override void SetDefaults()
		{
			Item.rare = ItemRarityID.Purple;
			Item.width = 16;
			Item.maxStack = 1;
			Item.useAnimation = Item.useTime = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = 0;
			Item.height = 16;
			Item.autoReuse = true;
		}

		public override bool? UseItem(Player player)
		{
			int x = (int)Main.MouseWorld.X / 16;
			int y = (int)Main.MouseWorld.Y / 16;

			if (player.ItemAnimationJustStarted)
			{
				//Generation.Biomes.Rhyolite.PlaceWallPool(x, y, -1);
				Generation.Biomes.Rhyolite.PlaceRhyolite(x, y);
			}
			return false;
		}
	}
}
