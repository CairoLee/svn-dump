using System.IO;
using GodLesZ.Library.Ragnarok.Grf;
using NUnit.Framework;

namespace GodLesZ.Library.Ragnarok.Tests.FileFormatTests {

	[TestFixture]
	public class Grf {

		#region Grf version 0x100
		[Test]
		[Ignore("No test grf")]
		public void TestGrfLoadVersion0X100() {
			var grf = LoadGrf("");
		}
		#endregion


		#region Grf version 0x101
		[Test]
		[Ignore("No test grf")]
		public void TestGrfLoadVersion0X101() {
			var grf = LoadGrf("");
		}
		#endregion


		#region Grf version 0x102
		[Test]
		[Ignore("No test grf")]
		public void TestGrfLoadVersion0X102() {
			var grf = LoadGrf("");
		}
		#endregion


		#region Grf version 0x103
		[Test]
		[Ignore("No test grf")]
		public void TestGrfLoadVersion0X103() {
			var grf = LoadGrf("");
		}
		#endregion


		#region Grf version 0x200
		[Test]
		public void TestGrfLoadVersion0X200() {
			var grf = LoadGrf("talonro-0x200.grf");
			Assert.True(grf.Version == 0x200);
		}
		#endregion



		private RoGrfFile LoadGrf(string filename) {
			var filepath = Path.Combine("data", filename);
			var grf = new RoGrfFile(filepath);
			return grf;
		}

	}

}