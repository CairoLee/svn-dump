using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using GodLesZ.Library.Formats;

namespace GodLesZ.EdenEternal.DataViewer.Library.Formats {

	/// <summary>
	/// Reads a Eden Eternal core data file, trailed by pipes.
	/// (NOT translation files, starting with "t_"!)
	/// </summary>
	public class PipeTrailedFile : GenericFileFormat {
		protected StreamReader mLineReader = null;
		protected bool mHasColumnNames = true;
		protected bool mHasFileVersion = true;
		protected int mFileVersionIndex = 0;
		protected EPipeTrailedFileType mFileReadType = EPipeTrailedFileType.Char;

		public DataTable Entries {
			get;
			protected set;
		}

		public Dictionary<int, int> RowSearchIndex {
			get;
			protected set;
		}

		public string FileVersion {
			get;
			protected set;
		}

		public IList<string> ColumnMappings {
			get;
			protected set;
		}

		public bool HasColumnNames {
			get { return mHasColumnNames; }
			set { mHasColumnNames = value; }
		}

		public int FileVersionIndex {
			get { return mFileVersionIndex; }
			set { mFileVersionIndex = value; }
		}

		public EPipeTrailedFileType FileReadType {
			get { return mFileReadType; }
			set { mFileReadType = value; }
		}


		public PipeTrailedFile() {
		}

		public PipeTrailedFile(bool hasColumnNames, bool hasFileVersion) {
			mHasColumnNames = hasColumnNames;
			mHasFileVersion = hasFileVersion;
		}

		public PipeTrailedFile(Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(enc) {
			mHasColumnNames = hasColumnNames;
			mHasFileVersion = hasFileVersion;
		}

		public PipeTrailedFile(string filepath, bool hasColumnNames, bool hasFileVersion)
			: base(filepath) {
			mHasColumnNames = hasColumnNames;
			mHasFileVersion = hasFileVersion;
		}

		public PipeTrailedFile(string filepath, Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(filepath, enc) {
			mHasColumnNames = hasColumnNames;
			mHasFileVersion = hasFileVersion;
		}

		public PipeTrailedFile(Stream stream, bool hasColumnNames, bool hasFileVersion)
			: base(stream) {
			mHasColumnNames = hasColumnNames;
			mHasFileVersion = hasFileVersion;
		}

		public PipeTrailedFile(Stream stream, Encoding enc, bool hasColumnNames, bool hasFileVersion)
			: base(stream, enc) {
			mHasColumnNames = hasColumnNames;
			mHasFileVersion = hasFileVersion;
		}


		protected override bool ReadInternal() {
			base.ReadInternal();

			// Prepare entry space
			Entries = new DataTable();
			// Prepare search index
			RowSearchIndex = new Dictionary<int, int>();

			// We need a per-line reader
			mLineReader = new StreamReader(ReaderBaseStream, Encoding);

			// First line defines the version and amount of columns
			var magicHeadLine = mLineReader.ReadLine();
			if (string.IsNullOrEmpty(magicHeadLine)) {
				return false;
			}

			// TODO: Abstract header reading/parsing per class
			var headerInfo = magicHeadLine.Split(new[] { '|' });
			int columnCount;
			if (mHasFileVersion) {
				FileVersion = headerInfo[FileVersionIndex];
				columnCount = int.Parse(headerInfo[FileVersionIndex + 1]);
			} else {
				columnCount = int.Parse(headerInfo[0]);
			}

			// Second line defines the column indices
			var columnsLine = mLineReader.ReadLine();
			if (string.IsNullOrEmpty(columnsLine)) {
				return false;
			}
			ColumnMappings = columnsLine
				.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			// Third line defines the column names (in chinese..)
			// These may contain newlines.. wtf
			var foundColumnNames = false;
			// Create columns in data table
			for (var i = 0; i < columnCount; i++) {
				Entries.Columns.Add(string.Format("Col{0}", i));
			}
			Entries.PrimaryKey = new DataColumn[] { Entries.Columns[0] };
			Entries.PrimaryKey[0].AllowDBNull = true;

			// We start loading data
			Entries.BeginLoadData();

			// Now we have to read every char, because column values may contain newlines to
			// This means, not every new line defines a new entry..

			try {
				if (mFileReadType == EPipeTrailedFileType.Char) {
					ReadInternalByChar(columnCount, foundColumnNames);
				} else {
					ReadInternalByLine(columnCount, foundColumnNames);
				}

			} catch (Exception ex) {
				// Something went wrong
				Console.WriteLine(ex);

				Entries.EndLoadData();

				return false;
			}

			// We finished loading data
			Entries.EndLoadData();

			return true;
		}

		protected virtual void ReadInternalByChar(int columnCount, bool foundColumnNames) {
			var currentColIndex = 0;
			var entry = Entries.NewRow();
			var columnValue = string.Empty;

			while (mLineReader.EndOfStream == false) {
				var c = (char)mLineReader.Read();

				// We got the trailing sign?
				if (c == '|') {
					// We have reached the next column number, or we have reached the next entry
					entry[currentColIndex] = columnValue;
					// Advance column index
					currentColIndex++;
					if (currentColIndex >= columnCount) {
						// Reached the amount of columns, means new entry

						// Got column names?
						if (mHasColumnNames && foundColumnNames == false) {
							// Third line contains column names, not an entry
							foundColumnNames = true;
							for (var i = 0; i < columnCount; i++) {
								Entries.Columns[i].ColumnName = string.Format("{0} ({1})", entry[i], ColumnMappings[i]);
							}

							// Now we have entries
						} else {
							// Only add entries with an primary key
							var pkValue = entry[0];
							if (pkValue != null && string.IsNullOrEmpty(pkValue.ToString()) == false) {
								// Clean primary key
								var pkCleaned = pkValue.ToString().Replace("\r\n", "").Trim();
								pkCleaned = Encoding.UTF8.GetString(Encoding.GetBytes(pkCleaned));
								pkCleaned = Regex.Replace(pkCleaned, "[^0-9]", "");
								var pkey = 0;
								if (int.TryParse(pkCleaned, out pkey) == false) {
									Console.WriteLine("Failed to parse primary key in column: " + pkValue);
								} else if (RowSearchIndex.ContainsKey(pkey) == false) {
									// Add primary key to search index
									RowSearchIndex.Add(pkey, Entries.Rows.Count);

									// Encode entries
									/*
									for (var i = 1; i < entry.ItemArray.Length; i++) {
										entry[i] = Encoding.UTF8.GetString(Encoding.GetBytes(entry[i].ToString()));
									}
									*/

									entry[0] = pkey;
									Entries.Rows.Add(entry);
								}
							}
						}

						entry = Entries.NewRow();
						currentColIndex = 0;
					}

					// Prepare new column value
					columnValue = string.Empty;

					continue;
				}

				// No new column or entry, store sign in current column
				columnValue += c;
			}

		}

		protected virtual void ReadInternalByLine(int columnCount, bool foundColumnNames) {
			var entry = Entries.NewRow();
			var iLine = 0;

			while (mLineReader.EndOfStream == false && mLineReader.BaseStream.Position < mLineReader.BaseStream.Length) {
				// We need to buffer the line... damn unicodes
				var line = string.Empty;
				while (mLineReader.BaseStream.Position < mLineReader.BaseStream.Length) {
					var c = (char)mLineReader.Read();
					line += c;
					if (line.EndsWith("\r\n")) {
						break;
					}
				}

				line = line.Trim();
				iLine++;

				if (string.IsNullOrEmpty(line)) {
					continue;
				}

				var lineColumns = line.Split('|');
				if (IsValidLine(line, ref lineColumns, columnCount) == false) {
					continue;
				}

				// Got column names?
				if (mHasColumnNames && foundColumnNames == false) {
					// Third line contains column names, not an entry
					foundColumnNames = true;
					for (var i = 0; i < columnCount; i++) {
						Entries.Columns[i].ColumnName = string.Format("{0} ({1})", entry[i], ColumnMappings[i]);
					}

					// Now we have entries
				} else {
					for (var i = 0; i < lineColumns.Length - 1; i++) {
						entry[i] = lineColumns[i];
					}

					AddEntry(entry);
				}

				entry = Entries.NewRow();
			}

		}

		protected virtual bool IsValidLine(string line, ref string[] lineColumns, int columnCount) {
			if (lineColumns.Length - 1 != columnCount) {
				Console.WriteLine("Unexpected amount (" + lineColumns.Length + " / " + columnCount + ") of columns in line: " + line);
				return false;
			}

			return true;
		}

		protected virtual void AddEntry(DataRow entry) {
			// Only add entries with an primary key
			var pkValue = entry[0];
			if (pkValue == null || string.IsNullOrEmpty(pkValue.ToString())) {
				return;
			}

			// Clean primary key
			var pkCleaned = pkValue.ToString().Replace("\r\n", "").Trim();
			pkCleaned = Encoding.UTF8.GetString(Encoding.GetBytes(pkCleaned));
			pkCleaned = Regex.Replace(pkCleaned, "[^0-9]", "");
			var pkey = 0;
			if (int.TryParse(pkCleaned, out pkey) == false) {
				Console.WriteLine("Failed to parse primary key in column: " + pkValue);
				return;
			}

			if (RowSearchIndex.ContainsKey(pkey)) {
				return;
			}

			// Add primary key to search index
			RowSearchIndex.Add(pkey, Entries.Rows.Count);

			// Encode entries
			/*
			for (var i = 1; i < entry.ItemArray.Length; i++) {
				entry[i] = Encoding.UTF8.GetString(Encoding.GetBytes(entry[i].ToString()));
			}
			*/

			entry[0] = pkey;
			Entries.Rows.Add(entry);
		}

	}

}