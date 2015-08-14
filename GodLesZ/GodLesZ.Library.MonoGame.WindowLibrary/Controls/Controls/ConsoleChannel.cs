using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class ConsoleChannel {
		private string name;
		private byte index;
		private Color color;

		public virtual byte Index {
			get { return index; }
			set { index = value; }
		}

		public virtual Color Color {
			get { return color; }
			set { color = value; }
		}

		public virtual string Name {
			get { return name; }
			set { name = value; }
		}

		public ConsoleChannel(byte index, string name, Color color) {
			this.name = name;
			this.index = index;
			this.color = color;
		}
	}

}
