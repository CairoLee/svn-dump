using GodLesZ.Library.Amf.Configuration;
using GodLesZ.Library.Amf.Messaging.Api;
using GodLesZ.Library.Amf.Messaging.Rtmp.Stream;

namespace GodLesZ.Library.Amf.Messaging {
	/// <summary>
	/// The global scope that acts as root for all applications in a host.
	/// </summary>
	class GlobalScope : Scope, IGlobalScope {
		internal GlobalScope() {
		}


		#region IGlobalScope Members

		public void Register() {
			//Start services
			GodLesZ.Library.Amf.Messaging.Rtmp.IO.IStreamableFileFactory streamableFileFactory = ObjectFactory.CreateInstance(FluorineConfiguration.Instance.FluorineSettings.StreamableFileFactory.Type) as GodLesZ.Library.Amf.Messaging.Rtmp.IO.IStreamableFileFactory;
			AddService(typeof(GodLesZ.Library.Amf.Messaging.Rtmp.IO.IStreamableFileFactory), streamableFileFactory, false);
			streamableFileFactory.Start(null);
			GodLesZ.Library.Amf.Scheduling.SchedulingService schedulingService = new GodLesZ.Library.Amf.Scheduling.SchedulingService();
			AddService(typeof(GodLesZ.Library.Amf.Scheduling.ISchedulingService), schedulingService, false);
			schedulingService.Start(null);
			GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IBWControlService bwControlService = ObjectFactory.CreateInstance(FluorineConfiguration.Instance.FluorineSettings.BWControlService.Type) as GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IBWControlService;
			AddService(typeof(GodLesZ.Library.Amf.Messaging.Rtmp.Stream.IBWControlService), bwControlService, false);
			bwControlService.Start(null);
			VideoCodecFactory videoCodecFactory = new VideoCodecFactory();
			AddService(typeof(VideoCodecFactory), videoCodecFactory, false);
			Init();
		}

		#endregion
	}
}
