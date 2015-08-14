using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class ConsoleChannelList : EventedList<ConsoleChannel> {

		public ConsoleChannel this[string name] {
			get {
				for (int i = 0; i < this.Count; i++) {
					ConsoleChannel s = (ConsoleChannel)this[i];
					if (s.Name.ToLower() == name.ToLower()) {
						return s;
					}
				}
				return default(ConsoleChannel);
			}

			set {
				for (int i = 0; i < this.Count; i++) {
					ConsoleChannel s = (ConsoleChannel)this[i];
					if (s.Name.ToLower() == name.ToLower()) {
						this[i] = value;
					}
				}
			}
		}

		public ConsoleChannel this[byte index] {
			get {
				for (int i = 0; i < this.Count; i++) {
					ConsoleChannel s = (ConsoleChannel)this[i];
					if (s.Index == index) {
						return s;
					}
				}
				return default(ConsoleChannel);
			}

			set {
				for (int i = 0; i < this.Count; i++) {
					ConsoleChannel s = (ConsoleChannel)this[i];
					if (s.Index == index) {
						this[i] = value;
					}
				}
			}
		}

	}

}
