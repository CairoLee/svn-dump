using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Scripting {
	
	public class ScriptRegistryEntry {

		public object Value {
			get;
			set;
		}

		public int ID {
			get;
			set;
		}

		public int ParentID {
			get;
			set;
		}


		public ScriptRegistryEntry() {
		}

		public ScriptRegistryEntry(int parent, int id, object value) {
			ParentID = parent;
			ID = id;
			Value = value;
		}


		public override string ToString() {
			return string.Format("[{0} {1}", ID, Value.ToString());
		}

	}

}
