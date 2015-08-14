
using GodLesZ.Library.Amf.Context;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Persistence;
using GodLesZ.Library.Amf.Messaging.Api.Service;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ScopeContext : IScopeContext {
		private string _contextPath = string.Empty;
		private IScopeResolver _scopeResolver;
		private IClientRegistry _clientRegistry;
		private IServiceInvoker _serviceInvoker;
		private IPersistenceStore _persistanceStore;

		private ScopeContext() {
		}

		public ScopeContext(string contextPath, IClientRegistry clientRegistry, IScopeResolver scopeResolver, IServiceInvoker serviceInvoker, IPersistenceStore persistanceStore) {
			_contextPath = contextPath;
			_clientRegistry = clientRegistry;
			_scopeResolver = scopeResolver;
			_persistanceStore = persistanceStore;
			_serviceInvoker = serviceInvoker;
		}

		public string ContextPath {
			get { return _contextPath; }
		}

		#region IScopeContext Members

		public IScopeResolver ScopeResolver {
			get { return _scopeResolver; }
		}

		public IClientRegistry ClientRegistry {
			get { return _clientRegistry; }
		}

		public IServiceInvoker ServiceInvoker {
			get { return _serviceInvoker; }
		}

		public IPersistenceStore PersistenceStore {
			get { return _persistanceStore; }
		}

		public IScope ResolveScope(string path) {
			return _scopeResolver.ResolveScope(path);
		}

		public IScope ResolveScope(IScope root, string path) {
			return _scopeResolver.ResolveScope(root, path);
		}

		public IScope GetGlobalScope() {
			return _scopeResolver.GlobalScope;
		}

		public IScopeHandler LookupScopeHandler(string contextPath) {
			return null;
		}

		/// <summary>
		/// Return an <see cref="GodLesZ.Library.Amf.Context.IResource"/> handle for the
		/// </summary>
		/// <param name="location">The resource location.</param>
		/// <returns>An appropriate <see cref="GodLesZ.Library.Amf.Context.IResource"/> handle.</returns>
		public IResource GetResource(string location) {
			//return FluorineContext.Current.GetResource(location);
			return new FileSystemResource(location);
		}

		#endregion
	}
}
