using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Additional regen data that only players have
	/// </summary>
	public class CharacterRegenerationData {
		public ushort HP;
		public ushort SP;
		public long TickHP;
		public long TickSP;
		public byte RateHP;
		public byte RateSP;

	}

}
