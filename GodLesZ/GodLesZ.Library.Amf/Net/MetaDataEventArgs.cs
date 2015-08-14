using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// Dispatched when the application receives descriptive information embedded in the video being played.
	/// </summary>
	public class MetaDataEventArgs : EventArgs {
		readonly IDictionary _obj;

		internal MetaDataEventArgs(IDictionary obj) {
			_obj = obj;
		}

		public IDictionary Object {
			get { return _obj; }
		}
	}
}
