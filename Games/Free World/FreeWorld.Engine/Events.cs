using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;

namespace FreeWorld.Engine {

	public delegate void WorldLoadEventHandler();


	public class Events {
		public static event WorldLoadEventHandler WorldLoad;


		public static void InvokeWorldLoad() {
			if( WorldLoad != null )
				WorldLoad();
		}


		public static void Reset() {
			WorldLoad = null;
		}


	}

}