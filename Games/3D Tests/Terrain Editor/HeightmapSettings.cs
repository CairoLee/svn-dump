using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ragnarok3D.Editor {
	public partial class HeightmapSettings : Form {
		List<string> skybox;
		string selectedSky = string.Empty;

		public CustomSize customSize;

		public Vector2 mapSize = new Vector2( 64f, 64f );
		public Vector2 tileSize = new Vector2( 50f, 50f );
		public float mapHeight = 500f;

		public HeightmapSettings() {
			InitializeComponent();
		}

		private void GetSkyboxes() {
			//Retreive Available Skyboxes
			skybox = new List<string>();
			string[] skyboxes = Directory.GetFiles( Editor.AppPath + "\\content\\textures\\skybox" );

			ListSkyTextures.Items.Clear();

			for( int i = 0; i < skyboxes.Length; i++ ) {
				string finalName = string.Empty;
				string[] skyName = skyboxes[ i ].Split( '\\' );
				finalName = skyName[ skyName.Length - 1 ];
				finalName = finalName.Substring( 0, finalName.Length - 4 );
				char[] trimmers = { '_' };
				string[] strSplit = finalName.Split( '_' );
				finalName = strSplit[ 0 ];

				if( skybox.Count > 0 ) {
					bool bFoundSimilar = false;
					for( int j = 0; j < skybox.Count; j++ ) {
						if( skybox[ j ] == finalName ) {
							bFoundSimilar = true;
						}
					}
					if( !bFoundSimilar ) {
						skybox.Add( finalName );
						ListSkyTextures.Items.Add( finalName );
					}
				} else {
					skybox.Add( finalName );
					ListSkyTextures.Items.Add( finalName );
				}
			}

			//lstSkybox.Text = Game1.skybox.name;
			ListSkyTextures.SelectedIndex = ListSkyTextures.FindString( Editor.skybox.name );
			selectedSky = ListSkyTextures.SelectedItem.ToString();
		}

		public void GetHeightmapData() {
			if( Editor.heightmap != null ) {
				ChkMapSmoothing.Checked = Editor.heightmap.bSmooth;

				SlideCellWidth.Value = (int)Editor.heightmap.cellSize.X;
				SlideCellHeight.Value = (int)Editor.heightmap.cellSize.Y;
				SlideMaxHeight.Value = (int)Editor.heightmap.maxHeight;

				InputCellWidth.Value = SlideCellWidth.Value;
				InputCellHeight.Value = SlideCellHeight.Value;
				InputMaxHeight.Value = SlideMaxHeight.Value;

				//lblHeightmap.Text = heightmap.heightmapFile;

				string currentDir = Directory.GetCurrentDirectory();

				//Get current fog settings
				LblFogColor.ForeColor = System.Drawing.Color.FromArgb( (int)( Editor.graphics.GraphicsDevice.RenderState.FogColor.ToVector4().W * 255f ), (int)( Editor.graphics.GraphicsDevice.RenderState.FogColor.ToVector4().X * 255f ), (int)( Editor.graphics.GraphicsDevice.RenderState.FogColor.ToVector4().Y * 255f ), (int)( Editor.graphics.GraphicsDevice.RenderState.FogColor.ToVector4().Z * 255f ) );
				LblFogColor.BackColor = LblFogColor.ForeColor;
				SlideFogStart.Value = (int)Editor.graphics.GraphicsDevice.RenderState.FogStart;
				SlideFogEnd.Value = (int)Editor.graphics.GraphicsDevice.RenderState.FogEnd;
				SlideFogDesinty.Value = (int)Editor.graphics.GraphicsDevice.RenderState.FogDensity;

				SlideWaterHeight.Value = Math.Max( 1, (int)( Editor.waterHeight / Editor.heightmap.maxHeight * 1000f ) );

				ChkDrawSkybox.Checked = Editor.bDrawSkybox;
				ChkWaterDraw.Checked = Editor.bDrawWater;
				ChkFogUse.Checked = Editor.bUseFog;

				//comboBox1.Text = Game1.fogMode.ToString();

				//comboBox1.Items.Add("None");
				//comboBox1.Items.Add("Linear");
				//comboBox1.Items.Add("Exponent");
				//comboBox1.Items.Add("ExponentSquared");

				ChkDrawDetail.Checked = Editor.heightmap.bDrawDetail;

				SlideSunItensity.Value = (int)( Editor.sun.lightPower * 10f );

				//checkBox4.Checked = Game1.water.bFollowCamera;

				SlideAmbientLight.Value = (int)( Editor.heightmap.ambientLight.Length() / 2f * 100f );
			}
		}

		private void GetSunData() {
			if( Editor.sun != null ) {
				SlideSunAngle.Value = (int)MathHelper.ToDegrees( Editor.sun.rotation.X );
				SlideSunElevation.Value = (int)MathHelper.ToDegrees( Editor.sun.rotation.Y );
				ChkSunVisible.Checked = Editor.bDrawSun;

				InputSunLongitude.Value = (decimal)( (float)Editor.sun.LongitudeSpeed * 100f );
				InputSunLatitude.Value = (decimal)( (float)Editor.sun.LatitudeSpeed * 100f );

				ChkSunRayCollision.Checked = Editor.sun.bCheckTerrainCollision;
			}
		}

		private void HeightmapSettings_Load( object sender, EventArgs e ) {
			openFileDialog1.InitialDirectory = Editor.AppPath;
			saveFileDialog1.InitialDirectory = Editor.AppPath;

			SlideCellWidth.Value = (int)tileSize.X;
			SlideCellHeight.Value = (int)tileSize.Y;
			SlideMaxHeight.Value = (int)mapHeight;
			InputCellWidth.Value = SlideCellWidth.Value;
			InputCellHeight.Value = SlideCellHeight.Value;
			InputMaxHeight.Value = SlideMaxHeight.Value;

			GetSkyboxes();
			GetHeightmapData();
			GetSunData();
		}

		private void SlideCellWidth_Scroll( object sender, EventArgs e ) {
			InputCellWidth.Value = SlideCellWidth.Value;

			if( Editor.heightmap != null ) {
				Editor.heightmap.cellSize.X = SlideCellWidth.Value;
				ResetHeightmap();
			}
		}

		private void SlideMaxHeight_Scroll( object sender, EventArgs e ) {
			InputMaxHeight.Value = SlideMaxHeight.Value;

			if( Editor.heightmap != null ) {
				Editor.heightmap.maxHeight = SlideMaxHeight.Value;
				Editor.waterHeight = SlideWaterHeight.Value / 1000f * Editor.heightmap.maxHeight;
				ResetHeightmap();
			}
		}

		private void ChkMapSmoothing_CheckedChanged( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				Editor.heightmap.bSmooth = ChkMapSmoothing.Checked;
				ResetHeightmap();
			}
		}

		private void ResetHeightmap() {
			if( Editor.heightmap != null ) {
				Editor.heightmap.quadTree = null;
				Editor.heightmap.CalculateHeightmap();
			}
		}

		private void LblFogColor_Click( object sender, EventArgs e ) {
			colorDialog1.ShowDialog();

			LblFogColor.ForeColor = colorDialog1.Color;
			LblFogColor.BackColor = colorDialog1.Color;

			Editor.fogColor = new Microsoft.Xna.Framework.Graphics.Color( new Microsoft.Xna.Framework.Vector4( (float)colorDialog1.Color.R / 255, (float)colorDialog1.Color.G / 255, (float)colorDialog1.Color.B / 255, 1.0f ) );
			Editor.graphics.GraphicsDevice.RenderState.FogColor = Editor.fogColor;
		}

		private void SlideFogStart_Scroll( object sender, EventArgs e ) {
			if( SlideFogStart.Value > SlideFogEnd.Value )
				SlideFogEnd.Value = SlideFogStart.Value + 1;

			Editor.fogStart = SlideFogStart.Value;
			Editor.graphics.GraphicsDevice.RenderState.FogStart = Editor.fogStart;
		}

		private void SlideFogEnd_Scroll( object sender, EventArgs e ) {
			if( SlideFogEnd.Value < SlideFogStart.Value )
				SlideFogStart.Value = SlideFogEnd.Value - 1;

			Editor.fogEnd = SlideFogEnd.Value;
			Editor.graphics.GraphicsDevice.RenderState.FogEnd = Editor.fogEnd;
		}

		private void SlideFogDesinty_Scroll( object sender, EventArgs e ) {
			Editor.fogDensity = (float)SlideFogDesinty.Value / 100f;
			Editor.graphics.GraphicsDevice.RenderState.FogDensity = Editor.fogDensity;
		}

		private void saveToolStripMenuItem_Click( object sender, EventArgs e ) {
			SaveTerrain( Editor.mapName );
		}

		private void closeSettingsToolStripMenuItem_Click( object sender, EventArgs e ) {
			this.Visible = false;
		}

		#region NewMap menu
		private void xsmall64x64ToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.paintTools != null )
				Editor.paintTools.Close();
			if( Editor.heightTools != null )
				Editor.heightTools.Close();
			Editor.heightmap = new Heightmap( new Vector2( (float)SlideCellWidth.Value, (float)SlideCellHeight.Value ) );
			Editor.heightmap.maxHeight = (float)SlideMaxHeight.Value;
			Editor.heightmap.CreateNewHeightmap( Heightmap.MapSize.XSmall, null );
			GetHeightmapData();
			Editor.mapName = string.Empty;
			Editor.water = new Water( null, true );

			SlideCellWidth.Enabled = false;
			SlideCellHeight.Enabled = false;
			InputCellWidth.Enabled = false;
			InputCellHeight.Enabled = false;

			//ResetCamera();
		}
		private void small128x128ToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.paintTools != null )
				Editor.paintTools.Close();
			if( Editor.heightTools != null )
				Editor.heightTools.Close();
			Editor.heightmap = new Heightmap( new Vector2( (float)SlideCellWidth.Value, (float)SlideCellHeight.Value ) );
			Editor.heightmap.maxHeight = (float)SlideMaxHeight.Value;
			Editor.heightmap.CreateNewHeightmap( Heightmap.MapSize.Small, null );
			GetHeightmapData();
			Editor.mapName = string.Empty;
			Editor.water = new Water( null, true );
			//ResetCamera();

			SlideCellWidth.Enabled = false;
			SlideCellHeight.Enabled = false;
			InputCellWidth.Enabled = false;
			InputCellHeight.Enabled = false;
		}
		private void medium256x256ToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.paintTools != null )
				Editor.paintTools.Close();
			if( Editor.heightTools != null )
				Editor.heightTools.Close();
			Editor.heightmap = new Heightmap( new Vector2( (float)SlideCellWidth.Value, (float)SlideCellHeight.Value ) );
			Editor.heightmap.maxHeight = (float)SlideMaxHeight.Value;
			Editor.heightmap.CreateNewHeightmap( Heightmap.MapSize.Medium, null );
			GetHeightmapData();
			Editor.mapName = string.Empty;
			Editor.water = new Water( null, true );
			//ResetCamera();

			SlideCellWidth.Enabled = false;
			SlideCellHeight.Enabled = false;
			InputCellWidth.Enabled = false;
			InputCellHeight.Enabled = false;
		}

		private void large512x512ToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.paintTools != null )
				Editor.paintTools.Close();
			if( Editor.heightTools != null )
				Editor.heightTools.Close();
			Editor.heightmap = new Heightmap( new Vector2( (float)SlideCellWidth.Value, (float)SlideCellHeight.Value ) );
			Editor.heightmap.maxHeight = (float)SlideMaxHeight.Value;
			Editor.heightmap.CreateNewHeightmap( Heightmap.MapSize.Large, null );
			GetHeightmapData();
			Editor.mapName = string.Empty;
			Editor.water = new Water( null, true );
			//ResetCamera();
		}

		private void xlarge1024x1024ToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.paintTools != null )
				Editor.paintTools.Close();
			if( Editor.heightTools != null )
				Editor.heightTools.Close();
			Editor.heightmap = new Heightmap( new Vector2( (float)SlideCellWidth.Value, (float)SlideCellHeight.Value ) );
			Editor.heightmap.maxHeight = (float)SlideMaxHeight.Value;
			Editor.heightmap.CreateNewHeightmap( Heightmap.MapSize.XLarge, null );
			GetHeightmapData();
			Editor.mapName = string.Empty;
			Editor.water = new Water( null, true );
			//ResetCamera();
		}

		private void ResetCamera() {
			Vector3 center = new Vector3( Editor.heightmap.center.X, 0f, Editor.heightmap.center.Z );
			Vector3 centerNormal = Vector3.Zero;
			Editor.heightmap.GetGroundHeight( Editor.heightmap.center, out center.Y, out centerNormal );
			center.Y += 300f;
			Editor.camera.position = center;
		}

		#endregion

		private void customSizeToolStripMenuItem_Click( object sender, EventArgs e ) {
			customSize = new CustomSize( this );
			customSize.Visible = true;
		}

		private void heightToolsToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				if( Editor.paintTools != null )
					Editor.paintTools.Close();

				if( Editor.heightTools == null || !Editor.heightTools.Visible ) {
					Editor.heightTools = new HeightTools( Editor.heightmap );
					Editor.heightTools.Visible = true;
				}
			}
		}

		private void textureToolsToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				if( Editor.heightTools != null )
					Editor.heightTools.Close();

				if( Editor.paintTools == null || !Editor.paintTools.Visible ) {
					Editor.paintTools = new PaintTools( Editor.heightmap );
					Editor.paintTools.Visible = true;
				}
			}
		}

		private void solidToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				Editor.heightmap.currentTechnique = "TransformTexture";
				wireframeToolStripMenuItem.Checked = false;
				solidWireframeToolStripMenuItem.Checked = false;
				solidToolStripMenuItem.Checked = true;
			}
		}

		private void smoothMapToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.SmoothHeightmap();
		}

		private void randomNoiseToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.RandomizeHeight( Heightmap.GenerationType.Random, 3, false );
		}

		private void perlinNoiseToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.RandomizeHeight( Heightmap.GenerationType.PerlinNoise, 5, false );
		}

		private void randomNoiseToolStripMenuItem1_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.RandomizeHeight( Heightmap.GenerationType.Random, 3, true );
		}

		private void perlinNoiseToolStripMenuItem1_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.RandomizeHeight( Heightmap.GenerationType.PerlinNoise, 5, true );
		}

		private void SlideWaterHeight_Scroll( object sender, EventArgs e ) {
			if( Editor.water != null ) {
				if( Editor.heightmap != null )
					Editor.waterHeight = SlideWaterHeight.Value / 1000f * Editor.heightmap.maxHeight;
				else
					Editor.waterHeight = SlideWaterHeight.Value / 1000f * 500f;
			}
		}

		private void SlideCellHeight_Scroll( object sender, EventArgs e ) {
			InputCellHeight.Value = SlideCellHeight.Value;

			if( Editor.heightmap != null ) {
				Editor.heightmap.cellSize.Y = SlideCellHeight.Value;
				ResetHeightmap();
			}
		}

		private void ChkDrawSkybox_CheckedChanged( object sender, EventArgs e ) {
			Editor.bDrawSkybox = ChkDrawSkybox.Checked;
		}

		private void ChkWaterDraw_CheckedChanged( object sender, EventArgs e ) {
			Editor.bDrawWater = ChkWaterDraw.Checked;
		}

		private void ChkFogUse_CheckedChanged( object sender, EventArgs e ) {
			Editor.bUseFog = ChkFogUse.Checked;
		}

		private void openToolStripMenuItem1_Click( object sender, EventArgs e ) {
			openFileDialog1.FileName = "";
			openFileDialog1.Filter = "*.xml|*.xml";
			openFileDialog1.ShowDialog();
			if( openFileDialog1.FileName != "" )
				LoadTerrain( openFileDialog1.FileName );
		}

		private void heightmapToolStripMenuItem_Click( object sender, EventArgs e ) {
			openFileDialog1.FileName = "";
			openFileDialog1.Filter = "All Images|*.bmp;*.jpg;*.dds;*.tga|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|DirectDraw Surface (*.dds)|*.dds|Truevision TGA (*.tga)|*.tga|*.*|*.*";
			openFileDialog1.ShowDialog();

			if( openFileDialog1.FileName != "" ) {
				if( Editor.heightmap == null ) {
					Editor.heightmap = new Heightmap( new Vector2( SlideCellWidth.Value, SlideCellHeight.Value ) );
					Editor.water = new Water( null, true );
				}

				Editor.heightmap.LoadHeightMap( openFileDialog1.FileName );
			}
		}

		private void wireframeToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				solidToolStripMenuItem.Checked = false;
				solidWireframeToolStripMenuItem.Checked = false;
				wireframeToolStripMenuItem.Checked = true;
				Editor.heightmap.currentTechnique = "TransformWireframe";
			}
		}

		private void solidWireframeToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				solidToolStripMenuItem.Checked = false;
				wireframeToolStripMenuItem.Checked = false;
				solidWireframeToolStripMenuItem.Checked = true;
				Editor.heightmap.currentTechnique = "TransformTextureWireframe";
			}
		}

		private void SlideSunAngle_Scroll( object sender, EventArgs e ) {
			Editor.sun.rotation.Y = MathHelper.ToRadians( SlideSunAngle.Value );
		}

		private void SlideSunElevation_Scroll( object sender, EventArgs e ) {
			Editor.sun.rotation.X = MathHelper.ToRadians( SlideSunElevation.Value );
		}

		private void createIslandToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.CreateIsland();
		}

		private void colormapGenerationToolStripMenuItem_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				Editor.heightmap.LoadDefaultTextures();
				Editor.heightmap.GenerateColorMap();
			}
		}

		private void heightmapToolStripMenuItem1_Click( object sender, EventArgs e ) {
			ShowSaveDialog();
			Editor.console.Add( "Saving heightmap as : " + saveFileDialog1.FileName );
			Editor.heightmap.UpdateHeightFile();
			SaveTexture( Editor.heightmap.heightmap, saveFileDialog1.FileName );
		}

		private void colormapToolStripMenuItem_Click( object sender, EventArgs e ) {
			ShowSaveDialog();
			Editor.console.Add( "Saving texture distribution map as : " + saveFileDialog1.FileName );
			SaveTexture( Editor.heightmap.colormap, saveFileDialog1.FileName );
		}

		private void ShowSaveDialog() {
			saveFileDialog1.FileName = string.Empty;
			saveFileDialog1.Filter = "All Images|*.bmp;*.jpg;*.dds;*.tga|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|DirectDraw Surface (*.dds)|*.dds|Truevision TGA (*.tga)|*.tga|*.*|*.*";
			saveFileDialog1.ShowDialog();
		}

		private void SaveTexture( Texture2D texture, string filename ) {
			string format = filename.Substring( filename.Length - 3, 3 ).ToLower().Trim();

			try {
				switch( format ) {
					case "bmp":
						texture.Save( filename, ImageFileFormat.Bmp );
						break;
					case "dds":
						texture.Save( filename, ImageFileFormat.Dds );
						break;
					case "jpg":
						texture.Save( filename, ImageFileFormat.Jpg );
						break;
					case "tga":
						texture.Save( filename, ImageFileFormat.Tga );
						break;
				}
			} catch( Exception ex ) {
				Console.WriteLine( "Error: " + ex.Message );
			}
		}

		private void saveAsToolStripMenuItem_Click( object sender, EventArgs e ) {
			saveFileDialog1.FileName = "";
			saveFileDialog1.Filter = "*.xml|*.xml";
			saveFileDialog1.ShowDialog();

			if( saveFileDialog1.FileName != string.Empty ) {
				Editor.mapName = saveFileDialog1.FileName;
				SaveTerrain( saveFileDialog1.FileName );
			}
		}

		private void LoadTerrain( string filename ) {
			if( !File.Exists( filename ) )
				return;

			XMLReader xmlReader = new XMLReader();
			xmlReader.Open( filename );

			Editor.bDrawSkybox = Convert.ToBoolean( xmlReader.GetElementValue( "drawskybox" ) );

			if( Editor.skybox == null )
				Editor.skybox = new Skybox();
			Editor.skybox.LoadTextures( xmlReader.GetElementValue( "skybox" ) );

			//Sun Settings
			Editor.bDrawSun = Convert.ToBoolean( xmlReader.GetElementValue( "drawsun" ) );
			Editor.sun = new Sun( Convert.ToDouble( xmlReader.GetElementValue( "angle" ) ), Convert.ToDouble( xmlReader.GetElementValue( "elevation" ) ) );
			string[] sColor = xmlReader.GetElementValue( "suncolor" ).Split( ';' );
			Editor.sun.color = new Vector3( (float)Convert.ToDouble( sColor[ 0 ] ), (float)Convert.ToDouble( sColor[ 1 ] ), (float)Convert.ToDouble( sColor[ 2 ] ) );
			Editor.sun.LongitudeSpeed = Convert.ToDouble( xmlReader.GetElementValue( "longitudespeed" ) );
			Editor.sun.LatitudeSpeed = Convert.ToDouble( xmlReader.GetElementValue( "latitudespeed" ) );
			Editor.sun.lightPower = (float)Convert.ToDouble( xmlReader.GetElementValue( "intensity" ) );
			Editor.sun.bCheckTerrainCollision = Convert.ToBoolean( xmlReader.GetElementValue( "sunraycollision" ) );

			//Fog Settings
			Editor.bUseFog = Convert.ToBoolean( xmlReader.GetElementValue( "usefog" ) );
			string[] fColor = xmlReader.GetElementValue( "fogcolor" ).Split( ';' );
			Microsoft.Xna.Framework.Graphics.Color fogColor = new Microsoft.Xna.Framework.Graphics.Color( new Vector3( (float)Convert.ToDouble( fColor[ 0 ] ), (float)Convert.ToDouble( fColor[ 1 ] ), (float)Convert.ToDouble( fColor[ 2 ] ) ) );
			Console.WriteLine( "FogColor: " + fogColor.ToString() );
			Editor.fogColor = fogColor;
			Editor.fogStart = (float)Convert.ToDouble( xmlReader.GetElementValue( "fogstart" ) );
			Editor.fogEnd = (float)Convert.ToDouble( xmlReader.GetElementValue( "fogend" ) );
			Editor.fogDensity = (float)Convert.ToDouble( xmlReader.GetElementValue( "fogdensity" ) );

			Editor.InitFog();

			//Heightmap
			if( xmlReader.GetElementValue( "heightmap" ) != string.Empty ) {
				string[] cSize = xmlReader.GetElementValue( "cellsize" ).Split( ';' );
				Editor.heightmap = new Heightmap( new Vector2( (float)Convert.ToDouble( cSize[ 0 ] ), (float)Convert.ToDouble( cSize[ 1 ] ) ) );
				Editor.water = new Water( null, true );

				Editor.heightmap.LoadHeightMap( xmlReader.GetElementValue( "heightmap" ) );
				Editor.heightmap.LoadColormap( xmlReader.GetElementValue( "colormap" ) );

				Editor.heightmap.maxHeight = (float)Convert.ToDouble( xmlReader.GetElementValue( "maxheight" ) );
				Editor.heightmap.bSmooth = Convert.ToBoolean( xmlReader.GetElementValue( "smooth" ) );
				Editor.heightmap.bDrawDetail = Convert.ToBoolean( xmlReader.GetElementValue( "drawdetail" ) );
				string[] aLight = xmlReader.GetElementValue( "ambientlight" ).Split( ';' );
				Editor.heightmap.ambientLight = new Vector3();
				Editor.heightmap.ambientLight.X = (float)Convert.ToDouble( aLight[ 0 ] );
				Editor.heightmap.ambientLight.Y = (float)Convert.ToDouble( aLight[ 1 ] );
				Editor.heightmap.ambientLight.Z = (float)Convert.ToDouble( aLight[ 2 ] );

				//Texture Layers
				for( int i = 0; i < 4; i++ ) {
					Editor.heightmap.textureLayer[ i ].layerTex = xmlReader.GetElementValue( "layer" + i + "tex" );
					Editor.heightmap.textureLayer[ i ].scale = (float)Convert.ToDouble( xmlReader.GetElementValue( "layer" + i + "texScale" ) );
				}

				Editor.heightmap.Init();
			}

			GetSkyboxes();
			GetSunData();
			GetHeightmapData();

		}

		private void SaveTerrain( string filename ) {
			if( File.Exists( filename ) )
				File.Delete( filename );

			XMLReader xmlReader = new XMLReader();
			xmlReader.CreateDocument();
			xmlReader.SetRoot( "Terrain" );

			xmlReader.AddElement( "drawskybox", Editor.bDrawSkybox.ToString() );
			xmlReader.AddElement( "skybox", selectedSky );

			if( Editor.heightmap != null ) {
				Editor.heightmap.UpdateHeightFile();

				//Heightmap Texture
				string title = Path.GetFileNameWithoutExtension( filename );
				Editor.heightmap.heightmap.Save( title + "_height.bmp", ImageFileFormat.Bmp );
				xmlReader.AddElement( "heightmap", title + "_height.bmp" );

				//Colormap Texture
				Editor.heightmap.colormap.Save( title + "_color.tga", ImageFileFormat.Tga );
				xmlReader.AddElement( "colormap", title + "_color.tga" );

				//Heightmap Settings
				xmlReader.AddElement( "cellsize", Editor.heightmap.cellSize.X + ";" + Editor.heightmap.cellSize.Y );
				xmlReader.AddElement( "maxheight", Editor.heightmap.maxHeight.ToString() );
				xmlReader.AddElement( "smooth", Editor.heightmap.bSmooth.ToString() );
				xmlReader.AddElement( "drawdetail", Editor.heightmap.bDrawDetail.ToString() );
				xmlReader.AddElement( "ambientlight", Editor.heightmap.ambientLight.X + ";" + Editor.heightmap.ambientLight.Y + ";" + Editor.heightmap.ambientLight.Z );

				//Texture Layers Settings
				if( Editor.heightmap.textureLayer != null ) {
					for( int i = 0; i < Editor.heightmap.textureLayer.Length; i++ ) {
						xmlReader.AddElement( "layer" + i + "tex", Editor.heightmap.textureLayer[ i ].layerTex );
						xmlReader.AddElement( "layer" + i + "texScale", Editor.heightmap.textureLayer[ i ].scale.ToString().Replace( '.', ';' ) );
					}
				}
			}

			//Sun Settings
			xmlReader.AddElement( "drawsun", Editor.bDrawSun.ToString() );
			xmlReader.AddElement( "suncolor", Editor.sun.color.X + ";" + Editor.sun.color.Y + ";" + Editor.sun.color.Z );
			xmlReader.AddElement( "angle", MathHelper.ToDegrees( Editor.sun.rotation.Y ).ToString() );
			xmlReader.AddElement( "elevation", MathHelper.ToDegrees( Editor.sun.rotation.X ).ToString() );
			xmlReader.AddElement( "longitudespeed", Editor.sun.LongitudeSpeed.ToString() );
			xmlReader.AddElement( "latitudespeed", Editor.sun.LatitudeSpeed.ToString() );
			xmlReader.AddElement( "intensity", Editor.sun.lightPower.ToString() );
			xmlReader.AddElement( "sunraycollision", ChkSunRayCollision.Checked.ToString() );

			//Fog Settings
			xmlReader.AddElement( "usefog", Editor.bUseFog.ToString() );
			xmlReader.AddElement( "fogcolor", Editor.fogColor.ToVector3().X + ";" + Editor.fogColor.ToVector3().Y + ";" + Editor.fogColor.ToVector3().Z );
			xmlReader.AddElement( "fogstart", Editor.fogStart.ToString() );
			xmlReader.AddElement( "fogend", Editor.fogEnd.ToString() );
			xmlReader.AddElement( "fogdensity", Editor.fogDensity.ToString() );

			xmlReader.Save( filename );

			Editor.console.Add( "File saved successfuly!" );
		}

		private void ChkDrawDetail_CheckedChanged( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.bDrawDetail = ChkDrawDetail.Checked;
		}

		private void ChkSunVisible_CheckedChanged( object sender, EventArgs e ) {
			Editor.bDrawSun = ChkSunVisible.Checked;
		}

		private void SlideSunItensity_Scroll( object sender, EventArgs e ) {
			if( Editor.sun != null )
				Editor.sun.lightPower = SlideSunItensity.Value * 0.1f;
		}

		private void InputSunLongitude_ValueChanged( object sender, EventArgs e ) {
			if( Editor.sun != null )
				Editor.sun.LongitudeSpeed = (float)InputSunLongitude.Value * 0.01f;
		}

		private void InputSunLatitude_ValueChanged( object sender, EventArgs e ) {
			if( Editor.sun != null )
				Editor.sun.LatitudeSpeed = (float)InputSunLatitude.Value * 0.01f;
		}

		private void ListSkyTextures_SelectedIndexChanged( object sender, EventArgs e ) {
			selectedSky = ListSkyTextures.SelectedItem.ToString();
			Editor.skybox.LoadTextures( selectedSky );
		}

		private void HeightmapSettings_FormClosed( object sender, FormClosedEventArgs e ) {
			Editor.settings = null;
		}

		private void InputMaxHeight_ValueChanged( object sender, EventArgs e ) {
			SlideMaxHeight.Value = (int)InputMaxHeight.Value;
			this.SlideMaxHeight_Scroll( sender, e );
		}

		private void InputCellHeight_ValueChanged( object sender, EventArgs e ) {
			SlideCellHeight.Value = (int)InputCellHeight.Value;
			this.SlideCellHeight_Scroll( sender, e );
		}

		private void InputCellWidth_ValueChanged( object sender, EventArgs e ) {
			SlideCellWidth.Value = (int)InputCellWidth.Value;
			this.SlideCellWidth_Scroll( sender, e );
		}

		private void colormapToolStripMenuItem1_Click( object sender, EventArgs e ) {
			if( Editor.heightmap != null ) {
				openFileDialog1.FileName = "";
				openFileDialog1.Filter = "All Images|*.bmp;*.jpg;*.dds;*.tga|Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|DirectDraw Surface (*.dds)|*.dds|Truevision TGA (*.tga)|*.tga|*.*|*.*";
				openFileDialog1.ShowDialog();

				if( openFileDialog1.FileName != "" )
					Editor.heightmap.LoadColormap( openFileDialog1.FileName );
			}
		}

		private void fileToolStripMenuItem_DropDownOpening( object sender, EventArgs e ) {
			if( Editor.heightmap == null ) {
				//saveToolStripMenuItem.Enabled = false;
				//saveAsToolStripMenuItem.Enabled = false;                
				heightmapToolStripMenuItem1.Enabled = false;
				colormapToolStripMenuItem.Enabled = false;
				colormapToolStripMenuItem1.Enabled = false;
			} else {
				//saveToolStripMenuItem.Enabled = true;
				//saveAsToolStripMenuItem.Enabled = true;
				heightmapToolStripMenuItem1.Enabled = true;
				colormapToolStripMenuItem.Enabled = true;
				colormapToolStripMenuItem1.Enabled = true;
			}

			if( Editor.mapName == string.Empty )
				saveToolStripMenuItem.Enabled = false;
			else
				saveToolStripMenuItem.Enabled = true;
		}

		private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
			Editor.bExit = true;
		}

		private void toolsToolStripMenuItem_DropDownOpening( object sender, EventArgs e ) {
			if( Editor.heightmap == null ) {
				heightToolsToolStripMenuItem.Enabled = false;
				textureToolsToolStripMenuItem.Enabled = false;
				randomNoiseToolStripMenuItem.Enabled = false;
				perlinNoiseToolStripMenuItem.Enabled = false;
				randomNoiseToolStripMenuItem1.Enabled = false;
				perlinNoiseToolStripMenuItem1.Enabled = false;
				createIslandToolStripMenuItem.Enabled = false;
				colormapGenerationToolStripMenuItem.Enabled = false;
				smoothMapToolStripMenuItem.Enabled = false;
			} else {
				heightToolsToolStripMenuItem.Enabled = true;
				textureToolsToolStripMenuItem.Enabled = true;
				randomNoiseToolStripMenuItem.Enabled = true;
				perlinNoiseToolStripMenuItem.Enabled = true;
				randomNoiseToolStripMenuItem1.Enabled = true;
				perlinNoiseToolStripMenuItem1.Enabled = true;
				createIslandToolStripMenuItem.Enabled = true;
				colormapGenerationToolStripMenuItem.Enabled = true;
				smoothMapToolStripMenuItem.Enabled = true;
			}
		}

		public void CreateMap() {
			Editor.heightmap = new Heightmap( tileSize );
			Editor.heightmap.maxHeight = mapHeight;
			Editor.heightmap.CreateNewHeightmap( null, new Microsoft.Xna.Framework.Point( (int)mapSize.X, (int)mapSize.Y ) );
			Editor.water = new Water( null, true );
		}

		private void SlideAmbientLight_Scroll( object sender, EventArgs e ) {
			if( Editor.heightmap != null )
				Editor.heightmap.ambientLight = Vector3.One * (float)SlideAmbientLight.Value / 100f * 2f;
		}

		private void ChkSunRayCollision_CheckedChanged( object sender, EventArgs e ) {
			Editor.sun.bCheckTerrainCollision = ChkSunRayCollision.Checked;
		}

		private void lightmapToolStripMenuItem_Click( object sender, EventArgs e ) {
			ShowSaveDialog();
			Editor.console.Add( "Saving texture distribution map as : " + saveFileDialog1.FileName );
			SaveTexture( Editor.heightmap.lightMap, saveFileDialog1.FileName );
		}

		private void normalmapToolStripMenuItem_Click( object sender, EventArgs e ) {
			ShowSaveDialog();
			Editor.console.Add( "Saving texture distribution map as : " + saveFileDialog1.FileName );
			SaveTexture( Editor.heightmap.normalMap, saveFileDialog1.FileName );
		}

		private void toolStripMenuItem1_Click( object sender, EventArgs e ) {
			Editor.heightmap = null;
			SlideCellWidth.Enabled = true;
			SlideCellHeight.Enabled = true;
			InputCellWidth.Enabled = true;
			InputCellHeight.Enabled = true;
		}

		private void tabPage5_Click( object sender, EventArgs e ) {
			if( Editor.heightmap == null ) {
				LblWaterHeight.ForeColor = System.Drawing.Color.LightGray;
				return;
			}

			SlideWaterHeight.Enabled = true;
			LblWaterHeight.ForeColor = System.Drawing.Color.White;
		}
	}
}