using System;
using System.Collections.Generic;

namespace FreeWorld.Server.Shared.Packets {
	/// <summary>
	///     Maps packet types to packet codes and vice versa. Used for serialization.
	/// </summary>
	public static class PacketMap {

		private static readonly Dictionary<EPacketCode, Type> mTypeMap = new Dictionary<EPacketCode, Type> {
			{ EPacketCode.AuthRequest, typeof (AuthRequest) },
			{ EPacketCode.AuthResponse, typeof (AuthResponse) },
			{ EPacketCode.PushState, typeof (PushState) }, 
			{ EPacketCode.CoalescedData, typeof (CoalescedData) }, 
			{ EPacketCode.RequestZoneTransfer, typeof (RequestZoneTransfer) },
			{ EPacketCode.WhoisRequest, typeof (WhoisRequest) }, 
			{ EPacketCode.WhoisResponse, typeof (WhoisResponse) },
			{ EPacketCode.ChatMessage, typeof (ChatMessage) },
			{ EPacketCode.ClockSyncRequest, typeof (ClockSyncRequest) },
			{ EPacketCode.ClockSyncResponse, typeof (ClockSyncResponse) },
		};


		/// <summary>
		///     Get the type for a given packet code.
		/// </summary>
		public static Type GetTypeForPacketCode(EPacketCode c) {
			Type t;

			mTypeMap.TryGetValue(c, out t);
			return t;
		}

	}

}