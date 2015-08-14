using System;
using System.Collections;
using System.Collections.Generic;

namespace eAthenaStudio.Library.IniParser {

	public class KeyDataCollection : ICloneable, IEnumerable<KeyData> {
		private readonly Dictionary<string, KeyData> mKeyData;

		public KeyData this[string keyName] {
			get {
				if (mKeyData.ContainsKey(keyName))
					return mKeyData[keyName];
				if (mKeyData.ContainsKey("Plugin - " + keyName))
					return mKeyData["Plugin - " + keyName];
				return null;
			}
			set {
				if (mKeyData.ContainsKey(keyName))
					mKeyData[keyName] = value;
				else if (mKeyData.ContainsKey(keyName))
					mKeyData["Plugin - " + keyName] = value;
			}
		}

		public int Count {
			get { return mKeyData.Count; }
		}


		public KeyDataCollection() {
			mKeyData = new Dictionary<string, KeyData>();
		}

		public KeyDataCollection(KeyDataCollection ori) {
			mKeyData = new Dictionary<string, KeyData>();
			foreach (string key in mKeyData.Keys)
				mKeyData.Add(key, (KeyData)ori.mKeyData[key].Clone());
		}


		public bool AddKey(string keyName) {
			if (!mKeyData.ContainsKey(keyName)) {
				mKeyData.Add(keyName, new KeyData(keyName));
				return true;
			}

			return false;
		}

		public bool AddKey(string keyName, KeyData keyData) {
			if (AddKey(keyName)) {
				mKeyData[keyName] = keyData;
				return true;
			}
			return false;
		}

		public bool AddKey(string keyName, string keyValue) {
			if (AddKey(keyName)) {
				mKeyData[keyName].Value = keyValue;
				return true;
			}
			return false;
		}

		public KeyData GetKeyData(string keyName) {
			if (mKeyData.ContainsKey(keyName))
				return mKeyData[keyName];
			return null;
		}

		public void SetKeyData(KeyData data) {
			if (data == null)
				return;
			if (mKeyData.ContainsKey(data.KeyName))
				RemoveKey(data.KeyName);

			AddKey(data.KeyName, data);
		}

		public bool ContainsKey(string keyName) {
			return mKeyData.ContainsKey(keyName);
		}

		public bool RemoveKey(string keyName) {
			return mKeyData.Remove(keyName);
		}



		public IEnumerator<KeyData> GetEnumerator() {
			foreach (string key in mKeyData.Keys)
				yield return mKeyData[key];
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return mKeyData.GetEnumerator();
		}


		public object Clone() {
			return new KeyDataCollection(this);
		}

	}

}