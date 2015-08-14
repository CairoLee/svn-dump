using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Rovolution.Server.Database {

	public class StoreableDatabaseObjectPropField {

		public PropertyInfo Prop {
			get;
			protected set;
		}

		public FieldInfo Field {
			get;
			protected set;
		}

	}

}
