using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FreeWorld.Editor.Animation {

	public static class Program {

		[STAThread]
		public static void Main() {
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormEditor());

		}

	}

}
