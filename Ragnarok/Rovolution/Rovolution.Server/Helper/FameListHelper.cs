using System.Data;
using GodLesZ.Library;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Helper {

	public class FameListHelper {
		public static FameList Blacksmith;
		public static FameList Alchemist;
		public static FameList Taekwon;

		public static void Initialize() {
			ServerConsole.Info("\t# loading fame lists...");
			// TODO: some sort of dynamic class lists would be nice to have..
			string jobsBlacksmith = string.Concat((int)EClass.Blacksmith, ',', (int)EClass.BabyBlacksmith, ',', (int)EClass.Whitesmith);
			string jobsAlchemist = string.Concat((int)EClass.Alchemist, ',', (int)EClass.BabyAlchemist, ',', (int)EClass.Creator);
			string jobsTaekwon = string.Concat((int)EClass.Taekwon);
			int size = 10;

			// Load from database
			Blacksmith = ReadFameList(jobsBlacksmith, size);
			Alchemist = ReadFameList(jobsAlchemist, size);
			Taekwon = ReadFameList(jobsTaekwon, size);

			ServerConsole.WriteLine(EConsoleColor.Status, " Done (" + Blacksmith.Count + " blacksmith, " + Alchemist.Count + " Alchemist, " + Taekwon.Count + " Taekwon)");
		}


		private static FameList ReadFameList(string jobs, int size) {
			FameList list = new FameList(size);

			string query = "SELECT `charID`,`fame` FROM `char` WHERE `fame` > 0 AND `class` IN ({0}) ORDER BY `fame` DESC LIMIT 0,{1}";
			DataTable table = Core.Database.Query(query, jobs, size);
			if (table.HasResults() == false) {
				return list;
			}

			foreach (DataRow row in table.Rows) {
				uint id = row.Field<uint>("char_id");
				int fame = row.Field<int>("fame");

				// Push it to the list
				list.Add(new FameListEntry(id, fame));
			}

			return list;
		}

	}

}
