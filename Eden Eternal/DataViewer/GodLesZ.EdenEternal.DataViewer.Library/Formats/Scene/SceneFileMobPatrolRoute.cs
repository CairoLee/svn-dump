using System;
using System.Collections.Generic;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats.Scene {

	public class SceneFileMobPatrolRoute : List<SceneFileMobPatrolEntry> {

		public int RouteID {
			get;
			set;
		}

		public int Unk1 {
			get;
			set;
		}

		public string Unk2 {
			get;
			set;
		}

		public string Unk3 {
			get;
			set;
		}


		public SceneFileMobPatrolRoute() {
		}

		public SceneFileMobPatrolRoute(int id, int unk1, string unk2, string unk3)
			: this() {
			RouteID = id;
			Unk1 = unk1;
			Unk2 = unk2;
			Unk3 = unk3;
		}
		

		public static SceneFileMobPatrolRoute Parse(string line) {
			var columns = line.Split(',');
			var route = new SceneFileMobPatrolRoute(
				int.Parse(columns[0]),
				int.Parse(columns[columns.Length - 3]),
				columns[columns.Length - 2],
				columns[columns.Length - 1]
			);

			for (var i = 1; i < columns.Length - 1; i += SceneFileMobPatrolEntry.FieldCount) {
				// No more spots on this route
				if (columns[i] == "0" && columns[i + 1] == "0") {
					break;
				}

				// Read fields
				var entryColumns = new string[SceneFileMobPatrolEntry.FieldCount];
				Array.Copy(columns, i, entryColumns, 0, entryColumns.Length);
				var entry = SceneFileMobPatrolEntry.Parse(entryColumns);
				if (entry == null) {
					continue;
				}

				route.Add(entry);
			}

			return route;
		}

	}

}