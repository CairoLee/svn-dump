
namespace GodLesZ.Library.Amf.Messaging.Api.Service {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IPendingServiceCallback {
		/// <summary>
		/// Triggered when results are recieved.
		/// </summary>
		/// <param name="call"></param>
		void ResultReceived(IPendingServiceCall call);
	}
}
