using System;
using GodLesZ.Library.Amf.Context;
using GodLesZ.Library.Amf.Messaging.Api.Persistence;
using GodLesZ.Library.Amf.Messaging.Api.Service;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public interface IScopeContext {
		/// <summary>
		/// Returns scope by path. You can think of IScope as of tree items, used to
		/// separate context and resources between users.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		IScope ResolveScope(string path);
		/// <summary>
		/// Resolves scope from given root using scope resolver.
		/// </summary>
		/// <param name="root">Scope to start from.</param>
		/// <param name="path">Path to resolve.</param>
		/// <returns></returns>
		IScope ResolveScope(IScope root, string path);
		/// <summary>
		/// Returns global scope reference.
		/// </summary>
		/// <returns></returns>
		IScope GetGlobalScope();
		/// <summary>
		/// Gets the client registry. Client registry is a place where all clients are registered.
		/// </summary>
		IClientRegistry ClientRegistry { get; }
		/// <summary>
		/// Gets persistence store object, a storage for persistent objects like persistent Shared objects.
		/// </summary>
		IPersistenceStore PersistenceStore { get; }
		/// <summary>
		/// Returns scope handler (object that handler all actions related to the scope) by path.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		IScopeHandler LookupScopeHandler(string path);
		/// <summary>
		/// Gets the service invoker object. Service invokers are objects that make
		/// service calls to client side NetConnection objects.
		/// </summary>
		IServiceInvoker ServiceInvoker { get; }
		/// <summary>
		/// Returns an <see cref="GodLesZ.Library.Amf.Context.IResource"/> handle for the specified path.
		/// </summary>
		/// <param name="path">The resource location.</param>
		/// <returns>An appropriate <see cref="GodLesZ.Library.Amf.Context.IResource"/> handle.</returns>
		IResource GetResource(string path);
		/// <summary>
		/// Gets the scope resolver object.
		/// </summary>
		/// <value>The scope resolver object.</value>
		IScopeResolver ScopeResolver { get; }
	}
}
