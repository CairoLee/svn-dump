using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace eAthenaStudio.Library.IniParser {

	public class StreamIniDataParser {
		private const string strCommentRegex = @".*";
		private const string strSectionRegexStart = @"^(\s*?)";
		private const string strSectionRegexMiddle = @"{1}\s*[_\.\-\w\d\s]+\s*";
		private const string strSectionRegexEnd = @"(\s*?)$";
		private const string strKeyRegex = @"^(\s*[_\.\d\w]*\s*)";
		private const string strValueRegex = @"([\s\d\w\W]*)$";
		private const string strSpecialRegexChars = @"[\^$.|?*+()";

		private readonly List<string> mCurrentCommentList = new List<string>();
		private string mCurrentSectionName;
		private readonly SectionDataCollection mCurrentTmpData;
		private char mCommentDelimiter;
		private char[] mCectionDelimiters;
		private char mKeyValueDelimiter;
		private Regex mCommentRegex;
		private Regex mSectionRegex;
		private Regex mKeyValuePairRegex;
		private bool mRelaxedIniFormat;
		private bool mProcessingSecion;

		private bool ProcessingSection {
			get { return mProcessingSecion; }
			set { mProcessingSecion = value; }
		}

		public char CommentDelimiter {
			get { return mCommentDelimiter; }
			set {
				mCommentRegex = new Regex(value + strCommentRegex);
				mCommentDelimiter = value;
			}
		}

		public char[] SectionDelimiters {
			get { return mCectionDelimiters; }
			set {
				if (value == null || value.Length != 2)
					return;

				string tmp = strSectionRegexStart;
				if (strSpecialRegexChars.Contains(new string(value[0], 1)))
					tmp += "\\" + value[0];
				else
					tmp += value[0];

				tmp += strSectionRegexMiddle;
				if (strSpecialRegexChars.Contains(new string(value[1], 1)))
					tmp += "\\" + value[1];
				else
					tmp += value[1];

				tmp += strSectionRegexEnd;

				mSectionRegex = new Regex(tmp);
				mCectionDelimiters = value;
			}
		}

		public char KeyValueDelimiter {
			get { return mKeyValueDelimiter; }
			set {
				mKeyValuePairRegex = new Regex(strKeyRegex + value + strValueRegex);
				mKeyValueDelimiter = value;
			}
		}

		public string CommentRegexString {
			get {
				if (mCommentRegex == null)
					return string.Empty;
				return mCommentRegex.ToString();
			}
		}

		public string SectionRegexString {
			get {
				if (mSectionRegex == null)
					return string.Empty;
				return mSectionRegex.ToString();
			}
		}

		public string KeyValuePairRegexString {
			get {
				if (mKeyValuePairRegex == null)
					return string.Empty;
				return mKeyValuePairRegex.ToString();
			}
		}


		public StreamIniDataParser() {
			CommentDelimiter = ';';
			KeyValueDelimiter = '=';
			SectionDelimiters = new char[] { '[', ']' };

			mCurrentTmpData = new SectionDataCollection();
		}


		public IniData ReadData(StreamReader reader) {
			return ReadData(reader, false);
		}

		public IniData ReadData(StreamReader reader, bool relaxedIniFormat) {
			mRelaxedIniFormat = relaxedIniFormat;

			if (reader == null)
				throw new ArgumentNullException("reader", "The StreamReader object is null oO");

			try {
				while (!reader.EndOfStream)
					ProcessLine(reader.ReadLine());
				return new IniData((SectionDataCollection)mCurrentTmpData.Clone());
			} catch (Exception ex) {
				mCurrentTmpData.Clear();
				throw new ParsingException("Parseerror: " + ex.Message, ex);
			} finally {
				mCurrentTmpData.Clear();
			}
		}


		public void WriteData(StreamWriter writer, IniData iniData) {
			SectionDataCollection sdc = iniData.Sections;
			foreach (SectionData sd in sdc) {

				foreach (string sectionComment in sd.Comments)
					writer.WriteLine(string.Format("{0}{1}", CommentDelimiter, sectionComment));
				writer.WriteLine(string.Format("{0}{1}{2}", SectionDelimiters[0], sd.SectionName, SectionDelimiters[1]));

				foreach (KeyData kd in sd.Keys) {
					foreach (string keyComment in kd.Comments)
						writer.WriteLine(string.Format("{0}{1}", CommentDelimiter, keyComment));
					writer.WriteLine(string.Format("{0} {1} {2}", kd.KeyName, KeyValueDelimiter, kd.Value));
				}

				writer.WriteLine();
			}
		}


		private bool MatchComment(string s) {
			if (string.IsNullOrEmpty(s))
				return false;
			return mCommentRegex.Match(s).Success;
		}

		private bool MatchSection(string s) {
			if (string.IsNullOrEmpty(s))
				return false;
			return mSectionRegex.Match(s).Success;
		}

		private bool MatchKeyValuePair(string s) {
			if (string.IsNullOrEmpty(s))
				return false;
			return mKeyValuePairRegex.Match(s).Success;
		}

		private string ExtractComment(string s) {
			string tmp = mCommentRegex.Match(s).Value.Trim();
			mCurrentCommentList.Add(tmp.Substring(1, tmp.Length - 1));
			return s.Replace(tmp, "").Trim();
		}

		private void ProcessLine(string currentLine) {
			currentLine = currentLine.Trim();
			if (MatchComment(currentLine))
				currentLine = ExtractComment(currentLine);

			if (currentLine == String.Empty)
				return;

			if (MatchSection(currentLine)) {
				ProcessSection(currentLine);
				return;
			}

			if (MatchKeyValuePair(currentLine)) {
				ProcessKeyValuePair(currentLine);
				return;
			}

			throw new ParsingException("Couldn't parse string: " + currentLine + ", unknown file format");
		}

		private void ProcessSection(string s) {
			ProcessingSection = true;

			string tmp = mSectionRegex.Match(s).Value.Trim();
			if (tmp == string.Empty)
				throw new ParsingException("Error parsing section. String: \"" + s + "\"");

			tmp = tmp.Substring(1, tmp.Length - 2).Trim();
			if (mCurrentTmpData.ContainsSection(tmp)) {
				if (mRelaxedIniFormat) {
					ProcessingSection = false;
					return;
				}
				throw new ParsingException(string.Format("Error parsing section: Another section with the name [{0}] exists!", s));
			}

			mCurrentSectionName = tmp;
			mCurrentTmpData.AddSection(tmp);
			mCurrentTmpData.GetSectionData(tmp).Comments = mCurrentCommentList;
			mCurrentCommentList.Clear();
		}


		private void ProcessKeyValuePair(string s) {
			if (!ProcessingSection)
				return;

			if (mCurrentSectionName == string.Empty)
				throw new ParsingException(
					"Bad file format: key doesn't match any section. String :" + s);
			string key = ExtractKey(s);
			string value = ExtractValue(s);


			if (mCurrentTmpData.GetSectionData(mCurrentSectionName).Keys.ContainsKey(key)) {
				if (mRelaxedIniFormat)
					return;
				throw new ParsingException(string.Format("Error parsing section: Another key with the same name [{0}] already exists in section", mCurrentSectionName));
			}

			mCurrentTmpData.GetSectionData(mCurrentSectionName).Keys.AddKey(key);
			mCurrentTmpData.GetSectionData(mCurrentSectionName).Keys.GetKeyData(key).Value = value;
			mCurrentTmpData.GetSectionData(mCurrentSectionName).Keys.GetKeyData(key).Comments = mCurrentCommentList;
			mCurrentCommentList.Clear();
		}

		private string ExtractKey(string s) {
			string tmp = mKeyValuePairRegex.Match(s).Value;
			if (tmp == string.Empty)
				throw new ParsingException("Error extracting key. String: \"" + s + "\"");

			int index = tmp.IndexOf(mKeyValueDelimiter, 0);
			return tmp.Substring(0, index).Trim();
		}

		private string ExtractValue(string s) {
			string tmp = mKeyValuePairRegex.Match(s).Value.Trim();
			if (tmp == string.Empty)
				throw new ParsingException("Error extracting value. String: \"" + s + "\"");

			int index = tmp.IndexOf(mKeyValueDelimiter, 0);
			return tmp.Substring(index + 1, tmp.Length - index - 1).Trim();
		}

	}

}
