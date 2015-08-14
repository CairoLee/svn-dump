
#if !(NET_1_1)
using System.Collections.Generic;
#endif

namespace GodLesZ.Library.Amf.Invocation {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class InvocationManager : IInvocationManager {
#if !(NET_1_1)
		Stack<object> _context;
		Dictionary<object, object> _properties;
#else
        Stack		_context;
        Hashtable	_properties;
#endif
		object _result;

#if !(NET_1_1)
		public InvocationManager() {
			_context = new Stack<object>();
			_properties = new Dictionary<object, object>();
		}

		#region IInvocationManager Members

		public Stack<object> Context {
			get {
				return _context;
			}
		}

		public Dictionary<object, object> Properties {
			get {
				return _properties;
			}
		}

		public object Result {
			get {
				return _result;
			}
			set {
				_result = value;
			}
		}

		#endregion

#else
		public InvocationManager()
		{
			_context = new Stack();
			_properties = new Hashtable();
		}

		#region IInvocationManager Members

		public Stack Context
		{
			get
			{
				return _context;
			}
		}

		public Hashtable Properties
		{
			get
			{
				return _properties;
			}
		}

		public object Result
		{
			get
			{
				return _result;
			}
			set
			{
				_result = value;
			}
		}

		#endregion
#endif
	}
}
