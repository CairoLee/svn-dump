using GodLesZ.Library.MySql.Properties;
using System;
using System.Diagnostics;

namespace GodLesZ.Library.MySql.Data.MySqlClient {

	internal class PerformanceMonitor {
		private MySqlConnection connection;
		private static PerformanceCounter procedureHardQueries;
		private static PerformanceCounter procedureSoftQueries;

		public PerformanceMonitor(MySqlConnection connection) {
			this.connection = connection;
			string perfMonCategoryName = Resources.PerfMonCategoryName;
			if (connection.Settings.UsePerformanceMonitor && (procedureHardQueries == null)) {
				try {
					procedureHardQueries = new PerformanceCounter(perfMonCategoryName, "HardProcedureQueries", false);
					procedureSoftQueries = new PerformanceCounter(perfMonCategoryName, "SoftProcedureQueries", false);
				} catch (Exception exception) {
					Logger.LogException(exception);
				}
			}
		}

		public void AddHardProcedureQuery() {
			if (this.connection.Settings.UsePerformanceMonitor && (procedureHardQueries != null)) {
				procedureHardQueries.Increment();
			}
		}

		public void AddSoftProcedureQuery() {
			if (this.connection.Settings.UsePerformanceMonitor && (procedureSoftQueries != null)) {
				procedureSoftQueries.Increment();
			}
		}
	}
}

