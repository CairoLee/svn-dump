using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GodLesZ.BlubbRO.Patcher.Download {

	public enum EPatchAction {
		None = 0,

		GrfAdd,
		GrfDelete,

		DataAdd,
		DataDelete,

		PatchReset,

		PatcherUpdate = 255,
	}

}
