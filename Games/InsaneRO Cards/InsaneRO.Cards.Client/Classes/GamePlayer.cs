using System;
using System.Collections.Generic;
using System.Text;
using InsaneRO.Cards.Library;
using System.Data;
using System.Linq;

namespace InsaneRO.Cards.Client.Classes {

	public class GamePlayer : Player {
		private int mUserID;
		private string mEmail;
		private string mDisplayname;
		private int mGroupID;
		private string mGroupName;
		private int mLevel;

		public int UserID {
			get { return mUserID; }
		}

		public string Email {
			get { return mEmail; }
		}

		public string Displayname {
			get { return mDisplayname; }
		}

		public int GroupID {
			get { return mGroupID; }
		}

		public string GroupName {
			get { return mGroupName; }
		}

		public int Level {
			get { return mLevel; }
		}



		public GamePlayer(DataRow row)
			: base(row.Field<string>("username"), 10) {

			mUserID = row.Field<int>("userID");
			mEmail = row.Field<string>("email");
			mDisplayname = row.Field<string>("name");
			mGroupID = row.Field<int>("groupID");
			mGroupName = row.Field<string>("groupName");
			mLevel = row.Field<int>("level");
		}

	}

}
