
using System.Collections;
using GodLesZ.Library.Amf.Messaging;
using GodLesZ.Library.Amf.Messaging.Config;
using GodLesZ.Library.Amf.Messaging.Services;
using GodLesZ.Library.Amf.Util;
using log4net;

namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class DataDestination : MessageDestination {
		private static readonly ILog log = LogManager.GetLogger(typeof(DataDestination));
		SequenceManager _sequenceManager;

		public DataDestination(IService service, DestinationDefinition destinationDefinition)
			: base(service, destinationDefinition) {
			_sequenceManager = new SequenceManager(this);
		}

		public SequenceManager SequenceManager {
			get { return _sequenceManager; }
		}

		public IdentityConfiguration[] GetIdentityKeys() {
			if (this.DestinationDefinition.Properties.Metadata != null &&
				this.DestinationDefinition.Properties.Metadata.Identity != null) {
				//ArrayList identity = this.DestinationSettings.MetadataSettings.Identity;
				//return identity.ToArray(typeof(string)) as string[];
				return this.DestinationDefinition.Properties.Metadata.Identity;
			}
			return IdentityConfiguration.Empty;
			//return new string[0];
		}

		public bool AutoRefreshFill(IList parameters) {
			if (this.ServiceAdapter is DotNetAdapter)
				return (this.ServiceAdapter as DotNetAdapter).AutoRefreshFill(parameters);
			return false;
		}

		public override MessageClient RemoveSubscriber(string clientId) {
			if (log.IsDebugEnabled)
				log.Debug(__Res.GetString(__Res.DataDestination_RemoveSubscriber, clientId));

			MessageClient messageClient = base.RemoveSubscriber(clientId);
			_sequenceManager.RemoveSubscriber(clientId);
			return messageClient;
		}


		internal override void Dump(DumpContext dumpContext) {
			base.Dump(dumpContext);
			dumpContext.Indent();
			_sequenceManager.Dump(dumpContext);
			dumpContext.Unindent();
		}
	}
}
