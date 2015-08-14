
namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Codec {
	class VideoCodec {
		/// <summary>
		/// FLV frame key marker constant.
		/// </summary>
		public const byte FLV_FRAME_KEY = 0x10;

		public static VideoCodec Jpeg = new VideoCodec(0x01);
		public static VideoCodec H263 = new VideoCodec(0x02);
		public static VideoCodec ScreenVideo = new VideoCodec(0x03);
		public static VideoCodec VP6 = new VideoCodec(0x04);
		public static VideoCodec VP6a = new VideoCodec(0x05);
		public static VideoCodec ScreenVideo2 = new VideoCodec(0x06);
		public static VideoCodec AVC = new VideoCodec(0x07);

		readonly byte _id;

		/// <summary>
		/// Gets the numeric id for this codec, that happens to correspond to the numeric identifier that FLV will use for this codec.
		/// </summary>
		/// <value>The codec id.</value>
		public byte Id {
			get { return _id; }
		}

		private VideoCodec(byte id) {
			_id = id;
		}
	}
}
