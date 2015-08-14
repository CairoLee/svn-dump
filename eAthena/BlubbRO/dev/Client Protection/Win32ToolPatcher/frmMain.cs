using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Win32ToolPatcher {

	public partial class frmMain : Form {
		private string mPatcherPath = "";

		public string PatcherPath {
			get {
				if( mPatcherPath == "" )
					mPatcherPath = AppDomain.CurrentDomain.BaseDirectory + @"\__patcher.exe";
				return mPatcherPath;
			}
		}


		public frmMain() {
			InitializeComponent();
		}

		private void btnOpenExe_Click( object sender, EventArgs e ) {
			using( OpenFileDialog dlg = new OpenFileDialog() ) {
				dlg.Filter = "Client.exe|*.exe";
				dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
				if( dlg.ShowDialog( this ) != DialogResult.OK )
					return;
				if( Path.GetDirectoryName( dlg.FileName ) + "\\" != AppDomain.CurrentDomain.BaseDirectory ) {
					MessageBox.Show( "Die Datei muss sich im selben Verzeichnis wie dieses Tool befinden!", "Pfad Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}

				txtExe.Text = dlg.FileName;
				btnPatch.Enabled = ( txtDll.Text.Length > 0 );
			}
		}

		private void btnOpenDll_Click( object sender, EventArgs e ) {
			using( OpenFileDialog dlg = new OpenFileDialog() ) {
				dlg.Filter = "Schutz DLL|*.dll";
				dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
				if( dlg.ShowDialog( this ) != DialogResult.OK )
					return;
				if( Path.GetDirectoryName( dlg.FileName ) + "\\" != AppDomain.CurrentDomain.BaseDirectory ) {
					MessageBox.Show( "Die Datei muss sich im selben Verzeichnis wie dieses Tool befinden!", "Pfad Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}

				txtDll.Text = dlg.FileName;
				btnPatch.Enabled = ( txtExe.Text.Length > 0 );
			}
		}


		private void btnPatch_Click( object sender, EventArgs e ) {
			string newExeName = Path.GetFileNameWithoutExtension( txtExe.Text ) + ".patched" + Path.GetExtension( txtExe.Text );
			if( File.Exists( newExeName ) )
				try {
					File.Delete( newExeName );
				} catch { }

			Assembly asm = Assembly.GetExecutingAssembly();
			using( Stream s = asm.GetManifestResourceStream( "Win32ToolPatcher.ToolPatcher.exe" ) ) {
				byte[] buf = new byte[ s.Length ];
				s.Read( buf, 0, buf.Length );
				File.WriteAllBytes( PatcherPath, buf );
			}

			ProcessStartInfo info = new ProcessStartInfo( PatcherPath, "\"" + Path.GetFileName( txtExe.Text ) + "\" \"" + Path.GetFileName( txtDll.Text ) + "\"" );
			info.CreateNoWindow = false;
			info.WorkingDirectory = Path.GetDirectoryName( PatcherPath );
			info.WindowStyle = ProcessWindowStyle.Hidden;

			Process p = Process.Start( info );
			p.WaitForExit();
			if( File.Exists( PatcherPath ) )
				try {
					File.Delete( PatcherPath );
				} catch { }

			MessageBox.Show( Path.GetFileName( txtExe.Text ) + " wurde erfolgreich gepatched!\nSpeicherort: " + newExeName, "Patch erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

	}

}
