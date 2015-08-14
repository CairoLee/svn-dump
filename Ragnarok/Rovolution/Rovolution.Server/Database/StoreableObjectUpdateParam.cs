using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Database {


	public class StoreableObjectUpdateParam {
		public string Column;
		public object Value;


		public StoreableObjectUpdateParam(string col, object value) {
			Column = col;
			Value = value;
		}

	}

}
