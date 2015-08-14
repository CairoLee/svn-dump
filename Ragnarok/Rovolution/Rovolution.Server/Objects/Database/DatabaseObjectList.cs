using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class DatabaseObjectList : SafeDictionary<DatabaseID, DatabaseObject>, IClearDisposable {


		public void Clear(bool dispose) {
			if (dispose == true) {
				DatabaseObject[] values = new DatabaseObject[Count];
				CopyValuesTo(values, 0);

				foreach (DatabaseObject obj in values) {
					// Avoid already disposed
					if (obj is DatabaseObject) {
						obj.Dispose();
					}
				}

				values = null;
			}

			base.Clear();
		}

	}

}
