
using System;

using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Messages;

namespace GodLesZ.Library.Amf.Messaging.Services {
	/// <summary>
	/// A Service adapter bridges destinations to back-end systems.
	/// The ServiceAdapter class is the base definition of a service adapter.
	/// </summary>
	[CLSCompliant(false)]
	public abstract class ServiceAdapter {
		private object _syncLock = new object();
		private Destination _destination;
		private DestinationDefinition _destinationDefinition;
		private AdapterDefinition _adapterDefinition;

		/// <summary>
		/// Initializes a new instance of the ServiceAdapter class.
		/// </summary>
		protected ServiceAdapter() {
		}

		/// <summary>
		/// Process a message routed for this adapter.
		/// </summary>
		/// <param name="message">The message sent by the client.</param>
		/// <returns>The body of the acknowledge message (or null if there is no body).</returns>
		public virtual object Invoke(IMessage message) {
			return null;
		}
		/// <summary>
		/// Gets whether the adapter performs custom subscription management. The default return value is false.
		/// </summary>
		public virtual bool HandlesSubscriptions {
			get { return false; }
		}

		/// <summary>
		/// Accept a command from the adapter's service (subscribe, unsubscribe and ping operations).
		/// </summary>
		/// <param name="commandMessage"></param>
		/// <returns></returns>
		public virtual object Manage(CommandMessage commandMessage) {
			return new AcknowledgeMessage();
		}
		/// <summary>
		/// Adapter initialization.
		/// </summary>
		public virtual void Init() {
		}
		/// <summary>
		/// Stops the adapter.
		/// </summary>
		public virtual void Stop() {
		}
		/// <summary>
		/// Returns the Destination of the ServiceAdapter.
		/// </summary>
		public Destination Destination { get { return _destination; } }
		internal void SetDestination(Destination value) {
			_destination = value;
		}
		/// <summary>
		/// Gets the settings for the Destination of the ServiceAdapter.
		/// </summary>
		public DestinationDefinition DestinationDefinition { get { return _destinationDefinition; } }
		internal void SetDestinationSettings(DestinationDefinition value) {
			_destinationDefinition = value;
		}
		/// <summary>
		/// Gets settings for the ServiceAdapter.
		/// </summary>
		public AdapterDefinition AdapterDefinition { get { return _adapterDefinition; } }
		internal void SetAdapterSettings(AdapterDefinition value) {
			_adapterDefinition = value;
		}
		/// <summary>
		/// Gets an object that can be used to synchronize access. 
		/// </summary>
		public object SyncRoot { get { return _syncLock; } }
	}
}
