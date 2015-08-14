using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace FreeWorld.Engine.Compontents.Input {

	public class ActionMap {
		public string Name = "Unknown";
		public List<Keys> Keys = new List<Keys>();

		public ActionMap() {
		}
		public ActionMap( string n, IEnumerable<Keys> keys ) {
			Name = n;
			Keys.AddRange( keys );
		}
		public ActionMap( string n, Keys key ) {
			Name = n;
			Keys.Add( key );
		}
	}

}
