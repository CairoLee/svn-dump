using System;

namespace GodLesZ.Library.Ragnarok.Tests.Library {

	[AttributeUsage(AttributeTargets.Method)]
	public class PerformanceTestRunAttribute : Attribute {

		public int RunCount {
			get;
			set;
		}


		public PerformanceTestRunAttribute(int runCount = 1) {
			RunCount = runCount;
		}

	}

}