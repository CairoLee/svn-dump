using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shaiya.Extended.Server.Objects;
using Shaiya.Extended.Server.Network.Packets;
using Shaiya.Extended.Library.Network;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server.Network.Handler {

	public class ClientPacketHandler {

		public static void Initialize() {
			PacketHandlers.Register( 0x010B, 10, KeydataResponse );
			PacketHandlers.Register( 0x0107, 4, KeydataResponse2 );
			
		}



		public static void KeydataResponse( NetState state, PacketReader reader ) {

		}

		public static void KeydataResponse2( NetState state, PacketReader reader ) {

		}

	}

}
