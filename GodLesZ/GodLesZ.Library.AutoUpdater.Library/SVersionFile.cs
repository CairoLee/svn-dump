using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GodLesZ.Library.AutoUpdater.Library {

	[Serializable]
	public class SVersionFile {

		public string ApplicationName {
			get;
			set;
		}

		public string Version {
			get;
			set;
		}

		[XmlArray(ElementName = "Files")]
		[XmlArrayItem(ElementName = "File")]
		public List<SVersionDownloadFile> Files {
			get;
			set;
		}


		public SVersionFile() {
			Files = new List<SVersionDownloadFile>();
		}

	}

}
