namespace Shaiya.Extended.Server.MySql.Data.Common {
	using System;
	using System.IO;
	using System.Net;
	using System.Net.Sockets;
	using System.Reflection;

	internal class StreamCreator {
		private string hostList;
		private string pipeName;
		private uint port;
		private uint timeOut;

		public StreamCreator( string hosts, uint port, string pipeName ) {
			this.hostList = hosts;
			if( ( this.hostList == null ) || ( this.hostList.Length == 0 ) ) {
				this.hostList = "localhost";
			}
			this.port = port;
			this.pipeName = pipeName;
		}

		private Stream CreateNamedPipeStream( string hostname ) {
			string str;
			if( string.Compare( hostname, "localhost", true ) == 0 ) {
				str = @"\\.\pipe\" + this.pipeName;
			} else {
				str = string.Format( @"\\{0}\pipe\{1}", hostname, this.pipeName );
			}
			return new NamedPipeStream( str, FileAccess.ReadWrite );
		}

		private Stream CreateSocketStream( IPAddress ip, bool unix ) {
			EndPoint point;
			if( !Platform.IsWindows() && unix ) {
				point = CreateUnixEndPoint( this.hostList );
			} else {
				point = new IPEndPoint( ip, (int)this.port );
			}
			Socket socket = unix ? new Socket( AddressFamily.Unix, SocketType.Stream, ProtocolType.IP ) : new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			IAsyncResult asyncResult = socket.BeginConnect( point, null, null );
			if( !asyncResult.AsyncWaitHandle.WaitOne( (int)( this.timeOut * 0x3e8 ), false ) ) {
				socket.Close();
				return null;
			}
			try {
				socket.EndConnect( asyncResult );
			} catch( Exception ) {
				socket.Close();
				return null;
			}
			NetworkStream stream = new NetworkStream( socket, true );
			GC.SuppressFinalize( socket );
			GC.SuppressFinalize( stream );
			return stream;
		}

		private static EndPoint CreateUnixEndPoint( string host ) {
			return (EndPoint)Assembly.Load( "Mono.Posix" ).CreateInstance( "Mono.Posix.UnixEndPoint", false, BindingFlags.CreateInstance, null, new object[] { host }, null, null );
		}

		private IPHostEntry GetHostEntry( string hostname ) {
			IPAddress address;
			if( IPAddress.TryParse( hostname, out address ) ) {
				IPHostEntry entry = new IPHostEntry();
				entry.AddressList = new IPAddress[] { address };
				return entry;
			}
			return Dns.GetHostEntry( hostname );
		}

		public Stream GetStream( uint timeout ) {
			this.timeOut = timeout;
			if( this.hostList.StartsWith( "/" ) ) {
				return this.CreateSocketStream( null, true );
			}
			string[] strArray = this.hostList.Split( new char[] { '&' } );
			int index = new Random( (int)DateTime.Now.Ticks ).Next( strArray.Length );
			int num2 = 0;
			bool flag = ( this.pipeName != null ) && ( this.pipeName.Length != 0 );
			Stream stream = null;
			while( num2 < strArray.Length ) {
				if( flag ) {
					stream = this.CreateNamedPipeStream( strArray[ index ] );
				} else {
					foreach( IPAddress address in this.GetHostEntry( strArray[ index ] ).AddressList ) {
						if( address.AddressFamily != AddressFamily.InterNetworkV6 ) {
							stream = this.CreateSocketStream( address, false );
							if( stream != null ) {
								break;
							}
						}
					}
				}
				if( stream != null ) {
					return stream;
				}
				index++;
				if( index == strArray.Length ) {
					index = 0;
				}
				num2++;
			}
			return stream;
		}
	}
}

