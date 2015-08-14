
namespace GodLesZ.Library.Amf.Data {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class ItemWrapper {
		object _instance;

		public ItemWrapper(object instance) {
			_instance = instance;
		}

		public object Instance {
			get { return _instance; }
			set { _instance = value; }
		}
	}
}
