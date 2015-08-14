using System;
using System.Collections;

namespace GodLesZ.Library.Amf.Scheduling {
	public abstract class ScheduledJobBase : IScheduledJob {
		private string _name;
		private Hashtable _jobDataMap;

		public ScheduledJobBase() {
			_name = "job" + Guid.NewGuid().ToString("N");
		}

		public ScheduledJobBase(string name) {
			_name = name;
		}

		#region IScheduledJob Members

		public virtual string Name {
			get { return _name; }
			set {
				if (value == null || value.Trim().Length == 0)
					throw new ArgumentException("Job name cannot be empty.");
				_name = value;
			}
		}

		public Hashtable JobDataMap {
			get {
				if (_jobDataMap == null) {
					_jobDataMap = new Hashtable();
				}
				return _jobDataMap;
			}
			set { _jobDataMap = value; }
		}

		public abstract void Execute(ScheduledJobContext context);

		#endregion

		public override string ToString() {
			return _name;
		}
	}
}
