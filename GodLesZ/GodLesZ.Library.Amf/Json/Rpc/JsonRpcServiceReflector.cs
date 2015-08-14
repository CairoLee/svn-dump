//JSON RPC based on Jayrock - JSON and JSON-RPC for Microsoft .NET Framework and Mono
//http://jayrock.berlios.de/
using System;
using GodLesZ.Library.Amf.Collections;
using GodLesZ.Library.Amf.Json.Services;
using GodLesZ.Library.Amf.Util;
using log4net;

namespace GodLesZ.Library.Amf.Json.Rpc {
	internal sealed class JsonRpcServiceReflector {
		private static readonly ILog log = LogManager.GetLogger(typeof(JsonRpcServiceReflector));
		private static readonly CopyOnWriteDictionary _classByTypeCache = new CopyOnWriteDictionary();

		public static ServiceClass FromType(Type type) {
			ValidationUtils.ArgumentNotNull(type, "type");

			ServiceClass serviceClass = (ServiceClass)_classByTypeCache[type];
			if (serviceClass == null) {
				serviceClass = BuildFromType(type);
				_classByTypeCache[type] = serviceClass;
			}
			return serviceClass;
		}

		private static ServiceClass BuildFromType(Type type) {
			bool isAccessible = TypeHelper.GetTypeIsAccessible(type);
			if (isAccessible) {
				ServiceClass serviceClass = new ServiceClass(type);
				return serviceClass;
			} else {
				string msg = __Res.GetString(__Res.Type_InitError, type.FullName);
				if (log.IsErrorEnabled)
					log.Error(msg);
				throw new TypeLoadException(msg);
			}
		}

		private JsonRpcServiceReflector() {
			throw new NotSupportedException();
		}
	}
}
