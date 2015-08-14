using System;
using GodLesZ.Library.Amf.Messaging.Api.Messaging;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Messaging {
	/// <summary>
	/// Filter marker interface groups consumer and provider interfaces
	/// </summary>
	[CLSCompliant(false)]
	public interface IFilter : IConsumer, IProvider {
	}
}
