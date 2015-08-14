using System;
using System.Web;
using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Rtmpt;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RtmptEndpoint : EndpointBase {
		public const string FluorineRtmptEndpointId = "__@fluorinertmpt";

		private static readonly ILog log = LogManager.GetLogger(typeof(RtmptEndpoint));
		//static object _objLock = new object();
		RtmptServer _rtmptServer;

		public RtmptEndpoint(MessageBroker messageBroker, ChannelDefinition channelDefinition)
			: base(messageBroker, channelDefinition) {
		}

		public override void Start() {
			_rtmptServer = new RtmptServer(this);
		}

		public override void Stop() {
		}

		public override void Service() {
			_rtmptServer.Service(HttpContext.Current.Request, HttpContext.Current.Response);
		}

		public void Service(RtmptRequest rtmptRequest) {
			_rtmptServer.Service(rtmptRequest);
		}

		public override int ClientLeaseTime {
			get {
				int timeout = this.GetMessageBroker().FlexClientSettings.TimeoutMinutes;
				timeout = Math.Max(timeout, 1);//start with 1 minute timeout at least
				return timeout;
			}
		}
	}
}
