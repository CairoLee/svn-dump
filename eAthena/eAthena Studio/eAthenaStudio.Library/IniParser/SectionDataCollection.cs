using System;
using System.Collections;
using System.Collections.Generic;

namespace eAthenaStudio.Library.IniParser {

	public class SectionDataCollection : ICloneable, IEnumerable<SectionData> {
		private readonly Dictionary<string, SectionData> mSectionData;

		public int Count {
			get { return mSectionData.Count; }
		}

		public KeyDataCollection this[string sectionName] {
			get {
				if (mSectionData.ContainsKey(sectionName))
					return mSectionData[sectionName].Keys;
				return null;
			}
		}


		public SectionDataCollection() {
			mSectionData = new Dictionary<string, SectionData>();
		}

		public SectionDataCollection(SectionDataCollection ori) {
			mSectionData = new Dictionary<string, SectionData>(ori.mSectionData);
		}


		public bool AddSection(string keyName) {
			if (!ContainsSection(keyName)) {
				mSectionData.Add(keyName, new SectionData(keyName));
				return true;
			}

			return false;
		}

		public bool ContainsSection(string keyName) {
			return mSectionData.ContainsKey(keyName);
		}

		public SectionData GetSectionData(string sectionName) {
			if (mSectionData.ContainsKey(sectionName))
				return mSectionData[sectionName];
			return null;
		}


		public void SetSectionData(string sectionName, SectionData data) {
			if (data != null)
				mSectionData[sectionName] = data;
		}

		public bool RemoveSection(string keyName) {
			return mSectionData.Remove(keyName);
		}

		public void Clear() {
			mSectionData.Clear();
		}


		public IEnumerator<SectionData> GetEnumerator() {
			foreach (string sectionName in mSectionData.Keys)
				yield return mSectionData[sectionName];
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}


		public object Clone() {
			return new SectionDataCollection(this);
		}

	}

}