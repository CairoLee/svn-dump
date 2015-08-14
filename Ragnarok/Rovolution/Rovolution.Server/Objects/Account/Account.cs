using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Network;
using GodLesZ.Library;
using System.Data;

namespace Rovolution.Server.Objects {

	public class Account : WorldObject {
		private static Random mLoginRandomizer = new Random();

		private int mNetstateID = -1;
		private int mActiveChar = -1;
		private DualDictionary<DatabaseID, Character> mChars = new DualDictionary<DatabaseID, Character>();


		public NetState Netstate {
			get {
				if (NetState.Instances.ContainsKey(mNetstateID) == false) {
					throw new Exception("Unknown netstateID! " + mNetstateID);
				}
				return NetState.Instances[mNetstateID];
			}
			internal set {
				if (!(value is NetState)) {
					throw new Exception("Netstate object cant be null!");
				}
				mNetstateID = value.InstanceID;
				if (mNetstateID != -1) {
					NetState.Instances[mNetstateID].Account = this;
				}
			}
		}

		public int LoginID1 {
			get;
			private set;
		}

		public int LoginID2 {
			get;
			private set;
		}

		public string Name {
			get;
			internal set;
		}

		public string Password {
			get;
			internal set;
		}

		public EAccountSex Sex {
			get;
			internal set;
		}

		public string Email {
			get;
			internal set;
		}

		public int GMLevel {
			get;
			internal set;
		}

		public string LastIP {
			get;
			internal set;
		}

		public DateTime LastLogin {
			get;
			internal set;
		}

		public DualDictionary<WorldID, Character> Chars {
			get;
			internal set;
		}

		public Character this[DatabaseID Key] {
			get { return mChars[Key]; }
			internal set { mChars[Key] = value; }
		}

		public Character ActiveChar {
			get {
				if (mActiveChar == -1) {
					return null;
				}
				return GetCharacter(mActiveChar);
			}
		}


		public EAccountState AccountState {
			get;
			set;
		}


		public Account(bool addToWorld)
			: base(DatabaseID.Zero, addToWorld) {
			Chars = new DualDictionary<WorldID, Character>();
			AccountState = EAccountState.None;
		}


		/// <summary>
		/// Try to load a specific account from the database, including all characters
		/// </summary>
		/// <param name="State"></param>
		/// <param name="Name"></param>
		/// <param name="Password"></param>
		/// <param name="Acc"></param>
		/// <returns>EAccountLoadResult</returns>
		public static EAccountLoadResult Load(NetState State, string Name, string Password, out Account Acc) {
			return Load(State, Name, Password, out Acc, true);
		}

		/// <summary>
		/// Try to load a specific account from the database
		/// </summary>
		/// <param name="state"></param>
		/// <param name="Name"></param>
		/// <param name="Password"></param>
		/// <param name="Acc"></param>
		/// <returns>EAccountLoadResult</returns>
		public static EAccountLoadResult Load(NetState state, string Name, string Password, out Account Acc, bool loadChars) {
			// Lookup on object manager
			if ((Acc = World.Objects.SearchAccount(Name)) != null) {
				if (loadChars == true) {
					Acc.LoadChars();
				}
				Acc.Netstate = state;
				return EAccountLoadResult.Success;
			}

			// Not found, load from Database
			Acc = new Account(true); // auto-push to world
			Acc.Netstate = state;
			DataTable table = Core.Database.Query("SELECT a.*, COUNT(*) AS charCount FROM account AS a LEFT JOIN `char` AS c ON c.accountID = a.accountID WHERE a.username = '{0}' LIMIT 0,1", Name.MysqlEscape());
			table.TableName = "Account Table";
			if (table.Rows.Count == 0) {
				return EAccountLoadResult.UnregisteredID;
			}

			DataRow accRow = table.Rows[0];

			// Password check
			if (accRow.Field<string>("password") != Password) {
				Acc = null;
				return EAccountLoadResult.IncorrectPassword;
			}
			Rovolution.Server.Database.RovolutionDatabase.PrintTableTypes(accRow.Table);
			// Enfore a serial value equal to the account ID
			// Assumes our Account creation script wont take a same ID twice
			Acc.WorldID = new WorldID(accRow.Field<uint>("accountID"), EDatabaseType.Account);
			Acc.Name = accRow.Field<string>("username");
			Acc.Password = accRow.Field<string>("password");
			Acc.Sex = (accRow.Field<string>("sex").ToLower() == "m" ? EAccountSex.Male : EAccountSex.Female);
			Acc.Email = accRow.Field<string>("email");
			Acc.GMLevel = accRow.FieldNull<sbyte>("gmLevel");
			Acc.LastIP = accRow.Field<string>("lastIP");
			Acc.LastLogin = accRow.FieldDateTime("lastLogin");
			Acc.LoginID1 = mLoginRandomizer.Next() + 1;
			Acc.LoginID2 = mLoginRandomizer.Next() + 1;
			// `accountState`, `unbanTime`, `expirationTime`, `loginCount`, `birthDate`
			if (loadChars == true) {
				Acc.LoadChars();
			}

			return EAccountLoadResult.Success;
		}


		public void UpdateLastLogin(string lastIP) {
			// Updates the database last_login and last_ip fields
			Core.Database.QuerySimple("UPDATE account SET lastLogin = NOW(), lastIP = '{0}' WHERE accountID = {1}", lastIP, WorldID.ID);
		}

		public void LoadChars() {

			// Load all chars
			DataTable table = Core.Database.Query("SELECT * FROM `char` WHERE accountID = {0}", WorldID.ID);
			table.TableName = "Char Table";
			if (table.Rows.Count == 0) {
				return;
			}

			// Already loaded?
			if (Chars.Count == table.Rows.Count) {
				return;
			}

			Character c;
			foreach (DataRow row in table.Rows) {
				c = Character.Load(this, row);
				Chars.Add(c.WorldID, c);
			}
		}


		public Character SetActiveChar(int slot) {
			// Remove prev char from world
			if (ActiveChar != null) {
				ActiveChar.Delete();
			}

			mActiveChar = slot;
			if (ActiveChar != null) {
				// We have an active character, load full data
				ActiveChar.LoadFull();
				// Push it
				World.Objects.Add(ActiveChar);
			}

			return ActiveChar;
		}


		public bool HasSlot(int slot) {
			return (GetCharacter(slot) != null);
		}

		public Character GetCharacter(int slot) {
			// TODO: we should sort characters by slot, so we may access them faster
			if (Chars.Count == 0) {
				return null;
			}

			foreach (Character c in Chars.Values) {
				if (c.Status.Slot == slot) {
					return c;
				}
			}

			return null;
		}

	}


}
