using GodLesZ.Library.Amf.Messaging.Api;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// The registry context for a controllable.
	/// </summary>
	public interface IBWControlContext {
		/// <summary>
		/// Returns the controllable that registered.
		/// </summary>
		/// <returns></returns>
		IBWControllable GetBWControllable();
	}
}
