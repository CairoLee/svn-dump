using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodLesZ.Library.Data.Tests {
	
	public class Program {
		
		public static void Main(string[] args) {
			var conString = string.Format("SERVER={0};UID={1};PASSWORD={2};DATABASE={3};", 
				"localhost", "root", "", "schule_hr"
			);
			var config = new ConnectionStringSettings("local", conString);

			
			//var con = new GodLesZ.Library.MySql.Data.MySqlClient.MySqlConnection(conString);
			//con.Open();

			dynamic table = new MysqlTestCountries(config);
			var results = table.Find(region_id : 1);
			Console.WriteLine("-- All with region_id = 1");
			foreach (var row in results) {
				Console.WriteLine("{0} | {1} | {2}", row.COUNTRY_ID, row.COUNTRY_NAME, row.REGION_ID);
			}

			Console.Read();
		}


		public class MysqlTestCountries : DynamicModel {

			public override string TableName {
				get { return "countries"; }
			}

			public override string PrimaryKeyField {
				get { return "country_id"; }
			}

			public MysqlTestCountries(ConnectionStringSettings settings)
				: base(settings, GodLesZ.Library.MySql.Data.MySqlClient.MySqlClientFactory.Instance) {
			}
			
		}

	}

}
