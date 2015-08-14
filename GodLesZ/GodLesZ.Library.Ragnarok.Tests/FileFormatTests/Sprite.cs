using System.IO;
using GodLesZ.Library.Ragnarok.Sprite;
using NUnit.Framework;

namespace GodLesZ.Library.Ragnarok.Tests.FileFormatTests {

	[TestFixture]
	public class Sprite {

		[Test]
		public void TestPoring() {
			var spr = new RoSprite(GetDataPath("poring.spr"));
		}

		[Test]
		public void TestGodPoring() {
			var spr = new RoSprite(GetDataPath("god_poring.spr"));
		}


		private string GetDataPath(string filename) {
			return Path.Combine("data", filename);
		}

	}

}