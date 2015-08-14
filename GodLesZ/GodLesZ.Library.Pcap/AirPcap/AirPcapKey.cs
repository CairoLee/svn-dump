﻿using System;

namespace GodLesZ.Library.Pcap.AirPcap {
	/// <summary>
	/// WEB key container
	/// </summary>
	public class AirPcapKey {
		/// <summary>
		/// Number of bytes in a wep key
		/// </summary>
		public const int WepKeyMaxSize = 32;

		/// <summary>
		/// Type of key, can be on of: \ref AIRPCAP_KEYTYPE_WEP, \ref AIRPCAP_KEYTYPE_TKIP, \ref AIRPCAP_KEYTYPE_CCMP. Only AIRPCAP_KEYTYPE_WEP is supported by the driver at the moment.
		/// </summary>
		public AirPcapKeyType Type;

		/// <summary>
		/// Key data
		/// </summary>
		public byte[] Data;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="Data"></param>
		public AirPcapKey(AirPcapKeyType Type, byte[] Data) {
			this.Type = Type;
			this.Data = Data;
		}

		internal AirPcapKey(AirPcapUnmanagedStructures.AirpcapKey key) {
			Type = key.KeyType;

			Data = new byte[key.KeyData.Length];
			Array.Copy(key.KeyData, Data, Data.Length);
		}

		/// <summary>
		///
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public override string ToString() {
			return string.Format("[AirPcapKey Type: {0}, Data.Length: {1}]",
								Type, Data.Length);
		}
	}
}
