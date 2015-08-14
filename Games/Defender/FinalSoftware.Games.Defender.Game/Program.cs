using System;
using System.Diagnostics;

namespace FinalSoftware.Games.Defender.Game {

	public static class Program {
		public static frmSplash SplashScreen;

		[STAThread]
		public static void Main(string[] args) {
			Process thisProc = Process.GetCurrentProcess();
			Process[] procs = Process.GetProcessesByName(thisProc.ProcessName);
			if (procs.Length >= 2) {
				System.Windows.Forms.MessageBox.Show("Defender kann nur einmal gestartet werden!", "Fehler", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				return;
			}

			SplashScreen = new frmSplash();
			SplashScreen.Show();
			using (Game game = new Game())
				game.Run();
			SplashScreen.Dispose();

		}

	}

}

