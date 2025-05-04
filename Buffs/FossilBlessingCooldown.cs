using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Rhyolite.Buffs;

public class FossilBlessingCooldown : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
	}
}
