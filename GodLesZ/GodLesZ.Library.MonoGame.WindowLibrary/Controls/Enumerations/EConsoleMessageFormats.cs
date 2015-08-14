using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	[Flags]
	public enum EConsoleMessageFormats {
		None = 0x00,
		ChannelName = 0x01,
		TimeStamp = 0x02,
		All = ChannelName | TimeStamp
	}

}
