using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Ragnarok3D.Editor {
	public partial class PaintTools : Form {
		public Tool currentTool = Tool.Select;
		public enum Tool {
			Select,
			Fill,
			Unfill,
		}

		Heightmap heightmap;
		MouseState ms;

		int layerID = -1;

		public PaintTools( Heightmap myHeightmap ) {
			heightmap = myHeightmap;
			InitializeComponent();
		}

		private void ResetToolSelection( Tool tool ) {
			if( tool != Tool.Select )
				ChkArrow.Checked = false;
			if( tool != Tool.Fill )
				ChkFill.Checked = false;
			if( tool != Tool.Unfill )
				ChkBordering.Checked = false;
		}

		private void SelectTool( Tool tool ) {
			ResetToolSelection( tool );

			switch( tool ) {
				case Tool.Select:
					currentTool = Tool.Select;
					break;
				case Tool.Fill:
					currentTool = Tool.Fill;
					break;
				case Tool.Unfill:
					currentTool = Tool.Unfill;
					break;
			}
		}

		private void SlideArrowSize_Scroll( object sender, ScrollEventArgs e ) {
			heightmap.groundCursorSize = SlideArrowSize.Value;
		}

		private void SlideCursorItensity_Scroll( object sender, ScrollEventArgs e ) {
			heightmap.groundCursorStrength = SlideCursorItensity.Value;
		}

		private void PaintTools_Load( object sender, EventArgs e ) {
			GetHeightmapData();
			ResetToolSelection( Tool.Select );
			SlideArrowSize.Value = heightmap.groundCursorSize;
			SlideCursorItensity.Value = heightmap.groundCursorStrength;
			heightmap.bShowCursor = true;
			timer1.Start();
		}

		private void ChkArrow_CheckedChanged( object sender, EventArgs e ) {
			if( ChkArrow.Checked == true )
				SelectTool( Tool.Select );
		}

		private void ChkFill_CheckedChanged( object sender, EventArgs e ) {
			if( ChkFill.Checked == true )
				SelectTool( Tool.Fill );
		}

		private void ChkBordering_CheckedChanged( object sender, EventArgs e ) {
			if( ChkBordering.Checked == true )
				SelectTool( Tool.Unfill );
		}

		private void timer1_Tick( object sender, EventArgs e ) {
			ms = Mouse.GetState();

			Ray pickRay = Editor.heightmap.GetPickRay();
			float rayLength = 0f;

			if( Editor.camera.state == Camera.State.Fixed && layerID != -1 && currentTool != Tool.Select ) {
				heightmap.bShowCursor = true;

				for( int i = 0; i < heightmap.triangle.Length; i++ ) {
					Heightmap.Tri thisTri = heightmap.triangle[ i ];
					if( MathExtra.Intersects( pickRay, thisTri.p1, thisTri.p3, thisTri.p2, thisTri.normal, false, true, out rayLength ) ) {
						heightmap.testTriangle[ 2 ].SetNewCoordinates( thisTri.p1, thisTri.p2, thisTri.p3, Microsoft.Xna.Framework.Graphics.Color.White );

						Vector3 rayTarget = pickRay.Position + pickRay.Direction * rayLength;
						heightmap.groundCursorPosition.X = rayTarget.X / ( heightmap.size.X * heightmap.cellSize.X );
						heightmap.groundCursorPosition.Y = rayTarget.Y;
						heightmap.groundCursorPosition.Z = rayTarget.Z / ( heightmap.size.Y * heightmap.cellSize.Y );

						Point pixel = new Point( (int)( rayTarget.X / heightmap.cellSize.X ), (int)( rayTarget.Z / heightmap.cellSize.Y ) );

						if( rayLength > 0f ) {
							if( ms.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ) {
								switch( currentTool ) {
									case Tool.Fill:
										heightmap.Paint( pixel.X, pixel.Y, heightmap.groundCursorStrength / 100f, layerID - 1 );
										break;
									case Tool.Unfill:
										heightmap.Paint( pixel.X, pixel.Y, -heightmap.groundCursorStrength / 100f, layerID - 1 );
										break;
								}
							}
						}
					}
				}
			} else if( heightmap.bShowCursor )
				heightmap.bShowCursor = false;
		}

		public void GetHeightmapData() {
			DropDownTexture.Items.Clear();

			string currentDir = Application.StartupPath;
			string[] textureFiles = Directory.GetFiles( currentDir + "\\content\\textures\\terrain" );

			foreach( string thisFile in textureFiles )
				DropDownTexture.Items.Add( thisFile.Substring( currentDir.Length + "\\content\\textures\\terrain\\".Length, thisFile.Length - 4 - currentDir.Length - "\\content\\textures\\terrain\\".Length ) );

			foreach( string customTex in heightmap.customTexture )
				DropDownTexture.Items.Add( customTex );

			DropDownTexture.Text = "";


			ListeTextures.Items.Clear();

			//Get current layers settings
			for( int i = 0; i < Editor.heightmap.textureLayer.Length; i++ ) {
				string[] layerItems = new string[ 3 ];

				if( i == 0 )
					layerItems[ 0 ] = "detail";
				else
					layerItems[ 0 ] = "layer" + i;

				layerItems[ 1 ] = Editor.heightmap.textureLayer[ i ].layerTex;
				layerItems[ 2 ] = Editor.heightmap.textureLayer[ i ].scale.ToString();

				ListViewItem item = new ListViewItem( layerItems );
				ListeTextures.Items.Add( item );
			}
		}

		private void DropDownTexture_SelectedIndexChanged( object sender, EventArgs e ) {
			if( layerID != -1 ) {
				Editor.heightmap.textureLayer[ layerID ].layerTex = DropDownTexture.Text;
				ListeTextures.Items[ layerID ].SubItems[ 1 ].Text = Editor.heightmap.textureLayer[ layerID ].layerTex;
				Editor.heightmap.LoadTextures();
				Editor.heightmap.UpdateTextures();
			}
		}

		private void trackBar4_Scroll( object sender, EventArgs e ) {
			if( layerID != -1 ) {
				Editor.heightmap.textureLayer[ layerID ].scale = SlideTextureScale.Value;
				ListeTextures.Items[ layerID ].SubItems[ 2 ].Text = Editor.heightmap.textureLayer[ layerID ].scale.ToString();
				Editor.heightmap.UpdateEffect();
			}
		}

		protected override void OnClosed( EventArgs e ) {
			heightmap.bShowCursor = false;
			base.OnClosed( e );
		}

		private void BtnTextureImport_Click( object sender, EventArgs e ) {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.Filter = "All Images|*.bmp;*.jpg;*.dds;*.tga|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|DirectDraw Surface (*.dds)|*.dds|Truevision TGA (*.tga)|*.tga|*.*|*.*";
			openFileDialog.ShowDialog();

			if( openFileDialog.FileName != "" ) {
				//Add to custom textures list (Texture2D.FromFile)
				if( !FoundInList( openFileDialog.FileName ) )
					Editor.heightmap.customTexture.Add( openFileDialog.FileName );

				if( ListeTextures.SelectedItems.Count > 0 ) {
					Editor.heightmap.textureLayer[ layerID ].layerTex = openFileDialog.FileName;
					Editor.heightmap.LoadTextures();
					Editor.heightmap.UpdateTextures();
				} else
					GetHeightmapData();
			}
		}

		private bool FoundInList( string s ) {
			for( int i = 0; i < Editor.heightmap.customTexture.Count; i++ ) {
				if( Editor.heightmap.customTexture[ i ] == s )
					return true;
			}

			return false;
		}

		private void DropDownTexture_KeyUp( object sender, KeyEventArgs e ) {
			DropDownTexture.Text = ListeTextures.FindItemWithText( ListeTextures.Items[ layerID ].Text ).SubItems[ 1 ].Text;
		}

		private void DropDownTexture_KeyDown( object sender, KeyEventArgs e ) {
			DropDownTexture.Text = ListeTextures.FindItemWithText( ListeTextures.Items[ layerID ].Text ).SubItems[ 1 ].Text;
		}

		private void ListeTextures_ItemSelectionChanged( object sender, ListViewItemSelectionChangedEventArgs e ) {
			if( ListeTextures.SelectedItems.Count > 0 ) {
				layerID = ListeTextures.SelectedItems[ 0 ].Index;
				Editor.heightmap.currentLayer = layerID;
				DropDownTexture.Text = ListeTextures.FindItemWithText( ListeTextures.Items[ layerID ].Text ).SubItems[ 1 ].Text;
				SlideTextureScale.Value = (int)Editor.heightmap.textureLayer[ layerID ].scale;
				Editor.console.Add( "LayerID : " + layerID + " selected" );
			} else
				layerID = -1;
		}
	}
}