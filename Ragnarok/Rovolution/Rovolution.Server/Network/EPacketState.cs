using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Network {

	[Flags()]
	public enum EPacketState {
		Inactive = 0x00,
		Static = 0x01,
		Acquired = 0x02,
		Accessed = 0x04,
		Buffered = 0x08,
		Warned = 0x10
	}

}
