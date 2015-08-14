using System;
using System.Collections;
#if !(NET_1_1)
using System.Collections.Generic;
#endif


namespace GodLesZ.Library.Amf.Messaging.Api.SO {
	/// <summary>
	/// Notifications about shared object updates.
	/// </summary>
	[CLSCompliant(false)]
	public interface ISharedObjectListener {
		/// <summary>
		/// Called when a client connects to a shared object.
		/// </summary>
		/// <param name="so">The shared object.</param>
		void OnSharedObjectConnect(ISharedObject so);
		/// <summary>
		/// Called when a client disconnects from a shared object.
		/// </summary>
		/// <param name="so">The shared object.</param>
		void OnSharedObjectDisconnect(ISharedObject so);
		/// <summary>
		/// Called when a shared object attribute is updated.
		/// </summary>
		/// <param name="so">The shared object.</param>
		/// <param name="key">The name of the attribute.</param>
		/// <param name="value">The value of the attribute.</param>
		void OnSharedObjectUpdate(ISharedObject so, string key, object value);
		/// <summary>
		/// Called when multiple attributes of a shared object are updated.
		/// </summary>
		/// <param name="so">The shared object.</param>
		/// <param name="values">The new attributes of the shared object.</param>
		void OnSharedObjectUpdate(ISharedObject so, IAttributeStore values);
#if !(NET_1_1)
		/// <summary>
		/// Called when multiple attributes of a shared object are updated.
		/// </summary>
		/// <param name="so">The shared object.</param>
		/// <param name="values">The new attributes of the shared object.</param>
		void OnSharedObjectUpdate(ISharedObject so, IDictionary<string, object> values);
#else
        /// <summary>
        /// Called when multiple attributes of a shared object are updated.
        /// </summary>
        /// <param name="so">The shared object.</param>
        /// <param name="values">The new attributes of the shared object.</param>
        void OnSharedObjectUpdate(ISharedObject so, IDictionary values);
#endif
		/// <summary>
		/// Called when an attribute is deleted from the shared object.
		/// </summary>
		/// <param name="so">The shared object.</param>
		/// <param name="key">The name of the attribute to delete.</param>
		void OnSharedObjectDelete(ISharedObject so, string key);
		/// <summary>
		/// Called when all attributes of a shared object are removed.
		/// </summary>
		/// <param name="so">The shared object.</param>
		void OnSharedObjectClear(ISharedObject so);
		/// <summary>
		/// Called when a shared object method call is sent.
		/// </summary>
		/// <param name="so">The shared object.</param>
		/// <param name="method">The method name to call.</param>
		/// <param name="parameters">The arguments.</param>
		void OnSharedObjectSend(ISharedObject so, string method, IList parameters);
	}
}
