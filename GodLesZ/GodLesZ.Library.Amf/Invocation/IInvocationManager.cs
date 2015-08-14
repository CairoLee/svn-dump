
#if !(NET_1_1)
using System.Collections.Generic;
#endif


namespace GodLesZ.Library.Amf.Invocation {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public interface IInvocationManager {
#if !(NET_1_1)
		/// <summary>
		/// Gets a stack-based, user-defined storage area that is useful for communication between callback handlers.
		/// </summary>
		Stack<object> Context { get; }
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		Dictionary<object, object> Properties { get; }
#else
		/// <summary>
		/// Gets a stack-based, user-defined storage area that is useful for communication between callback handlers.
		/// </summary>
		Stack Context {get;}
        /// <summary>
        /// This method supports the infrastructure and is not intended to be used directly from your code.
        /// </summary>
		Hashtable Properties { get; }
#endif
		/// <summary>
		/// This method supports the infrastructure and is not intended to be used directly from your code.
		/// </summary>
		object Result { get; set; }
	}
}
