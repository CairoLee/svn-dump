using GodLesZ.Library.Amf.Context;
using GodLesZ.Library.Amf.Messaging.Config;

namespace GodLesZ.Library.Amf.Messaging {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class DotNetFactory : IFlexFactory {
		public const string Id = "dotnet";
		/// <summary>
		/// Initializes a new instance of the DotNetFactory class.
		/// </summary>
		public DotNetFactory() {
		}

		#region IFlexFactory Members

		/// <summary>
		/// Creates a FactoryInstance.
		/// </summary>
		/// <param name="id">The Destination identity.</param>
		/// <param name="properties">Configuration properties for the destination.</param>
		/// <returns>A FactoryInstance instance.</returns>
		public FactoryInstance CreateFactoryInstance(string id, DestinationProperties properties) {
			DotNetFactoryInstance factoryInstance = new DotNetFactoryInstance(this, id, properties);
			if (properties != null) {
				factoryInstance.Source = properties.Source;
				factoryInstance.Scope = properties.Scope;
				factoryInstance.AttributeId = properties.AttributeId;
			}
			if (factoryInstance.Scope == null)
				factoryInstance.Scope = FactoryInstance.RequestScope;
			return factoryInstance;
		}
		/// <summary>
		/// Return an instance as appropriate for this instance of the given factory.
		/// </summary>
		/// <param name="factoryInstance">FactoryInstance used to retrieve the object instance.</param>
		/// <returns>The Object instance to use for the given operation for the current destination.</returns>
		public object Lookup(FactoryInstance factoryInstance) {
			DotNetFactoryInstance dotNetFactoryInstance = factoryInstance as DotNetFactoryInstance;
			switch (dotNetFactoryInstance.Scope) {
				case FactoryInstance.ApplicationScope: {
						object instance = dotNetFactoryInstance.ApplicationInstance;
						if (FluorineContext.Current != null && FluorineContext.Current.ApplicationState != null && dotNetFactoryInstance.AttributeId != null)
							FluorineContext.Current.ApplicationState[dotNetFactoryInstance.AttributeId] = instance;
						return instance;
					}
				case FactoryInstance.SessionScope:
					if (FluorineContext.Current.Session != null) {
						object instance = FluorineContext.Current.Session[dotNetFactoryInstance.AttributeId];
						if (instance == null) {
							instance = dotNetFactoryInstance.CreateInstance();
							FluorineContext.Current.Session[dotNetFactoryInstance.AttributeId] = instance;
						}
						return instance;
					}
					break;
				default:
					return dotNetFactoryInstance.CreateInstance();
			}
			return null;
		}

		#endregion
	}
}
