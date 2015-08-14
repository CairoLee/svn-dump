using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ClientPatcher {

	[Serializable]
	public class PatchReplace {
		[XmlAttribute]
		public string Replace;
		[XmlAttribute]
		public int IndexAdd;


		public PatchReplace() {
		}

		public PatchReplace( string String, int Index ) {
			Replace = String;
			IndexAdd = Index;
		}

	}

	[Serializable]
	public class PatchPart {
		public static PatchPart ZeroPatch = new PatchPart( "", new List<PatchReplace>() );

		public string FindString = "";
		public int StartIndex = 0;
		public List<PatchReplace> ReplaceList = new List<PatchReplace>();
		public PatchPart SubPatch = PatchPart.ZeroPatch;


		public PatchPart() {
		}

		public PatchPart( string Find, List<PatchReplace> Replace ) {
			FindString = Find;
			StartIndex = 0;
			ReplaceList = Replace;
			SubPatch = PatchPart.ZeroPatch;
		}

		public PatchPart( string Find, int Start, List<PatchReplace> Replace ) {
			FindString = Find;
			StartIndex = Start;
			ReplaceList = Replace;
			SubPatch = PatchPart.ZeroPatch;
		}

		public PatchPart( string Find, int Start, List<PatchReplace> Replace, PatchPart Sub ) {
			FindString = Find;
			StartIndex = Start;
			ReplaceList = Replace;
			SubPatch = Sub;
		}



		public void PatchBuf( List<byte> Buf, StringBuilder stringBuilder, int startAt ) {

			ReplaceList.ForEach(
				delegate( PatchReplace rep ) {
					int i = startAt + rep.IndexAdd;
					Buf[ startAt + rep.IndexAdd ] = Tools.Hex2Dec( rep.Replace );
					stringBuilder[ i * 2 ] = rep.Replace[ 0 ];
					stringBuilder[ ( i * 2 ) + 1 ] = rep.Replace[ 1 ];
				}
			);

		}

	}

}
