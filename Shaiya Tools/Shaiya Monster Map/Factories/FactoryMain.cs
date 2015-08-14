using FinalSoftware.MySql;
using System.Windows.Forms;
using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap {

	public class FactoryMain {
		public static MySqlWrapper Mysql = new MySqlWrapper();

		private static ConnectionHolder mConnectionHolder = new ConnectionHolder( "127.0.0.1", 3306, "root", "", "shaiya_db" );

		public static string Password {
			set { mConnectionHolder.Password = HelperCrypt.Decrypt( value ); }
		}

		public IPoint this[ int i ] {
			get { return Points[ i ]; }
		}

		public EMap Map {
			get { return Points.Map; }
			set { Points.Map = value; }
		}
		
		public ShaiyaMonsterMap.IPointList Points = new IPointList();
		public ListView ListView;
		public PictureBox Image;



		public static bool Initialize() {
			ShaiyaMonsterMap.Structs.SMobMapRule.Initialize();

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



		public virtual void AddToList( IPoint p ) {
		}

	}

}
