using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Items.Placeable.Furniture.Rhyolite;

public class RhyoliteBathtub : ModItem
{
    public override void SetDefaults()
    {
        Item.autoReuse = true;
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Furniture.Rhyolite.RhyoliteBathtub>();
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
            .AddIngredient(ModContent.ItemType<Tile.SmoothRhyoliteBlock>(), 14)
            .AddTile(TileID.Sawmill).Register();
    }
}
