using System;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Interface to be notified when a session is created or destroyed.
	/// </summary>
	/// <remarks>
	/// This is not the ASP.NET provided session-state but rather the server side client
	/// object representing a client-side session.
	/// </remarks>
	/// <example>
	/// 	<code lang="CS">
	///     class ChatAdapter : MessagingAdapter, ISessionListener
	///     {
	///         public ChatAdapter()
	///         {
	///             ClientManager.AddSessionCreatedListener(this);
	///         }
	///  
	///         public void SessionCreated(IClient client)
	///         {
	///             client.AddSessionDestroyedListener(this);
	///         }
	///  
	///         public void SessionDestroyed(IClient client)
	///         {
	///         }
	///     }
	/// </code>
	/// </example>
	[CLSCompliant(false)]
	public interface ISessionListener {
		/// <summary>
		/// Notification that a session was created.
		/// </summary>
		/// <param name="session">The session that was created.</param>
		void SessionCreated(ISession session);
		/// <summary>
		/// Notification that a session is about to be destroyed.
		/// </summary>
		/// <param name="session">The session that will be destroyed.</param>
		void SessionDestroyed(ISession session);
	}
}
