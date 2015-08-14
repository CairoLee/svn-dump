using GodLesZ.Library.Amf.Messaging.Api;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Service {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	interface IServiceResolver {
		/// <summary>
		/// Search for a service with the given name in the scope.
		/// </summary>
		/// <param name="scope">The scope to search in.</param>
		/// <param name="serviceName">The name of the service.</param>
		/// <returns>The object implemening the service or <code>null</code> if service doesn't exist.</returns>
		object ResolveService(IScope scope, string serviceName);
	}
}
