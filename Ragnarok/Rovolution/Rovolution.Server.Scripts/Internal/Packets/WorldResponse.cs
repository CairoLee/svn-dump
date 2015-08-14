using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Scripts.Packets.Response {

	public class WorldConnectionResponse : Packet {
		public WorldConnectionResponse(Account account)
			: base(0x283, 6) {
			Write(account.ID);
		}
	}

	public class WorldAuthOK : Packet {
		public WorldAuthOK(Account account)
			: base(0x73, 11) {
			Write((int)DateTime.Now.Ticks);
			Write(account.ActiveChar.Location);
			Write((byte)5); // ignored..
			Write((byte)5); // ignored..
		}
	}

	public class WorldConfirmGameExit : Packet {
		public WorldConfirmGameExit(bool allowed)
			: base(0x18b, 4) {
			if (allowed == true) {
				Write((short)0);
			} else {
				Write((short)1);
			}
		}
	}

	public class WorldWalkOK : Packet {
		public WorldWalkOK(Character c)
			: base(0x87, 11) {
			Write((int)DateTime.Now.Ticks);
			Write(c.Location.Point, c.TargetLocation, new Point2D(8, 8));
		}
	}

}
