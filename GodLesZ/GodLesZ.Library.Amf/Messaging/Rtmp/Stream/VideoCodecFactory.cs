using System;
using System.Collections;
using GodLesZ.Library.Amf.Messaging.Api.Stream;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream.Codec;
using GodLesZ.Library.Amf.Util;
using log4net;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.Stream {
	/// <summary>
	/// Factory for video codecs. Creates and returns video codecs.
	/// </summary>
	class VideoCodecFactory {
		private static ILog log = LogManager.GetLogger(typeof(VideoCodecFactory));
		/// <summary>
		/// List of available codecs.
		/// </summary>
		private IList _codecs = new ArrayList();

		public IList Codecs {
			set { _codecs = value; }
		}
		/// <summary>
		/// Create and return new video codec applicable for byte buffer data
		/// </summary>
		/// <param name="data">Byte buffer data.</param>
		/// <returns>Video codec.</returns>
		public IVideoStreamCodec GetVideoCodec(ByteBuffer data) {
			IVideoStreamCodec result = null;
			//get the codec identifying byte
			int codecId = data.Get() & 0x0f;
			switch (codecId) {
				case 2: //sorenson 
					result = new SorensonVideo();
					break;
				case 3: //screen video
					result = new ScreenVideo();
					break;
				case 7: //avc/h.264 video
					result = new AVCVideo();
					break;
			}
			data.Rewind();
			if (result == null) {
				IVideoStreamCodec codec;
				foreach (IVideoStreamCodec storedCodec in _codecs) {
					// XXX: this is a bit of a hack to create new instances of the
					// configured video codec for each stream
					try {
						codec = Activator.CreateInstance(storedCodec.GetType()) as IVideoStreamCodec;
					} catch (Exception ex) {
						log.Error("Could not create video codec instance.", ex);
						continue;
					}

					log.Info("Trying codec " + codec);
					if (codec.CanHandleData(data)) {
						result = codec;
						break;
					}
				}
			}
			return result;
		}
	}
}
