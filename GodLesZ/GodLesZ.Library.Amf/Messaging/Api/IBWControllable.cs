
namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Marks an object that can be bandwidth controlled.
	/// <para>
	/// A bw-controlled object has the bandwidth config property and a link to the parent controllable object.
	/// </para>
	/// <para>
	/// The parent controllable object acts as the bandwidth provider
	/// for this object, thus generates a tree structure, in which the null parent means the host. 
	/// The next depth level is the IClient. The following is IStreamCapableConnection.
	/// The deepest level is IClientStream. That is, bandwidth can be separately configured for
	/// client stream or connection, or client or the whole application.
	/// </para>
	/// <para>
	/// The summary of children's bandwidth can't exceed the parent's bandwidth
	/// even though the children's bandwidth could be configured larger than the parent's bandwidth.
	/// </para>
	/// </summary>
	public interface IBWControllable {
		/// <summary>
		/// Returns parent IBWControllable object.
		/// </summary>
		/// <returns>Parent IBWControllable.</returns>
		IBWControllable GetParentBWControllable();
		/// <summary>
		/// Gets or sets bandwidth configuration object.
		/// Bandwidth configuration allows you to set bandwidth size for audio, video and total amount.
		/// </summary>
		IBandwidthConfigure BandwidthConfiguration { get; set; }
	}
}
