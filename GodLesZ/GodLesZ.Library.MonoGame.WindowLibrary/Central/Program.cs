using System;
using System.IO;

namespace GodLesZ.Library.XNA.WindowLibrary.Central {
	static class Program {

#if (!XBOX && !XBOX_FAKE)
		[STAThread]
#endif
		static void Main(string[] args) {
			using (Central central = new Central()) {
				central.Run();
			}
		}

	}

}