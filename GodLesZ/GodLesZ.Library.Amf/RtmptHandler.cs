using System;
using System.Web;
using GodLesZ.Library.Amf.Messaging;
using log4net;

namespace GodLesZ.Library.Amf {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class RtmptHandler : IHttpHandler {
		private static readonly ILog log = LogManager.GetLogger(typeof(RtmptHandler));

		private MessageServer GetMessageServer(HttpContext context) {
			return context.Application[FluorineGateway.FluorineMessageServerKey] as MessageServer;
		}

		#region IHttpHandler Members

		/// <summary>
		/// Gets a value indicating whether another request can use the IHttpHandler instance.
		/// </summary>
		public bool IsReusable {
			get { return true; }
		}
		/// <summary>
		/// Processing of RTMPT HTTP Web requests.
		/// </summary>
		/// <param name="context">An HttpContext object that provides references to the intrinsic server objects used to service HTTP requests.</param>
		public void ProcessRequest(HttpContext context) {
			HttpApplication httpApplication = context.ApplicationInstance;
			if (httpApplication.Request.ContentType == ContentType.RTMPT) {
				httpApplication.Response.Clear();
				httpApplication.Response.ContentType = ContentType.RTMPT;

				log4net.ThreadContext.Properties["ClientIP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
				if (log.IsDebugEnabled)
					log.Debug(__Res.GetString(__Res.Amf_Begin));

				try {
					//FluorineWebContext.Initialize();

					MessageServer messageServer = GetMessageServer(context);
					if (messageServer != null)
						messageServer.ServiceRtmpt();
					else
						log.Fatal(__Res.GetString(__Res.MessageServer_AccessFail));

					if (log.IsDebugEnabled)
						log.Debug(__Res.GetString(__Res.Amf_End));

					httpApplication.CompleteRequest();
				} catch (Exception ex) {
					log.Fatal(__Res.GetString(__Res.Amf_Fatal), ex);
					httpApplication.Response.Clear();
					httpApplication.Response.ClearHeaders();
					httpApplication.Response.Status = __Res.GetString(__Res.Amf_Fatal404) + " " + ex.Message;
					httpApplication.CompleteRequest();
				}
			}
		}

		#endregion
	}
}
