using System;
using System.Collections;
using System.Reflection;
using GodLesZ.Library.Amf.IO;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Util;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Endpoints.Filter {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class WsdlFilter : AbstractFilter {
		private static readonly ILog log = LogManager.GetLogger(typeof(WsdlFilter));

		/// <summary>
		/// Initializes a new instance of the WsdlFilter class.
		/// </summary>
		public WsdlFilter() {
		}

		#region IFilter Members

		public override void Invoke(AMFContext context) {
			for (int i = 0; i < context.AMFMessage.BodyCount; i++) {
				AMFBody amfBody = context.AMFMessage.GetBodyAt(i);

				if (!amfBody.IsEmptyTarget) {
					if (amfBody.IsWebService) {
						try {
							Type type = GetTypeForWebService(amfBody.TypeName);
							if (type != null) {
								//We can handle it with a LibraryAdapter now
								amfBody.Target = type.FullName + "." + amfBody.Method;
							} else {
								Exception exception = new TypeInitializationException(amfBody.TypeName, null);
								if (log != null && log.IsErrorEnabled)
									log.Error(__Res.GetString(__Res.Type_InitError, amfBody.Target), exception);

								ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, exception);
								context.MessageOutput.AddBody(errorResponseBody);
							}
						} catch (Exception exception) {
							if (log != null && log.IsErrorEnabled)
								log.Error(__Res.GetString(__Res.Wsdl_ProxyGen, amfBody.Target), exception);
							ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, exception);
							context.MessageOutput.AddBody(errorResponseBody);
						}
					}
				} else {
					//Flex message
					object content = amfBody.Content;
					if (content is IList)
						content = (content as IList)[0];
					IMessage message = content as IMessage;
					if (message != null && message is RemotingMessage) {
						RemotingMessage remotingMessage = message as RemotingMessage;
						//Only RemotingMessages for now
						string source = remotingMessage.source;
						if (source != null && source.ToLower().EndsWith(".asmx")) {
							try {
								Type type = GetTypeForWebService(source);
								if (type != null) {
									//We can handle it with a LibraryAdapter now
									remotingMessage.source = type.FullName;
								} else {
									Exception exception = new TypeInitializationException(source, null);
									if (log != null && log.IsErrorEnabled)
										log.Error(__Res.GetString(__Res.Type_InitError, source), exception);

									ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, message, exception);
									context.MessageOutput.AddBody(errorResponseBody);
								}
							} catch (Exception exception) {
								if (log != null && log.IsErrorEnabled)
									log.Error(__Res.GetString(__Res.Wsdl_ProxyGen, source), exception);
								ErrorResponseBody errorResponseBody = new ErrorResponseBody(amfBody, message, exception);
								context.MessageOutput.AddBody(errorResponseBody);
							}
						}
					}
				}
			}
		}

		#endregion

		private Type GetTypeForWebService(string webService) {
			if (log != null && log.IsInfoEnabled)
				log.Info(__Res.GetString(__Res.Wsdl_ProxyGen, webService));

			Assembly assembly = WsdlHelper.GetAssemblyFromAsmx(webService);
			if (assembly != null) {
				Type[] types = assembly.GetTypes();
				if (types.Length > 0) {
					return types[0];
				}
			}
			return null;
		}
	}
}
