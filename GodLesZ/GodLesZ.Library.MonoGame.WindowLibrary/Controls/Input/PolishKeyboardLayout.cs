using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace GodLesZ.Library.Xna.WindowLibrary.Controls {

	public class PolishKeyboardLayout : KeyboardLayout {

		public PolishKeyboardLayout() {
			Name = "Polish";
			LayoutList.Clear();
			LayoutList.Add(1045);
		}

		protected override string KeyToString(KeyEventArgs args) {
			if (args.Alt) {
				switch (args.Key) {
					case Keys.A:
						return (args.Shift) ? "¥" : "¹";
					case Keys.C:
						return (args.Shift) ? "Æ" : "æ";
					case Keys.E:
						return (args.Shift) ? "Ê" : "ê";
					case Keys.L:
						return (args.Shift) ? "£" : "³";
					case Keys.N:
						return (args.Shift) ? "Ñ" : "ñ";
					case Keys.O:
						return (args.Shift) ? "Ó" : "ó";
					case Keys.S:
						return (args.Shift) ? "Œ" : "œ";
					case Keys.X:
						return (args.Shift) ? "" : "Ÿ";
					case Keys.Z:
						return (args.Shift) ? "¯" : "¿";
				}
			}
			return base.KeyToString(args);
		}

	}

}
