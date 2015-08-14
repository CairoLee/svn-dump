using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	[Flags()]
	public enum EMonsterDamageLogType {
		Normal = 0,
		Homunculus = 1,
		Pet = 2
	}
}
