namespace Shaiya.Extended.Server.MySql.Data.MySqlClient {
	using Shaiya.Extended.Server.MySql.Data.MySqlClient.Properties;
	using System;
	using System.Diagnostics;

	internal class PerformanceMonitor {
		private MySqlConnection connection;
		private static PerformanceCounter procedureHardQueries;
		private static PerformanceCounter procedureSoftQueries;

		public PerformanceMonitor( MySqlConnection connection ) {
			this.connection = connection;
			if( connection.Settings.UsePerformanceMonitor && ( procedureHardQueries == null ) ) {
				string perfMonCategoryName = Resources.PerfMonCategoryName;
				try {
					procedureHardQueries = new PerformanceCounter( perfMonCategoryName, "HardProcedureQueries", false );
					procedureSoftQueries = new PerformanceCounter( perfMonCategoryName, "SoftProcedureQueries", false );
				} catch( Exception exception ) {
					Logger.LogException( exception );
				}
			}
		}

		public void AddHardProcedureQuery() {
			if( this.connection.Settings.UsePerformanceMonitor && ( procedureHardQueries != null ) ) {
				procedureHardQueries.Increment();
			}
		}

		public void AddSoftProcedureQuery() {
			if( this.connection.Settings.UsePerformanceMonitor && ( procedureSoftQueries != null ) ) {
				procedureSoftQueries.Increment();
			}
		}

	}

}

