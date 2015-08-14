using System;
using System.Collections.Generic;
using System.Text;
using Shaiya.Extended.Server.Network;
using Shaiya.Extended.Server.Objects;

namespace Shaiya.Extended.Server.Scripting {

	public class BasicHeal {

		public static void Initialize() {
			World.GetItem( "Red Potion" ).SetOnUseScript( AddHP, 50 ); // +50 HP
		}



		/// <summary>
		/// Generic Method to add HP
		/// </summary>
		/// <param name="Player"></param>
		/// <param name="Item"></param>
		public static void AddHP( NetState Player, BaseItem Item ) {
			if( Item.ScriptArgs == null || Item.ScriptArgs.Length == 0 )
				return;
			//Player.Active.Status.AddHP( (int)Item.ScriptArgs[ 0 ] ); // gets <Value> HP
		}


	}

}
