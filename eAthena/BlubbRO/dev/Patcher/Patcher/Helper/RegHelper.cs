using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace GodLesZ.BlubbRO.Patcher {

	public class RegHelper {
		public static RegistryKey Regkey;


		public static bool Initialize() {
			try {
				Regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\BlubbRO\\Patcher", true);
				if (Regkey == null) {
					// failed to open, try create it
					Regkey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\BlubbRO\\Patcher");
					if (TestRegistry() == false) {
						return false;
					}
				}
			} catch {
				return false;
			}

			return true;
		}

		public static void PatchReset(int PatchResetID) {
			Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\BlubbRO\\Patcher");
			Initialize();

			if (PatchResetID != 0) {
				SavePatch(PatchResetID);
			}
		}


		private static bool TestRegistry() {
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


		public static bool Close() {
			try {
				Regkey.Close();
			} catch {
				return false;
			}
			return true;
		}



		public static bool SavePatch(int PatchID) {
			return WriteValue("Patch_" + PatchID, 1);
		}

		public static bool HasPatch(int PatchID) {
			return ((int)GetValue("Patch_" + PatchID) != 0);
		}

		public static bool WriteValue(string Keyname, int value) {
			if (Regkey == null)
				return false;

			try {
				Regkey.SetValue(Keyname, value);
				return true;
			} catch {
				return false;
			}
		}

		public static bool WriteValue(string Keyname, uint value) {
			if (Regkey == null)
				return false;

			try {
				Regkey.SetValue(Keyname, value);
				return true;
			} catch {
				return false;
			}
		}

		public static object GetValue(string Keyname) {
			object obj = 0;
			if (Regkey == null)
				return obj;

			try {
				obj = Regkey.GetValue(Keyname);
				if (obj == null) // nah... write it
					throw new Exception();
			} catch {
				WriteValue(Keyname, 0);
				return GetValue(Keyname);
			}

			return obj;
		}

	}

}
