using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats {

	public class MonsterDataFile : PipeTrailedFile {
		public static Encoding DefaultEncoding = Encoding.GetEncoding("GB2312");

		public static Dictionary<int, string> KnownColumns = new Dictionary<int, string>();


		static MonsterDataFile() {
			KnownColumns.Add(0, "ID");
			KnownColumns.Add(1, "Icon");
			KnownColumns.Add(2, "Name");
			KnownColumns.Add(3, "Level");
			KnownColumns.Add(8, "HP");
			KnownColumns.Add(9, "MP");
		}


		public MonsterDataFile()
			: base(DefaultEncoding, false, true) {
		}

		public MonsterDataFile(Encoding enc)
			: base(enc, false, true) {
		}

		public MonsterDataFile(string filepath)
			: base(filepath, DefaultEncoding, false, true) {
		}

		public MonsterDataFile(string filepath, Encoding enc)
			: base(filepath, enc, false, true) {
		}

		public MonsterDataFile(Stream stream)
			: base(stream, DefaultEncoding, false, true) {
		}

		public MonsterDataFile(Stream stream, Encoding enc)
			: base(stream, enc, false, true) {
		}


		public override bool Read() {
			FileVersionIndex = 1;
			FileReadType = EPipeTrailedFileType.Line;

			if (base.Read() == false) {
				return false;
			}

			// Rename yet-known columns
			foreach (var kvp in KnownColumns) {
				var index = kvp.Key;
				var name = kvp.Value;
				Entries.Columns[index].ColumnName = name;
			}
			
			return true;
		}


		/// <summary>
		/// Overrides base method to handle special cases
		/// </summary>
		/// <param name="line"></param>
		/// <param name="lineColumns"></param>
		/// <param name="columnCount"></param>
		/// <returns></returns>
		protected override bool IsValidLine(string line, ref string[] lineColumns, int columnCount) {
			// Monster names may be trailed by a PIPE too
			// This means, we have 1 column more
			if (lineColumns.Length - 1 != columnCount) {
				Console.WriteLine("Unexpected amount (" + lineColumns.Length + " / " + columnCount + ") of columns in line: " + line);
				return false;
			}

			return true;
		}

	}

}