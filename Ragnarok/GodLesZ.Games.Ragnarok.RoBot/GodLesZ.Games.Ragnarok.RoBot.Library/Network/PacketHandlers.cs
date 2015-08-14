using System;
using System.Collections.Generic;
using GodLesZ.Library.Network.Packets;

namespace GodLesZ.Games.Ragnarok.RoBot.Library.Network {

	public class PacketHandlers {

		/// <summary>
		/// returnes the Array of Packet Handler
		/// <para>Index is the PacketID</para>
		/// </summary>
		public static Dictionary<short, PacketHandler> Handlers {
			get;
			private set;
		}


		static PacketHandlers() {
			Handlers = new Dictionary<short, PacketHandler>();
		}


		public static void Initialize() {
			Register("Default", 0x00, 0, EmptyHandler);
		}


		/// <summary>
		/// Registers a Packet to Listen for
		/// </summary>
		/// <param name="name"> </param>
		/// <param name="packetID">PacketID</param>
		/// <param name="length">
		/// Length of the Incoming Data
		/// <para>NOTE: this must be EXACTLY the Length! Too much Data will be handled as a new Packet!</para>
		/// </param>
		/// <param name="onReceive">CallBack Function - will be called on Packet income</param>
		public static void Register(string name, short packetID, int length, OnPacketReceive onReceive) {
			if (Handlers.ContainsKey(packetID)) {
				throw new Exception(String.Format("Packet {0} already exists!", packetID));
			}

			Handlers.Add(packetID, new PacketHandler(name, packetID, length, onReceive));
		}

		/// <summary>
		/// returnes the Packet Handler for a PackeID
		/// </summary>
		/// <param name="packetID"></param>
		/// <returns></returns>
		public static PacketHandler GetHandler(short packetID) {
			if (Handlers.ContainsKey(packetID))
				return Handlers[packetID];

			return null;
		}

		/// <summary>
		/// removes, or better "nullify" a Packet Handler
		/// </summary>
		/// <param name="packetID"></param>
		public static void RemoveHandler(short packetID) {
			if (Handlers.ContainsKey(packetID))
				Handlers[packetID] = null;
		}


		/// <summary>
		/// an Empty/Unused/not yet available Packet Handler
		/// </summary>
		/// <param name="reader"></param>
		public static void EmptyHandler(PacketReader reader) {
		}

	}

}
