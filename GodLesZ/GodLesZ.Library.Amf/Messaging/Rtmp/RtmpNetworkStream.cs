using System.Net.Sockets;

#if !SILVERLIGHT

#endif


namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class RtmpNetworkStream : RtmpQueuedWriteStream {
		private Socket _socket;

		public RtmpNetworkStream(Socket socket)
			: base(new NetworkStream(socket, false)) {
			_socket = socket;
		}

		public RtmpNetworkStream(Socket socket, System.IO.Stream stream)
			: base(stream) {
			_socket = socket;
		}

		public Socket Socket {
			get {
				return _socket;
			}
		}

		public override void Close() {
			base.Close();
			_socket.Close();
		}

		public virtual bool DataAvailable {
			get {
#if !SILVERLIGHT
				NetworkStream ns = this.InnerStream as NetworkStream;
				if (ns != null)
					return (this.InnerStream as NetworkStream).DataAvailable;
				return false;
#else
                return false;
#endif
			}
		}
	}
}