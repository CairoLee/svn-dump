using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.IO;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Endpoints.Filter {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ServiceMapFilter : AbstractFilter {
		private static readonly ILog log = LogManager.GetLogger(typeof(ServiceMapFilter));
		EndpointBase _endpoint;

		/// <summary>
		/// Initializes a new instance of the ServiceMapFilter class.
		/// </summary>
		/// <param name="endpoint"></param>
		public ServiceMapFilter(EndpointBase endpoint) {
			_endpoint = endpoint;
		}

		#region IFilter Members

		public override void Invoke(AMFContext context) {
			for (int i = 0; i < context.AMFMessage.BodyCount; i++) {
				AMFBody amfBody = context.AMFMessage.GetBodyAt(i);

				if (!amfBody.IsEmptyTarget) {//Flash
					if (FluorineConfiguration.Instance.ServiceMap != null) {

						string typeName = amfBody.TypeName;
						string method = amfBody.Method;
						if (typeName != null && FluorineConfiguration.Instance.ServiceMap.Contains(typeName)) {
							string serviceLocation = FluorineConfiguration.Instance.ServiceMap.GetServiceLocation(typeName);
							method = FluorineConfiguration.Instance.ServiceMap.GetMethod(typeName, method);
							string target = serviceLocation + "." + method;
							if (log != null && log.IsDebugEnabled)
								log.Debug(__Res.GetString(__Res.Service_Mapping, amfBody.Target, target));
							amfBody.Target = target;
						}
					}
				}
			}
		}

		#endregion
	}
}
