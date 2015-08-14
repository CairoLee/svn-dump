using System;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using GodLesZ.Library;
using GodLesZ.SiedlerOnline.TradeListener.Language;
using GodLesZ.SiedlerOnline.TradeListener.Library.Language;

namespace GodLesZ.SiedlerOnline.TradeListener {

	public static class Program {

		public static LocaleHelper Language {
			get;
			private set;
		}


		[STAThread]
		public static void Main() {
			// Only 1 proc
			// @TODO: User may rename the application file
			Process[] procs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
			if (procs.Length > 1) {
				MessageBox.Show("An instance of the application is already runing.", "Application load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// Close
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			LoadLanguage();

			Application.Run(new frmMain());
		}


		public static void LoadLanguage() {
			LoadLanguage(null);
		}

		public static void LoadLanguage(Form parent) {
			LoadLanguage(parent, false);
		}

		public static void LoadLanguage(Form parent, bool force) {
			if (force || Properties.Settings.Default.SelectedLanguage == ELanguage.None) {
				using (frmLanguage frm = new frmLanguage(Properties.Settings.Default.SelectedLanguage)) {
					if (frm.ShowDialog(parent) == System.Windows.Forms.DialogResult.OK) {
						string lang = frm.SelectedLanguage.FirstCharToUpper();
						Properties.Settings.Default.SelectedLanguage = (ELanguage)Enum.Parse(typeof(ELanguage), lang);
					}
				}
			}

			// Default to english
			if (Properties.Settings.Default.SelectedLanguage == ELanguage.None) {
				Properties.Settings.Default.SelectedLanguage = ELanguage.English;
			}

			if (Language == null || Language.Language != Properties.Settings.Default.SelectedLanguage) {
				// Initialize locale helper
				ResourceManager mgrLocales = null;
				ResourceManager mgrResources = null;
				CultureInfo culture = null;
				switch (Properties.Settings.Default.SelectedLanguage) {
					case ELanguage.German:
						mgrLocales = locale_de.ResourceManager;
						mgrResources = Properties.Resources.ResourceManager;
						culture = locale_de.Culture;
						break;
					case ELanguage.English:
						mgrLocales = locale_en.ResourceManager;
						mgrResources = Properties.Resources.ResourceManager;
						culture = locale_en.Culture;
						break;
				}
				Language = new LocaleHelper(Properties.Settings.Default.SelectedLanguage, mgrLocales, mgrResources, culture);
			}
		}

	}

}
