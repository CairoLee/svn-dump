using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseEditor.Library.Classes {

	public class DatabaseMobDrop {
		private int mID;
		private int mChance;

		public int ID {
			get { return mID; }
			set { mID = value; }
		}

		public int Chance {
			get { return mChance; }
			set { mChance = value; }
		}


		public DatabaseMobDrop() {
		}

		public DatabaseMobDrop( int id, int chance ) {
			mID = id;
			mChance = chance;
		}


		public string ChanceToFloat() {
			return string.Format( "{0:00.00}", (float)mChance / 100f );
		}

		public override string ToString() {
			return string.Format( "{0} @ {1}%", mID, ChanceToFloat() );
		}

	}

}
