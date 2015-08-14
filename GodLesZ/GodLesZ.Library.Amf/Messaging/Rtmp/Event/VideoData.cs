using System;
using GodLesZ.Library.Amf.IO;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Api.Event;
using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Event {
	/// <summary>
	/// Videoframe type.
	/// </summary>
	public enum FrameType {
		/// <summary>
		/// Unknow frame type.
		/// </summary>
		Unknown,
		/// <summary>
		/// Keyframe.
		/// </summary>
		Keyframe,
		/// <summary>
		/// Inter frame.
		/// </summary>
		Interframe,
		/// <summary>
		/// Disposable inter frame.
		/// </summary>
		DisposableInterframe
	}

	/// <summary>
	/// This type supports the infrastructure and is not intended to be used directly from your code.
	/// </summary>
	[CLSCompliant(false)]
	public class VideoData : BaseEvent, IStreamData, IStreamPacket {
		/// <summary>
		/// Video data.
		/// </summary>
		protected ByteBuffer _data;
		/// <summary>
		/// Frame type, unknown by default.
		/// </summary>
		FrameType _frameType = FrameType.Unknown;

		/// <summary>
		/// Initializes a new instance of the VideoData class.
		/// </summary>
		/// <param name="data">VideoData buffer.</param>
		public VideoData(ByteBuffer data)
			: base(EventType.STREAM_DATA) {
			_dataType = Constants.TypeVideoData;
			_data = data;
			if (_data != null && _data.Limit > 0) {
				long oldPos = _data.Position;
				int firstByte = (data.Get()) & 0xff;
				data.Position = oldPos;
				int frameType = (firstByte & IOConstants.MASK_VIDEO_FRAMETYPE) >> 4;
				if (frameType == IOConstants.FLAG_FRAMETYPE_KEYFRAME)
					_frameType = FrameType.Keyframe;
				else if (frameType == IOConstants.FLAG_FRAMETYPE_INTERFRAME)
					_frameType = FrameType.Interframe;
				else if (frameType == IOConstants.FLAG_FRAMETYPE_DISPOSABLE)
					_frameType = FrameType.DisposableInterframe;
				else
					_frameType = FrameType.Unknown;
			}
		}
		/// <summary>
		/// Initializes a new instance of the VideoData class.
		/// </summary>
		public VideoData()
			: this(ByteBuffer.Allocate(0)) {
		}
		/// <summary>
		/// Initializes a new instance of the VideoData class.
		/// </summary>
		/// <param name="data">VideoData buffer.</param>
		public VideoData(byte[] data)
			: this(ByteBuffer.Wrap(data)) {
		}
		/// <summary>
		/// Gets video frame type.
		/// </summary>
		public FrameType FrameType {
			get { return _frameType; }
		}

		#region IStreamData Members

		/// <summary>
		/// Gets video data buffer.
		/// </summary>
		public ByteBuffer Data {
			get { return _data; }
		}

		#endregion

		/// <summary>
		/// Returns a string that represents the current object fields.
		/// </summary>
		/// <param name="indentLevel">The indentation level used for tracing the members.</param>
		/// <returns>A string that represents the current object fields.</returns>
		protected override string ToStringFields(int indentLevel) {
			string sep = GetFieldSeparator(indentLevel);
			string value = base.ToStringFields(indentLevel);
			value += sep + "frame = " + Enum.GetName(typeof(FrameType), this.FrameType);
			value += sep + "data = " + (_data != null ? "buffer(" + _data.Length + ")" : "(null)");
			return value;
		}
	}
}
