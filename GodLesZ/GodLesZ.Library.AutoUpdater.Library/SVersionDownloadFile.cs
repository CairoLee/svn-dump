using System;
using System.Xml.Serialization;

namespace GodLesZ.Library.AutoUpdater.Library {

	[Serializable]
	public class SVersionDownloadFile {

		[XmlAttribute]
		public string Url {
			get;
			set;
		}

		[XmlAttribute]
		public string Name {
			get;
			set;
		}


		public SVersionDownloadFile() {
		}

	}

}
