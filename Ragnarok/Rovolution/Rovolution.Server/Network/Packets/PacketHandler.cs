using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rovolution.Server.Network;

namespace Rovolution.Server.Network {

	public delegate void OnPacketReceive(NetState state, PacketReader reader);

	public class PacketHandler {
		private string mName;
		private short mPacketID;
		private int mLength;
		private OnPacketReceive mOnReceive;

		/// <summary>
		/// returnes the PacketID
		/// </summary>
		public short PacketID {
			get { return mPacketID; }
		}

		/// <summary>
		/// returnes the Length of byte Code/Data
		/// </summary>
		public int Length {
			get { return mLength; }
		}

		/// <summary>
		/// CallBack Function - triggers on Packet receive
		/// </summary>
		public OnPacketReceive OnReceive {
			get { return mOnReceive; }
		}

		public string Name {
			get { return mName; }
		}


		/// <summary>
		/// Registers a new PacketHandler for a single Packet
		/// </summary>
		/// <param name="packetID"></param>
		/// <param name="length"></param>
		/// <param name="ingame"></param>
		/// <param name="onReceive"></param>
		public PacketHandler(string name, short packetID, int length, OnPacketReceive onReceive) {
			mName = name;
			mPacketID = packetID;
			mLength = length;
			mOnReceive = onReceive;
		}
	}

}
