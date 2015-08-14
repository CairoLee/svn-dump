using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ZenAIConfigPanel.Library {

	public class HomuModHandler {
		public const string SelectedModFileName = "SelectedMod.lua";

		private static string mModDir;
		private static List<string> mMods;
		private static int mSelectedMod = -1;

		public static string ModDir {
			get { return mModDir; }
		}

		public static List<string> Mods {
			get { return mMods; }
		}

		public static int SelectedMod {
			get { return mSelectedMod; }
			set { mSelectedMod = value; }
		}


		public static void Initialize(string FromDir) {
			mModDir = FromDir;
			mMods = new List<string>();

			ReadMods();
			ReadSelectedMod();
		}

		public static string GetModContent() {
			return File.ReadAllText(Path.Combine(mModDir, mMods[mSelectedMod]), ASCIIEncoding.Default);
		}

		public static void SaveModContent(string Content) {
			File.WriteAllText(Path.Combine(mModDir, mMods[mSelectedMod]), Content, ASCIIEncoding.Default);
		}

		public static void SaveSelectedMod() {
			string selectedModPath = Path.Combine(mModDir, SelectedModFileName);
			if (File.Exists(selectedModPath) == true)
				try { File.Delete(selectedModPath); } catch { }

			using (StreamWriter file = new StreamWriter(File.OpenWrite(selectedModPath), ASCIIEncoding.Default)) {
				file.WriteLine("-- Please choose your Homunculus mod here");
				file.WriteLine("-- [created with GodLesZ " + frmMain.APP_VERSION + "]");
				if (SelectedMod != -1)
					file.WriteLine("require \"./AI/USER_AI/" + Mods[SelectedMod] + "\";");
			}
		}


		private static void ReadMods() {
			string[] mods = Directory.GetFiles(ModDir, "*_Mod.lua");
			for (int i = 0; i < mods.Length; i++) {
				string modName = Path.GetFileName(mods[i]);
				mMods.Add(modName);
			}

		}

		private static void ReadSelectedMod() {
			string selectedModPath = Path.Combine(ModDir, SelectedModFileName);
			if (File.Exists(selectedModPath) == false)
				return;

			string[] lines = File.ReadAllLines(selectedModPath);
			for (int i = 0; i < lines.Length; i++) {
				string line = lines[i].Trim();
				// kill comments
				if (line.Length < 2 || line.StartsWith("--"))
					continue;
				if (line.Contains("--"))
					line = lines[i].Substring(0, lines[i].IndexOf("--")).Trim();
				if (line.StartsWith("require", StringComparison.OrdinalIgnoreCase) == false)
					continue;

				Match m = Regex.Match(line, "^require[ \t]*\"([^\"]*)\"", RegexOptions.IgnoreCase);
				if (m.Groups.Count < 2)
					continue; // should never happen?

				string selectedModName = m.Groups[1].Value;
				selectedModName = Path.GetFileName(selectedModName);
				int modPos = Mods.IndexOf(selectedModName);
				if (modPos == -1)
					return; // invalid/non-existing Mod selected.. error?

				SelectedMod = modPos;
			}
		}

	}

}
