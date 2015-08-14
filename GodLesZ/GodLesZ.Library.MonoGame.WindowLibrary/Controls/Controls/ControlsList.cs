using System.Collections.Generic;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	/// <summary>
	/// Defines type used as a controls collection.
	/// </summary>
	public class ControlsList : EventedList<Control> {

		public Control this[string name] {
			get { return Find(name); }
		}

		public ControlsList() {
		}

		public ControlsList(int capacity)
			: base(capacity) {
		}

		public ControlsList(IEnumerable<Control> collection)
			: base(collection) {
		}


		public Control Find(string name) {
			return Find(c => c.Name == name);
		}

	}

}
