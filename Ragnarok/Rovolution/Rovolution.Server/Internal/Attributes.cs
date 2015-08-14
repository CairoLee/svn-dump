using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Rovolution.Server {

	/// <summary>
	/// Script call priority attribute for methods
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class CallPriorityAttribute : Attribute {

		public int Priority {
			get;
			set;
		}

		public CallPriorityAttribute(int priority) {
			Priority = priority;
		}

	}

}
