using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShaiyaMonsterMap {
	static class Program {
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() {
			Updater.Library.UpdateHandler uHandler = new Updater.Library.UpdateHandler();
			if( uHandler.CheckVersion( System.Reflection.Assembly.GetExecutingAssembly(), "http://shaiya-obscura.dz-net.net/updates/shaiya_mobmap/" ) == true && uHandler.StartUpdate() == true )
				return;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmSplash( 4000 ) );
			Application.Run( new frmMain() );
		}
	}
}
