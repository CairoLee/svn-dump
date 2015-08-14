using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Util;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Codec {
	class SorensonVideo : IVideoStreamCodec {
		/// <summary>
		/// SorensonVideo video codec constant.
		/// </summary>
		static string CodecName = "SorensonVideo";

		/// <summary>
		/// Block of data.
		/// </summary>
		private byte[] _blockData;
		/// <summary>
		/// Number of data blocks.
		/// </summary>
		private int _dataCount;
		/// <summary>
		/// Data block size.
		/// </summary>
		private int _blockSize;

		public SorensonVideo() {
			Reset();
		}

		#region IVideoStreamCodec Members

		public string Name {
			get { return SorensonVideo.CodecName; }
		}

		public void Reset() {
			_blockData = null;
			_blockSize = 0;
			_dataCount = 0;
		}

		public bool CanDropFrames {
			get { return true; }
		}

		public bool CanHandleData(ByteBuffer data) {
			if (data.Limit == 0)
				return false;// Empty buffer
			byte first = data.Get();
			bool result = ((first & 0x0f) == VideoCodec.H263.Id);
			data.Rewind();
			return result;
		}

		public bool AddData(ByteBuffer data) {
			if (data.Limit == 0)
				return false;// Empty buffer
			if (!CanHandleData(data))
				return false;
			byte first = data.Get();
			data.Rewind();
			if ((first & 0xf0) != VideoCodec.FLV_FRAME_KEY)
				return true;// Not a keyframe
			// Store last keyframe
			_dataCount = data.Limit;
			if (_blockSize < _dataCount) {
				_blockSize = _dataCount;
				_blockData = new byte[_blockSize];
			}
			data.Read(_blockData, 0, _dataCount);
			data.Rewind();
			return true;
		}

		public ByteBuffer GetKeyframe() {
			if (_dataCount == 0)
				return null;
			ByteBuffer result = ByteBuffer.Allocate(_dataCount);
			result.Put(_blockData, 0, _dataCount);
			result.Rewind();
			return result;
		}

		public ByteBuffer GetDecoderConfiguration() {
			return null;
		}

		#endregion
	}
}
