
namespace GodLesZ.Library.Amf.Exceptions {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class ServiceNotFoundException : FluorineException {
		/// <summary>
		/// Initializes a new instance of the ServiceNotFoundException class.
		/// </summary>
		/// <param name="serviceName"></param>
		public ServiceNotFoundException(string serviceName)
			: base(__Res.GetString(__Res.Service_NotFound, serviceName)) {
		}
	}
}
