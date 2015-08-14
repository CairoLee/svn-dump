using System.Collections;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.IO;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Endpoints.Filter {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class CacheFilter : AbstractFilter {
		private static readonly ILog log = LogManager.GetLogger(typeof(CacheFilter));

		public CacheFilter() {
		}

		#region IFilter Members

		public override void Invoke(AMFContext context) {
			MessageOutput messageOutput = context.MessageOutput;
			if (FluorineConfiguration.Instance.CacheMap != null && FluorineConfiguration.Instance.CacheMap.Count > 0) {
				for (int i = 0; i < context.AMFMessage.BodyCount; i++) {
					AMFBody amfBody = context.AMFMessage.GetBodyAt(i);
					//Check if response exists.
					ResponseBody responseBody = messageOutput.GetResponse(amfBody);
					if (responseBody != null) {
						//AuthenticationFilter may insert response.
						continue;
					}

					if (!amfBody.IsEmptyTarget) {
						string source = amfBody.Target;
						IList arguments = amfBody.GetParameterList();
						string key = GodLesZ.Library.Amf.Configuration.CacheMap.GenerateCacheKey(source, arguments);
						//Flash message
						if (FluorineConfiguration.Instance.CacheMap.ContainsValue(key)) {
							object cachedContent = FluorineConfiguration.Instance.CacheMap.Get(key);

							if (log != null && log.IsDebugEnabled)
								log.Debug(__Res.GetString(__Res.Cache_HitKey, amfBody.Target, key));

							CachedBody cachedBody = new CachedBody(amfBody, cachedContent);
							messageOutput.AddBody(cachedBody);
						}
					}
				}
			}
		}

		#endregion

	}
}
