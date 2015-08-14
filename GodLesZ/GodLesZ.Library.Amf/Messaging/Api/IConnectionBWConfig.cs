
namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// The bandwidth configure for connection that has an extra
	/// property "upstreamBandwidth" which is not used by Bandwidth Control Framework.
	/// </summary>
	public interface IConnectionBWConfig : IBandwidthConfigure {
		/// <summary>
		/// Gets or sets the upstream bandwidth to be notified to the client.
		/// Upstream is the data that is sent from the client to the server.
		/// </summary>
		long UpstreamBandwidth { get; set; }
		/// <summary>
		/// Gets downstream bandwidth.
		/// </summary>
		/// <value>Downstream bandwidth, from server to client.</value>
		long DownstreamBandwidth { get; }
	}
}
