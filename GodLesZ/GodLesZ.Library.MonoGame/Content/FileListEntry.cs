using System;

namespace GodLesZ.Library.MonoGame.Content {

	[Serializable]
	public class FileListEntry {
		public string Filename;
		public EFileListType FileType;

		public FileListEntry() {
		}

		public FileListEntry( string Name, EFileListType Type ) {
			this.Filename = Name;
			this.FileType = Type;
		}

		public override string ToString() {
			return Filename;
		}
	}

}
