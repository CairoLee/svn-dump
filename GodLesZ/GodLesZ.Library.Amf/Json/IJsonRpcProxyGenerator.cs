using System.Web;
using GodLesZ.Library.Amf.Json.Services;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Json {
	/// <summary>
	/// Json-Rpc proxy code generator interface.
	/// </summary>
	public interface IJsonRpcProxyGenerator {
		/// <summary>
		/// Generates Json-Rpc Proxy.
		/// </summary>
		/// <param name="service"></param>
		/// <param name="writer"></param>
		/// <param name="request"></param>
		/// <remarks>
		/// A proxy must post back to request.Url
		/// </remarks>
		void WriteProxy(ServiceClass service, IndentedTextWriter writer, HttpRequest request);
	}
}
