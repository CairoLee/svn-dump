using System;

namespace GodLesZ.Library.Amf.Scheduling {
	/// <summary>
	/// Service that supports periodic execution of jobs, adding, removing and getting their name as list.
	/// </summary>
	public interface ISchedulingService : GodLesZ.Library.Amf.Messaging.Api.IScopeService {
		/// <summary>
		/// Schedule a job for periodic execution.
		/// </summary>
		/// <param name="interval">Time in milliseconds between two notifications of the job.</param>
		/// <param name="job">The job to trigger periodically.</param>
		/// <returns>The name of the scheduled job.</returns>
		string AddScheduledJob(int interval, IScheduledJob job);
		/// <summary>
		/// Schedule a job for periodic execution.
		/// </summary>
		/// <param name="interval">Time in milliseconds between two notifications of the job.</param>
		/// <param name="repeatCount">Repeat counter.</param>
		/// <param name="job">The job to trigger periodically.</param>
		/// <returns>The name of the scheduled job.</returns>
		string AddScheduledJob(int interval, int repeatCount, IScheduledJob job);
		/// <summary>
		/// Schedule a job for single execution in the future.  Please note
		/// that the jobs are not persisted.
		/// </summary>
		/// <param name="timeDelta">Time delta in milliseconds from the current date.</param>
		/// <param name="job">The job to trigger.</param>
		/// <returns>The name of the scheduled job.</returns>
		string AddScheduledOnceJob(long timeDelta, IScheduledJob job);
		/// <summary>
		/// Schedule a job for single execution at a given date. Please note that the jobs are not persisted.
		/// </summary>
		/// <param name="date">Date when the job should be executed.</param>
		/// <param name="job">The job to trigger.</param>
		/// <returns>The name of the scheduled job.</returns>
		string AddScheduledOnceJob(DateTime date, IScheduledJob job);
		/// <summary>
		/// Schedule a job.
		/// </summary>
		/// <param name="job"></param>
		/// <param name="trigger"></param>
		/// <returns></returns>
		DateTime ScheduleJob(IScheduledJob job, Trigger trigger);
		/// <summary>
		/// Remove (delete) the <see cref="IScheduledJob" /> with the given and any <see cref="Trigger" /> s that reference it.
		/// </summary>
		/// <param name="jobName">The name of the job to stop.</param>
		bool RemoveScheduledJob(string jobName);
		/// <summary>
		/// Return names of scheduled jobs.
		/// </summary>
		/// <returns>List of job names.</returns>
		string[] GetScheduledJobNames();
	}
}
