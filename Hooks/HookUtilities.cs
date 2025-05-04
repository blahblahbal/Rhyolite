using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhyolite.Hooks;

internal class HookUtilities
{
	public static void AddAlternativeIdChecks(ILContext il, ushort origId, Func<ushort, bool> predicate)
	{
		var c = new ILCursor(il);

		while (c.TryGotoNext(i =>
				   (i.MatchBeq(out _) || i.MatchBneUn(out _)) && i.Offset != 0 && i.Previous.MatchLdcI4(origId)))
		{
			c.Index--;
			c.EmitDelegate<Func<ushort, ushort>>(id => predicate.Invoke(id) ? origId : id);
			c.Index += 2;
		}
	}
}
