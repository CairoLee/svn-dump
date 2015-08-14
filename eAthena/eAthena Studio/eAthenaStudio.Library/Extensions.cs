using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace eAthenaStudio.Library {

	public static class StringExtensions {

		public static bool Contains(this string Text, char c) {
			return Text.IndexOf(c) == -1;
		}

		public static bool Contains(this string Text, IEnumerable<string> NeedleArray) {
			foreach (string Needle in NeedleArray)
				if (Text.Contains(Needle))
					return true;
			return false;
		}


		public static bool IsNullOrEmpty(this string Text) {
			return String.IsNullOrEmpty(Text);
		}


		public static string SubStringAfterIndex(this string Text, char Search) {
			int i = -1;
			if ((i = Text.IndexOf(Search)) == -1)
				return Text;
			return Text.Substring(i);
		}
		public static string SubStringAfterIndex(this string Text, char Search, int StartPos) {
			int i = -1;
			if ((i = Text.IndexOf(Search, StartPos)) == -1)
				return Text;
			return Text.Substring(i);
		}

		public static string SubStringBeforeIndex(this string Text, char Search) {
			int i = -1;
			if ((i = Text.IndexOf(Search)) == -1)
				return Text;
			return Text.Substring(0, i);
		}
		public static string SubStringBeforeIndex(this string Text, char Search, int StartPos) {
			int i = -1;
			if ((i = Text.IndexOf(Search, StartPos)) == -1)
				return Text;
			return Text.Substring(0, i);
		}
		public static string SubStringBeforeIndex(this string Text, string Search) {
			int i = -1;
			if ((i = Text.IndexOf(Search)) == -1)
				return Text;
			return Text.Substring(0, i);
		}
		public static string SubStringBeforeIndex(this string Text, string Search, int StartPos) {
			int i = -1;
			if ((i = Text.IndexOf(Search, StartPos)) == -1)
				return Text;
			return Text.Substring(0, i);
		}

	}


	public static class StreamWriterExtensions {

		public static void WriteLines(this StreamWriter Writer, IEnumerable<string> Lines, string Prefix) {
			foreach (string line in Lines)
				Writer.WriteLine(Prefix + line);
		}

		public static void WriteLines(this StreamWriter Writer, IEnumerable<string> Lines) {
			Writer.WriteLines(Lines, "");
		}

	}


	public static class BinaryReaderExtensions {

		public static Color ReadRoSpriteColor(this BinaryReader Reader) {
			byte r = Reader.ReadByte();
			byte g = Reader.ReadByte();
			byte b = Reader.ReadByte();
			byte a = Reader.ReadByte();
			return Color.FromArgb(255 - a, r, g, b);
		}

	}

	public static class BinaryWriterExtensions {

		public static void Write(this BinaryWriter Writer, Color c) {
			Writer.Write(c.R);
			Writer.Write(c.G);
			Writer.Write(c.B);
			Writer.Write((byte)(255 - c.A));
		}

	}

}
