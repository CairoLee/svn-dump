using System;

namespace GodLesZ.Library.Amf.Net {
	/// <summary>
	/// Event dispatched when a remote SharedObject instance has been updated by the server.
	/// </summary>
	public class SyncEventArgs : EventArgs {
		ASObject[] _changeList;

		internal SyncEventArgs(ASObject[] changeList) {
			_changeList = changeList;
		}
		/// <summary>
		/// <para>
		/// An array of objects; each object contains properties that describe the changed members of a remote shared object.
		/// The properties of each object are <b>code</b>, <b>name</b>, and <b>oldValue</b>.
		/// </para>
		/// <para>
		/// When you initially connect to a remote shared object that is persistent locally and/or on the server, all the properties of this object are set to empty strings.
		/// </para>
		/// </summary>
		public ASObject[] ChangeList {
			get { return _changeList; }
		}
	}
}
