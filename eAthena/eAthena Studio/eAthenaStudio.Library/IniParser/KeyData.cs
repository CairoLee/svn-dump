using System;
using System.Collections.Generic;

namespace eAthenaStudio.Library.IniParser {

	public class KeyData : ICloneable {
		private List<string> mComments;
		private string mValue;
		private string mKeyName;

		public List<string> Comments {
			get { return mComments; }
			set { mComments = new List<string>(value); }
		}

		public string Value {
			get { return mValue; }
			set { mValue = value; }
		}

		public string KeyName {
			get { return mKeyName; }

			set {
				if (value != string.Empty)
					mKeyName = value;
			}

		}


		public KeyData(string keyName) {
			mComments = new List<string>();
			mValue = string.Empty;
			mKeyName = keyName;
		}

		public KeyData(KeyData ori) {
			mValue = ori.mValue;
			mComments = new List<string>(mComments);
		}


		public object Clone() {
			return new KeyData(this);
		}

	}

}