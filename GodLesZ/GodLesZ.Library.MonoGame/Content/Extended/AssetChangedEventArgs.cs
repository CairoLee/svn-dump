using System;

namespace GodLesZ.Library.MonoGame.Content.Extended {
	/// <summary>
	/// Event Args to provide information about a changed asset item
	/// </summary>
	public class AssetChangedEventArgs : EventArgs {
		/// <summary>
		/// New asset reference
		/// </summary>
		public object NewReference;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="newRef">New asset reference</param>
		public AssetChangedEventArgs( object newRef ) {
			NewReference = newRef;
		}
	}
}