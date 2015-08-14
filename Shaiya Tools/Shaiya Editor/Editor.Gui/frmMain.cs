using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Editor.Gui {

	public partial class frmMain : Form {
		Editor.Lib.ShaiyaData Data;


		public frmMain() {
			InitializeComponent();
		}



		#region frmMain Events
		private void frmMain_FormClosing( object sender, FormClosingEventArgs e ) {
			if( Data == null )
				return;

			Data.Dispose();
		}
		#endregion

		#region Toolstrip Events
		private void ToolStripOpen_Click( object sender, EventArgs e ) {
			OpenDataFile();
		}

		private void ToolStripSave_Click( object sender, EventArgs e ) {
			SaveDataFile();
		}
		#endregion

		#region Menu Events
		private void MenuProgramClose_Click( object sender, EventArgs e ) {
			this.Close();
		}

		private void MenuDataOpen_Click( object sender, EventArgs e ) {
			OpenDataFile();
		}

		private void MenuDataSave_Click( object sender, EventArgs e ) {
			SaveDataFile();
		}

		private void MenuDataRepack_Click( object sender, EventArgs e ) {
			RepackDataFile();
		}
		#endregion


		#region FileTree Events
		private void FileTree_AfterSelect( object sender, TreeViewEventArgs e ) {
			TreeNode node = e.Node;
			if( node == FileTree.Nodes[ 0 ] ) // root
				return;

			Editor.Lib.ShaiyaDataEntry entry = Data.GetFlatEntry( node.Name );
			if( entry == null )
				MessageBox.Show( "Failed to fetch Entry from File ôo" );
			if( entry.IsDir == true )
				return;

			byte[] buffer;
			Data.GetData( entry, out buffer );
			DoPreview( buffer, entry );
		}
		private void FileTree_MouseClick( object sender, MouseEventArgs e ) {

		}
		#endregion

		#region FileTreeContext Menu
		private void FileTreeContext_Opening( object sender, CancelEventArgs e ) {
			if( FileTree.Nodes.Count == 0 || FileTree.SelectedNode == null ) {
				e.Cancel = true;
				return;
			}

			// allowed to add in a dir?
			if( FileTree.SelectedNode != FileTree.Nodes[ 0 ] ) {
				// not root, is it a dir?
				Editor.Lib.ShaiyaDataEntry entry = Data.GetFlatEntry( FileTree.SelectedNode.Name );
				if( entry.IsDir == false ) {
					// its a file, not allowed to add here
					FileTreeContextSep1.Visible = false;
					FileTreeContextAddFile.Visible = false;
					FileTreeContextAddFolder.Visible = false;
					// allowed to replace
					FileTreeContextReplace.Enabled = true;
					return;
				}
			}

			// its a dir, allowed to add files/dirs
			FileTreeContextSep1.Visible = true;
			FileTreeContextAddFile.Visible = true;
			FileTreeContextAddFolder.Visible = true;
			// not allowed to replace
			FileTreeContextReplace.Enabled = false;
		}

		private void FileTreeContextExtract_Click( object sender, EventArgs e ) {
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			using( frmExtract frm = new frmExtract( FileTree.SelectedNode.Name, dlg.SelectedPath, Data ) )
				frm.ShowDialog();
		}

		private void FileTreeContextReplace_Click( object sender, EventArgs e ) {
			Editor.Lib.ShaiyaDataEntry entry = Data.GetFlatEntry( FileTree.SelectedNode.Name );
			if( entry.IsDir == true )
				return;

			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = entry.Filename + "|" + entry.Filename;
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			if( Data.UpdateFile( entry.ID, dlg.FileName ) == false ) {
				MessageBox.Show( "Fehler beim ersetzen der Datei!?" );
				return;
			}

			// reload Content
			//LoadData( Data.BasePath + ".sah" );
		}

		private void FileTreeContextAddFolder_Click( object sender, EventArgs e ) {

		}

		private void FileTreeContextAddFile_Click( object sender, EventArgs e ) {
			Editor.Lib.ShaiyaDataEntry parentEntry = Data.GetFlatEntry( FileTree.SelectedNode.Name );
			if( parentEntry.IsDir == false )
				return;

			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "All Files *.*|*.*";
			dlg.Multiselect = true;
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			Editor.Lib.ShaiyaDataEntry newEntry;
			for( int i = 0; i < dlg.FileNames.Length; i++ ) {
				if( Data.AddFile( parentEntry, dlg.FileNames[ i ], out newEntry ) == false ) {
					MessageBox.Show( "Fehler beim hinzufügen der Datei!\n" + dlg.FileNames[ i ] );
					continue;
				}

				int index = GetImageIndex( newEntry.Filename );
				FileTree.SelectedNode.Nodes.Add( newEntry.ID, newEntry.Filename, index, index );
			}
		}
		#endregion



		private void DoPreview( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			if( buffer == null || Entry == null ) {
				PanelPreview.Controls.Clear();
				return;
			}

			switch( Path.GetExtension( Entry.Filename ).ToLower() ) {
				case ".txt":
					PreviewTextFile( buffer, Entry );
					return;

				case ".tga":
					PreviewImageTgaFile( buffer, Entry );
					return;
				case ".dds":
					try {
						PreviewImageDdsFile( buffer, Entry );
					} catch( Exception e ) {
						System.Diagnostics.Debug.WriteLine( e );
					}
					return;
				case ".jpg":
				case ".jepg":
				case ".bmp":
					PreviewImageFile( buffer, Entry );
					return;

				case ".wav":
				case ".mp3":
				case ".mp4":
					PreviewSoundFile( buffer, Entry );
					return;

				case ".sdata":
					PreviewSDataFile( buffer, Entry );
					return;

			}
		}

		#region PreviewFile
		private void PreviewSoundFile( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			Editor.Lib.Native.PlaySound( ref buffer[ 0 ], IntPtr.Zero, 5 );
		}
		private void PreviewImageFile( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			PanelPreview.Controls.Clear();
			PictureBox box = new PictureBox();
			box.Dock = System.Windows.Forms.DockStyle.Fill;
			box.Location = System.Drawing.Point.Empty;
			box.Name = "box";


			try {
				using( MemoryStream tmpStream = new MemoryStream( buffer ) ) {
					box.Image = Bitmap.FromStream( tmpStream );
				}
			} catch {
				box.Image = null;
				MessageBox.Show( "unable to Preview this Image :/" );
			}
			PanelPreview.Controls.Add( box );
		}
		private void PreviewImageTgaFile( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			PanelPreview.Controls.Clear();
			PictureBox box = new PictureBox();
			box.Dock = System.Windows.Forms.DockStyle.Fill;
			box.Location = System.Drawing.Point.Empty;
			box.Name = "box";


			try {
				using( MemoryStream tmpStream = new MemoryStream( buffer ) ) {
					box.Image = new TargaImage( tmpStream ).Image;
				}
			} catch {
				box.Image = null;
				MessageBox.Show( "unable to Preview this Image :/" );
			}
			PanelPreview.Controls.Add( box );
		}
		private void PreviewImageDdsFile( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			PanelPreview.Controls.Clear();
			PictureBox box = new PictureBox();
			box.Dock = System.Windows.Forms.DockStyle.Fill;
			box.Location = System.Drawing.Point.Empty;
			box.Name = "box";

			string tmpFile = Path.Combine( Path.GetTempPath(), Path.GetRandomFileName() ) + ".dds";
			try {
				File.WriteAllBytes( tmpFile, buffer );
				box.Image = DevIL.DevIL.LoadBitmap( tmpFile );
			} catch {
				box.Image = null;
				MessageBox.Show( "unable to Preview this Image :/" );
			} finally {
				File.Delete( tmpFile );
			}
			PanelPreview.Controls.Add( box );
		}
		private void PreviewTextFile( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			PanelPreview.Controls.Clear();
			RichTextBox box = new RichTextBox();
			box.Dock = System.Windows.Forms.DockStyle.Fill;
			box.Location = System.Drawing.Point.Empty;
			box.Name = "box";
			box.ReadOnly = true;
			box.Text = "";

			box.Text = System.Text.Encoding.Unicode.GetString( buffer );
			PanelPreview.Controls.Add( box );
		}
		private void PreviewSDataFile( byte[] buffer, Editor.Lib.ShaiyaDataEntry Entry ) {
			/*byte[] decompressedBuf;
			byte[] compressedBuf;
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			for( int i = 0; i < 100; i++ ) {
				compressedBuf = new byte[ buffer.Length - i ];
				Buffer.BlockCopy( buffer, i, compressedBuf, 0, compressedBuf.Length );
				try {
					System.Diagnostics.Debug.Write( "try " + i + "..." );
					decompressedBuf = Editor.Lib.Deflate.Decompress( compressedBuf );
					System.Diagnostics.Debug.WriteLine( " success! " + decompressedBuf.Length + " bytes" );

					File.WriteAllBytes( AppDomain.CurrentDomain.BaseDirectory + "debug_" + i + ".txt", decompressedBuf );
				} catch( Exception e ) {
					//System.Diagnostics.Debug.WriteLine( e );
					System.Diagnostics.Debug.WriteLine( " fail.." );
				}
			}*/

		}
		#endregion



		private void AddNodes( TreeNode RootNode, List<Editor.Lib.ShaiyaDataEntry> Files ) {
			TreeNode tempNode;
			int index = 0;
			for( int i = 0; i < Files.Count; i++ ) {
				index = GetImageIndex( Files[ i ].Filename );
				tempNode = RootNode.Nodes.Add( Files[ i ].ID, Files[ i ].Filename, index, index );
				if( Files[ i ].IsDir == true )
					AddNodes( tempNode, Files[ i ].Entrys );
			}
		}

		/// <summary>
		/// Imagelist:
		///  0: Folder
		///  1: Text
		///  2: Image
		///  3: Sound
		///  4: Code
		/// </summary>
		/// <param name="Filename"></param>
		/// <returns></returns>
		private int GetImageIndex( string Filename ) {
			string extension = Path.GetExtension( Filename );
			if( extension == "" )
				return 0; // Folder

			switch( extension.ToLower() ) {
				case ".txt":
					return 1;

				case ".jpg":
				case ".jepg":
				case ".tga":
				case ".bmp":
				case ".dds":
					return 2;

				case ".wav":
				case ".mp3":
				case ".mp4":
					return 3;
			}

			return 4;
		}




		private void OpenDataFile() {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Shaiya data.sah (*.sah)|*.sah";
			dlg.Title = "Shaiya Data File speichern";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			LoadData( dlg.FileName );
			MenuDataSave.Enabled = true;
			MenuDataRepack.Enabled = true;
			ToolStripSave.Enabled = true;
		}

		private void LoadData( string FileName ) {
			PanelPreview.Controls.Clear();
			FileTree.Nodes.Clear();

			Data = new Editor.Lib.ShaiyaData( FileName );
			FileTree.Nodes.Add( "data" );
			AddNodes( FileTree.Nodes[ 0 ], Data.Files );

			FileTree.Nodes[ 0 ].Expand();
		}

		private void RepackDataFile() {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Shaiya data.sah (*.sah)|*.sah";
			dlg.InitialDirectory = Path.GetDirectoryName( Data.BasePath ) + @"\";
			dlg.Title = "Shaiya Data File speichern";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			using( frmRepack frm = new frmRepack( EPackType.RepackAll, dlg.FileName, Data ) )
				frm.ShowDialog();
		}

		private void SaveDataFile() {
			using( frmRepack frm = new frmRepack( EPackType.SaveUpdates, "", Data ) )
				frm.ShowDialog();
		}


	}

}
