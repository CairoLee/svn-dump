using System;
using System.Threading;
using FreeWorld.Server.Shared;

namespace FreeWorld.Server {

	public class Program {

		public static void Main(string[] args) {
			//Start up the world!
			var world = new World();
			world.Start();

			//Update metrics in the window title every second. Like a boss.
			//TODO: Do this properly!
			var lastCheck = DateTime.Now;
			var interval = TimeSpan.FromSeconds(1);
			while (true) {
				var delta = DateTime.Now - lastCheck;
				if (delta >= interval) {
					//Update every second or so
					Console.Title = "IN: [" + NetEntity.StatIncomingPackets + " Req/s | " + (NetEntity.StatIncomingBytes / 1024) + " KB/s]  OUT: [" + NetEntity.StatOutgoingPackets + " Req/s | " + (NetEntity.StatOutgoingBytes / 1024) + " KB/s]  CCU: [" + world.CurrentConnectedUsers + "]  World Update Time: [" + world.LastUpdateDelta + "]";
					NetEntity.StatIncomingPackets = 0;
					NetEntity.StatOutgoingPackets = 0;
					NetEntity.StatOutgoingBytes = 0;
					NetEntity.StatIncomingBytes = 0;
					lastCheck = DateTime.Now + (delta - interval);
				}

				Thread.Sleep(100);
			}
		}

	}

}
