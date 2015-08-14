using System;
using System.Collections;
using System.Web;
using GodLesZ.Library.Amf.Messaging;
using GodLesZ.Library.Amf.Util;
using log4net;

namespace GodLesZ.Library.Amf.Json.Rpc {
	class JsonRpcHandler {
		private static readonly ILog log = LogManager.GetLogger(typeof(JsonRpcHandler));

		HttpContext _context;
		static Hashtable Features;

		static JsonRpcHandler() {
			Features = new Hashtable();
		}

		public JsonRpcHandler(HttpContext context) {
			_context = context;
		}

		public void ProcessRequest() {
			HttpRequest request = _context.Request;
			string verb = request.RequestType;
			string feature = null;
			if (StringUtils.CaselessEquals(verb, "GET") || StringUtils.CaselessEquals(verb, "HEAD")) {
				feature = request.QueryString[null];
			} else if (StringUtils.CaselessEquals(verb, "POST")) {
				//POST means RPC.
				feature = "rpc";
			}
			IHttpHandler handler = GetFeature(feature) as IHttpHandler;
			handler.ProcessRequest(_context);
		}

		private object GetFeature(string feature) {
			if (Features.Contains(feature))
				return Features[feature];
			lock (Features.SyncRoot) {
				if (!Features.Contains(feature)) {
					MessageBroker messageBroker = MessageBroker.GetMessageBroker(MessageBroker.DefaultMessageBrokerId);
					if (feature == "proxy") {
						IHttpHandler handler = new JsonRpcProxyGenerator(messageBroker);
						Features[feature] = handler;
						return handler;
					}
					if (feature == "rpc") {
						IHttpHandler handler = new JsonRpcExecutive(messageBroker);
						Features[feature] = handler;
						return handler;
					}
				} else
					return Features[feature];
			}
			throw new NotImplementedException(string.Format("The requested feature {0} is not implemented ", feature));
		}

	}
}
