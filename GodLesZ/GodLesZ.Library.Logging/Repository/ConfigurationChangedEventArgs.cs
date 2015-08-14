using System;
using System.Collections;

namespace GodLesZ.Library.Logging.Repository {
	/// <summary>
	/// 
	/// </summary>
	public class ConfigurationChangedEventArgs : EventArgs {
		private readonly ICollection configurationMessages;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="configurationMessages"></param>
		public ConfigurationChangedEventArgs(ICollection configurationMessages) {
			this.configurationMessages = configurationMessages;
		}

		/// <summary>
		/// 
		/// </summary>
		public ICollection ConfigurationMessages {
			get { return configurationMessages; }
		}
	}
}
