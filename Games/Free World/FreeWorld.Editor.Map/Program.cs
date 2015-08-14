using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FreeWorld.Editor.Map {

	public static class Program {

		[STAThread]
		public static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmEditor(args));
		}

	}

}