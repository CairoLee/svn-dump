

using GodLesZ.Library.Amf.Messaging.Config;

namespace GodLesZ.Library.Amf.Messaging.Services.Remoting {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RemotingDestination : Destination {

		/// <summary>
		/// Initializes a new instance of the RemotingDestination class.
		/// </summary>
		/// <param name="service">Service.</param>
		/// <param name="destinationDefinition">Destination definition.</param>
		public RemotingDestination(IService service, DestinationDefinition destinationDefinition)
			: base(service, destinationDefinition) {
		}

		/// <summary>
		/// Initializes the current Destination.
		/// </summary>
		/// <param name="adapterDefinition">Adapter definition.</param>
		public override void Init(AdapterDefinition adapterDefinition) {
			//For remoting destinations it is ok to use the default 'dotnet' adapter if no adapter was specified for the service
			if (adapterDefinition == null && this.DestinationDefinition != null && this.DestinationDefinition.Service != null)
				adapterDefinition = this.DestinationDefinition.Service.GetDefaultAdapter();
			base.Init(adapterDefinition);
		}
	}
}
