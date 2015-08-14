using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace GodLesZ.FunRO.Patcher {

	public static class Program {

		[STAThread]
		public static void Main() {
			// add global exception handler..
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

			bool isGod = false; // IsGodMode();
			if (IsAdminRole() == false) {
				MessageBox.Show("You need to run this Patcher with Administration Rights!\nPlease Rightclick the Patcher.exe and run it as Administrator!\nThank You", "Administrative access missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// a God may start everything WAHAHAHAHA
			if (isGod == false) {
				// Disable multiple patcher instances
				Process[] pList = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
				if (pList.Length > 1) {
					MessageBox.Show("An instance of the patcher is already running.", "Patcher start error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					try {
						Form.FromHandle(pList[0].Handle).Focus();
					} catch { }
					return;
				}
				pList = null; // cleanup
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain(isGod));
		}


		#region Exception Events
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			LastChanceHandler(e.Exception);
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args) {
			LastChanceHandler((Exception)(args.ExceptionObject));
		}

		private static void LastChanceHandler(Exception ex) {
			using (StreamWriter log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\Exception log-" + DateTime.Now.ToString("dd-MM_HHmmss") + ".txt")) {
				log.WriteLine("****** LastChanceHandler ******");
				log.WriteLine("ExceptionType: {0}", ex.GetType().Name);
				log.WriteLine("HelpLine: {0}", ex.HelpLink);
				log.WriteLine("Message: {0}", ex.Message);
				log.WriteLine("Source: {0}", ex.Source);
				log.WriteLine("StackTrace: {0}", ex.StackTrace);
				log.WriteLine("TargetSite: {0}", ex.TargetSite);
				string indent = new string(' ', 9);
				Exception ie = ex;
				while ((ie = ie.InnerException) != null) {
					log.WriteLine(indent + "****** Inner Exception ******");
					log.WriteLine(indent + "ExceptionType: {0}", ie.GetType().Name);
					log.WriteLine(indent + "HelpLine: {0}", ie.HelpLink);
					log.WriteLine(indent + "Message: {0}", ie.Message);
					log.WriteLine(indent + "Source: {0}", ie.Source);
					log.WriteLine(indent + "StackTrace: {0}", ie.StackTrace);
					log.WriteLine(indent + "TargetSite: {0}", ie.TargetSite);
					indent += new string(' ', 9);
				}
			}
		}
		#endregion


		private static bool IsAdminRole() {
			try {
				AppDomain myDomain = Thread.GetDomain();
				myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
				WindowsPrincipal role = Thread.CurrentPrincipal as WindowsPrincipal;

				return role.IsInRole(WindowsBuiltInRole.Administrator);
			} catch {
				return true;
			}
		}

		private static bool IsGodMode() {
			List<string> good = new List<string>(
				new string[2]{
					"00:0B:6A:37:D2:4B",
					"1C:4B:D6:FA:2F:CA"
				}
			);

			return good.Contains(GetMac());
		}

		private static string GetMac() {
			string Mac = string.Empty;
			try {
				System.Management.ManagementClass MC = new System.Management.ManagementClass("Win32_NetworkAdapter");
				System.Management.ManagementObjectCollection MOCol = MC.GetInstances();
				foreach (System.Management.ManagementObject MO in MOCol)
					if (MO != null && MO["MacAddress"] != null) {
						Mac = MO["MacAddress"].ToString();
						if (Mac != string.Empty) {
							break;
						}
					}
			} catch {
			}
			return Mac;
		}

	}

}
