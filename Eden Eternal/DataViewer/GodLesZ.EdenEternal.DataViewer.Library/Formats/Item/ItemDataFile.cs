using System.IO;
using System.Text;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats {

	public class ItemDataFile : PipeTrailedFile {
		public static Encoding DefaultEncoding = Encoding.GetEncoding("GB2312");


		public ItemDataFile()
			: base(DefaultEncoding, true, true) {
		}

		public ItemDataFile(Encoding enc)
			: base(enc, true, true) {
		}

		public ItemDataFile(string filepath)
			: base(filepath, DefaultEncoding, true, true) {
		}

		public ItemDataFile(string filepath, Encoding enc)
			: base(filepath, enc, true, true) {
		}

		public ItemDataFile(Stream stream)
			: base(stream, DefaultEncoding, true, true) {
		}

		public ItemDataFile(Stream stream, Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(stream, enc, true, true) {
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

			return true;
		}

	}

}