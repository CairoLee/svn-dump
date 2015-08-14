using System;
using System.Reflection;
#if !SILVERLIGHT
using log4net;
#endif

namespace GodLesZ.Library.Amf.Invocation {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class InvocationHandler {
#if !SILVERLIGHT
		private static readonly ILog log = LogManager.GetLogger(typeof(InvocationHandler));
#endif
		MethodInfo _methodInfo;
		/// <summary>
		/// Initializes a new instance of the InvocationHandler class.
		/// </summary>
		/// <param name="methodInfo"></param>
		public InvocationHandler(MethodInfo methodInfo) {
			_methodInfo = methodInfo;
		}

		public object Invoke(object obj, object[] arguments) {
#if !SILVERLIGHT
			if (log.IsDebugEnabled)
				log.Debug(__Res.GetString(__Res.Invoke_Method, _methodInfo.DeclaringType.FullName + "." + _methodInfo.Name));
#endif

			object result = _methodInfo.Invoke(obj, arguments);

			object[] attributes = _methodInfo.GetCustomAttributes(false);
			if (attributes != null && attributes.Length > 0) {
				InvocationManager invocationManager = new InvocationManager();
				invocationManager.Result = result;
				for (int i = 0; i < attributes.Length; i++) {
					Attribute attribute = attributes[i] as Attribute;
					if (attribute is IInvocationCallback) {
						IInvocationCallback invocationCallback = attribute as IInvocationCallback;
						invocationCallback.OnInvoked(invocationManager, _methodInfo, obj, arguments, result);
					}
				}
				for (int i = 0; i < attributes.Length; i++) {
					Attribute attribute = attributes[i] as Attribute;
					if (attribute is IInvocationResultHandler) {
						IInvocationResultHandler invocationResultHandler = attribute as IInvocationResultHandler;
						invocationResultHandler.HandleResult(invocationManager, _methodInfo, obj, arguments, result);
					}
				}
				return invocationManager.Result;
			}
			return result;
		}


	}
}
