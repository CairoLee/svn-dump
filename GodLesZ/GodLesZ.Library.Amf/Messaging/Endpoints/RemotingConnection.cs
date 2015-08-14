
using System.Collections;
using System.Net;
using GodLesZ.Library.Amf.Messaging.Api;
using log4net;


namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	class RemotingConnection : BaseConnection {
		private static ILog log = LogManager.GetLogger(typeof(RemotingConnection));
		IEndpoint _endpoint;

		public RemotingConnection(IEndpoint endpoint, ISession session, string path, string connectionId, Hashtable parameters)
			: base(path, connectionId, parameters) {
			_endpoint = endpoint;
			_session = session;
		}

		public override IPEndPoint RemoteEndPoint {
			get {
				IPAddress ipAddress = IPAddress.Parse(System.Web.HttpContext.Current.Request.UserHostAddress);
				return new IPEndPoint(ipAddress, 80);
			}
		}

		public IEndpoint Endpoint { get { return _endpoint; } }

		public override long ReadBytes {
			get { return 0; }
		}

		public override long WrittenBytes {
			get { return 0; }
		}

		public override int LastPingTime {
			get { return -1; }
		}

		/*
		public override int ClientLeaseTime
		{
			get
			{
				int timeout = this.Endpoint.GetMessageBroker().FlexClientSettings.TimeoutMinutes;
				if (this.Endpoint is AMFEndpoint)
				{
					timeout = Math.Max(timeout, 1);//start with 1 minute timeout at least
					AMFEndpoint amfEndpoint = this.Endpoint as AMFEndpoint;
					Debug.Assert(amfEndpoint.GetSettings().IsPollingEnabled);
					int pollingInterval = amfEndpoint.GetSettings().PollingIntervalSeconds / 60;
					timeout = Math.Max(timeout, pollingInterval + 1);//set timout 1 minute longer then the polling interval in minutes
				}
				return timeout;
			}
		}
		*/
	}
}
