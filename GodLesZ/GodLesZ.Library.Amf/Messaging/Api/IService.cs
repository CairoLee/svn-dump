using GodLesZ.Library.Amf.Configuration;

namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Base interface for all services.
	/// </summary>
	public interface IService {
#if !FXCLIENT
		/// <summary>
		/// Start service.
		/// </summary>
		/// <param name="configuration">Application configuration.</param>
		void Start(ConfigurationSection configuration);
#endif
		/// <summary>
		/// Shutdown service.
		/// </summary>
		void Shutdown();
	}
}
