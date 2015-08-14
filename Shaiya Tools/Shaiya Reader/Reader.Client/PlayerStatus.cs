using FinalSoftware.MySql;

using Worker = Shaiya.Reader.API.Worker;

namespace Shaiya.Reader.Client {

	public class Position {
		public static Position Zero = new Position( 0f, 0f, 0f );
		public float X;
		public float Y;
		public float Z;

		public Position( float x, float y, float z ) {
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString() {
			return string.Format( "{0:000} / {1:000} / {2:000}", X, Y, Z );
		}
	}

	public class PlayerStatus {
		public static string ForumUsername = "";
		public static string ForumPassword = "";
		public static int ForumUserID = 0;
		public static MySqlWrapper MySql;
		public static bool IsSqlInit = false;
		private static bool IsCharMarked = true;

		public int HP = 0;
		public int HPMax = 0;

		public int MP = 0;
		public int MPMax = 0;

		public int AP = 0;
		public int APMax = 0;

		public int Exp = 0;
		public int ExpMax = 0;
		public int ExpLastKill = 0;
		public int Level = 1;

		public string Name = "";

		public int StatusInt = 0;
		public int StatusStr = 0;
		public int StatusGes = 0;
		public int StatusWei = 0;
		public int StatusAbw = 0;
		public int StatusGlu = 0;

		public Position Position = Position.Zero;
		public Position PositionFuture = Position.Zero;


		public PlayerStatus() {
		}

		public void Update() {
			int expNew = Worker.Exp;

			HP = Worker.HP;
			HPMax = Worker.HPMax;
			MP = Worker.MP;
			MPMax = Worker.MPMax;
			AP = Worker.AP;
			APMax = Worker.APMax;

			Position = new Position( Worker.PositionX, Worker.PositionY, Worker.PositionZ );
			PositionFuture = new Position( Worker.PositionFutureX, Worker.PositionFutureY, Worker.PositionFutureZ );

			if( expNew > 0 && frmMain.LastEXP > 0 ) {
				int expDiff = ( expNew - frmMain.LastEXP );
				if( expDiff > 0 && expDiff != ExpLastKill )
					ExpLastKill = ( expNew - frmMain.LastEXP );
			}
			Exp = expNew;
			ExpMax = Worker.ExpMax;
			Level = Worker.Level;

			Name = Worker.Name;

			StatusInt = Worker.StatusInt;
			StatusStr = Worker.StatusStr;
			StatusGes = Worker.StatusGes;
			StatusWei = Worker.StatusWei;
			StatusAbw = Worker.StatusAbw;
			StatusGlu = Worker.StatusGlu;


			if( frmMain.LastEXP > 0 && Exp != frmMain.LastEXP ) {
				frmMain.EarnedEXP += ( Exp - frmMain.LastEXP );
				frmMain.KillCount++;
			}

			frmMain.LastEXP = Exp;
		}



		public int SqlUpdate() {
			int initSql = InitSql();
			if( initSql != 1 )
				return initSql;

			if( this.Name == string.Empty )
				return 1;

			int sqlKey;
			if( this.IsInTable( out sqlKey ) == false ) {
				if( IsCharMarked == false )
					System.Windows.Forms.MessageBox.Show( "Fehler beim aktualisieren des Charakters!\nDer Charakter wurde nicht in der Forum Datenbank gefunden.\nFalls du ihn neu erstellt hast, musst du ihn erst im Forum eintragen.\n\nSollte dieses Problem weiterhin bestehen, wende dich bitte an GodLesZ", "Charakter nicht gefunden", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error );
				IsCharMarked = true;
				return -1;
			}

			// safty Check no. 2
			if( HP == -1 || HP >= 100000 || Level == 0 )
				return -1;

			MySql.QuerySimple( "UPDATE shaiya_chars SET `name` = '{0}', `level` = {1}, `hp` = {2}, `hp_max` = {3}, `mp` = {4}, `mp_max` = {5}, `ap` = {6}, `ap_max` = {7}, `int` = {8}, `str` = {9}, `ges` = {10}, `wei` = {11}, `abw` = {12}, `glu` = {13}, `last_update` = NOW() WHERE char_id = {14}", Name.MysqlEscape(), Level, HP, HPMax, MP, MPMax, AP, APMax, StatusInt, StatusStr, StatusGes, StatusWei, StatusAbw, StatusGlu, sqlKey );
			//MySql.QuerySimple( "INSERT INTO shaiya_chars VALUES( NULL, " + ForumUserID + ", '{0}', {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, 0, 1, 1, '', NOW() );", Name.MysqlEscape(), Level, HP, HPMax, MP, MPMax, AP, APMax, StatusInt, StatusStr, StatusGes, StatusWei, StatusAbw, StatusGlu );

			if( MySql.LastError != null ) {
				System.Diagnostics.Debug.WriteLine( MySql.LastError );
				System.Windows.Forms.MessageBox.Show( "SQL Fehler!\n\n" + MySql.LastError );
				return -1;
			}

			return 1;
		}

		private bool IsInTable( out int key ) {
			key = 0;
			ResultTable table = MySql.Query( "SELECT char_id FROM shaiya_chars WHERE forum_id = {0} AND name = '{1}'", ForumUserID, this.Name.MysqlEscape() );
			if( table.Rows.Count == 0 )
				return false;
			key = table.Rows[ 0 ][ "char_id" ].GetInt32();
			return true;
		}



		private int InitSql() {
			if( IsSqlInit == true )
				return 1;

			MySql = new MySqlWrapper( "blubb-gaming.de", 3306, "shaiya_forum", "alone4ever", "shaiya_forum" );
			MysqlError error = MySql.Prepare();
			switch( error ) {
				case MysqlError.None:
					break;
				default:
					System.Diagnostics.Debug.WriteLine( "SqlInit Fehler: " + error );
					System.Windows.Forms.MessageBox.Show( "SqlInit Fehler!\n\n" + error );
					return -1;
			}

			ResultTable table = MySql.Query( "SELECT userID FROM wcf1_user WHERE username = '{0}' AND password = '{1}'", ForumUsername.MysqlEscape(), this.GetForumPass( ForumUsername, ForumPassword ).MysqlEscape() );
			if( table.Rows.Count == 0 )
				return 0;

			if( MySql.LastError != null ) {
				System.Diagnostics.Debug.WriteLine( MySql.LastError );
				System.Windows.Forms.MessageBox.Show( "SQL Fehler!\n\n" + MySql.LastError );
				return -1;
			}

			ForumUserID = table.Rows[ 0 ][ "userID" ].GetInt32();

			IsSqlInit = true;
			return 1;
		}

		#region SQL Helper
		private bool GetUserID() {
			ResultTable table = MySql.Query( "SELECT forum_id FROM wcf1_user WHERE username = '{0}'", ForumUsername.MysqlEscape() );
			if( table.Rows.Count == 0 )
				return false;
			ForumUserID = table.Rows[ 0 ][ "forum_id" ].GetInt32();
			return true;
		}

		private string GetForumPass( string Username, string Password ) {
			ResultTable table = MySql.Query( "SELECT salt FROM wcf1_user WHERE username = '{0}'", ForumUsername.MysqlEscape() );
			if( table.Rows.Count == 0 )
				return Password;

			string salt = table.Rows[ 0 ][ "salt" ].ToString();
			string saltedHash = HelperCrypt.SHA1( salt + HelperCrypt.SHA1( Password ) );

			return HelperCrypt.SHA1( salt + saltedHash );
		} 
		#endregion

	}

}
