using System;

using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Event;
using GodLesZ.Library.Amf.Messaging.Rtmp.Service;

namespace GodLesZ.Library.Amf.Messaging.Rtmp {
	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class RtmpChannel {
		/// <summary>
		/// RTMP connection used to transfer packets.
		/// </summary>
		RtmpConnection _connection;
		/// <summary>
		/// Channel id.
		/// </summary>
		int _channelId;

		internal RtmpChannel(RtmpConnection connection, int channelId) {
			_connection = connection;
			_channelId = channelId;
		}
		/// <summary>
		/// Gets the channel id.
		/// </summary>
		public int ChannelId {
			get { return _channelId; }
		}
		/// <summary>
		/// Get the connection.
		/// </summary>
		public RtmpConnection Connection {
			get { return _connection; }
		}
		/// <summary>
		/// Closes channel with this id on RTMP connection.
		/// </summary>
		public void Close() {
			_connection.CloseChannel(_channelId);
		}
		/// <summary>
		/// Writes packet from event data to the RTMP connection.
		/// </summary>
		/// <param name="message">Event data.</param>
		public void Write(IRtmpEvent message) {
			IClientStream stream = null;
			if (_connection is IStreamCapableConnection)
				stream = (_connection as IStreamCapableConnection).GetStreamByChannelId(_channelId);
			if (_channelId > 3 && stream == null) {
				//Stream doesn't exist any longer, discarding message
				return;
			}
			int streamId = (stream == null) ? 0 : stream.StreamId;
			Write(message, streamId);
		}
		/// <summary>
		/// Writes packet from event data to the RTMP connection using the specified stream id.
		/// </summary>
		/// <param name="message">Event data.</param>
		/// <param name="streamId">Stream id.</param>
		private void Write(IRtmpEvent message, int streamId) {
			RtmpHeader header = new RtmpHeader();
			RtmpPacket packet = new RtmpPacket(header, message);

			header.ChannelId = _channelId;
			header.Timer = message.Timestamp;
			header.StreamId = streamId;
			header.DataType = message.DataType;
			if (message.Header != null)
				header.IsTimerRelative = message.Header.IsTimerRelative;
			_connection.Write(packet);
		}
		/// <summary>
		/// Sends status notification.
		/// </summary>
		/// <param name="status">Status object.</param>
		public void SendStatus(StatusASO status) {
			bool andReturn = !status.code.Equals(StatusASO.NS_DATA_START);
			Invoke invoke;
			if (andReturn) {
				PendingCall call = new PendingCall(null, "onStatus", new object[] { status });
				invoke = new Invoke();
				invoke.InvokeId = 1;
				invoke.ServiceCall = call;
			} else {
				Call call = new Call(null, "onStatus", new object[] { status });
				invoke = (Invoke)new Notify();
				invoke.InvokeId = 1;
				invoke.ServiceCall = call;
			}
			// We send directly to the corresponding stream as for
			// some status codes, no stream has been created and thus
			// "getStreamByChannelId" will fail.
			Write(invoke, _connection.GetStreamIdForChannel(_channelId));
		}
		/// <summary>
		/// Returns a string that represents the current RtmpChannel object.
		/// </summary>
		/// <returns>A string that represents the current RtmpChannel object.</returns>
		public override string ToString() {
			return "RTMP Channel " + _channelId;
		}

	}
}
