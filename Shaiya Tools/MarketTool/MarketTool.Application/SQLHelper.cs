using System;
using System.Collections.Generic;
using System.Text;

using FinalSoftware.MySql;

namespace MarketTool.Application {

	public class SQLHelper {
		public static MySqlWrapper Mysql = new MySqlWrapper();

		private static ConnectionHolder mConnectionHolder = new ConnectionHolder( "shaiya-obscura.dz-net.net", 3306, "shaiya-obscura", "+H91wbb$56!", "shaiya_obscura" );
		private static Exception mLastException = null;

		public static string Password {
			set { mConnectionHolder.Password = HelperCrypt.Decrypt( value ); }
		}

		public static string LastException {
			get { return mLastException != null ? mLastException.ToString() : ""; }
		}



		public static bool Initialize() {
			MysqlError result = Mysql.Init( mConnectionHolder );
			switch( result ) {
				case MysqlError.None: // all okay
					return true;
				case MysqlError.OpenBeforeInit:
				case MysqlError.CanNotConnectToDB:
				case MysqlError.FailedToOpen:
				case MysqlError.UnknownOpen:
				case MysqlError.CloseBeforeInit:
				case MysqlError.CanNotDisconnectFromDB:
				case MysqlError.FailedToClose:
				case MysqlError.UnknownClose:
				default:
					return false;
			}

		}


		public static bool SendQuery( string Query ) {
			ResultTable Result;
			return SendQuery( Query, out Result );
		}

		public static bool SendQuery( string Query, out ResultTable Result ) {
			try {
				Result = Mysql.Query( Query );
				mLastException = null;
				return true;
			} catch( Exception e ) {
				System.Diagnostics.Debug.WriteLine( e );
				Result = null;
				mLastException = e;
				return false;
			}

		}


	}

}
