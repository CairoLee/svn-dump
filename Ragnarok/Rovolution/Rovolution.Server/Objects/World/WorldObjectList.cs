using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class WorldObjectList : SafeDictionary<WorldID, WorldObject>, IClearDisposable {

		/// <summary>
		/// Removes all objects from this list AND from the world lists
		/// </summary>
		/// <param name="dispose"></param>
		public void Clear(bool dispose) {
			if (dispose == true) {
				// Copy objects to an array
				WorldObject[] objects = new WorldObject[Count];
				Values.CopyTo(objects, 0);
				
				// Call Delete() to remove them from world lists
				foreach (WorldObject obj in objects) {
					// Avoid already disposed
					if (obj is WorldObject) {
						obj.Dispose();
						obj.Delete();
					}
				}
			}

			// Base call, to let the underlying dictionary now that it is empty
			base.Clear();
		}

	}

}
