using System;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public sealed class ScopeUtils {
		/// <summary>
		/// Depth of Global scope.
		/// </summary>
		public static int Global = 0x00;
		/// <summary>
		/// Application scope depth.
		/// </summary>
		public static int Application = 0x01;
		/// <summary>
		/// Room depth.
		/// </summary>
		public static int Room = 0x02;
		//private static string ServiceCachePrefix = "__service_cache:";

		/// <summary>
		/// Check whether scope is an application scope (level 1 leaf in scope tree) or not
		/// </summary>
		/// <param name="scope"></param>
		/// <returns></returns>
		public static bool IsApplication(IBasicScope scope) {
			return scope.Depth == Application;
		}
		/// <summary>
		/// Check whether scope is a room scope (level 2 leaf in scope tree or lower, e.g. 3, 4, ...) or not
		/// </summary>
		/// <param name="scope"></param>
		/// <returns></returns>
		public static bool IsRoom(IBasicScope scope) {
			return scope.Depth >= Room;
		}
		/*
		public static object GetScopeService(IScope scope, Type type)
		{
			return GetScopeService(scope, type, null, true);
		}

		public static object GetScopeService(IScope scope, Type type, string defaultTypeName)
		{
			return GetScopeService(scope, type, defaultTypeName, true);
		}

		public static object GetScopeService(IScope scope, Type type, string defaultTypeName, bool checkHandler) 
		{
			if (scope == null || type == null) 
				return null;

			object service = scope.GetService(type);
			if (service != null)
				return service;

			if (checkHandler)
			{
				IScope current = scope;
				while (current != null)
				{
					IScopeHandler scopeHandler = current.Handler;
					if (type.IsInstanceOfType(scopeHandler))
					{
						service = scopeHandler;
						break;
					}
					if (!current.HasParent)
						break;
					current = current.Parent;
				}
			}

			if (service == null && typeof(IScopeService).IsAssignableFrom(type))
			{
				if (defaultTypeName != null)
				{
					//handler = GetScopeService(scope, defaultTypeName);
					Type resolvedType = TypeHelper.Locate(defaultTypeName);
					if (resolvedType == null)
						throw new FluorineException(__Res.GetString(__Res.Type_InitError, defaultTypeName));
					service = Activator.CreateInstance(resolvedType);
					scope.AddService(type, service, true);

				}
			}
			return service;
		}
		*/
		/// <summary>
		/// Returns scope service by service type.
		/// </summary>
		/// <param name="scope">The scope service belongs to.</param>
		/// <param name="type">Service type.</param>
		/// <returns>Service object.</returns>
		public static object GetScopeService(IScope scope, Type type) {
			return GetScopeService(scope, type, true);
		}
		/// <summary>
		/// Returns scope service by service type.
		/// </summary>
		/// <param name="scope">The scope service belongs to.</param>
		/// <param name="type">Service type.</param>
		/// <param name="checkHandler">Indicates whether to check the scope's handler for the requested service.</param>
		/// <returns>Service object.</returns>
		public static object GetScopeService(IScope scope, Type type, bool checkHandler) {
			if (scope == null || type == null)
				return null;

			object service = scope.GetService(type);
			if (service != null)
				return service;

			if (checkHandler) {
				IScope current = scope;
				while (current != null) {
					IScopeHandler scopeHandler = current.Handler;
					if (type.IsInstanceOfType(scopeHandler)) {
						service = scopeHandler;
						break;
					}
					if (!current.HasParent)
						break;
					current = current.Parent;
				}
			}
			return service;
		}

		/// <summary>
		/// Returns the application scope for specified scope. Application scope has depth of 1 and has no parent.
		/// </summary>
		/// <param name="scope">Scope to find application for.</param>
		/// <returns>Application scope.</returns>
		public static IScope FindApplication(IScope scope) {
			IScope current = scope;
			while (current.HasParent && current.Depth != ScopeUtils.Application) {
				current = current.Parent;
			}
			return current;
		}
		/// <summary>
		/// Finds root scope for specified scope object. Root scope is the top level scope among scope's parents.
		/// </summary>
		/// <param name="scope">Scope to find root for.</param>
		/// <returns>Root scope object.</returns>
		public static IScope FindRoot(IScope scope) {
			IScope current = scope;
			while (current.HasParent) {
				current = current.Parent;
			}
			return current;
		}
	}
}
