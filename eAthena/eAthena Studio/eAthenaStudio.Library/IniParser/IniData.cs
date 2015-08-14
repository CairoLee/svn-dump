using System;

namespace eAthenaStudio.Library.IniParser {

	public class IniData : ICloneable {
		private SectionDataCollection mSections;

		public KeyDataCollection this[string sectionName] {
			get {
				if (mSections.ContainsSection(sectionName))
					return mSections[sectionName];
				else if (mSections.ContainsSection("Plugin - " + sectionName))
					return mSections["Plugin - " + sectionName];
				return null;
			}

		}

		public SectionDataCollection Sections {
			get { return mSections; }
			set { mSections = value; }
		}


		public IniData() {
			mSections = new SectionDataCollection();
		}

		public IniData(SectionDataCollection sdc) {
			mSections = (SectionDataCollection)sdc.Clone();
		}


		public object Clone() {
			return new IniData(Sections);
		}

	}

}