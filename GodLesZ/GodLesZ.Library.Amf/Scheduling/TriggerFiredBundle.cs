using System;
using GodLesZ.Library.Amf.Util;

#if NET_1_1
using GodLesZ.Library.Amf.Util.Nullables;
#else
using NullableDateTime = System.Nullable<System.DateTime>;
#endif

namespace GodLesZ.Library.Amf.Scheduling {
	/// <summary>
	/// A simple class used for returning execution-time data from the JobStore to the <see cref="SchedulerThread" />.
	/// </summary>
	[Serializable]
	class TriggerFiredBundle {
		private readonly IScheduledJob _job;
		private readonly Trigger _trigger;
		private readonly bool _jobIsRecovering;
		private NullableDateTime _fireTimeUtc;
		private NullableDateTime _scheduledFireTimeUtc;
		private NullableDateTime _prevFireTimeUtc;
		private NullableDateTime _nextFireTimeUtc;

		/// <summary>
		/// Gets the job detail.
		/// </summary>
		/// <value>The job detail.</value>
		public virtual IScheduledJob Job {
			get { return _job; }
		}

		/// <summary>
		/// Gets the trigger.
		/// </summary>
		/// <value>The trigger.</value>
		public virtual Trigger Trigger {
			get { return _trigger; }
		}


		/// <summary>
		/// Gets a value indicating whether this <see cref="TriggerFiredBundle"/> is recovering.
		/// </summary>
		/// <value><c>true</c> if recovering; otherwise, <c>false</c>.</value>
		public virtual bool Recovering {
			get { return _jobIsRecovering; }
		}

		/// <returns> 
		/// Returns the UTC fire time.
		/// </returns>
		public virtual NullableDateTime FireTimeUtc {
			get { return _fireTimeUtc; }
		}

		/// <summary>
		/// Gets the next UTC fire time.
		/// </summary>
		/// <value>The next fire time.</value>
		/// <returns> Returns the nextFireTimeUtc.</returns>
		public virtual NullableDateTime NextFireTimeUtc {
			get { return _nextFireTimeUtc; }
		}

		/// <summary>
		/// Gets the previous UTC fire time.
		/// </summary>
		/// <value>The previous fire time.</value>
		/// <returns> Returns the previous fire time. </returns>
		public virtual NullableDateTime PrevFireTimeUtc {
			get { return _prevFireTimeUtc; }
		}

		/// <returns> 
		/// Returns the scheduled UTC fire time.
		/// </returns>
		public virtual NullableDateTime ScheduledFireTimeUtc {
			get { return _scheduledFireTimeUtc; }
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="TriggerFiredBundle"/> class.
		/// </summary>
		/// <param name="job">The job.</param>
		/// <param name="trigger">The trigger.</param>
		/// <param name="jobIsRecovering">if set to <c>true</c> [job is recovering].</param>
		/// <param name="fireTimeUtc">The fire time.</param>
		/// <param name="scheduledFireTimeUtc">The scheduled fire time.</param>
		/// <param name="prevFireTimeUtc">The previous fire time.</param>
		/// <param name="nextFireTimeUtc">The next fire time.</param>
		public TriggerFiredBundle(IScheduledJob job, Trigger trigger, bool jobIsRecovering,
								  NullableDateTime fireTimeUtc,
								  NullableDateTime scheduledFireTimeUtc,
								  NullableDateTime prevFireTimeUtc,
								  NullableDateTime nextFireTimeUtc) {
			_job = job;
			_trigger = trigger;
			_jobIsRecovering = jobIsRecovering;
			_fireTimeUtc = DateTimeUtils.AssumeUniversalTime(fireTimeUtc);
			_scheduledFireTimeUtc = DateTimeUtils.AssumeUniversalTime(scheduledFireTimeUtc);
			_prevFireTimeUtc = DateTimeUtils.AssumeUniversalTime(prevFireTimeUtc);
			_nextFireTimeUtc = DateTimeUtils.AssumeUniversalTime(nextFireTimeUtc);
		}
	}
}
