using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public struct ConsoleMessage {
		public string Text;
		public byte Channel;
		public DateTime Time;

		public ConsoleMessage(string text, byte channel) {
			this.Text = text;
			this.Channel = channel;
			this.Time = DateTime.Now;
		}
	}

}
