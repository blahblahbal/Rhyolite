using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Items.Placeable.Furniture.Rhyolite;

public class RhyoliteClock : ModItem
{
    public override void SetDefaults()
    {
        
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteClock>();
        Item.width = 16;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 9999;
        Item.value = 300;
        Item.useAnimation = 15;
        Item.height = 16;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddRecipeGroup("IronBar", 3)
            .AddIngredient(ItemID.Glass, 6)
            .AddIngredient(ModContent.ItemType<Tile.SmoothRhyoliteBlock>(), 10)
            .AddTile(TileID.Sawmill).Register();
    }
}
