using System;
using System.Windows.Forms;
using GodLesZ.Library.AutoUpdater.Library;

namespace ZenAIConfigPanel {

	public static class Program {

		[STAThread]
		public static void Main() {
			/*
			UpdateHandler uHandler = new UpdateHandler();
			var asm = System.Reflection.Assembly.GetExecutingAssembly();
			if (uHandler.CheckVersion(asm, "http://178.77.65.232/p/zenai_configpanel/") == true && uHandler.StartUpdate() == true) {
				return;
			}
			*/

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}

	}

}
