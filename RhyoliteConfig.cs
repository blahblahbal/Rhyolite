using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Rhyolite;

internal class RhyoliteConfigLimiter : ModSystem
{
    public override void PostSetupContent()
    {
        if (ModContent.GetInstance<RhyoliteConfig>().NumCaves < 2) ModContent.GetInstance<RhyoliteConfig>().NumCaves = 2;
        if (ModContent.GetInstance<RhyoliteConfig>().NumCaves > 4) ModContent.GetInstance<RhyoliteConfig>().NumCaves = 4;
    }
}
internal class RhyoliteConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;
    [Header("$Mods.Rhyolite.Config.ItemHeader")]
    [DefaultValue(2)] // This sets the configs default value.
    [ReloadRequired]
    public int NumCaves;
}
