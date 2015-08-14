using System.IO;

#if !NET_1_1
using System.Collections.Generic;
#endif
using log4net;
using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Messaging.Rtmp.IO.Flv;
using GodLesZ.Library.Amf.Messaging.Rtmp.IO.Mp3;
using GodLesZ.Library.Amf.Messaging.Rtmp.IO.Mp4;

namespace GodLesZ.Library.Amf.Messaging.Rtmp.IO {
	/// <summary>
	/// Creates streamable file services.
	/// </summary>
	class StreamableFileFactory : IStreamableFileFactory {
		private static ILog log = LogManager.GetLogger(typeof(StreamableFileFactory));

		public StreamableFileFactory() {
			_services.Add(new FlvService());
			_services.Add(new Mp3Service());
			_services.Add(new Mp4Service());
		}

		/// <summary>
		/// Set of IStreamableFileService instances.
		/// </summary>
#if !NET_1_1
		List<IStreamableFileService> _services = new List<IStreamableFileService>();
#else
        ArrayList _services = new ArrayList();
#endif

		/*
        public void SetServices(Set services)
        {
            _services = services;
        }
        */

		#region IStreamableFileFactory Members

		public void Start(ConfigurationSection configuration) {
		}

		public void Shutdown() {
		}

		public IStreamableFileService GetService(FileInfo file) {
			log.Info("Get service for file: " + file.Name);
			// Return first service that can handle the passed file
			foreach (IStreamableFileService service in _services) {
				if (service.CanHandle(file)) {
					log.Info("Found service for file: " + file.Name);
					return service;
				}
			}
			return null;
		}

#if !NET_1_1
		public ICollection<IStreamableFileService> GetServices()
#else
        public ICollection GetServices()
#endif
 {
			//log.Info("StreamableFileFactory get services.");
			return _services;
		}

		#endregion
	}
}
