using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shaiya.Extended.Library.Network;

namespace Shaiya.Extended.Server.Network.Packets {

	public sealed class Packet0xA101 : Packet {
		public Packet0xA101( NetState ns )
			: base( 0xA101 ) {
			byte[] buf = System.IO.File.ReadAllBytes( AppDomain.CurrentDomain.BaseDirectory + @"\Packets\0xA101.bin" );
			this.mStream.Write( buf, 0, buf.Length );
		}
	}





}
