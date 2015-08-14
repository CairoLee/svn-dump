

#if NET_1_1
using GodLesZ.Library.Amf.Util.Nullables;
#else

#endif

namespace GodLesZ.Library.Amf.Scheduling {
	/// <summary>
	/// A context bundle that is given to an <see cref="IScheduledJob" /> instance as it is
	/// executed, and to a <see cref="Trigger" /> instance after the
	/// execution completes.
	/// </summary>
	public class ScheduledJobContext {
	}
}
