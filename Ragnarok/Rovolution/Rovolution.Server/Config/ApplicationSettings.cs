using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using GodLesZ.Library;

namespace Rovolution.Server {

	public class ApplicationSettings {
		private static Properties.Settings mMainSettings;
		private static PrivateSettings mPrivateSettings;

		public string ConfigDir {
			get;
			internal set;
		}

		public PrivateSettingFile this[ESettingType FileType] {
			get { return mPrivateSettings[FileType]; }
		}


		public PrivateSettingFile Connection {
			get { return this[ESettingType.Connection]; }
		}

		public PrivateSettingFile Maplist {
			get { return this[ESettingType.Maplist]; }
		}

		public PrivateSettingFile General {
			get { return this[ESettingType.General]; }
		}



		public ApplicationSettings() {
			if (mMainSettings != null || mPrivateSettings != null) {
				return;
			}

			mMainSettings = new Properties.Settings();
			mPrivateSettings = new PrivateSettings();
			mPrivateSettings.MainDir = mMainSettings.MainConfDir;
		}

		public void ReadAll() {
			int count = 0;
			ServerConsole.StatusLine("Loading Configuration Files...");

			System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
			string MainDir = AppDomain.CurrentDomain.BaseDirectory;
			ConfigDir = Path.Combine(MainDir, mPrivateSettings.MainDir);
			if (Directory.Exists(ConfigDir) == false) {
				ServerConsole.ErrorLine("Configuration Directory not found!");
				ServerConsole.ErrorLine("# used Main Dir: " + MainDir);
				ServerConsole.ErrorLine("# used Conf Dir: " + mPrivateSettings.MainDir);
				ServerConsole.ErrorLine("# searched in Dir: " + ConfigDir);
				watch.Stop();
				return;
			}

			XmlSerializer xml = new XmlSerializer(typeof(PrivateSettingFileSerializeable));
			PrivateSettingFileSerializeable tempFile;
			List<string> dirFiles = new List<string>();

			// Search for our extension (".cnfx")
			dirFiles.AddRange(Directory.GetFiles(ConfigDir, "*.cnfx", SearchOption.AllDirectories));

			// Iterate and parse them
			foreach (string fileName in dirFiles) {
				using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
					tempFile = xml.Deserialize(fs) as PrivateSettingFileSerializeable;
					mPrivateSettings.Add(tempFile.ToNonSerializeable());

					ServerConsole.StatusLine(" # {0}: `{1}` ...", ++count, tempFile.FileName);
				}
			}

			ServerConsole.Status("Done Reading {0} Configs!", mPrivateSettings.Count);
			ServerConsole.WriteLine(EConsoleColor.Status, " Needed {0:F2} sec", watch.Elapsed.TotalSeconds);

			watch.Stop();
		}

	}


	public class PrivateSettings {
		public string MainDir;

		public Dictionary<ESettingType, PrivateSettingFile> Files;

		public int Count {
			get { return Files.Count; }
		}

		public PrivateSettingFile this[ESettingType FileType] {
			get { return Get(FileType); }
			set { Add(value); }
		}

		public PrivateSettings() {
			Files = new Dictionary<ESettingType, PrivateSettingFile>();
		}

		public PrivateSettings(string mainDir, Dictionary<ESettingType, PrivateSettingFile> files) {
			MainDir = mainDir;
			Files = files;
		}


		public PrivateSettingFile Get(ESettingType Type) {
			if (Files.ContainsKey(Type) == true)
				return Files[Type];
			return null;
		}

		public void Add(ESettingType Key, PrivateSettingFile Value) {
			if (Files.ContainsKey(Key) == true)
				return;
			Files.Add(Key, Value);
		}

		public void Add(PrivateSettingFile Value) {
			Add(Value.FileType, Value);
		}

	}

	public class PrivateSettingFile {
		public string FileName;
		public ESettingType FileType;

		public Dictionary<string, string> Settings;

		public string this[string Key] {
			get { return GetString(Key); }
			set { Add(Key, value); }
		}

		public int Count {
			get { return Settings.Count; }
		}



		public PrivateSettingFile() {
			Settings = new Dictionary<string, string>();
		}

		public PrivateSettingFile(string fileName, ESettingType fileType, Dictionary<string, string> settings) {
			FileName = fileName;
			FileType = fileType;
			Settings = settings;
		}



		public string GetString(string Key) {
			if (Settings.ContainsKey(Key) == true)
				return Settings[Key];
			return string.Empty;
		}

		public int GetInt(string Key) {
			if (Settings.ContainsKey(Key) == true) {
				int ret;
				if (int.TryParse(Settings[Key], out ret) == true)
					return ret;
				return 0;
			}
			return 0;
		}


		public void Add(string Key, string Value) {
			if (Settings.ContainsKey(Key) == true)
				return;
			Settings.Add(Key, Value);
		}

	}

	#region [Serializable]
	[Serializable]
	public enum ESettingType {
		Connection = 1,

		Maplist,
		General,
	}

	[Serializable]
	public class PrivateSettingFileSerializeable {
		[XmlElement("FileName")]
		public string FileName;

		[XmlElement("FileType")]
		public ESettingType FileType;

		[XmlArray("Settings")]
		[XmlArrayItem("Setting")]
		public List<PrivateSettingFileSetting> Settings;

		/// <summary>
		/// searchs all Settings and returns/sets the Value if found
		/// </summary>
		/// <param name="Key"></param>
		/// <returns></returns>
		[XmlIgnore]
		public string this[string Key] {
			get {
				for (int i = 0; i < Settings.Count; i++)
					if (Settings[i].Key == Key)
						return Settings[i].Value;
				return String.Empty;
			}
			set {
				int i;
				for (i = 0; i < Settings.Count; i++)
					if (Settings[i].Key == Key) {
						Settings[i].Value = value;
						break;
					}
				if (i >= Settings.Count)
					throw new Exception("Setting not found!");
			}
		}

		public PrivateSettingFileSerializeable() {
		}

		public PrivateSettingFileSerializeable(string fileName, ESettingType fileType, List<PrivateSettingFileSetting> settings) {
			FileName = fileName;
			FileType = fileType;
			Settings = settings;
		}


		public PrivateSettingFile ToNonSerializeable() {
			PrivateSettingFile newFile = new PrivateSettingFile();
			newFile.FileName = this.FileName;
			newFile.FileType = this.FileType;
			foreach (PrivateSettingFileSetting Pair in this.Settings) {
				newFile.Add(Pair.Key, Pair.Value);
			}

			return newFile;
		}
	}

	public class PrivateSettingFileSetting {
		[XmlAttribute("Name")]
		public string Key;
		[XmlAttribute("Value")]
		public string Value;

		public PrivateSettingFileSetting() {
		}
		public PrivateSettingFileSetting(string key, string value) {
			Key = key;
			Value = value;
		}
	}
	#endregion

}
