using System;
using System.Windows.Forms;

namespace GrfEditor.Client {

	public static class Program {

		[STAThread]
		public static void Main(string[] args) {
			// Debug startup
			/*
			string startupArgs = "Debug startup args\n\n";
			if (args == null || args.Length == 0) {
				startupArgs += "No args given";
			} else {
				startupArgs += args.Length + " args found:\n";
				int i = 0;
				foreach (string arg in args) {
					startupArgs += "[" + i + "] " + arg + "\n";
					i++;
				}
			}
			MessageBox.Show(startupArgs);
			return;
			*/

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmMain(args));
		}

	}

}
