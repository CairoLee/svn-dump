using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Shaiya_Signatur_Generator {
	static class Program {
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() {
			Updater.Library.UpdateHandler uHandler = new Updater.Library.UpdateHandler();
			if( uHandler.CheckVersion( System.Reflection.Assembly.GetExecutingAssembly(), "http://blubb-gaming.de/Updates/Shaiya/SigGen/" ) == true && uHandler.StartUpdate() == true )
				return;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	}
}
