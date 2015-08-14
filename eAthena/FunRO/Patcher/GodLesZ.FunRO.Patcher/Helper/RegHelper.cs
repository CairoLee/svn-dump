using System;
using Microsoft.Win32;

namespace GodLesZ.FunRO.Patcher {

	public class RegHelper {

		public RegistryKey Regkey {
			get;
			private set;
		}

		public bool FirstRun {
			get;
			private set;
		}


		public RegHelper() {

		}


		public bool Initialize() {
			try {
				Regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\FunRO\\Patcher", true);
				if (Regkey == null) {
					// Failed to open, try create it
					Regkey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\FunRO\\Patcher");
					// So this is our first run
					FirstRun = true;
				}

				// Test registry access for read and write
				if (TestRegistry() == false) {
					return false;
				}
			} catch {
				return false;
			}

			return true;
		}

		public void PatchReset(int PatchResetID) {
			Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\FunRO\\Patcher");
			Initialize();

			if (PatchResetID != 0) {
				SavePatch(PatchResetID);
			}
		}

		public bool SearchPatcherUpdates() {
			string patcherUpdate = (string)GetValue("LastPatcherUpdate", "");
			string now = DateTime.Now.ToString("yyyy-MM-dd");
			if (patcherUpdate != now) {
				return true;
			}

			return false;
		}

		public void SetLastPatcherUpdate() {
			WriteValue("LastPatcherUpdate", DateTime.Now.ToString("yyyy-MM-dd"));
		}


		public bool Close() {
			try {
				Regkey.Close();
			} catch {
				return false;
			}
			return true;
		}



		public bool SavePatch(int PatchID) {
			return WriteValue("Patch_" + PatchID, 1);
		}

		public bool HasPatch(int PatchID) {
			return ((int)GetValue("Patch_" + PatchID) != 0);
		}

		public bool WriteValue(string Keyname, object value) {
			if (Regkey == null)
				return false;

			try {
				Regkey.SetValue(Keyname, value);
				return true;
			} catch {
				return false;
			}
		}

		public object GetValue(string keyname) {
			return GetValue(keyname, 0);
		}

		public object GetValue(string keyname, object defaultValue) {
			object obj = 0;
			if (Regkey == null)
				return obj;

			try {
				obj = Regkey.GetValue(keyname);
				if (obj == null) // nah... write it
					throw new Exception();
			} catch {
				WriteValue(keyname, defaultValue);
				return GetValue(keyname);
			}

			return obj;
		}


		private bool TestRegistry() {
			try {
				Regkey.SetValue("TestKey", "1");
				string testKey = (string)Regkey.GetValue("TestKey");
				if (testKey != "1") {
					return false;
				}

				Regkey.DeleteSubKey("TestKey", false);
			} catch {
				return false;
			}
			return true;
		}

	}

}
