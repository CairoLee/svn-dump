using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;
using Rovolution.Server.Scripts.Packets.Response;

namespace Rovolution.Server.Systems {
	
	public class Walking {

		public static void WalkToXY(SerialObject obj, NetState state) {

			Timer.DelayCall(TimeSpan.FromMilliseconds(120), new TimerStateCallback<SerialObject>(WalkToXY_Tick), obj);

		}


		private static void WalkToXY_Tick(SerialObject obj) {
			// Player needs to notify clients about a successfull move
			if (obj is Character) {
				((obj as Character).Parent.Netstate).Send(new WorldWalkOK(obj as Character));
			}


		}

	}

}
