using System;
using GodLesZ.Library.Amf.Messaging.Api;
using log4net;

namespace GodLesZ.Library.Amf.Context {
	sealed class _TimeoutContext : FluorineContext {
		private static readonly ILog log = LogManager.GetLogger(typeof(_TimeoutContext));

		private _TimeoutContext() {
		}

		internal _TimeoutContext(ISession session) {
			_session = session;
		}

		internal _TimeoutContext(IClient client) {
			_client = client;
		}

		internal _TimeoutContext(IMessageClient messageClient) {
			_session = messageClient.Session;
			_client = messageClient.Client;
			if (log.IsDebugEnabled)
				log.Debug(__Res.GetString(__Res.Context_Initialized, "[not available]", _client != null ? _client.Id : "[not available]", _session != null ? _session.Id : "[not available]"));
		}

		public override string RootPath {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override string RequestPath {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override string RequestApplicationPath {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override string PhysicalApplicationPath {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override string ApplicationPath {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override string AbsoluteUri {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override string ActivationMode {
			get { throw new NotImplementedException("The method or operation is not implemented."); }
		}

		public override IResource GetResource(string location) {
			return new FileSystemResource(location);
		}
	}
}
