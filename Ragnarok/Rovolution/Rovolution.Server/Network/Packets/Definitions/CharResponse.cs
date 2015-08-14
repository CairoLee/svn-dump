using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;
using Rovolution.Server.Geometry;

namespace Rovolution.Server.Network.Packets {

	public class CharacterResponseError : Packet {
		public CharacterResponseError(byte errNumber)
			: base(0x6C, 3) {
			Write(errNumber);
		}
	}

	public class CharacterResponseSuccess : Packet {
		public CharacterResponseSuccess(Account account)
			: base(0, 4) {
			Write(account.WorldID.ID);
		}
	}

	public class CharacterResponseCreation : Packet {
		public CharacterResponseCreation(ECharacterCreationResult result)
			: base(0x6E, 3) {
			Write((byte)result);
		}
	}

	public class CharacterResponseList : Packet {
		public CharacterResponseList(Account account)
			: base(0x6b) {
			int charCount = account.Chars.Count;

			// Space for packet length
			Write((short)0);
			// if PACKETVER >= 20100413
			Write((byte)12); // Max slots.
			Write((byte)12); // Available slots.
			Write((byte)12); // Premium slots.
			// endif
			Writer.Fill(20); // unknown bytes

			int charsLength = 0;
			foreach (Character c in account.Chars.Values) {
				charsLength += c.ToStream(Writer);
			}

			// Write packet length
			short length = (short)Writer.Length;
			Writer.Seek(2, System.IO.SeekOrigin.Begin);
			Write(length);
			// Just to be sure.. seek to end
			Writer.Seek(0, System.IO.SeekOrigin.End);
		}
	}

	public class CharacterResponseNewData : Packet {
		public CharacterResponseNewData(Character c)
			: base(0x6d) {
			c.ToStream(Writer);
		}
	}

	public class CharacterResponseWorldLogin : Packet {
		public CharacterResponseWorldLogin(Character c)
			: base(0x71, 28) {
			string mapname = Map.GetClientName(c.Status.Location.Map.Name);
			Write((uint)c.WorldID.ID);
			Write(mapname, Global.MAP_NAME_LENGTH_EXT);
			Write((int)Core.Connector.Listener.IPs[0].GetAddress());
			Write((short)Core.Connector.Listener.Ports[0]);
		}
	}

}
