
namespace Rovolution.Server.Helper {

	/// <summary>
	/// Contains infos about a famelist entry
	/// </summary>
	public class FameListEntry {
		public uint ID {
			get;
			set;
		}

		public int Fame {
			get;
			set;
		}

		public FameListEntry(uint id, int fame) {
			ID = id;
			Fame = fame;
		}

	}

}
