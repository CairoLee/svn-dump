
using System;
using System.Reflection;
using GodLesZ.Library.Amf.Reflection.Lightweight;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Reflection {
	/// <summary>
	/// Type instantiation helper.
	/// </summary>
	static class ConstructorExtensions {
		/// <summary>
		/// Invokes a constructor whose parameter types are inferred from <paramref name="parameters" /> 
		/// on the given <paramref name="type"/> with <paramref name="parameters" /> being the arguments.
		/// </summary>
		/// <param name="type">The type of object to create.</param>
		/// <param name="parameters">An array of arguments that match in number, order, and type the parameters of the constructor to invoke.</param>
		/// <returns>A reference to the newly created object.</returns>
		public static object CreateInstance(Type type, params object[] parameters) {
			return DelegateForCreateInstance(type, ReflectionUtils.ToTypeArray(parameters))(parameters);
		}

		/// <summary>
		/// Creates a delegate which can invoke the constructor whose parameter types are <paramref name="parameterTypes" /> on the given <paramref name="type"/>.
		/// </summary>
		/// <param name="type">The type of object to create.</param>
		/// <param name="parameterTypes">An array of argument types that match in number, order, and type the parameters of the constructor to invoke.</param>
		/// <returns>A delegate for constructor invocation.</returns>
		public static ConstructorInvoker DelegateForCreateInstance(Type type, params Type[] parameterTypes) {
			return (ConstructorInvoker)new CtorInvocationEmitter(type, BindingFlags.CreateInstance | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, parameterTypes).GetDelegate();
		}

		/// <summary>
		/// Creates a delegate which can invoke the constructor whose parameter types are inferred from <paramref name="parameters" /> on the given <paramref name="type"/>.
		/// </summary>
		/// <param name="type">The type of object to create.</param>
		/// <param name="parameters">An array of arguments that match in number, order, and type the parameters of the constructor to invoke.</param>
		/// <returns>A delegate for constructor invocation.</returns>
		public static ConstructorInvoker DelegateForCreateInstance(Type type, params object[] parameters) {
			return DelegateForCreateInstance(type, ReflectionUtils.ToTypeArray(parameters));
		}
	}
}
