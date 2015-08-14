using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ClientPatcher {

	public partial class frmMain : Form {
		private List<PatchPart> mPatches = new List<PatchPart>();

		public frmMain() {
			InitializeComponent();

			AddLog( "Client Patcher initialized & ready...", Color.DarkGreen );
		}


		private void btnOpenPatches_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "XML Patch List (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			txtPatchList.Text = dlg.FileName;
			if( txtPatchFile.Text.Length > 0 && File.Exists( txtPatchFile.Text ) )
				btnPatchIt.Enabled = true;
		}

		private void btnOpenPatchFile_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "All Files|*.*";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			txtPatchFile.Text = dlg.FileName;
			if( txtPatchList.Text.Length > 0 && File.Exists( txtPatchList.Text ) )
				btnPatchIt.Enabled = true;
		}

		private void btnAbout_Click( object sender, EventArgs e ) {
			using( frmAbout frm = new frmAbout( "Thanks @ my Brain & Hands" ) )
				frm.ShowDialog();
		}

		private void btnPatchIt_Click( object sender, EventArgs e ) {
			btnPatchIt.Enabled = false;
			btnPatchIt.Text = "@ Work";
			PatchFile( txtPatchFile.Text, txtPatchList.Text );
			btnPatchIt.Enabled = true;
			btnPatchIt.Text = "Patch";
		}


		private void PatchFile( string Filename, string PatchList ) {
			ClearLog();
			AddLog( "Start reading Files...", Color.DarkGreen );

			XmlSerializer xml = new XmlSerializer( typeof( List<PatchPart> ) );
			using( FileStream fs = File.OpenRead( PatchList ) )
				mPatches = xml.Deserialize( fs ) as List<PatchPart>;


			byte[] streamBuf = null;
			using( FileStream input = new FileStream( Filename, FileMode.Open ) ) {
				streamBuf = new byte[ input.Length ];
				using( BinaryReader reader = new BinaryReader( input ) ) {
					reader.Read( streamBuf, 0, streamBuf.Length );
				}
			}


			StringBuilder stringBuilder = new StringBuilder();
			List<byte> byteList = new List<byte>( streamBuf );
			streamBuf = null;
			byteList.ForEach( 
				delegate( byte b ) { 
					stringBuilder.Append( b.ToString( "X2" ) ); 
				} 
			);
			string stringBuf = stringBuilder.ToString();

			AddLog( "Start Patching \"{0}\"...", Color.DarkGreen, Path.GetFileName( Filename ) );

			int foundPatchups = 0;
			int startIndex = 0;
			int subIndex = 0;
			bool error = false;
			mPatches.ForEach( 
				delegate( PatchPart patch ) {
					// refresh stringBuf
					if( error == false )
						stringBuf = stringBuilder.ToString();

					error = false;
					patch.FindString = patch.FindString.Replace( " ", "" ).ToUpper();
					startIndex = Tools.FindString( stringBuf, patch.FindString, patch.StartIndex );
					if( startIndex == -1 ) {
						error = true;
						AddLog( "Unable to find HexPart! Searched: {0}", Color.Red, patch.FindString );
						return;
					}

					if( patch.SubPatch != PatchPart.ZeroPatch ) {
						patch.SubPatch.FindString = patch.SubPatch.FindString.Replace( " ", "" ).ToUpper();
						subIndex = Tools.FindString( stringBuf, patch.SubPatch.FindString, startIndex + patch.SubPatch.StartIndex );
						if( ( subIndex - startIndex ) > 30 ) {
							error = true;
							AddLog( "Unable to find SubPatch! Searched: {0}", Color.Red, patch.SubPatch.FindString );
							return;
						}

						patch.SubPatch.PatchBuf( byteList, stringBuilder, subIndex );
						AddLog( "Successfull patched (subpatch): {0}", Color.DarkGreen, patch.SubPatch.FindString );
						foundPatchups++;
						return;
					}

					patch.PatchBuf( byteList, stringBuilder, startIndex );
					AddLog( "Successfull patched: {0}", Color.DarkGreen, patch.FindString );
					foundPatchups++;
				}
			);

			// cleanup
			stringBuf = null;
			stringBuilder = null;

			// not all patched :/
			if( foundPatchups != mPatches.Count ) {
				AddLog( "Error Finding all patch points ({0} from {1})!", Color.Red, foundPatchups, mPatches.Count );
				return;
			}

			AddLog( "Finished patching, start backup & writing the new File", Color.DarkGreen );

			// Backup
			File.Copy( Filename, Path.GetDirectoryName( Filename ) + @"\" + Path.GetFileNameWithoutExtension( Filename ) + @"_backup" + Path.GetExtension( Filename ) );
			// delete existing File
			File.Delete( Filename );

			// write new Stream
			using( FileStream output = new FileStream( Filename, FileMode.OpenOrCreate ) ) {
				using( BinaryWriter writer = new BinaryWriter( output ) )
					writer.Write( byteList.ToArray(), 0, byteList.Count );
			}

			byteList.Clear();

			AddLog( "Successfull patched & saved File \"{0}\"!", Color.DarkGreen, Path.GetFileName( Filename ) );
		}





		public void AddLog( string Text, Color Color ) {
			txtLog.SelectedText = "[" + DateTime.Now.ToString( "HH:mm:ss" ) + "] ";

			txtLog.SelectionColor = Color;
			txtLog.SelectedText = Text + "\n";
			Application.DoEvents();
		}

		public void AddLog( string Text ) {
			AddLog( Text, Color.Black );
		}

		public void AddLog( string Text, params object[] args ) {
			AddLog( string.Format( Text, args ) );
		}

		public void AddLog( string Text, Color Color, params object[] args ) {
			AddLog( string.Format( Text, args ), Color );
		}

		public void ClearLog() {
			txtLog.Text = "";
			Application.DoEvents();
		}

	}

	#region Program.Main()
	static class Program {
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new frmMain() );
		}
	}
	#endregion

}
