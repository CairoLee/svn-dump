using System;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Stream;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Abstract base for client streams.
	/// </summary>
	[CLSCompliant(false)]
	public abstract class AbstractClientStream : AbstractStream, IClientStream {
		/// <summary>
		/// Stream identifier. Unique across server.
		/// </summary>
		private int _streamId;
		/// <summary>
		/// Connection that works with streams.
		/// </summary>
		private WeakReference _streamCapableConnection;
		/// <summary>
		/// Bandwidth configuration.
		/// </summary>
		private IBandwidthConfigure _bwConfig;
		/// <summary>
		/// Buffer duration in ms as requested by the client.
		/// </summary>
		private int _clientBufferDuration;

		/// <summary>
		/// Gets duration in ms as requested by the client.
		/// </summary>
		public int ClientBufferDuration {
			get { return _clientBufferDuration; }
		}


		#region IClientStream Members

		/// <summary>
		/// Gets stream id.
		/// </summary>
		public int StreamId {
			get { return _streamId; }
			set { _streamId = value; }
		}

		/// <summary>
		/// Set the buffer duration for this stream as requested by the client.
		/// </summary>
		/// <param name="bufferTime">Duration in ms the client wants to buffer.</param>
		public void SetClientBufferDuration(int bufferTime) {
			_clientBufferDuration = bufferTime;
		}

		/// <summary>
		/// Gets connection associated with stream.
		/// </summary>
		public IStreamCapableConnection Connection {
			get {
				if (_streamCapableConnection != null && _streamCapableConnection.IsAlive)
					return _streamCapableConnection.Target as IStreamCapableConnection;
				return null;
			}
			set {
				_streamCapableConnection = new WeakReference(value);
			}
		}

		#endregion

		#region IBWControllable Members

		/// <summary>
		/// Gets the parent IBWControllable object.
		/// </summary>
		/// <returns></returns>
		public IBWControllable GetParentBWControllable() {
			return this.Connection;
		}
		/// <summary>
		/// Gets or sets stream bandwidth configuration.
		/// </summary>
		public virtual IBandwidthConfigure BandwidthConfiguration {
			get {
				return _bwConfig;
			}
			set {
				_bwConfig = value;
			}
		}

		#endregion
	}
}
