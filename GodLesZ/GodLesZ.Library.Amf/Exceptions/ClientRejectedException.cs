
namespace GodLesZ.Library.Amf.Exceptions {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class ClientRejectedException : FluorineException {
		object _reason;

		/// <summary>
		/// Gets the object representing the rejection reason.
		/// </summary>
		public object Reason { get { return _reason; } }

		/// <summary>
		/// Initializes a new instance of the ClientRejectedException class.
		/// </summary>
		/// <param name="reason"></param>
		public ClientRejectedException(object reason) {
			_reason = reason;
		}
	}
}
