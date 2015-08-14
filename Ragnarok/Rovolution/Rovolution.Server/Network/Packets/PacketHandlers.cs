using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Network {

	public class PacketHandlers {
		/// <summary>
		/// Storage for our Income Packets
		/// </summary>
		private static Dictionary<short, PacketHandler> mHandlers = new Dictionary<short, PacketHandler>();

		/// <summary>
		/// returnes the Array of Packet Handler
		/// <para>Index is the PacketID</para>
		/// </summary>
		public static Dictionary<short, PacketHandler> Handlers {
			get { return mHandlers; }
		}


		public static void Initialize() {
			Register("Default", 0x00, 0, EmptyHandler);
		}



		/// <summary>
		/// Registers a Packet to Listen for
		/// </summary>
		/// <param name="packetID">PacketID</param>
		/// <param name="length">
		/// Length of the Incoming Data
		/// <para>NOTE: this must be EXACTLY the Length! Too much Data will be handled as a new Packet!</para>
		/// </param>
		/// <param name="type">Type of the Packet</param>
		/// <param name="onReceive">CallBack Function - will be called on Packet income</param>
		public static void Register(string name, short packetID, int length, OnPacketReceive onReceive) {
			if (mHandlers.ContainsKey(packetID) == true)
				throw new Exception(String.Format("Packet {0} already exists!", packetID));

			mHandlers.Add(packetID, new PacketHandler(name, packetID, length, onReceive));
		}

		/// <summary>
		/// returnes the Packet Handler for a PackeID
		/// </summary>
		/// <param name="packetID"></param>
		/// <returns></returns>
		public static PacketHandler GetHandler(short packetID) {
			if (mHandlers.ContainsKey(packetID) == true)
				return mHandlers[packetID];

			return null;
		}

		/// <summary>
		/// removes, or better "nullify" a Packet Handler
		/// </summary>
		/// <param name="packetID"></param>
		public static void RemoveHandler(short packetID) {
			if (mHandlers.ContainsKey(packetID) == true)
				mHandlers[packetID] = null;
		}





		/// <summary>
		/// an Empty/Unused/not yet available Packet Handler
		/// </summary>
		/// <param name="state"></param>
		/// <param name="reader"></param>
		public static void EmptyHandler(NetState state, PacketReader reader) {
		}


	}

}
