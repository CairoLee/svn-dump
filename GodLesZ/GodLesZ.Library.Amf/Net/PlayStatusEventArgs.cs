using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// Dispatched when a NetStream object has completely played a stream.
	/// </summary>
	public class PlayStatusEventArgs : EventArgs {
		readonly IDictionary _infoObject;

		internal PlayStatusEventArgs(IDictionary infoObject) {
			_infoObject = infoObject;
		}

		public IDictionary InfoObject {
			get { return _infoObject; }
		}
	}
}
