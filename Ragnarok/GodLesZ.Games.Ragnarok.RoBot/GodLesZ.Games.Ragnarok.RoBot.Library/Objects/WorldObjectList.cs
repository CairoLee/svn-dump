using System.Linq;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects.Interfaces;
using GodLesZ.Library;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Objects {

	public class WorldObjectList : SafeDictionary<WorldID, WorldObject>, IClearDisposable {

		/// <summary>
		/// Removes all objects from this list AND from the world lists
		/// </summary>
		/// <param name="dispose"></param>
		public void Clear(bool dispose) {
			if (dispose) {
				// Copy objects to an array
				var objects = new WorldObject[Count];
				Values.CopyTo(objects, 0);

				// Call Delete() to remove them from world lists
				foreach (var obj in objects.Where(obj => obj != null)) {
					obj.Dispose();
					obj.Delete();
				}
			}

			// Base call, to let the underlying dictionary now that it is empty
			Clear();
		}

	}

}
