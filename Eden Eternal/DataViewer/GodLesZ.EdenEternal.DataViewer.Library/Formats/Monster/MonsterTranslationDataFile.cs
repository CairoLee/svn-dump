using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats {

	public class MonsterTranslationDataFile : TranslatedPipeTrailedFile {
		public static Encoding DefaultTranslationEncoding = Encoding.GetEncoding("iso-8859-1");


		public MonsterTranslationDataFile()
			: base(false, true) {
		}

		public MonsterTranslationDataFile(string filepath)
			: base(filepath, false, true) {
		}


		/// <summary>
		/// Overrides <see cref="Read"/> to set correct version index and read type (per line).
		/// </summary>
		/// <returns></returns>
		public override bool Read() {
			FileVersionIndex = 1;
			FileReadType = EPipeTrailedFileType.Line;

			if (base.Read() == false) {
				return false;
			}

			// Rename columns from nonster file
			foreach (var kvp in MonsterDataFile.KnownColumns) {
				var index = kvp.Key;
				var name = kvp.Value;
				Entries.Columns[index].ColumnName = name;
			}

			// Read translation
			ReadTranslation(DefaultTranslationEncoding);

			return true;
		}

		public override bool ReadTranslation(Encoding translationEncoding) {
			// Read translation file
			var translationFilepath = BuildTranslationFilepath();
			mTranslationFile = new PipeTrailedFile(translationEncoding, false, false);
			mTranslationFile.Read(translationFilepath);

			Entries.BeginInit();

			// Apply translations by the first column (always ID?)
			for (var r = 0; r < mTranslationFile.Entries.Rows.Count; r++) {
				var translatedRow = mTranslationFile.Entries.Rows[r];
				var pkey = int.Parse(translatedRow[0].ToString());
				if (RowSearchIndex.ContainsKey(pkey) == false) {
					continue;
				}

				var sourceIndex = RowSearchIndex[pkey];
				var sourceRow = Entries.Rows[sourceIndex];

				for (var c = 1; c < mTranslationFile.Entries.Columns.Count; c++) {
					var columnSourceValue = mTranslationFile.ColumnMappings[c];
					var columnSourceIndex = int.Parse(columnSourceValue);
					// Columns start with 0, numbers with 1
					columnSourceIndex--;
					sourceRow[columnSourceIndex] = translatedRow[c];
				}

			}

			Entries.EndInit();

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
				if (lineColumns.Length - 2 != columnCount) {
					Console.WriteLine("Unexpected amount (" + lineColumns.Length + " / " + columnCount + ") of columns in line: " + line);
					return false;
				}

				var tmpColumns = new List<string>(lineColumns);
				tmpColumns[2] = string.Format("{0}|{1}", tmpColumns[2], tmpColumns[3]);
				tmpColumns.RemoveAt(3);
				lineColumns = tmpColumns.ToArray();
			}

			return true;
		}

	}

}