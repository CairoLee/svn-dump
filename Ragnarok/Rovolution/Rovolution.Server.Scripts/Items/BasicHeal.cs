using System;
using System.Collections.Generic;
using System.Text;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Scripting {

	public class BasicHeal {

		public static void Initialize() {
			Item item = World.GetItem("Red Potion");
			if (item != null) {
				// Add our ScriptHandler to the handler list of the Item
				item.AddScript(AddHP); // +X HP
			}
		}



		/// <summary>
		/// Generic Method to add HP
		/// </summary>
		/// <param name="Player"></param>
		/// <param name="Item"></param>
		public static void AddHP(SerialObject obj, params object[] args) {
			Item item = obj as Item;
			if (item == null) {
				return;
			}
			if (args == null || args.Length == 0) {
				return;
			}

			//Player.Active.Status.AddHP( (int)args[ 0 ] ); // gets <Value> HP
		}


	}

}
