using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDSExtractor.Library {

	public class NDSFileEntry {
		public ushort ID { get; set; }
		public string Name { get; set; }
		public uint Offset { get; set; }
		public uint Size { get; set; }
		public bool IsDir { get; set; }
		public Dictionary<ushort, NDSFileEntry> Files { get; internal set; }


		public NDSFileEntry() {
			Files = new Dictionary<ushort, NDSFileEntry>();
		}



	}

}
