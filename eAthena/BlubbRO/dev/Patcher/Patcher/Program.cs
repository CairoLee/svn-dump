using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace GodLesZ.BlubbRO.Patcher {

	public static class Program {

		[STAThread]
		public static void Main() {
			// add global exception handler..
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

			bool isGod = IsGodMode();
			if (IsAdminRole() == false) {
				MessageBox.Show("You need to run this Patcher with Administration Rights!\nPlease Rightclick the BlubbRO Patcher.exe and run it as Administrator!\nThank You", "Administrator Access missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// a God may start everything WAHAHAHAHA
			if (isGod == false) {
				Process[] pList = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
				if (pList.Length > 1) {
					MessageBox.Show("Dual clienting is against our rules!\nYour IP got logged.", "Dual client error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				while (!((ie.InnerException == null))) {
					ie = ie.InnerException;
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
			AppDomain myDomain = Thread.GetDomain();
			myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			WindowsPrincipal role = Thread.CurrentPrincipal as WindowsPrincipal;

			return role.IsInRole(WindowsBuiltInRole.Administrator);
		}

		private static bool IsGodMode() {
			List<string> goodMacs = new List<string>(
				new string[]{
					// GodLesZ
					"00:30:05:AF:77:4B",
					"50:50:54:50:30:30",
					"33:50:6F:45:30:30",
					"4C:E4:20:52:41:53"
				}
			);

			List<string> macs = GetMacList();
			if (macs.Count == 0) {
				return false;
			}
			foreach (string macString in macs) {
				if (goodMacs.Contains(macString) == true) {
					return true;
				}
			}
			return false;
		}

		private static List<string> GetMacList() {
			List<string> macs = new List<string>();
			string mac = string.Empty;
			try {
				System.Management.ManagementClass MC = new System.Management.ManagementClass("Win32_NetworkAdapter");
				System.Management.ManagementObjectCollection MOCol = MC.GetInstances();
				foreach (System.Management.ManagementObject MO in MOCol) {
					if (MO == null || MO["MacAddress"] == null) {
						continue;
					}

					mac = MO["MacAddress"].ToString();
					if (mac != string.Empty) {
						macs.Add(mac);
					}
				}
			} catch { }

			string debugString = "";
			foreach (string debug in macs) {
				debugString += Environment.NewLine + debug;
			}
			MessageBox.Show("Macs found (" + macs.Count + ": " + Environment.NewLine + debugString);
			
			return macs;
		}

	}

}
