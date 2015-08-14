using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eAthenaStudio.Client {

	public static class Program {

		[STAThread]
		public static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain(args));
		}

	}

}
