using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Extended.Server.Objects {

	public class Character : SerialObject {
		private Account mParent = null;
		private string mName = string.Empty;

		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		public Account Parent {
			get { return mParent; }
		}



		public Character( Account Parent, int ID, string Name ) {
			mParent = Parent;
			Serial = Serial.NewChar;
			mName = Name;
		}

	}


}
