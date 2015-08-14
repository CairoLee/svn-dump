using System;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using GodLesZ.Library.Formats;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats {
	
	public abstract class TranslatedPipeTrailedFile : PipeTrailedFile {
		protected PipeTrailedFile mTranslationFile = null;


		protected TranslatedPipeTrailedFile() {
		}

		protected TranslatedPipeTrailedFile(bool hasColumnNames, bool hasFileVersion)
			: base(hasColumnNames, hasFileVersion) {
		}

		protected TranslatedPipeTrailedFile(Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(enc, hasColumnNames, hasFileVersion) {
		}

		protected TranslatedPipeTrailedFile(string filepath, bool hasColumnNames, bool hasFileVersion)
			: base(filepath, hasColumnNames, hasFileVersion) {
		}

		protected TranslatedPipeTrailedFile(string filepath, Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(filepath, enc, hasColumnNames, hasFileVersion) {
		}

		protected TranslatedPipeTrailedFile(Stream stream, bool hasColumnNames, bool hasFileVersion)
			: base(stream, hasColumnNames, hasFileVersion) {
		}

		protected TranslatedPipeTrailedFile(Stream stream, Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(stream, enc, hasColumnNames, hasFileVersion) {
		}


		public virtual bool ReadTranslation(Encoding translationEncoding) {
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


		protected string BuildTranslationFilepath() {
			var filename = Path.GetFileName(Filepath);
			// Sometimes the filename start with "c_"..
			if (filename.StartsWith("c_")) {
				filename = filename.Substring(2);
			}
			var translationFilename = string.Format("t_{0}", filename);
			var translationFilepath = Path.Combine(Path.GetDirectoryName(Filepath), translationFilename);

			return translationFilepath;
		}

	}

}