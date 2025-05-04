using Terraria;

namespace Rhyolite.Hooks;

internal class PlayerFallSpeedHook : ModHook
{
    protected override void Apply()
    {
        On_Player.Update += On_Player_Update;
        On_Player.ResizeHitbox += On_Player_ResizeHitbox;
    }

    private void On_Player_ResizeHitbox(On_Player.orig_ResizeHitbox orig, Player self)
    {
        if (self.GetModPlayer<RhyolitePlayer>().GroundPoundActivated)
        {
            self.maxFallSpeed = 25f;
        }
        orig.Invoke(self);
    }

    private void On_Player_Update(On_Player.orig_Update orig, Player self, int i)
    {
        orig.Invoke(self, i);
        if (self.GetModPlayer<RhyolitePlayer>().GroundPoundActivated)
        {
            self.maxFallSpeed = 10f;
        }
    }
}
