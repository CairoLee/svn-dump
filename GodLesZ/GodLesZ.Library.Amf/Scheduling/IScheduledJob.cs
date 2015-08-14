using System.Collections;

namespace GodLesZ.Library.Amf.Scheduling {
	/// <summary>
	/// Interface that must be implemented by classes that can be scheduled for periodic execution.
	/// </summary>
	public interface IScheduledJob {
		/// <summary>
		/// Get or sets the name of this job.
		/// </summary>
		string Name { get; set; }
		/// <summary>
		/// Get or set the data map that is associated with the job.
		/// </summary>
		Hashtable JobDataMap { get; set; }
		/// <summary>
		/// Called each time the job is triggered by the scheduling service.
		/// </summary>
		/// <param name="context">The execution context.</param>
		void Execute(ScheduledJobContext context);
	}
}
