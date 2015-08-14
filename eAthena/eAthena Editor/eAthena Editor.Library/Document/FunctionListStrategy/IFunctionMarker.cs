using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Library.Document {
	
	interface IFunctionMarker {
		string Name {
			get;
			set;
		}
		int Offset {
			get;
			set;
		}
		EFunctionMarkerType Type {
			get;
			set;
		}
	}

}
