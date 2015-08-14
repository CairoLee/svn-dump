using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Database;

namespace Rovolution.Server.Objects {
	
	// TODO: this is storeable!
	public class WorldObjectStatusChangeEntry : StoreableObject {
		public Timer Timer {
			get;
			set;
		}

		public int Value1 {
			get;
			set;
		}

		public int Value2 {
			get;
			set;
		}

		public int Value3 {
			get;
			set;
		}

		public int Value4 {
			get;
			set;
		}


	}

}
