using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shaiya.Extended.Server.MySql;
using Shaiya.Extended.Server.Network;
using Shaiya.Extended.Library.Utility;

namespace Shaiya.Extended.Server.Objects {

	public class Account : SerialObject {

		private NetState mNetstate;
		private string mName = string.Empty;
		private string mPassword = string.Empty;
		private string mEmail = string.Empty;
		private string mLastIP = string.Empty;
		private int mLastLogin = 0;
		private Character mActiveChar = null;
		private DualDictionary<Serial, Character> mChars = new DualDictionary<Serial, Character>();


		public NetState Netstate {
			get { return mNetstate; }
			set { mNetstate = value; }
		}

		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		public string Password {
			get { return mPassword; }
			set { mPassword = value; }
		}

		public string LastIP {
			get { return mLastIP; }
			set { mLastIP = value; }
		}

		public int LastLogin {
			get { return mLastLogin; }
			set { mLastLogin = value; }
		}

		public string Email {
			get { return mEmail; }
			set { mEmail = value; }
		}

		public DualDictionary<Serial, Character> Chars {
			get { return mChars; }
			set { mChars = value; }
		}

		public Character this[ Serial Key ] {
			get { return mChars[ Key ]; }
			set { mChars[ Key ] = value; }
		}

		public Character ActiveChar {
			get { return mActiveChar; }
		}



		public Account() {
			Serial = Serial.NewAccount;
		}

		public static bool Read( NetState State, string Name, string Password, out Account Acc ) {
			Acc = new Account();
			Acc.Netstate = State;
			ResultTable table = Core.Database.Query( "SELECT * FROM accounts WHERE name = '{0}' AND password = '{1}' LIMIT 0,1", Name.MysqlEscape(), Password.MysqlEscape() );
			table.TableName = "Account Table";
			if( table.Rows.Count == 0 )
				return false;

			ResultRow row = table[ 0 ];
			Acc.Serial = new Serial( row[ "account_id" ].GetInt(), ESerialType.Account );
			Acc.Name = row[ "name" ].GetString();
			Acc.Password = row[ "password" ].GetString();
			Acc.LastIP = row[ "last_ip" ].GetString();
			Acc.LastLogin = row[ "last_login" ].GetInt();
			Acc.Email = row[ "email" ].GetString();

			Acc.UpdateLastLogin();

			table = Core.Database.Query( "SELECT * FROM chars WHERE account_id = {0}", Acc.Serial.Value );
			table.TableName = "Char Table";
			if( table.Rows.Count == 0 )
				return true;

			Character c;
			while( ( row = table.GetNext() ) != null ) {
				c = new Character( Acc, row[ "char_id" ].GetInt(), row[ "name" ].GetString() );
				Acc.Chars.Add( c.Serial, c );
			}


			return true;
		}

		public void UpdateLastLogin() {
			Core.Database.QuerySimple( "UPDATE accounts SET last_login = {0}, last_ip = '{1}' WHERE account_id = {2}", DateTime.Now.UnixTimestamp(), "in.a.byte.blubb", this.Serial.Value );
		}


		public Character SetActiveChar( int ChaNum ) {
			mActiveChar = mChars[ ChaNum ];

			World.CharacterLogin( mActiveChar );

			return mActiveChar;
		}

	}


}
