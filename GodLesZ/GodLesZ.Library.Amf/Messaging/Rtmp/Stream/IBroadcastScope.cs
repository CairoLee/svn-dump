using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Broadcast scope is marker interface that represents object that works as basic scope and
	/// has pipe connection event dispatching capabilities.
	/// </summary>
	[CLSCompliant(false)]
	public interface IBroadcastScope : IBasicScope, IPipe {
	}
}
