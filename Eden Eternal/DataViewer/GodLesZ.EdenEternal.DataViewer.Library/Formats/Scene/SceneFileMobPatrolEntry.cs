namespace GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene {

	public class SceneFileMobPatrolEntry {
		public const int FieldCount = 5;
		
		public float X {
			get;
			protected set;
		}

		public float Y {
			get;
			protected set;
		}

		public int Unk1 {
			get;
			protected set;
		}

		public int Unk2 {
			get;
			protected set;
		}

		public int Unk3 {
			get;
			protected set;
		}


		public SceneFileMobPatrolEntry() {

		}

		public SceneFileMobPatrolEntry(float x, float y, int unk1, int unk2, int unk3)
			: this() {
			X = x;
			Y = y;
			Unk1 = unk1;
			Unk2 = unk2;
			Unk3 = unk3;
		}


		public static SceneFileMobPatrolEntry Parse(string[] columns) {
			var entry = new SceneFileMobPatrolEntry(
				float.Parse(columns[0], SceneFile.DefaultFloatFormat),
				float.Parse(columns[1], SceneFile.DefaultFloatFormat),
				int.Parse(columns[2]),
				int.Parse(columns[3]),
				int.Parse(columns[4])
			);
			return entry;
		}


		public static implicit operator SceneFileMobPatrolEntry(string line) {
			return Parse(line.Split(','));
		}

		public static implicit operator SceneFileMobPatrolEntry(string[] columns) {
			return Parse(columns);
		}

	}

}