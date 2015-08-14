
using System;
using System.Collections;
using System.Reflection;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Invocation;
using GodLesZ.Library.Amf.IO;
using GodLesZ.Library.Amf.Messaging;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Messaging.Services;
using log4net;

namespace GodLesZ.Library.Amf.Remoting {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RemotingAdapter : ServiceAdapter {
		private static readonly ILog log = LogManager.GetLogger(typeof(RemotingAdapter));

		public RemotingAdapter() {
		}

		public override object Invoke(IMessage message) {
			object result = null;
			RemotingMessage remotingMessage = message as RemotingMessage;
			string operation = remotingMessage.operation;
			string className = this.DestinationDefinition.Properties.Source;
			//This property is provided for backwards compatibility. The best practice, however, is to not expose the underlying source of a 
			//RemoteObject destination on the client and only one source to a destination.
			if (remotingMessage.source != null && remotingMessage.source != string.Empty) {
				if (className == "*")
					className = remotingMessage.source;
				if (className != remotingMessage.source) {
					string msg = __Res.GetString(__Res.Type_MismatchMissingSource, remotingMessage.source, this.DestinationDefinition.Properties.Source as string);
					throw new MessageException(msg, new TypeLoadException(msg));
				}
			}

			if (className == null)
				throw new TypeInitializationException("null", null);

			//Service mapping obsolete for Flex Remoting
			/*
			if (FluorineConfiguration.Instance.ServiceMap != null)
			{
				string method = remotingMessage.operation;
				if (FluorineConfiguration.Instance.ServiceMap.Contains(className))
				{
					string serviceLocation = FluorineConfiguration.Instance.ServiceMap.GetServiceLocation(className);
					method = FluorineConfiguration.Instance.ServiceMap.GetMethod(className, method);
					if (log != null && log.IsDebugEnabled)
						log.Debug(__Res.GetString(__Res.Service_Mapping, className + "." + remotingMessage.operation, serviceLocation + "." + method));

					className = serviceLocation;
					remotingMessage.operation = method;
				}
			}
			*/
			//Cache check
			string source = className + "." + operation;
			IList parameterList = remotingMessage.body as IList;
			string key = GodLesZ.Library.Amf.Configuration.CacheMap.GenerateCacheKey(source, parameterList);
			if (FluorineConfiguration.Instance.CacheMap.ContainsValue(key)) {
				result = GodLesZ.Library.Amf.Configuration.FluorineConfiguration.Instance.CacheMap.Get(key);
				if (result != null) {
					if (log != null && log.IsDebugEnabled)
						log.Debug(__Res.GetString(__Res.Cache_HitKey, operation, key));
					return result;
				}
			}

			FactoryInstance factoryInstance = this.Destination.GetFactoryInstance();
			factoryInstance.Source = className;
			object instance = factoryInstance.Lookup();

			if (instance != null) {
				try {
					Type type = instance.GetType();
					bool isAccessible = TypeHelper.GetTypeIsAccessible(type);
					if (!isAccessible) {
						string msg = __Res.GetString(__Res.Type_InitError, type.FullName);
						throw new MessageException(msg, new TypeLoadException(msg));
					}

					MethodInfo mi = MethodHandler.GetMethod(type, operation, parameterList);
					if (mi != null) {
						try {
							//Messagebroker checked xml configured security, check attributes too
							object[] roleAttributes = mi.GetCustomAttributes(typeof(RoleAttribute), true);
							if (roleAttributes != null && roleAttributes.Length == 1) {
								RoleAttribute roleAttribute = roleAttributes[0] as RoleAttribute;
								string[] roles = roleAttribute.Roles.Split(',');

								bool authorized = this.Destination.Service.GetMessageBroker().LoginManager.DoAuthorization(roles);
								if (!authorized)
									throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_AccessNotAllowed));
							}

							ParameterInfo[] parameterInfos = mi.GetParameters();
							object[] args = new object[parameterInfos.Length];
							parameterList.CopyTo(args, 0);
							TypeHelper.NarrowValues(args, parameterInfos);
							InvocationHandler invocationHandler = new InvocationHandler(mi);
							result = invocationHandler.Invoke(instance, args);
						} catch (TargetInvocationException exception) {
							MessageException messageException = null;
							if (exception.InnerException is MessageException)
								messageException = exception.InnerException as MessageException;//User code throws MessageException
							else
								messageException = new MessageException(exception.InnerException);

							if (log.IsDebugEnabled)
								log.Debug(__Res.GetString(__Res.Invocation_Failed, mi.Name, messageException.Message));
							return messageException.GetErrorMessage();
							//Do not throw here, we do not want to log user code exceptions.
							//throw messageException;
						}

					} else
						throw new MessageException(new MissingMethodException(className, operation));
				} catch (MessageException) {
					throw;
				} catch (Exception exception) {
					MessageException messageException = new MessageException(exception);
					throw messageException;
				} finally {
					factoryInstance.OnOperationComplete(instance);
				}
			} else
				throw new MessageException(new TypeInitializationException(className, null));

			if (FluorineConfiguration.Instance.CacheMap != null && FluorineConfiguration.Instance.CacheMap.ContainsCacheDescriptor(source)) {
				//The result should be cached
				CacheableObject cacheableObject = new CacheableObject(source, key, result);
				FluorineConfiguration.Instance.CacheMap.Add(cacheableObject.Source, cacheableObject.CacheKey, cacheableObject);
				result = cacheableObject;
			}
			return result;
		}
	}
}
