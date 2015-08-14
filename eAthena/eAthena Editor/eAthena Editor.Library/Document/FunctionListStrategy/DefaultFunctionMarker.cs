using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Library.Document {

	public class DefaultFunctionMarker : IFunctionMarker {
		public string Name {
			get;
			set;
		}

		public int Offset {
			get;
			set;
		}

		public EFunctionMarkerType Type {
			get;
			set;
		}


		public DefaultFunctionMarker(string name, int offset)
			: this(name, offset, EFunctionMarkerType.Abstract) {
		}

		public DefaultFunctionMarker(string name, int offset, EFunctionMarkerType type) {
			Name = name;
			Offset = offset;
			Type = type;
		}

	}

}
