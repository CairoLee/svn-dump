using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
namespace a
{
	public class K1
	{
		public class UserSettings
		{
			public List<string> RecentFiles = new List<string>();
			public List<string> WorkingFiles = new List<string>();
			public string DefaultAuthorName = ("" + Environment.UserName).Trim();
			public string RecentProjectPath = K1.B;
			public string RecentPicturePath = K1.B;
			public bool AllowMultipleProjects;
			public bool TextEditDialogLineBreakSwitch;
			public G2 PapToolBarPlacement;
			public bool KeepBackupFiles;
			public bool AllowMultipleTutorials;
			public bool PreferredSymbolLanguageEnglish;
			public bool SuppressConfigStorageOnce;
			public bool SmartConnectionDClick = true;
			public bool DoubleClickAction;
			public bool FollowModuleLinkOnClick = true;
			public bool SuppressProjectProtectionSwitch;
			public bool ToolCursorExitOnLeave;
			public bool SeparatePrintPageScaling;
			public bool UseNarrowTextFont;
			public int ToolTipAutoPopDelay = 6000;
			public int ToolTipInitialDelay = 300;
			public int ToolTipReshowDelay = 100;
		}
		public class ConfigSettings
		{
			public string AppKey = "VOID";
			public bool ConfigFileReadOnly;
			public bool LoadUserConfigData = true;
			public bool StoreUserConfigData = true;
			public bool SuppressTutorialTip;
			public bool EnableProjectProtection;
			public bool EnableDiagramCheck;
			public K1.UserSettings UserSettings = new K1.UserSettings();
		}
		[CompilerGenerated]
		private sealed class A
		{
			public string A;
			public bool A(string text)
			{
				return text.ToLower() == this.A.ToLower();
			}
		}
		[CompilerGenerated]
		private sealed class a
		{
			public string A;
			public bool A(string text)
			{
				return text.ToLower() == this.A.ToLower();
			}
		}
		[CompilerGenerated]
		private sealed class B
		{
			public string A;
			public bool A(string text)
			{
				return text.ToLower() == this.A.ToLower();
			}
		}
		private const int A = 3;
		private static K1 A = null;
		private K1.ConfigSettings A;
		private static string A = Environment.OSVersion.VersionString;
		private static bool A = K1.A.ToLower().Contains("windows");
		private static string a = null;
		private static string B = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		private static bool a = false;
		private static string b = null;
		public static K1 A()
		{
			if (K1.A == null)
			{
				K1.A = new K1();
			}
			return K1.A;
		}
		private K1()
		{
			this.b();
		}
		~K1()
		{
			this.C();
		}
		public static bool A()
		{
			return K1.A;
		}
		public static string A()
		{
			if (K1.a == null)
			{
				K1.a = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
				if (!K1.A().ToLower().EndsWith(".exe"))
				{
					throw new l1();
				}
			}
			return K1.a;
		}
		public K1.UserSettings A()
		{
			return this.A.UserSettings;
		}
		private void A(K1.UserSettings userSettings)
		{
			this.A.UserSettings = userSettings;
		}
		public K1.ConfigSettings A()
		{
			return this.A;
		}
		public bool a()
		{
			return K1.a;
		}
		public string a()
		{
			return K1.b;
		}
		public void A()
		{
			this.A().RecentFiles.Clear();
		}
		public void A(string text)
		{
			K1.b(text);
			this.a(text);
			this.A().RecentFiles.Insert(0, text);
			while (this.A().RecentFiles.Count > 3)
			{
				this.A().RecentFiles.RemoveAt(this.A().RecentFiles.Count - 1);
			}
		}
		public void a(string text)
		{
			K1.A a = new K1.A();
			a.A = text;
			this.A().RecentFiles.RemoveAll(new Predicate<string>(a.A));
		}
		public string[] A()
		{
			K1.A(this.A().RecentFiles);
			return this.A().RecentFiles.ToArray();
		}
		public void B(string text)
		{
			K1.a a = new K1.a();
			a.A = text;
			this.A().WorkingFiles.RemoveAll(new Predicate<string>(a.A));
			this.A().WorkingFiles.Insert(0, a.A);
		}
		public void a()
		{
			this.A().WorkingFiles.Clear();
		}
		public string[] A(bool flag)
		{
			K1.A(this.A().WorkingFiles);
			string[] result = this.A().WorkingFiles.ToArray();
			if (flag)
			{
				this.a();
			}
			return result;
		}
		public void B()
		{
			this.A(new K1.UserSettings());
		}
		public static bool A(bool flag)
		{
			return K1.A(".pap", flag, out K1.b) && K1.A(".pap-backup", flag, out K1.b);
		}
		public static bool A(string text, bool flag, out string ptr)
		{
			ptr = null;
			if (!text.StartsWith("."))
			{
				text = "." + text;
			}
			string text2 = text.Substring(1) + "_auto_file";
			RegistryKey classesRoot = Registry.ClassesRoot;
			if (flag)
			{
				bool result = true;
				try
				{
					classesRoot.DeleteSubKeyTree(text);
				}
				catch (Exception)
				{
					result = false;
				}
				try
				{
					classesRoot.DeleteSubKeyTree(text2);
				}
				catch (Exception)
				{
					result = false;
				}
				K1.a = false;
				return result;
			}
			string text3 = text2;
			if (!K1.A(classesRoot, text, "", ref text3))
			{
				return false;
			}
			string text4 = " \"%1\"";
			string text5 = K1.A() + text4;
			if (!K1.A(classesRoot, text2 + "\\shell\\open\\command", "", ref text5))
			{
				ptr = text5.Replace(text4, "");
				return false;
			}
			K1.a = true;
			return true;
		}
		public static string B()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			text = Path.Combine(text, j1.a());
			Directory.CreateDirectory(text);
			return text;
		}
		private static bool A(RegistryKey registryKey, string text, string name, ref string ptr)
		{
			string text2 = null;
			try
			{
				RegistryKey registryKey2 = registryKey.OpenSubKey(text);
				if (registryKey2 != null)
				{
					text2 = (string)registryKey2.GetValue(name);
				}
				if (ptr.Equals(text2))
				{
					bool result = true;
					return result;
				}
				registryKey2 = registryKey.CreateSubKey(text);
				registryKey2.SetValue(name, ptr, RegistryValueKind.String);
				if (ptr.Equals(registryKey2.GetValue(name)))
				{
					bool result = true;
					return result;
				}
			}
			catch (Exception)
			{
			}
			ptr = text2;
			return false;
		}
		private void b()
		{
			string text = K1.b();
			try
			{
				FileInfo fileInfo = new FileInfo(text);
				using (TextReader textReader = new StreamReader(text))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(K1.ConfigSettings));
					K1.ConfigSettings configSettings = (K1.ConfigSettings)xmlSerializer.Deserialize(textReader);
					if (configSettings.AppKey != j1.A())
					{
						throw new l1();
					}
					if (!configSettings.LoadUserConfigData)
					{
						this.A.UserSettings = new K1.UserSettings();
					}
					textReader.Close();
					this.A = configSettings;
				}
				if (fileInfo.IsReadOnly)
				{
					this.A.ConfigFileReadOnly = true;
				}
			}
			catch (Exception)
			{
				this.A = new K1.ConfigSettings();
				this.A.AppKey = j1.A();
			}
		}
		private void C()
		{
			if (this.A.ConfigFileReadOnly)
			{
				return;
			}
			string text = K1.b();
			try
			{
				FileInfo fileInfo = new FileInfo(text);
				fileInfo.Directory.Create();
				using (TextWriter textWriter = new StreamWriter(text))
				{
					if (!this.A.StoreUserConfigData || this.A.UserSettings.SuppressConfigStorageOnce)
					{
						this.A.UserSettings = new K1.UserSettings();
					}
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(K1.ConfigSettings));
					xmlSerializer.Serialize(textWriter, this.A);
				}
			}
			catch (Exception)
			{
			}
		}
		private static string b()
		{
			string path = K1.B();
			return Path.Combine(path, j1.a() + ".config");
		}
		private static void b(string text)
		{
			if (text == null)
			{
				throw new ArgumentException("File name is 'null'");
			}
			if (text.Trim() != text)
			{
				throw new ArgumentException("File name is framed with spaces");
			}
			if (!Path.IsPathRooted(text))
			{
				throw new ArgumentException("File is not rooted");
			}
		}
		private static void A(List<string> list)
		{
			Predicate<string> predicate = null;
			K1.B b = new K1.B();
			string[] array = list.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				b.A = array[i];
				if (!File.Exists(b.A))
				{
					if (predicate == null)
					{
						predicate = new Predicate<string>(b.A);
					}
					list.RemoveAll(predicate);
				}
			}
		}
	}
	public class k1
	{
		public const int A = 64;
		public const int a = 1024;
		public const int B = 180;
		public const string A = ".pap";
		public const string a = ".temp";
		public const string B = ".pap-backup";
		public const string b = "yyyy.MM.dd HH:mm:ss";
		public const string C = "dd.MM.yy HH:mm";
		public const string c = "dd.MM.yy";
		public static readonly Size A = new Size(12000, 12000);
		public static readonly Point A = new Point(k1.A.Width / 2, k1.A.Height / 4);
		public static readonly Size a = new Size(30, 63);
		public static readonly string D = string.Format("{0} Projekte (*{1})|*{1};*{2}", j1.a(), ".pap", ".pap-backup");
		public static readonly string d = string.Format("{0} Projekte (*{1})|*{1}", j1.a(), ".pap");
		public static readonly Color A = Color.LightPink;
	}
}
