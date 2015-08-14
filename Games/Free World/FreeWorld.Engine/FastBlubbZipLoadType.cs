using System;

namespace FreeWorld.Engine {

	[Flags()]
	public enum EBlubbZipHelperLoadType {
		Streams = 1,
		FileList = 2,
		Entrys = 4,

		All = (Streams | FileList | Entrys)
	}

}