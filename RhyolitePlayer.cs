using Microsoft.Xna.Framework;
using Rhyolite.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite;

internal class RhyolitePlayer : ModPlayer
{
    public bool FossilBlessing;
    public bool FossilBlessingActive;
    public Vector2[] playerOldVelocity = new Vector2[3];
    public bool GroundPoundActivated;

    public override void ResetEffects()
    {
        FossilBlessing = false;
    }
    public override void PreUpdate()
    {
        playerOldVelocity[2] = playerOldVelocity[1];
        playerOldVelocity[1] = playerOldVelocity[0];
        playerOldVelocity[0] = Player.velocity;

        if (GroundPoundActivated)
        {
            if (!Player.IsOnGroundPrecise())
            {
                Player.velocity.Y = 20f * Player.gravDir;
            }
            if (Player.velocity.Y > 0)
            {
                for (int x = 0; x < 5; x++)
                {
                    int d = Dust.NewDust(new Vector2(Player.Center.X, Player.position.Y + Player.height), 10, 10, DustID.Smoke);
                }
            }
            if (Main.rand.NextBool(20))
            {
                int D = Dust.NewDust(Player.position, Player.width, Player.height, 9, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D].noGravity = true;
                Main.dust[D].velocity.X *= 1.2f;
                Main.dust[D].velocity.X *= 1.2f;
            }
            if (Main.rand.NextBool(20))
            {
                int D2 = Dust.NewDust(Player.position, Player.width, Player.height, 9, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D2].noGravity = true;
                Main.dust[D2].velocity.X *= -1.2f;
                Main.dust[D2].velocity.X *= 1.2f;
            }
            if (Main.rand.NextBool(20))
            {
                int D3 = Dust.NewDust(Player.position, Player.width, Player.height, 9, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D3].noGravity = true;
                Main.dust[D3].velocity.X *= 1.2f;
                Main.dust[D3].velocity.X *= -1.2f;
            }
            if (Main.rand.NextBool(20))
            {
                int D4 = Dust.NewDust(Player.position, Player.width, Player.height, 9, (Player.velocity.X * 0.2f) + (Player.direction * 3), Player.velocity.Y * 1.2f, 60, new Color(), 1f);
                Main.dust[D4].noGravity = true;
                Main.dust[D4].velocity.X *= -1.2f;
                Main.dust[D4].velocity.X *= -1.2f;
            }
        }
    }
    public override void PostUpdateEquips()
    {
        if (!FossilBlessing)
        {
            FossilBlessingActive = false;
        }
        if (FossilBlessing && !Player.mount.Active && Player.DoublePressedReversedSetBonusActivateKey())
        {
            Main.NewText(FossilBlessingActive);
            if (FossilBlessingActive)
            {
                FossilBlessingActive = false;
            }
            else if (!Player.HasBuff<FossilBlessingCooldown>())
            {
                FossilBlessingActive = true;
                Player.AddBuff(ModContent.BuffType<FossilBlessing>(), 10 * 60);
                Player.AddBuff(ModContent.BuffType<FossilBlessingCooldown>(), 60 * 1);
            }
        }

        if (!FossilBlessing && Player.HasBuff<FossilBlessing>())
        {
            Player.ClearBuff(ModContent.BuffType<FossilBlessing>());
        }
    }
}
