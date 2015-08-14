using System.IO;
using GodLesZ.Library.Amf.IO;

namespace AmfTest {
	
	public class DsoAmfReader : AMFReader {

		static DsoAmfReader() {
			AMFReader.AmfTypeTable[3]
		}
		
		public DsoAmfReader(Stream stream) : base(stream) {
			
		}
		 
	}

}