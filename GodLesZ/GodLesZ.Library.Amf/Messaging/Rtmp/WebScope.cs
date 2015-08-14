using System;
using System.Collections;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Endpoints;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class WebScope : Scope {
		private RtmpEndpoint _endpoint;
		ApplicationConfiguration _appConfig;
		protected string _contextPath;
		/// <summary>
		/// Is the scope currently shutting down?
		/// </summary>
		protected bool _isShuttingDown;
		/// <summary>
		/// Has the web scope been registered?
		/// </summary>
		protected bool _isRegistered;

		internal WebScope(RtmpEndpoint endpoint, IGlobalScope globalScope, ApplicationConfiguration appConfig)
			: base(null) {
			_endpoint = endpoint;
			_appConfig = appConfig;
			base.Parent = globalScope;
		}

		public override string Name {
			get {
				return base.Name;
			}
			set {
				throw new InvalidOperationException("Cannot set name, you must set context path");
			}
		}

		public override IScope Parent {
			get {
				return base.Parent;
			}
			set {
				throw new InvalidOperationException("Cannot set parent, you must set global scope");
			}
		}

		public override string ContextPath {
			get { return _contextPath; }
		}

		public override IEndpoint Endpoint {
			get {
				return _endpoint;
			}
		}

		public void SetContextPath(string contextPath) {
			_contextPath = contextPath;
			base.Name = _contextPath.Substring(1);
		}

		public void Register() {
			lock (this.SyncRoot) {
				if (_isRegistered) {
					// Already registered
					return;
				}
				//Start services
				GodLesZ.Library.Amf.Messaging.Api.Stream.IStreamFilenameGenerator streamFilenameGenerator = ObjectFactory.CreateInstance(_appConfig.StreamFilenameGenerator.Type) as GodLesZ.Library.Amf.Messaging.Api.Stream.IStreamFilenameGenerator;
				AddService(typeof(GodLesZ.Library.Amf.Messaging.Api.Stream.IStreamFilenameGenerator), streamFilenameGenerator, false);
				streamFilenameGenerator.Start(_appConfig.StreamFilenameGenerator);
				GodLesZ.Library.Amf.Messaging.Api.SO.ISharedObjectService sharedObjectService = ObjectFactory.CreateInstance(_appConfig.SharedObjectServiceConfiguration.Type) as GodLesZ.Library.Amf.Messaging.Api.SO.ISharedObjectService;
				AddService(typeof(GodLesZ.Library.Amf.Messaging.Api.SO.ISharedObjectService), sharedObjectService, false);
				sharedObjectService.Start(_appConfig.SharedObjectServiceConfiguration);
				GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IProviderService providerService = ObjectFactory.CreateInstance(_appConfig.ProviderServiceConfiguration.Type) as GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IProviderService;
				AddService(typeof(GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IProviderService), providerService, false);
				providerService.Start(_appConfig.ProviderServiceConfiguration);
				GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IConsumerService consumerService = ObjectFactory.CreateInstance(_appConfig.ConsumerServiceConfiguration.Type) as GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IConsumerService;
				AddService(typeof(GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IConsumerService), consumerService, false);
				consumerService.Start(_appConfig.ConsumerServiceConfiguration);
				GodLesZ.Library.Amf.Messaging.Api.Stream.IStreamService streamService = ObjectFactory.CreateInstance(_appConfig.StreamService.Type) as GodLesZ.Library.Amf.Messaging.Api.Stream.IStreamService;
				AddService(typeof(GodLesZ.Library.Amf.Messaging.Api.Stream.IStreamService), streamService, false);
				streamService.Start(_appConfig.StreamService);
				if (_appConfig.SharedObjectSecurityService.Type != null) {
					GodLesZ.Library.Amf.Messaging.Api.SO.ISharedObjectSecurityService sharedObjectSecurityService = ObjectFactory.CreateInstance(_appConfig.SharedObjectSecurityService.Type) as GodLesZ.Library.Amf.Messaging.Api.SO.ISharedObjectSecurityService;
					AddService(typeof(GodLesZ.Library.Amf.Messaging.Api.SO.ISharedObjectSecurityService), sharedObjectSecurityService, false);
					sharedObjectSecurityService.Start(_appConfig.SharedObjectSecurityService);
				}
				Init();
				// We don't want to have configured scopes to get freed when a client disconnects.
				_keepOnDisconnect = true;
				_isRegistered = true;
			}
		}

		public void Unregister() {
			lock (this.SyncRoot) {
				if (!_isRegistered) {
					// Not registered
					return;
				}

				_isShuttingDown = true;
				_keepOnDisconnect = false;
				Uninit();
				// We need to disconnect all clients before unregistering
				IEnumerator enumerator = GetConnections();
				while (enumerator.MoveNext()) {
					IConnection connection = enumerator.Current as IConnection;
					connection.Close();
				}
				// Various cleanup tasks
				//setStore(null);
				base.Parent = null;
				//setServer(null);
				_isRegistered = false;
				_isShuttingDown = false;
			}
		}

		public bool IsShuttingDown {
			get { return _isShuttingDown; }
		}
	}
}
