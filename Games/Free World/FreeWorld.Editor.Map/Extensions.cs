using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using XnaKeys = Microsoft.Xna.Framework.Input.Keys;

namespace FreeWorld.Editor.Map {

	public static class DrawModeExtensions {

		public static bool Has( this EDrawMode Mode, EDrawMode HasMode ) {
			return ( Mode & HasMode ) != EDrawMode.None;
		}

		public static bool HasNot( this EDrawMode Mode, EDrawMode HasMode ) {
			return Mode.Has( HasMode ) == false;
		}

	}


}
