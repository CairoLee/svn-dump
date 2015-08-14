using System;
using GodLesZ.Library.Amf.Messaging.Api;
using log4net;

namespace GodLesZ.Library.Amf.Context {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class FluorineRtmpContext : FluorineContext {
		private static readonly ILog log = LogManager.GetLogger(typeof(FluorineRtmpContext));

		private FluorineRtmpContext(IConnection connection) {
			_connection = connection;
			_session = connection.Session;
			_client = connection.Client;
			if (_client != null)
				_client.Renew();
		}

		internal static void Initialize(IConnection connection) {
			FluorineRtmpContext fluorineContext = new FluorineRtmpContext(connection);
			WebSafeCallContext.SetData(FluorineContext.FluorineContextKey, fluorineContext);
			if (log.IsDebugEnabled)
				log.Debug(__Res.GetString(__Res.Context_Initialized, connection.ConnectionId, connection.Client != null ? connection.Client.Id : "[not set]", connection.Session != null ? connection.Session.Id : "[not set]"));
		}

		public FluorineRtmpContext() {
		}

		/// <summary>
		/// Gets the physical drive path of the application directory for the application hosted in the current application domain.
		/// </summary>
		public override string RootPath {
			get {
				//return HttpRuntime.AppDomainAppPath;
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}

		/// <summary>
		/// Gets the virtual path of the current request.
		/// </summary>
		public override string RequestPath {
			get { return null; }
		}
		/// <summary>
		/// Gets the ASP.NET application's virtual application root path on the server.
		/// </summary>
		public override string RequestApplicationPath {
			get { return null; }
		}

		public override string ApplicationPath {
			get {
				return null;
			}
		}

		/// <summary>
		/// Gets the absolute URI from the URL of the current request.
		/// </summary>
		public override string AbsoluteUri {
			get { return null; }
		}

		public override string ActivationMode {
			get {
				return null;
			}
		}

		public override string PhysicalApplicationPath {
			get {
				//return HttpRuntime.AppDomainAppPath;
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}
	}
}
