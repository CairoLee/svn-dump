using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GodLesZ.Ragnarok.SkillCalculator {
	
	public static class Program {

		[STAThread]
		public static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			using (frmMain main = new frmMain()) {
				using (frmLoading loading = new frmLoading(main)) {
					loading.ShowDialog();

					Application.Run(main);
				}
			}
		}

	}

}
