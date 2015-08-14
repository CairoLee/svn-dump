using System;
using System.Collections.Generic;

namespace eAthenaStudio.Library.IniParser {

	public class SectionData : ICloneable {
		private List<string> mComments;
		private KeyDataCollection mKeyDataCollection;
		private string mSectionName;

		public string SectionName {
			get { return mSectionName; }
			set {
				if (value != string.Empty)
					mSectionName = value;
			}
		}

		public List<string> Comments {
			get { return mComments; }
			set { mComments = new List<string>(value); }
		}

		public KeyDataCollection Keys {
			get { return mKeyDataCollection; }
			set { mKeyDataCollection = value; }
		}


		public SectionData(string sectionName) {
			mComments = new List<string>();
			mKeyDataCollection = new KeyDataCollection();
			SectionName = sectionName;
		}

		public SectionData(SectionData ori) {
			mComments = new List<string>(ori.mComments);
			mKeyDataCollection = new KeyDataCollection(ori.mKeyDataCollection);
		}


		public object Clone() {
			return new SectionData(this);
		}

	}

}