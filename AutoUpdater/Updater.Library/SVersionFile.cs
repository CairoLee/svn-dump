using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Updater.Library {

	[Serializable]
	public class SVersionFile {
		public string ApplicationName;
		public string Version;

		[XmlArray( ElementName = "Files" )]
		[XmlArrayItem( ElementName = "File" )]
		public List<SVersionDownloadFile> Files = new List<SVersionDownloadFile>();
	}

	public class SVersionDownloadFile {
		[XmlAttribute]
		public string Url;
		[XmlAttribute]
		public string Name;
	}

}
