#define DISABLE_GRF_EVENTS

using System.IO;
using GodLesZ.Library.Ragnarok.Grf;
using GodLesZ.Library.Ragnarok.Tests.Library;

namespace GodLesZ.Library.Ragnarok.Tests.PerformanceTests {

	public static class Grf {

		[PerformanceTestRun(10)]
		public static bool ReadVersion0X200() {
			bool testResult;
			RoGrfFile grf = null;
			try {
				grf = LoadLocalGrf("talonro-0x200.grf");
				testResult = true;
			} catch {
				testResult = false;
			} finally {
				if (grf != null) {
					grf.Dispose();
				}
			}

			return testResult;
		}

		[PerformanceTestRun(10)]
		public static bool ReadBigVersion0X200() {
			bool testResult;
			RoGrfFile grf = null;
			try {
				grf = new RoGrfFile(@"C:\Games\TalonRO\sdata.grf");
				testResult = true;
			} catch {
				testResult = false;
			} finally {
				if (grf != null) {
					grf.Dispose();
				}
			}

			return testResult;
		}


		private static RoGrfFile LoadLocalGrf(string filename) {
			var filepath = Path.Combine("data", filename);
			var grf = new RoGrfFile(filepath);
			return grf;
		}

	}

}