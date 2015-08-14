using System;
using System.Threading;
using System.Windows.Forms;
using PathDefence.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

namespace PathDefence {
	internal static class Program {
		[STAThread]
		private static void Main(string[] commands) {
			bool pobjIOwnMutex;
			using (new Mutex(true, "PathDefence", out pobjIOwnMutex)) {
				if (pobjIOwnMutex || (commands.Length > 0 && commands[0] == "-r")) {
					//LogFramework.Initialize("PathDefence",Settings.Default.LogServer, Settings.Default.LogAccount,Settings.Default.LogPw,"1.0.0.0",1,"abc");
					//LogFramework.AddLog("Starting PathDefence...",false,LogType.StartLog);
					using (var game = new PathDefenceGame()) {
						game.Run();
					}
					//LogFramework.FinalizeLogger();
				} else {
					if (TaskDialog.IsPlatformSupported) {
						var dlg = new TaskDialog {
							Cancelable = true,
							Caption = "Fehler",
							DetailsCollapsedLabel = "Hilfe anzeigen",
							DetailsExpandedText =
								"Sollten Sie das Programm soeben beendet haben, so warten Sie ein paar Sekunden und versuchen Sie es erneut.",
							DetailsExpandedLabel = "Hilfe ausblenden",
							ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandContent,
							InstructionText = "Es wird bereits eine Instanz dieses Programms ausgeführt!",
							Text =
								"Bitte schließen Sie diese Instanz bevor Sie das Programm erneut öffnen!",
							StandardButtons = TaskDialogStandardButtons.Close,
							Icon = TaskDialogStandardIcon.Error
						};

						var killProcess = new TaskDialogCommandLink("killprocess", "Andere Instanz beenden",
																	"Die andere laufende Instanz wird beendet.\nDaten des Spiels könnten möglicherweise verloren gehen.");
						killProcess.Click += killProcess_Click;
						dlg.Controls.Add(killProcess);

						dlg.Show();
					} else {
						MessageBox.Show(
							"Es wird bereits eine Instanz dieses Programms ausgeführt!\n" +
							"Bitte schließen Sie diese Instanz bevor Sie das Programm erneut öffnen!\n" +
							"Sollten Sie das Programm soeben beendet haben, so warten Sie ein paar Sekunden und versuchen Sie es erneut.",
							"Fehler beim Starten des Programms", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		static void killProcess_Click(object sender, EventArgs e) {
			foreach (var process in Process.GetProcesses()) {
				if (process.MainWindowTitle == "PathDefence" && process != Process.GetCurrentProcess()) {
					process.Kill();
					break;
				}
			}
			Process.Start(Process.GetCurrentProcess().MainModule.FileName, "-r");
		}
	}
}