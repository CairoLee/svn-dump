using System;
using GodLesZ.Library.Amf.Messaging.Config;

namespace GodLesZ.Library.Amf.Messaging {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class DotNetFactoryInstance : FactoryInstance {
		Type _cachedType;
		object _applicationInstance;

		/// <summary>
		/// Initializes a new instance of the DotNetFactoryInstance class.
		/// </summary>
		/// <param name="flexFactory">The IFlexFactory this FactoryInstance is created from.</param>
		/// <param name="id">The Destination identity.</param>
		/// <param name="properties">The configuration properties for this destination.</param>
		public DotNetFactoryInstance(IFlexFactory flexFactory, string id, DestinationProperties properties)
			: base(flexFactory, id, properties) {
		}
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <returns>Instance of the given factory.</returns>
		public object CreateInstance() {
			Type type = GetInstanceClass();
			if (type == null) {
				string msg = __Res.GetString(__Res.Type_InitError, Source);
				throw new MessageException(msg, new TypeLoadException(msg));
			}
			return ObjectFactory.CreateInstance(type);
		}
		/// <summary>
		/// Gets or sets the FactoryInstance source.
		/// </summary>
		public override string Source {
			get {
				return base.Source;
			}
			set {
				if (base.Source != value) {
					base.Source = value;
					_cachedType = null;
				}
			}
		}
		/// <summary>
		/// Returns the class for the underlying configuration (used when the lookup method is called). 
		/// </summary>
		/// <returns>A Type instance.</returns>
		public override Type GetInstanceClass() {
			return _cachedType ?? (_cachedType = ObjectFactory.LocateInLac(Source));
		}

		/// <summary>
		/// Gets the application-scoped instance.
		/// </summary>
		public object ApplicationInstance {
			get {
				if (_applicationInstance == null) {
					lock (typeof(DotNetFactoryInstance)) {
						if (_applicationInstance == null)
							_applicationInstance = CreateInstance();
					}
				}
				return _applicationInstance;
			}
		}
		/// <summary>
		/// When the caller is done with the instance, this method is called. For session scoped components, this gives you the opportunity to 
		/// update any state modified in the instance in a remote persistence store. 
		/// </summary>
		/// <param name="instance">Instance of the given factory.</param>
		public override void OnOperationComplete(object instance) {
			base.OnOperationComplete(instance);
			if (Scope == RequestScope) {
				if (instance is IDisposable) {
					IDisposable disposable = instance as IDisposable;
					disposable.Dispose();
				}
			}
		}
	}
}
