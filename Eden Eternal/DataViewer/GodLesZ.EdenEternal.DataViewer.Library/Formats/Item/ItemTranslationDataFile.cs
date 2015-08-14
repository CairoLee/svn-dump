using System.IO;
using System.Text;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats {

	public class ItemTranslationDataFile : TranslatedPipeTrailedFile {
		public static Encoding DefaultTranslationEncoding = Encoding.GetEncoding("iso-8859-1");


		public ItemTranslationDataFile()
			: base(true, true) {
		}

		public ItemTranslationDataFile(string filepath)
			: base(filepath, true, true) {
		}


		public override bool Read() {
			if (base.Read() == false) {
				return false;
			}

			// Rename columns
			Entries.Columns[0].ColumnName = "ID";
			Entries.Columns[1].ColumnName = "Icon";
			Entries.Columns[7].ColumnName = "Name";
			Entries.Columns[33].ColumnName = "Description";

			// Read translation
			ReadTranslation(DefaultTranslationEncoding);

			return true;
		}

	}

}