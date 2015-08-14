using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace MapRead.GAT {

	public class EEnum<T> {
		public EEnum() {
		}

		public static T Parse( string input ) {
			try {
				return (T)Enum.Parse( typeof( T ), input );
			} catch {
				return default( T );
			}
		}
	}


	[Serializable]
	public enum EMapCellType {
		Walkable = 0,
		NoWalkable = 1,
		NoWalkableNoSnipeableWater = 2, // not snipeable
		WalkableWater = 3,
		NoWalkableSnipeableWater = 4, // snipeable
		Snipeable = 5, // snipeable
		NoSnipeable = 6,
		Unknown = 10
	};

	[Serializable]
	public struct GATFile {
		[XmlAttribute()]
		public int Width;			// 6
		[XmlAttribute()]
		public int Height;			// 10
		[XmlArray( "Blocks" )]
		[XmlArrayItem( "CellType" )]
		public EMapCellType[] CellType;
	};





	public partial class GATViewer : Form {
		private GATFile mGat;
		private Bitmap mBmp;
		private float mZoom = 1.0f;

		private Color[] Colors = new Color[ 7 ] {
			Color.Gray, // Walk
			Color.Black, // no Walk
			Color.Navy, // NoWalkNoSnipeWater
			Color.Aquamarine, // WalkWater
			Color.Black, // NoWalkWater
			Color.Violet, // Snipe
			Color.Black // NoSnipe
		};

		public GATViewer() {
			InitializeComponent();

			lblColor1.Text = EMapCellType.Walkable.ToString();
			PictureBoxColor1.BackColor = Colors[ (int)EMapCellType.Walkable ];
			lblColor2.Text = EMapCellType.NoWalkable.ToString();
			PictureBoxColor2.BackColor = Colors[ (int)EMapCellType.NoWalkable ];
			lblColor3.Text = EMapCellType.NoWalkableNoSnipeableWater.ToString();
			PictureBoxColor3.BackColor = Colors[ (int)EMapCellType.NoWalkableNoSnipeableWater ];
			lblColor4.Text = EMapCellType.WalkableWater.ToString();
			PictureBoxColor4.BackColor = Colors[ (int)EMapCellType.WalkableWater ];
			lblColor5.Text = EMapCellType.NoWalkableSnipeableWater.ToString();
			PictureBoxColor5.BackColor = Colors[ (int)EMapCellType.NoWalkableSnipeableWater ];
			lblColor6.Text = EMapCellType.Snipeable.ToString();
			PictureBoxColor6.BackColor = Colors[ (int)EMapCellType.Snipeable ];
			lblColor7.Text = EMapCellType.NoSnipeable.ToString();
			PictureBoxColor7.BackColor = Colors[ (int)EMapCellType.NoSnipeable ];
		}



		private void btnOpenGat_Click( object sender, EventArgs e ) {
			OpenFileDialog dlg = new OpenFileDialog();

			dlg.Filter = "GAT Map (*.gat)|*.gat|XML GAT Map (*.xml)|*.xml";
			if( dlg.ShowDialog() != DialogResult.OK )
				return;
			txtFile.Text = dlg.FileName;

			Stopwatch watch = Stopwatch.StartNew();
			switch( Path.GetExtension( txtFile.Text ).ToLower() ) {
				case ".gat":
					ReadGat();
					break;
				case ".xml":
					ReadXml();
					break;
			}

			Debug.WriteLine( "Map reading needed: " + watch.ElapsedMilliseconds );
			watch = null;

			Draw();

		}


		private void ReadXml() {
			XmlSerializer xml = new XmlSerializer( typeof( GATFile ) );
			using( StreamReader sr = new StreamReader( txtFile.Text ) )
				mGat = (GATFile)xml.Deserialize( sr );
		}


		private void ReadGat() {
			using( FileStream s = new FileStream( txtFile.Text, FileMode.Open ) ) {
				if( s.CanRead == false ) {
					MessageBox.Show( "Can not read form File Stream?!", "Error!" );
					try { s.Close(); } catch { }
					return;
				}
				using( BinaryReader bin = new BinaryReader( s ) ) {

					s.Position = 6; // 0-6 = Magic Header [GRAT..]
					mGat = new GATFile();
					mGat.Width = bin.ReadInt32();
					mGat.Height = bin.ReadInt32();

					int num_cells = ( mGat.Width * mGat.Height );
					mGat.CellType = new EMapCellType[ num_cells ];
					for( int i = 0; i < num_cells; i++ ) {
						bin.BaseStream.Position += 4 * 4;
						mGat.CellType[ i ] = EEnum<EMapCellType>.Parse( bin.ReadByte().ToString() );
						bin.BaseStream.Position += 3; // 3x unknown Char
					}
				}
			}
		}


		private void Draw() {
			if( mGat.CellType == null )
				return;

			mBmp = new Bitmap( mGat.Width, mGat.Height );
			Utilitys.FastBitmap fastBmp = new Utilitys.FastBitmap( mBmp );

			using( Graphics g = Graphics.FromImage( mBmp ) ) {

				fastBmp.LockImage();
				for( int y = 0, i = 0; y < mGat.Height; y++ )
					for( int x = 0; x < mGat.Width; x++ )
						fastBmp.SetPixel( x, y, Colors[ (int)mGat.CellType[ i++ ] ] );
				fastBmp.UnlockImage();

				PictureBoxMap.Width = mBmp.Width;
				PictureBoxMap.Height = mBmp.Height;
				PictureBoxMap.Image = mBmp;
				g.Flush();
			}

		}

		private void MapRead_Paint( object sender, PaintEventArgs e ) {
			SetZoom( 0 );
		}

		private void btnZoomMinus_Click( object sender, EventArgs e ) {
			SetZoom( -0.25f );
		}

		private void btnZoomPlus_Click( object sender, EventArgs e ) {
			SetZoom( +0.25f );
		}

		private void SetZoom( float add ) {
			float tmp = ( mZoom + add );
			if( mBmp == null || mGat.CellType == null || tmp <= 0f )
				return;

			mZoom = tmp;
			lblZoom.Text = mZoom.ToString();

			PictureBoxMap.Image = ScalePercent( (Image)mBmp, (int)( mZoom * 100 ) );
			PictureBoxMap.Width = PictureBoxMap.Image.Width;
			PictureBoxMap.Height = PictureBoxMap.Image.Height;
		}

		private static Image ScalePercent( Image imgPhoto, int Percent ) {
			float nPercent = ( (float)Percent / 100 );

			int sourceWidth = imgPhoto.Width;
			int sourceHeight = imgPhoto.Height;
			int sourceX = 0, sourceY = 0;

			int destX = 0, destY = 0;
			int destWidth = (int)( sourceWidth * nPercent );
			int destHeight = (int)( sourceHeight * nPercent );

			Bitmap bmPhoto = new Bitmap( destWidth, destHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb );
			bmPhoto.SetResolution( imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution );

			using( Graphics g = Graphics.FromImage( bmPhoto ) ) {
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.DrawImage( imgPhoto, new Rectangle( destX, destY, destWidth, destHeight ), new Rectangle( sourceX, sourceY, sourceWidth, sourceHeight ), GraphicsUnit.Pixel );
			}

			return bmPhoto;
		}

		private void PictureBoxColor1_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor1 );
			Colors[ 0 ] = PictureBoxColor1.BackColor;
			Draw();
		}

		private void PictureBoxColor2_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor2 );
			Colors[ 1 ] = PictureBoxColor2.BackColor;
			Draw();
		}

		private void PictureBoxColor3_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor3 );
			Colors[ 2 ] = PictureBoxColor3.BackColor;
			Draw();
		}

		private void PictureBoxColor4_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor4 );
			Colors[ 3 ] = PictureBoxColor4.BackColor;
			Draw();
		}

		private void PictureBoxColor5_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor5 );
			Colors[ 4 ] = PictureBoxColor5.BackColor;
			Draw();
		}

		private void PictureBoxColor6_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor6 );
			Colors[ 5 ] = PictureBoxColor6.BackColor;
			Draw();
		}

		private void PictureBoxColor7_Click( object sender, EventArgs e ) {
			ChooseColor( PictureBoxColor7 );
			Colors[ 6 ] = PictureBoxColor7.BackColor;
			Draw();
		}



		private void ChooseColor( PictureBox box ) {
			ColorDialog dlg = new ColorDialog();
			dlg.AllowFullOpen = true;
			if( dlg.ShowDialog() != DialogResult.OK )
				return;
			box.BackColor = dlg.Color;
		}

		private void beendenToolStripMenuItem_Click( object sender, EventArgs e ) {
			Environment.Exit( 0 );
		}

		private void neuZeichnenRefreshToolStripMenuItem_Click( object sender, EventArgs e ) {
			Draw();
		}

		private void imageSpeichernToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( PictureBoxMap.Image == null )
				return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "PNG Image (*.png)|*.png";
			dlg.FileName = Path.GetFileNameWithoutExtension( txtFile.Text );
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			PictureBoxMap.Image.Save( dlg.FileName, System.Drawing.Imaging.ImageFormat.Png );
		}

		private void xMLVonMapSpeichernToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( PictureBoxMap.Image == null )
				return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "XML Datei (*.xml)|*.xml";
			dlg.FileName = Path.GetFileNameWithoutExtension( txtFile.Text );
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			XmlSerializer xml = new XmlSerializer( typeof( GATFile ) );
			using( StreamWriter sw = new StreamWriter( dlg.FileName ) )
				xml.Serialize( sw, mGat );
		}


	}

}
