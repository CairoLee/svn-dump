using System;
using System.IO;
using System.Net;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Context;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Messages;
using GodLesZ.Library.Amf.Messaging.Rtmp;
using GodLesZ.Library.Amf.Util;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Endpoints {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	internal class RtmpEndpoint : EndpointBase {
		private static readonly ILog log = LogManager.GetLogger(typeof(RtmpEndpoint));

		//static object _objLock = new object();
		public static string Slash = "/";

		RtmpServer _rtmpServer;

		public RtmpEndpoint(MessageBroker messageBroker, ChannelDefinition channelDefinition)
			: base(messageBroker, channelDefinition) {
		}

		public override void Start() {
			try {
				if (log.IsInfoEnabled)
					log.Info(__Res.GetString(__Res.RtmpEndpoint_Start));

				//Each Application has its own Scope hierarchy and the root scope is WebScope. 
				//There's a global scope that aims to provide common resource sharing across Applications namely GlobalScope.
				//The GlobalScope is the parent of all WebScopes. 
				//Other scopes in between are all instances of Scope. Each scope takes a name. 
				//The GlobalScope is named "default".
				//The WebScope is named per Application context name.
				//The Scope is named per path name.
				IGlobalScope globalScope = GetMessageBroker().GlobalScope;
				string baseDirectory;
				if (FluorineContext.Current != null)
					baseDirectory = Path.Combine(FluorineContext.Current.ApplicationBaseDirectory, "apps");
				else
					baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apps");
				if (Directory.Exists(baseDirectory)) {
					foreach (string appDirectory in Directory.GetDirectories(baseDirectory)) {
						DirectoryInfo directoryInfo = new DirectoryInfo(appDirectory);
						string appName = directoryInfo.Name;
						string appConfigFile = Path.Combine(appDirectory, "app.config");
						ApplicationConfiguration configuration = ApplicationConfiguration.Load(appConfigFile);
						WebScope scope = new WebScope(this, globalScope, configuration);

						// Create context for the WebScope and initialize 
						ScopeContext scopeContext = new ScopeContext("/" + appName, globalScope.Context.ClientRegistry, globalScope.Context.ScopeResolver, globalScope.Context.ServiceInvoker, null);
						// Store context in scope
						scope.Context = scopeContext;
						// ApplicationAdapter
						IFlexFactory factory = GetMessageBroker().GetFactory(configuration.ApplicationHandler.Factory);
						FactoryInstance factoryInstance = factory.CreateFactoryInstance(this.Id, null);
						if (factoryInstance == null) {
							string msg = string.Format("Missing factory {0}", configuration.ApplicationHandler.Factory);
							log.Fatal(msg);
							throw new NotSupportedException(msg);
						}
						factoryInstance.Source = configuration.ApplicationHandler.Type;
						object applicationHandlerInstance = factoryInstance.Lookup();
						IScopeHandler scopeHandler = applicationHandlerInstance as IScopeHandler;
						if (scopeHandler == null) {
							log.Error(__Res.GetString(__Res.Type_InitError, configuration.ApplicationHandler.Type));
							throw new TypeInitializationException(configuration.ApplicationHandler.Type, null);
						}
						scope.Handler = scopeHandler;
						// Make available as "/<directoryName>" and allow access from all hosts
						scope.SetContextPath("/" + appName);
						// Register WebScope in server
						scope.Register();
					}
				}
				_rtmpServer = new RtmpServer(this);

				UriBase uri = this.ChannelDefinition.GetUri();
				if (uri.Protocol == "http" || uri.Protocol == "https") {
					log.Info(string.Format("Rtmp endpoint was not started, specified protocol: {0}", uri.Protocol));
					return;
				}
				int port = 1935;
				if (uri.Port != null && uri.Port != string.Empty) {
					try {
						port = System.Convert.ToInt32(uri.Port);
					} catch (FormatException ex) {
						log.Error("Invalid port", ex);
						return;
					}
				}
				if (log.IsInfoEnabled)
					log.Info(__Res.GetString(__Res.RtmpEndpoint_Starting, port.ToString()));

				IPEndPoint ipEndPoint;
				if (this.ChannelDefinition.Properties.BindAddress != null) {
					IPAddress ipAddress = IPAddress.Parse(this.ChannelDefinition.Properties.BindAddress);
					ipEndPoint = new IPEndPoint(ipAddress, port);
				} else
					ipEndPoint = new IPEndPoint(IPAddress.Any, port);
				_rtmpServer.AddListener(ipEndPoint);
				_rtmpServer.OnError += new ErrorHandler(OnError);
				_rtmpServer.Start();

				if (log.IsInfoEnabled)
					log.Info(__Res.GetString(__Res.RtmpEndpoint_Started));
			} catch (Exception ex) {
				if (log.IsFatalEnabled)
					log.Fatal("RtmpEndpoint failed", ex);
			}
		}

		public override void Stop() {
			try {
				if (log.IsInfoEnabled)
					log.Info(__Res.GetString(__Res.RtmpEndpoint_Stopping));
				if (_rtmpServer != null) {
					_rtmpServer.Stop();
					_rtmpServer.OnError -= new ErrorHandler(OnError);
					_rtmpServer.Dispose();
					_rtmpServer = null;
				}
				if (log.IsInfoEnabled)
					log.Info(__Res.GetString(__Res.RtmpEndpoint_Stopped));
			} catch (Exception ex) {
				if (log.IsFatalEnabled)
					log.Fatal(__Res.GetString(__Res.RtmpEndpoint_Failed), ex);
			}
		}

		public override void Push(IMessage message, MessageClient messageClient) {
			/*
			IMessageConnection messageConnection = messageClient.MessageConnection;
			Debug.Assert(messageConnection != null);
			if (messageConnection != null)
				messageConnection.Push(message, messageClient);
			*/
			ISession session = messageClient.Session;
			System.Diagnostics.Debug.Assert(session != null);
			session.Push(message, messageClient);
		}


		private void OnError(object sender, ServerErrorEventArgs e) {
			System.Diagnostics.Debug.WriteLine(e.Exception.Message);
			if (log.IsErrorEnabled)
				log.Error(__Res.GetString(__Res.RtmpEndpoint_Error), e.Exception);
		}
		/// <summary>
		/// This property supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		public override int ClientLeaseTime {
			get {
				int timeout = this.GetMessageBroker().FlexClientSettings.TimeoutMinutes;
				return timeout;
			}
		}
	}
}
