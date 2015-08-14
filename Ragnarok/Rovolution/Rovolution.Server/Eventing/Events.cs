using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Rovolution.Server.Objects;

namespace Rovolution.Server {
	public delegate void CrashedEventHandler(CrashedEventArgs e);
	public delegate void ShutdownEventHandler(ShutdownEventArgs e);
	public delegate void SocketConnectEventHandler(SocketConnectEventArgs e);
	public delegate void ServerStartedEventHandler();
	public delegate void WorldLoadStartEventHandler();
	public delegate void WorldLoadFinishEventHandler();


	/// <summary>
	/// Global events, can be used anywhere
	/// </summary>
	public class Events {
		public static event CrashedEventHandler Crashed;
		public static event ShutdownEventHandler Shutdown;
		public static event SocketConnectEventHandler SocketConnect;
		public static event ServerStartedEventHandler ServerStarted;
		public static event WorldLoadStartEventHandler WorldLoadStart;
		public static event WorldLoadFinishEventHandler WorldLoadFinish;


		public static void InvokeServerStarted() {
			if (ServerStarted != null)
				ServerStarted();
		}


		public static void InvokeSocketConnect(SocketConnectEventArgs e) {
			if (SocketConnect != null)
				SocketConnect(e);
		}


		public static void InvokeShutdown(ShutdownEventArgs e) {
			if (Shutdown != null)
				Shutdown(e);
		}

		public static void InvokeCrashed(CrashedEventArgs e) {
			if (Crashed != null)
				Crashed(e);
		}


		public static void InvokeWorldLoadStart() {
			if (WorldLoadStart != null)
				WorldLoadStart();
		}

		public static void InvokeWorldLoadFinish() {
			if (WorldLoadFinish != null)
				WorldLoadFinish();
		}


		public static void Reset() {
			Crashed = null;
			Shutdown = null;
			SocketConnect = null;
			WorldLoadFinish = null;
		}


	}

}
