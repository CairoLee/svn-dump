
namespace GodLesZ.Library.Amf.Messaging.Api {
	/// <summary>
	/// Base marker interface for all scope services. Used by the ScopeUtils to lookup services defined. 
	/// A scope service usually can perform various tasks on a scope like managing shared objects, streams, etc.
	/// </summary>
	public interface IScopeService : IService {
	}
}
