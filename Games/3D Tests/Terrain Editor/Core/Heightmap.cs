using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ragnarok3D.Editor {
	public class Heightmap {
		#region Globals
		private Color[] bits;
		private VertexDeclaration vertexDeclaration;
		private VertexBuffer vertexBuffer;
		private IndexBuffer indexBuffer;
		public VertexPositionNormalTexture[] heightmapVertices;
		public short[] heightmapIndices;

		public QuadTree quadTree;

		public BoundingBox[] collisionArea;

		public bool bUpdateAndDraw = false;

		//Triangles used for the ray intersection detection
		public Tri[] triangle;
		public struct Tri {
			public int id;
			public Vector3 p1;
			public Vector3 p2;
			public Vector3 p3;
			public Vector3 normal;
		}

		public Vector3 position;

		public Texture2D heightmap;
		public string heightmapFile;

		public Layer[] textureLayer;
		public struct Layer {
			public Layer( string textureName, float textureScale ) {
				this.texture = null;
				this.layerTex = textureName;
				this.tag = string.Empty;
				this.scale = textureScale;
			}
			public Texture2D texture;
			public string layerTex;
			public string tag;
			public float scale;
		}

		public List<string> customTexture;

		public Texture2D normalMap;
		public Texture2D colormap;
		public Texture2D lightMap;
		public string strColormapTex;
		public string strLightmapTex;
		Color[] lightmapBits;
		Color[] normalBits;
		Color[] colorBits;

		Texture2D decalMap;
		Color[] decalBits;

		public bool bSmooth = true;
		public bool bDrawDetail = true;

		public Vector3 ambientLight = new Vector3( 0.25f, 0.25f, 0.25f );

		private Matrix world;

		private Effect effect;

		private EffectParameter worldViewProjParam;
		private EffectParameter worldParam;
		private EffectParameter viewParam;

		private EffectParameter colormapParam;
		private EffectParameter lightMapParam;
		private EffectParameter normalMapParam;
		private EffectParameter decalMapParam;
		private EffectParameter[] textureParam;
		private EffectParameter[] textureScaleParam;
		private EffectParameter DrawDetailParam;

		private EffectParameter ambientLightParam;
		private EffectParameter lightPositionParam;
		private EffectParameter lightDirectionParam;
		private EffectParameter lightPowerParam;

		private EffectParameter cameraPositionParam;
		private EffectParameter cameraDirectionParam;

		private EffectParameter groundCursorPositionParam;
		private EffectParameter groundCursorTextureParam;
		private EffectParameter groundCursorSizeParam;
		private EffectParameter showCursorParam;

		private EffectParameter useSunParam;
		private EffectParameter sunColorParam;

		public Point size; // divisions
		public float Width;
		public float Height;

		public Vector2 cellSize = new Vector2( 50f, 50f );
		public float maxHeight = 500f;

		public Vector3 center;

		public Vector2 heightmapCoords; //Cursor heightmap coordinates
		public int currentLayer = 1;    //Current layer being edited

		public List<Triangle> testTriangle;

		public Vector3 groundCursorPosition = Vector3.Zero;
		public Vector3 lastGroundCursorPos = Vector3.Zero;
		private Texture2D groundCursorTex;
		public int groundCursorSize = 2;
		public int groundCursorStrength = 20;
		public bool bShowCursor = false;
		public float flattenHeight = 0f;

		EffectTechniqueCollection effectTechniques;
		public string currentTechnique = "TransformTexture";

		public float highestPoint = 0f;
		public float lowestPoint = 0f;

		public int lastX = 0;
		public int lastY = 0;
		public float lastHeight = 0f;
		#endregion

		public Heightmap( Vector2 tileSize ) {
			position = Vector3.Zero;
			cellSize = tileSize;

			textureLayer = new Layer[ 5 ];
			textureLayer[ 0 ] = new Layer( "detail02", 50f );
			textureLayer[ 1 ] = new Layer( "grass02", 64f );
			textureLayer[ 2 ] = new Layer( "dirt01", 25f );
			textureLayer[ 3 ] = new Layer( "rock01", 20f );
			textureLayer[ 4 ] = new Layer( "snow01", 25f );

			customTexture = new List<string>();

			groundCursorTex = Editor.Content.Load<Texture2D>( @"Textures\\Icons\\groundCursor" );
			testTriangle = new List<Triangle>();
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightBlue ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightGreen ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightYellow ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightBlue ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightGreen ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightYellow ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightYellow ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightGreen ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightYellow ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightBlue ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightGreen ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightYellow ) );
			testTriangle.Add( new Triangle( new Vector3( 0f, 0f, 0f ), new Vector3( 64f, 0f, 0f ), new Vector3( 64f, 0f, 64f ), Color.LightYellow ) );

			LoadTextures();
			InitEffect();

			Editor.console.Add( "New Heightmap Created" );
		}

		public enum MapSize {
			XSmall,
			Small,
			Medium,
			Large,
			XLarge
		}
		public void CreateNewHeightmap( Nullable<MapSize> mapSize, Nullable<Point> customMapSize ) {
			if( mapSize != null ) {
				switch( mapSize.Value ) {
					case MapSize.XSmall:
						size = new Point( 64, 64 );
						textureLayer[ 4 ].scale = 64;
						break;
					case MapSize.Small:
						size = new Point( 128, 128 );
						textureLayer[ 4 ].scale = 128;
						break;
					case MapSize.Medium:
						size = new Point( 256, 256 );
						textureLayer[ 4 ].scale = 256;
						break;
					case MapSize.Large:
						size = new Point( 512, 512 );
						textureLayer[ 4 ].scale = 512;
						break;
					case MapSize.XLarge:
						size = new Point( 1024, 1024 );
						textureLayer[ 4 ].scale = 1024;
						break;
				}
			} else if( customMapSize != null )
				size = new Point( customMapSize.Value.X, customMapSize.Value.Y );

			Width = size.X * cellSize.X;
			Height = size.Y * cellSize.Y;
			center = new Vector3( Width * .5f, 0f, Height * .5f );

			bits = new Color[ size.X * size.Y ];
			heightmap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 1, TextureUsage.None, SurfaceFormat.Color );
			heightmap.SetData<Color>( bits );

			collisionArea = new BoundingBox[ (int)( size.X / 8f ) * (int)( size.Y / 8f ) ];

			if( colormap == null )
				InitColorMap();

			Init();
			bUpdateAndDraw = true;

			Editor.console.Add( "New Heightmap Created" );
			Editor.console.Add( "Map Size: " + size.ToString() );
			Editor.console.Add( "Tile Size: " + cellSize.ToString() );
		}

		public void LoadHeightMap( string filename ) {
			heightmap = Texture2D.FromFile( Editor.graphics.GraphicsDevice, filename );
			size = new Point( heightmap.Width, heightmap.Height );

			Width = size.X * cellSize.X;
			Height = size.Y * cellSize.Y;

			bits = new Color[ size.X * size.Y ];
			heightmap.GetData<Color>( bits );

			if( colormap == null || colormap.Width != heightmap.Width || colormap.Height != heightmap.Height )
				InitColorMap();

			Init();

			bUpdateAndDraw = true;

			center = new Vector3( Width * .5f, 0f, Height * .5f );
			Vector3 centerNormal = Vector3.Zero;
			GetGroundHeight( center, out center.Y, out centerNormal );

			Editor.console.Add( "Heightmap Loaded [" + filename + "]" );
		}

		private void InitDecalMap() {
			decalMap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 1, TextureUsage.None, SurfaceFormat.Vector4 );
			decalBits = new Color[ size.X * size.Y ];
			decalMap.SetData<Color>( decalBits );
		}

		private void InitColorMap() {
			//Console.WriteLine("Heightmap:InitColorMap");
			colormap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 1, TextureUsage.None, SurfaceFormat.Color );
			colorBits = new Color[ size.X * size.Y ];
			for( int i = 0; i < colorBits.Length; i++ )
				colorBits[ i ] = new Color( new Vector4( 1f, 0f, 0f, 0f ) );

			colormap.SetData<Color>( colorBits );
		}

		private void InitLightMap() {
			lightMap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 1, TextureUsage.None, SurfaceFormat.Vector4 );
			lightmapBits = new Color[ size.X * size.Y ];
			for( int i = 0; i < lightmapBits.Length; i++ )
				lightmapBits[ i ] = new Color( Vector3.One );

			lightMap.SetData<Color>( lightmapBits );
		}

		private void InitNormalMap() {
			normalMap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 1, TextureUsage.None, SurfaceFormat.Vector4 );
			normalBits = new Color[ size.X * size.Y ];
			for( int i = 0; i < normalBits.Length; i++ )
				normalBits[ i ] = new Color( Vector3.Up );

			normalMap.SetData<Color>( normalBits );
		}

		public void Init() {
			LoadTextures();
			CalculateHeightmap();
			InitEffect();
			Update();

			Editor.console.Add( "Heightmap Initialized." );
		}

		public void LoadTextures() {

			for( int i = 0; i < textureLayer.Length; i++ ) {
				//Dont reload the same textures..
				if( textureLayer[ i ].tag != textureLayer[ i ].layerTex ) {
					bool TextureExists = false;
					try {
						textureLayer[ i ].texture = Editor.Content.Load<Texture2D>( @"Textures\Terrain\" + textureLayer[ i ].layerTex );
						TextureExists = true;
					} catch {
						try {
							textureLayer[ i ].texture = Texture2D.FromFile( Editor.graphics.GraphicsDevice, textureLayer[ i ].layerTex );
							TextureExists = true;
						} catch {
							Console.WriteLine( "Texture not found: " + textureLayer[ i ].layerTex );
						}
					}

					if( TextureExists )
						textureLayer[ i ].tag = textureLayer[ i ].layerTex;

				}
			}
		}

		public void LoadColormap( string filename ) {
			if( File.Exists( filename ) ) {
				Texture2D textureFile = Texture2D.FromFile( Editor.graphics.GraphicsDevice, filename );
				if( textureFile.Width == heightmap.Width && textureFile.Height == heightmap.Height ) {
					colormap = Texture2D.FromFile( Editor.graphics.GraphicsDevice, filename );
					colormap.GetData<Color>( colorBits );
					Editor.console.Add( "Colormap Loaded [" + filename + "]" );
				} else {
					Console.WriteLine( "Invalid Size\nSize required: " + size.X + " x " + size.Y );
					textureFile.Dispose();
				}
			}
		}

		public void UpdateHeightFile() {
			heightmap.SetData<Color>( bits );
		}

		public void CalculateHeightmap() {
			SetUpVertices();
			//SetUpCollisionAreas();

			if( bSmooth )
				SmoothVertices();

			CalculateNormals();

			SetVertexBuffer();

			SetUpIndices();
			SetIndexBuffer();
			quadTree = new QuadTree( Width, Height, cellSize, triangle );
			//GenerateNormals();
			//CalculateLightmapNormals();
		}

		private void SetVerticesNormals() {
			for( int i = 0; i < heightmapVertices.Length; i++ ) {
				try {
					Vector3 firstvec = heightmapVertices[ i + 1 ].Position - heightmapVertices[ i ].Position;
					Vector3 secondvec = heightmapVertices[ i ].Position - heightmapVertices[ i + heightmap.Width ].Position;

					Vector3 normal = Vector3.Cross( firstvec, secondvec );
					normal.Normalize();

					heightmapVertices[ i ].Normal += normal;
					heightmapVertices[ i + 1 ].Normal += normal;
					heightmapVertices[ i + heightmap.Width ].Normal += normal;
				} catch( Exception e ) {
					Console.WriteLine( "Error: " + e.Message );
				}
			}

			for( int i = 0; i < heightmapVertices.Length; i++ )
				heightmapVertices[ i ].Normal.Normalize();
		}

		private void SetUpVertices() {
			if( heightmapVertices == null || heightmapVertices.Length != bits.Length )
				heightmapVertices = new VertexPositionNormalTexture[ bits.Length ];

			vertexDeclaration = new VertexDeclaration( Editor.graphics.GraphicsDevice, VertexPositionNormalTexture.VertexElements );
			vertexBuffer = new VertexBuffer( Editor.graphics.GraphicsDevice, typeof( VertexPositionNormalTexture ), bits.Length, BufferUsage.None );

			Vector3 vectorPos = new Vector3();
			highestPoint = 0f;
			lowestPoint = maxHeight;
			int o = 1;
			//string content = "";
			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					if( x == 511 )
						o++;

					float pointHeight = (float)bits[ x + y * size.X ].ToVector4().X;
					vectorPos.X = x * cellSize.X;
					vectorPos.Z = y * cellSize.Y;
					vectorPos.Y = pointHeight * maxHeight;

					if( x >= 512 || y >= 512 )
						Console.WriteLine( "x:" + x + " y:" + y + " pos:" + vectorPos.ToString() );

					heightmapVertices[ x + y * size.X ].Position = vectorPos;
					heightmapVertices[ x + y * size.X ].TextureCoordinate = new Vector2( x / ( size.X / cellSize.X ) / cellSize.X, y / ( size.Y / cellSize.Y ) / cellSize.Y );
					heightmapVertices[ x + y * size.X ].Normal = Vector3.Up;

					//if (x > 250 && y > 250)
					//    content += vectorPos.ToString() + "\n";

					if( pointHeight > highestPoint )
						highestPoint = pointHeight;
					if( pointHeight < lowestPoint )
						lowestPoint = pointHeight;
				}
			}

			//Debugging map bigger than 256x256
			//if(content != "")
			//    File.WriteAllText("vertices_debug.txt", content);
		}

		/// <summary>
		/// Calculate Normals for the entire heightmap
		/// </summary>
		public void CalculateNormals() {
			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					if( x == size.X - 1 || y == size.Y - 1 )
						heightmapVertices[ x + y * size.X ].Normal = Vector3.Up;
					else
						CalculateVertexNormal( x, y );
				}
			}

			//UpdateVertices();
		}

		/// <summary>
		/// Calculate Normal for a specific Vertex
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private void CalculateVertexNormal( int x, int y ) {
			if( x + y * size.X < 0 || x + y * size.X >= bits.Length )
				return;

			Vector3[] corner = new Vector3[ 4 ];
			corner[ 0 ] = heightmapVertices[ x + y * size.X ].Position;

			Vector3 normalA = Vector3.Zero;
			Vector3 normalB = Vector3.Zero;

			int bitID1 = ( x + 1 ) + y * size.X;
			int bitID2 = ( x + 1 ) + ( y + 1 ) * size.X;
			int bitID3 = x + ( y + 1 ) * size.X;

			if( bitID1 >= 0 && bitID1 < bits.Length )
				corner[ 1 ] = heightmapVertices[ bitID1 ].Position;
			if( bitID2 >= 0 && bitID2 < bits.Length )
				corner[ 2 ] = heightmapVertices[ bitID2 ].Position;
			if( bitID3 >= 0 && bitID3 < bits.Length )
				corner[ 3 ] = heightmapVertices[ bitID3 ].Position;

			if( corner[ 1 ] != Vector3.Zero && corner[ 2 ] != Vector3.Zero && corner[ 3 ] != Vector3.Zero ) {
				if( corner[ 1 ] != Vector3.Zero && corner[ 3 ] != Vector3.Zero )
					normalA = new Plane( corner[ 0 ], corner[ 3 ], corner[ 1 ] ).Normal;

				if( corner[ 2 ] != Vector3.Zero && corner[ 2 ] != Vector3.Zero && corner[ 3 ] != Vector3.Zero )
					normalB = new Plane( corner[ 1 ], corner[ 3 ], corner[ 2 ] ).Normal;
			}

			heightmapVertices[ x + y * size.X ].Normal = normalA + normalB;
			heightmapVertices[ x + y * size.X ].Normal.Normalize();

			//Console.WriteLine("Vertex[" + (x + y * size.X) + "] Normal: " + heightmapVertices[x + y * size.X].Normal.ToString());
		}

		public void CalculateLightmapNormals() {
			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					if( heightmapVertices != null && heightmapVertices.Length > 0 )
						CalculateLightBit( x + y * size.X );
				}
			}

			try {
				lightMap.SetData<Color>( lightmapBits );
			} catch( Exception e ) {
				Console.WriteLine( "Error: " + e );
			}
		}

		private void CalculateLightBit( int bitID ) {
			float ambientLight = 0.8f;
			float lightPower = 2.5f;
			float light, dotProduct;

			light = ambientLight;
			dotProduct = Vector3.Dot( Vector3.Normalize( Editor.sun.sunPosition - center ), heightmapVertices[ bitID ].Normal );
			light = ambientLight + dotProduct * lightPower;
			lightmapBits[ bitID ] = new Color( new Vector3( light ) );
		}

		private void SetVertexBuffer() {
			vertexBuffer.SetData<VertexPositionNormalTexture>( heightmapVertices );
		}

		/// <summary>
		/// Change the height of a specific vertex.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private void UpdateVertex( int x, int y ) {
			float pointHeight = (float)bits[ x + y * size.X ].ToVector4().X;

			heightmapVertices[ x + y * size.X ].Position.Y = pointHeight * maxHeight;

			if( pointHeight > highestPoint )
				highestPoint = pointHeight;
			if( pointHeight < lowestPoint )
				lowestPoint = pointHeight;

			SetVertexBuffer();
		}

		/// <summary>
		/// Update the position of all verticies in the hightmap.
		/// </summary>
		public void UpdateVertices() {
			Vector3 vectorPos = new Vector3();
			highestPoint = 0f;

			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					vectorPos.X = x * cellSize.X;
					vectorPos.Z = y * cellSize.Y;
					vectorPos.Y = (float)bits[ x + y * size.X ].ToVector4().X * maxHeight;

					heightmapVertices[ x + y * size.X ].Position = vectorPos;
					heightmapVertices[ x + y * size.X ].TextureCoordinate = new Vector2( x / ( size.X / cellSize.X ) / cellSize.X, y / ( size.Y / cellSize.Y ) / cellSize.Y );
					//heightmapVertices[x + y * size.X].Normal = Vector3.Up;

					if( vectorPos.Y / maxHeight > highestPoint )
						highestPoint = vectorPos.Y / maxHeight;
				}
			}

			if( bSmooth )
				SmoothVertices();

			vertexBuffer.SetData<VertexPositionNormalTexture>( heightmapVertices );
			SetUpIndices();
		}

		/// <summary>
		/// Update the position of a specific list of Verticies.
		/// </summary>
		/// <param name="verticiesToUpdate"></param>
		public void UpdateVertices( List<Point> verticiesToUpdate ) {
			Vector3 vectorPos = new Vector3();
			highestPoint = 0f;
			int pID = 0;
			foreach( Point vec in verticiesToUpdate ) {
				//vectorPos.X = x * cellSize.X;
				//vectorPos.Z = y * cellSize.Y;
				pID = vec.X + vec.Y * size.X;
				if( pID > 0 && pID < bits.Length ) {
					vectorPos.Y = (float)bits[ pID ].ToVector4().X * maxHeight;

					heightmapVertices[ pID ].Position.Y = vectorPos.Y;
					heightmapVertices[ pID ].TextureCoordinate = new Vector2( vec.X / ( size.X / cellSize.X ) / cellSize.X, vec.Y / ( size.Y / cellSize.Y ) / cellSize.Y );
					//heightmapVertices[x + y * size.X].Normal = Vector3.Up;

					if( vectorPos.Y / maxHeight > highestPoint )
						highestPoint = vectorPos.Y / maxHeight;
				}
			}

			if( bSmooth )
				SmoothVertices( verticiesToUpdate );

			vertexBuffer.SetData<VertexPositionNormalTexture>( heightmapVertices );

			//TODO: Why setup the indices again?  If this is necessary? If so, it needs to be optimized!!
			//SetUpIndices();
			//If not making a call to SetUpIndices(), then we still need to Update Collisions
			UpdateCollisions( verticiesToUpdate );
		}

		/// <summary>
		/// Smooth all Verticies in the entire hightmap
		/// </summary>
		private void SmoothVertices() {
			Vector3[] nearVertex = new Vector3[ 5 ];

			for( int y = 1; y < size.Y - 1; y++ ) {
				for( int x = 1; x < size.X - 1; x++ ) {
					nearVertex[ 0 ] = heightmapVertices[ x + y * size.X ].Position;
					nearVertex[ 1 ] = heightmapVertices[ ( x + 1 ) + y * size.X ].Position;
					nearVertex[ 2 ] = heightmapVertices[ ( x - 1 ) + y * size.X ].Position;
					nearVertex[ 3 ] = heightmapVertices[ x + ( y * size.X ) + size.X ].Position;
					nearVertex[ 4 ] = heightmapVertices[ x + ( y * size.X ) + size.X ].Position;

					float dist1 = ( ( nearVertex[ 1 ].Y - nearVertex[ 0 ].Y ) + ( nearVertex[ 2 ].Y - nearVertex[ 0 ].Y ) );
					float dist2 = ( ( nearVertex[ 3 ].Y - nearVertex[ 0 ].Y ) + ( nearVertex[ 4 ].Y - nearVertex[ 0 ].Y ) );
					float dist = ( dist1 + dist2 ) / 6f;

					heightmapVertices[ x + y * size.X ].Position.Y += dist;
				}
			}
		}

		/// <summary>
		/// Smooth a specific list of verticies.
		/// </summary>
		/// <param name="verticiesToUpdate"></param>
		private void SmoothVertices( List<Point> verticiesToUpdate ) {
			Vector3[] nearVertex = new Vector3[ 5 ];

			foreach( Point vec in verticiesToUpdate ) {
				if( vec.X > 0 && vec.Y > 0 && vec.X < size.X - 1 && vec.Y < size.Y - 1 ) {
					nearVertex[ 0 ] = heightmapVertices[ vec.X + vec.Y * size.X ].Position;
					nearVertex[ 1 ] = heightmapVertices[ ( vec.X + 1 ) + vec.Y * size.X ].Position;
					nearVertex[ 2 ] = heightmapVertices[ ( vec.X - 1 ) + vec.Y * size.X ].Position;
					nearVertex[ 3 ] = heightmapVertices[ vec.X + ( vec.Y * size.X ) + size.X ].Position;
					nearVertex[ 4 ] = heightmapVertices[ vec.X + ( vec.Y * size.X ) + size.X ].Position;

					float dist1 = ( ( nearVertex[ 1 ].Y - nearVertex[ 0 ].Y ) + ( nearVertex[ 2 ].Y - nearVertex[ 0 ].Y ) );
					float dist2 = ( ( nearVertex[ 3 ].Y - nearVertex[ 0 ].Y ) + ( nearVertex[ 4 ].Y - nearVertex[ 0 ].Y ) );
					float dist = ( dist1 + dist2 ) / 6f;

					heightmapVertices[ vec.X + vec.Y * size.X ].Position.Y += dist;
				}
			}
		}

		public void GenerateNormals() {
			//normalMap = new Texture2D(Game1.graphics.GraphicsDevice, size.X, size.Y, 1, ResourceUsage.Dynamic, SurfaceFormat.Color, ResourceManagementMode.Manual);
			//normalBits = new Color[size.X * size.Y];

			for( int i = 0; i < heightmapIndices.Length / 3; i++ ) {
				Vector3 firstvec = heightmapVertices[ heightmapIndices[ i * 3 + 1 ] ].Position - heightmapVertices[ heightmapIndices[ i * 3 ] ].Position;
				Vector3 secondvec = heightmapVertices[ heightmapIndices[ i * 3 ] ].Position - heightmapVertices[ heightmapIndices[ i * 3 + 2 ] ].Position;

				Vector3 normal = Vector3.Cross( firstvec, secondvec );
				normal.Normalize();

				heightmapVertices[ heightmapIndices[ i * 3 ] ].Normal += normal;
				heightmapVertices[ heightmapIndices[ i * 3 + 1 ] ].Normal += normal;
				heightmapVertices[ heightmapIndices[ i * 3 + 2 ] ].Normal += normal;
			}

			for( int i = 0; i < heightmapVertices.Length; i++ ) {
				heightmapVertices[ i ].Normal.Normalize();
				//normalBits[i] = new Color(heightmapVertices[i].Normal);
			}

			//normalMap.SetData<Color>(normalBits);
			//normalMap.Save("normalmap.jpg", ImageFileFormat.Jpg);

			UpdateVertices();

			//Game1.console.Add("NormalMap Generated.");
		}

		private void SetUpIndices() {
			heightmapIndices = new short[ ( size.X - 1 ) * ( size.Y - 1 ) * 6 ];

			triangle = new Tri[ ( size.X - 1 ) * ( size.Y - 1 ) * 2 ];
			int triangleID = 0;

			int indiceID = 0;
			for( int y = 0; y < size.Y - 1; y++ ) {
				for( int x = 0; x < size.X - 1; x++ ) {
					heightmapIndices[ indiceID ] = (short)( x + y * size.X );
					heightmapIndices[ indiceID + 1 ] = (short)( x + ( y + 1 ) * size.X );
					heightmapIndices[ indiceID + 2 ] = (short)( ( x + 1 ) + y * size.X );

					heightmapIndices[ indiceID + 3 ] = (short)( ( x + 1 ) + y * size.X );
					heightmapIndices[ indiceID + 4 ] = (short)( x + ( y + 1 ) * size.X );
					heightmapIndices[ indiceID + 5 ] = (short)( ( x + 1 ) + ( y + 1 ) * size.X );

					indiceID += 6;

					SetUpCollision( indiceID, triangleID, x, y );
					triangleID += 2;
				}
			}
		}

		private void UpdateCollisions( List<Point> verticiesToUpdate ) {
			int tID = 0;
			int indiceID = 0;
			List<int> TriangleIDs = new List<int>();

			foreach( Point vec in verticiesToUpdate ) {
				int x = vec.X;
				int y = vec.Y;

				if( x > 0 && y > 0 && x < size.X - 1 && y < size.Y - 1 ) {
					tID = ( x + y * ( size.X - 1 ) ) * 2;
					indiceID = ( ( x + y * ( size.X - 1 ) ) + 1 ) * 6;

					triangle[ tID ] = new Tri();
					triangle[ tID ].p1 = heightmapVertices[ x + y * size.X ].Position;
					triangle[ tID ].p2 = heightmapVertices[ x + ( y + 1 ) * size.X ].Position;
					triangle[ tID ].p3 = heightmapVertices[ ( x + 1 ) + y * size.X ].Position;
					triangle[ tID ].normal = MathExtra.GetNormal( triangle[ tID ].p1, triangle[ tID ].p2, triangle[ tID ].p3 );
					triangle[ tID ].id = indiceID / 6 - 1;

					triangle[ tID + 1 ] = new Tri();
					triangle[ tID + 1 ].p1 = heightmapVertices[ ( x + 1 ) + y * size.X ].Position;
					triangle[ tID + 1 ].p2 = heightmapVertices[ x + ( y + 1 ) * size.X ].Position;
					triangle[ tID + 1 ].p3 = heightmapVertices[ ( x + 1 ) + ( y + 1 ) * size.X ].Position;
					triangle[ tID + 1 ].normal = MathExtra.GetNormal( triangle[ tID + 1 ].p1, triangle[ tID + 1 ].p2, triangle[ tID + 1 ].p3 );
					triangle[ tID + 1 ].id = indiceID / 6;

					TriangleIDs.Add( tID );
					TriangleIDs.Add( tID + 1 );

					quadTree.UpdateBoundingBox( quadTree.NodeList[ 0 ], tID );
					quadTree.UpdateBoundingBox( quadTree.NodeList[ 0 ], tID + 1 );
				}
			}

		}

		private void SetUpCollision( int indiceID, int tID, int x, int y ) {
			triangle[ tID ] = new Tri();
			triangle[ tID ].p1 = heightmapVertices[ x + y * size.X ].Position;
			triangle[ tID ].p2 = heightmapVertices[ x + ( y + 1 ) * size.X ].Position;
			triangle[ tID ].p3 = heightmapVertices[ ( x + 1 ) + y * size.X ].Position;
			triangle[ tID ].normal = MathExtra.GetNormal( triangle[ tID ].p1, triangle[ tID ].p2, triangle[ tID ].p3 );
			triangle[ tID ].id = indiceID / 6 - 1;

			triangle[ tID + 1 ] = new Tri();
			triangle[ tID + 1 ].p1 = heightmapVertices[ ( x + 1 ) + y * size.X ].Position;
			triangle[ tID + 1 ].p2 = heightmapVertices[ x + ( y + 1 ) * size.X ].Position;
			triangle[ tID + 1 ].p3 = heightmapVertices[ ( x + 1 ) + ( y + 1 ) * size.X ].Position;
			triangle[ tID + 1 ].normal = MathExtra.GetNormal( triangle[ tID + 1 ].p1, triangle[ tID + 1 ].p2, triangle[ tID + 1 ].p3 );
			triangle[ tID + 1 ].id = indiceID / 6;
		}

		private void SetIndexBuffer() {
			indexBuffer = new IndexBuffer( Editor.graphics.GraphicsDevice, sizeof( short ) * heightmapIndices.Length, BufferUsage.None, IndexElementSize.SixteenBits );
			indexBuffer.SetData<short>( heightmapIndices );
		}

		private void InitEffect() {
			effect = Editor.Content.Load<Effect>( @"Shaders\heightmap_multilayer" );
			effectTechniques = effect.Techniques;

			worldViewProjParam = effect.Parameters[ "WorldViewProj" ];
			worldParam = effect.Parameters[ "World" ];
			viewParam = effect.Parameters[ "View" ];

			textureParam = new EffectParameter[ 5 ];
			textureScaleParam = new EffectParameter[ 5 ];
			for( int i = 0; i < textureParam.Length; i++ ) {
				textureParam[ i ] = effect.Parameters[ "t" + i ];
				textureScaleParam[ i ] = effect.Parameters[ "t" + i + "scale" ];
			}

			DrawDetailParam = effect.Parameters[ "bDrawDetail" ];
			colormapParam = effect.Parameters[ "colormap" ];
			lightMapParam = effect.Parameters[ "lightMap" ];
			normalMapParam = effect.Parameters[ "normalMap" ];
			decalMapParam = effect.Parameters[ "decalMap" ];

			cameraPositionParam = effect.Parameters[ "cameraPosition" ];
			cameraDirectionParam = effect.Parameters[ "cameraDirection" ];

			ambientLightParam = effect.Parameters[ "ambientLight" ];
			lightPositionParam = effect.Parameters[ "lightPosition" ];
			lightDirectionParam = effect.Parameters[ "lightDirection" ];
			lightPowerParam = effect.Parameters[ "lightPower" ];

			groundCursorPositionParam = effect.Parameters[ "groundCursorPosition" ];
			groundCursorTextureParam = effect.Parameters[ "groundCursorTex" ];
			groundCursorSizeParam = effect.Parameters[ "groundCursorSize" ];
			showCursorParam = effect.Parameters[ "bShowCursor" ];

			useSunParam = effect.Parameters[ "bUseSun" ];
			sunColorParam = effect.Parameters[ "sunColor" ];

			UpdateTextures();
			UpdateEffect();
		}

		public void UpdateTextures() {
			colormapParam.SetValue( colormap );
			//lightMapParam.SetValue(lightMap);
			//decalMapParam.SetValue(decalMap);

			for( int i = 0; i < textureLayer.Length; i++ ) {
				if( textureParam[ i ] != null )
					textureParam[ i ].SetValue( textureLayer[ i ].texture );
				if( textureScaleParam[ i ] != null )
					textureScaleParam[ i ].SetValue( textureLayer[ i ].scale );
			}

			groundCursorTextureParam.SetValue( groundCursorTex );
		}

		public void UpdateEffect() {
			lightPositionParam.SetValue( Editor.sun.sunPosition );
			lightDirectionParam.SetValue( Editor.sun.direction );
			lightPowerParam.SetValue( (float)Editor.sun.lightPower );

			cameraPositionParam.SetValue( Editor.camera.position );
			cameraDirectionParam.SetValue( -Editor.camera.direction );

			groundCursorPositionParam.SetValue( groundCursorPosition );
			groundCursorSizeParam.SetValue( groundCursorSize );

			showCursorParam.SetValue( bShowCursor );
			DrawDetailParam.SetValue( bDrawDetail );

			useSunParam.SetValue( Editor.bDrawSun );
			sunColorParam.SetValue( Editor.sun.color );

			ambientLightParam.SetValue( ambientLight );
		}

		public void Update() {
			UpdateMatrices();
			UpdateTextures();
			UpdateEffect();

			lastGroundCursorPos = groundCursorPosition;
		}

		public void SaveImages() {
			//Console.WriteLine("Saving images..");

			if( heightmap != null )
				heightmap.Save( "heightmap.bmp", ImageFileFormat.Bmp );
			if( normalMap != null )
				normalMap.Save( "normalmap.bmp", ImageFileFormat.Bmp );
			if( lightMap != null )
				lightMap.Save( "lightmap.bmp", ImageFileFormat.Bmp );
			if( colormap != null )
				colormap.Save( "colormap.bmp", ImageFileFormat.Bmp );
			if( decalMap != null )
				decalMap.Save( "decalmap.bmp", ImageFileFormat.Bmp );
		}

		private void UpdateMatrices() {
			world = Matrix.Identity;
		}

		public Ray GetPickRay() {
			MouseState mouseState = Mouse.GetState();

			int mouseX = mouseState.X;
			int mouseY = mouseState.Y;

			float width = 800f;
			float height = 600f;

			double screenSpaceX = ( (float)mouseX / ( width / 2 ) - 1.0f ) * Editor.camera.aspectRatio;
			double screenSpaceY = ( 1.0f - (float)mouseY / ( height / 2 ) );

			double viewRatio = Math.Tan( Editor.camera.fov / 2 );

			screenSpaceX = screenSpaceX * viewRatio;
			screenSpaceY = screenSpaceY * viewRatio;

			Vector3 cameraSpaceNear = new Vector3( (float)( screenSpaceX * Editor.camera.NearPlane ), (float)( screenSpaceY * Editor.camera.NearPlane ), (float)( -Editor.camera.NearPlane ) );
			Vector3 cameraSpaceFar = new Vector3( (float)( screenSpaceX * Editor.camera.FarPlane ), (float)( screenSpaceY * Editor.camera.FarPlane ), (float)( -Editor.camera.FarPlane ) );

			Matrix invView = Matrix.Invert( Editor.camera.view );
			Vector3 worldSpaceNear = Vector3.Transform( cameraSpaceNear, invView );
			Vector3 worldSpaceFar = Vector3.Transform( cameraSpaceFar, invView );

			Ray pickRay = new Ray( worldSpaceNear, worldSpaceFar - worldSpaceNear );

			return new Ray( pickRay.Position, Vector3.Normalize( pickRay.Direction ) );
		}

		public void Draw( Matrix view, Matrix projection ) {
			Editor.graphics.GraphicsDevice.RenderState.CullMode = CullMode.CullClockwiseFace;

			if( Editor.bUseFog )
				Editor.graphics.GraphicsDevice.RenderState.FogEnable = true;

			effect.CurrentTechnique = effect.Techniques[ currentTechnique ];

			effect.Begin();

			Matrix WorldViewProj = world * view * projection;

			worldParam.SetValue( world );
			viewParam.SetValue( view );
			worldViewProjParam.SetValue( WorldViewProj );

			//eyePosParam.SetValue(Game1.camera.position);

			effect.CommitChanges();

			if( heightmapVertices != null ) {
				foreach( EffectPass pass in effect.CurrentTechnique.Passes ) {
					pass.Begin();

					Editor.graphics.GraphicsDevice.Indices = indexBuffer;
					Editor.graphics.GraphicsDevice.VertexDeclaration = vertexDeclaration;
					Editor.graphics.GraphicsDevice.Vertices[ 0 ].SetSource( vertexBuffer, 0, VertexPositionNormalTexture.SizeInBytes );
					Editor.graphics.GraphicsDevice.DrawIndexedPrimitives( PrimitiveType.TriangleList, 0, 0, heightmapVertices.Length, 0, heightmapIndices.Length / 3 );

					pass.End();
				}
			}

			effect.End();


			for( int i = 0; i < testTriangle.Count; i++ )
				if( testTriangle[ i ] != null )
					testTriangle[ i ].Draw( view, projection );

		}

		public void GetGroundHeight( Vector3 pos, out float height, out Vector3 normal ) {
			height = lastHeight;
			normal = Vector3.Zero;

			//Get the current Position (XY) relative to the heightmap size and position
			int bitX = (int)( pos.X / cellSize.X );
			int bitY = (int)( pos.Z / cellSize.Y );

			//HUD stuff
			lastX = bitX;
			lastY = bitY;

			//Get the four heightmap vertex ids
			int[] vID = new int[ 4 ];
			vID[ 0 ] = bitX + bitY * size.X;
			vID[ 1 ] = ( bitX + 1 ) + bitY * size.X;
			vID[ 2 ] = bitX + ( bitY + 1 ) * size.X;
			vID[ 3 ] = ( bitX + 1 ) + ( bitY + 1 ) * size.X;

			//Get 4 vector corners (2 triangles : 1-2-0 & 3-2-1)
			Vector3[] corner = new Vector3[ 4 ];
			for( int i = 0; i < 4; i++ )
				if( vID[ i ] >= 0 && vID[ i ] < heightmapVertices.Length )
					corner[ i ] = heightmapVertices[ vID[ i ] ].Position;

			if( corner[ 0 ].Y == corner[ 2 ].Y && corner[ 2 ].Y == corner[ 1 ].Y )
				height = corner[ 0 ].Y;
			else if( corner[ 0 ].Y == corner[ 2 ].Y && corner[ 2 ].Y == corner[ 3 ].Y )
				height = corner[ 0 ].Y;

			Vector3 rayStart = new Vector3( pos.X, 0f, pos.Z );

			Vector3 normalA = new Plane( corner[ 0 ], corner[ 2 ], corner[ 1 ] ).Normal;
			Vector3 normalB = new Plane( corner[ 1 ], corner[ 2 ], corner[ 3 ] ).Normal;

			Ray rayIntersect = new Ray( rayStart, Vector3.Up );

			float rayLength = 0f;
			if( MathExtra.Intersects( rayIntersect, corner[ 0 ], corner[ 2 ], corner[ 1 ], normalA, true, true, out rayLength ) == true ) {
				height = rayLength;
				normal = normalA;
				return;
			} else if( MathExtra.Intersects( rayIntersect, corner[ 1 ], corner[ 2 ], corner[ 3 ], normalB, true, true, out rayLength ) == true ) {
				height = rayLength;
				normal = normalB;
				return;
			}

			if( Editor.water != null )
				height = Editor.waterHeight;
			else
				height = pos.Y;

			normal = Vector3.Zero;
			lastHeight = height;
		}

		public void RiseHeight( int indiceID ) {
			MoveVertices( indiceID, groundCursorStrength * .0001f );
		}

		public void LowerHeight( int indiceID ) {
			MoveVertices( indiceID, -groundCursorStrength * .0001f );
		}

		private void AddVertexToUpdate( Point point, ref List<Point> verticiesToUpdate ) {

			if( point.X >= 0 && point.X < size.X && point.Y >= 0 && point.Y < size.Y ) {

				if( !verticiesToUpdate.Contains( point ) ) {
					verticiesToUpdate.Add( point );
				}
			}
			if( point.X + 1 >= 0 && point.X + 1 < size.X && point.Y >= 0 && point.Y < size.Y ) {
				Point p = new Point( point.X + 1, point.Y );
				if( !verticiesToUpdate.Contains( p ) ) {
					verticiesToUpdate.Add( p );
				}
			}

			if( point.X - 1 >= 0 && point.X - 1 < size.X && point.Y >= 0 && point.Y < size.Y ) {
				Point p = new Point( point.X - 1, point.Y );
				if( !verticiesToUpdate.Contains( p ) ) {
					verticiesToUpdate.Add( p );
				}
			}

			if( point.X >= 0 && point.X < size.X && point.Y + 1 >= 0 && point.Y + 1 < size.Y ) {
				Point p = new Point( point.X, point.Y + 1 );
				if( !verticiesToUpdate.Contains( p ) ) {
					verticiesToUpdate.Add( p );
				}
			}

			if( point.X >= 0 && point.X < size.X && point.Y - 1 >= 0 && point.Y - 1 < size.Y ) {
				Point p = new Point( point.X, point.Y - 1 );
				if( !verticiesToUpdate.Contains( p ) ) {
					verticiesToUpdate.Add( p );
				}
			}
		}

		private void MoveVertices( int indiceID, float height ) {
			int x = (int)( groundCursorPosition.X * heightmap.Width );
			int y = (int)( groundCursorPosition.Z * heightmap.Height );
			List<Point> verticiesToUpdate = new List<Point>();

			for( int v = -groundCursorSize; v < groundCursorSize; v++ ) {
				for( int w = -groundCursorSize; w < groundCursorSize; w++ ) {
					float l = Vector2.Distance( Vector2.Zero, new Vector2( v, w ) );
					if( l < groundCursorSize ) {

						// Vertices to update
						AddVertexToUpdate( new Point( x + v, y + w ), ref verticiesToUpdate );


						AddBitHeight( ( x + v ) + ( y + w ) * size.X, height * ( groundCursorSize - l ) / 2f );
						CalculateVertexNormal( x + v, y + w );
						CalculateVertexNormal( x + v + 1, y + w );
						CalculateVertexNormal( x + v - 1, y + w );
						CalculateVertexNormal( x + v, y + w + 1 );
						CalculateVertexNormal( x + v, y + w - 1 );




					}
				}
			}

			UpdateVertices( verticiesToUpdate );
			verticiesToUpdate.Clear();
		}

		public void FlattenVertices( int indiceID ) {
			List<Point> verticiesToUpdate = new List<Point>();

			float flatColor = flattenHeight / maxHeight;

			int x = (int)( groundCursorPosition.X * heightmap.Width );
			int y = (int)( groundCursorPosition.Z * heightmap.Height );

			for( int v = -groundCursorSize; v < groundCursorSize; v++ ) {
				for( int w = -groundCursorSize; w < groundCursorSize; w++ ) {
					float l = Vector2.Distance( Vector2.Zero, new Vector2( v, w ) );
					if( l < groundCursorSize ) {

						// Vertices to update
						AddVertexToUpdate( new Point( x + v, y + w ), ref verticiesToUpdate );
						/*
						verticiesToUpdate.Add(new Point(x + v, y + w));
						verticiesToUpdate.Add(new Point(x + v + 1, y + w));
						verticiesToUpdate.Add(new Point(x + v - 1, y + w));
						verticiesToUpdate.Add(new Point(x + v, y + w + 1));
						verticiesToUpdate.Add(new Point(x + v, y + w - 1));
						*/

						SetBitHeight( ( x + w ) + ( y + v ) * size.X, flatColor );
						CalculateVertexNormal( x + v, y + w );
						CalculateVertexNormal( x + v + 1, y + w );
						CalculateVertexNormal( x + v - 1, y + w );
						CalculateVertexNormal( x + v, y + w + 1 );
						CalculateVertexNormal( x + v, y + w - 1 );
					}
				}
			}

			UpdateVertices( verticiesToUpdate );
			verticiesToUpdate.Clear();
		}

		public void Smooth( int indiceID ) {
			List<Point> verticiesToUpdate = new List<Point>();

			Nullable<float>[] pixColor = new Nullable<float>[ 4 ];

			int x = (int)( groundCursorPosition.X * heightmap.Width );
			int y = (int)( groundCursorPosition.Z * heightmap.Height );

			for( int v = -groundCursorSize; v < groundCursorSize; v++ ) {
				for( int w = -groundCursorSize; w < groundCursorSize; w++ ) {
					float l = Vector2.Distance( Vector2.Zero, new Vector2( v, w ) );
					if( l < groundCursorSize ) {
						pixColor[ 0 ] = pColor( x + w + 1, y + v );
						pixColor[ 1 ] = pColor( x + w - 1, y + v );
						pixColor[ 2 ] = pColor( x + w, y + v + 1 );
						pixColor[ 3 ] = pColor( x + w, y + v - 1 );

						float averageColor = 0f;
						int numpix = 0;
						for( int i = 0; i < 4; i++ ) {
							if( pixColor[ i ] != null ) {
								averageColor += pixColor[ i ].Value;
								numpix++;
							}
						}


						// Vertices to update
						verticiesToUpdate.Add( new Point( x + v, y + w ) );
						verticiesToUpdate.Add( new Point( x + v + 1, y + w ) );
						verticiesToUpdate.Add( new Point( x + v - 1, y + w ) );
						verticiesToUpdate.Add( new Point( x + v, y + w + 1 ) );
						verticiesToUpdate.Add( new Point( x + v, y + w - 1 ) );

						averageColor = averageColor / numpix;
						SetBitHeight( ( x + w ) + ( y + v ) * size.X, averageColor );
						CalculateVertexNormal( x + v, y + w );
						CalculateVertexNormal( x + v + 1, y + w );
						CalculateVertexNormal( x + v - 1, y + w );
						CalculateVertexNormal( x + v, y + w + 1 );
						CalculateVertexNormal( x + v, y + w - 1 );
					}
				}
			}

			UpdateVertices( verticiesToUpdate );
			verticiesToUpdate.Clear();
		}

		private float AverageHeight( Point[] p ) {
			//Get the average height
			float pHeight = 0f;
			float smoothHeight = 0f;
			float originalHeight = pColor( p[ 0 ].X, p[ 0 ].Y ).Value * maxHeight;

			if( p.Length > 1 ) {
				for( int i = 1; i < p.Length; i++ )
					pHeight += pColor( p[ i ].X, p[ i ].Y ).Value * maxHeight;

				smoothHeight = pHeight / p.Length;
				smoothHeight = -originalHeight + ( smoothHeight + originalHeight ) / 2f;
			} else
				smoothHeight = originalHeight;

			return smoothHeight;
		}

		public void Paint( int x, int y, float amount, int layerID ) {
			for( int v = -groundCursorSize; v < groundCursorSize; v++ ) {
				for( int w = -groundCursorSize; w < groundCursorSize; w++ ) {
					float l = Vector2.Distance( Vector2.Zero, new Vector2( v, w ) );
					if( l < groundCursorSize )
						Fill( x + w, y + v, amount * ( 1f - ( l / groundCursorSize ) ), layerID );
				}
			}
		}

		private void Fill( int x, int y, float amount, int layerID ) {
			int bitID = x + y * size.X;

			if( bitID < 0 || bitID >= bits.Length )
				return;

			Color[] bitColor = new Color[ 1 ];
			Vector4 pixelColor = colorBits[ bitID ].ToVector4();

			switch( layerID ) {
				case 0:
					pixelColor.X += amount;
					break;
				case 1:
					pixelColor.Y += amount;
					break;
				case 2:
					pixelColor.Z += amount;
					break;
				case 3:
					pixelColor.W += amount;
					break;
			}

			if( pixelColor.X > 1.0f )
				pixelColor.X = 1.0f;
			else if( pixelColor.X < 0f )
				pixelColor.X = 0f;
			if( pixelColor.Y > 1.0f )
				pixelColor.Y = 1.0f;
			else if( pixelColor.Y < 0f )
				pixelColor.Y = 0f;
			if( pixelColor.Z > 1.0f )
				pixelColor.Z = 1.0f;
			else if( pixelColor.Z < 0f )
				pixelColor.Z = 0f;
			if( pixelColor.W > 1.0f )
				pixelColor.W = 1.0f;
			else if( pixelColor.W < 0f )
				pixelColor.W = 0f;

			colorBits[ bitID ] = new Color( pixelColor );

			//colormap.SetData<Color>(colorBits, bitID, 1, SetDataOptions.None);

			try {
				colormap.SetData<Color>( colorBits );
			} catch {
				colormap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 0, TextureUsage.None, SurfaceFormat.Color );
				colormap.SetData<Color>( colorBits );
			}
		}

		public enum GenerationType {
			Random,
			PerlinNoise,
			TestNoise
		}
		public void RandomizeHeight( GenerationType randomGenType, int smoothingPasses, bool bAdditive ) {
			Point randomHeight = new Point( 0, 70 ); //percentage
			Random random = new Random();

			Editor.console.Add( "Generating Heightmap Noise." );

			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					float currentHeight = 0f;

					switch( randomGenType ) {
						case GenerationType.Random:
							currentHeight = (float)random.Next( randomHeight.X, randomHeight.Y ) * 0.01f;
							break;
						case GenerationType.PerlinNoise:
							currentHeight = PerlinNoise( x, y, 200 ) * 5.0f;
							break;
						case GenerationType.TestNoise:
							float xHeight = (float)Math.Sin( x * 1.5f ) * 0.4f;
							float yHeight = -(float)Math.Cos( y * 1.3f ) * 0.6f;
							currentHeight = ( xHeight + yHeight );
							break;
					}

					if( bAdditive )
						currentHeight += pColor( x, y ).Value;

					SetBitHeight( x + y * size.X, currentHeight );
					bits[ x + y * size.X ] = new Color( new Vector3( currentHeight ) );
				}
			}

			heightmap.SetData<Color>( bits );

			if( smoothingPasses > 0 )
				for( int i = 0; i < smoothingPasses; i++ )
					SmoothHeightmap();

			CalculateHeightmap();
		}

		/// <summary>
		/// Perlin Noise Generation
		/// Special Thanks to Francis "AK 47" Huang
		/// http://www.gamedev.net/reference/articles/article2085.asp
		/// </summary>
		private float PerlinNoise( int x, int y, int random ) {
			Random rand = new Random();
			int n = x + y * 57 + rand.Next( 0, random ) * 131;
			n = ( n << 13 ) ^ n;
			return ( 1.0f - ( ( n * ( n * n * 15731 + 789221 ) + 1376312589 ) & 0x7fffffff ) * 0.000000000931322574615478515625f );
		}

		public void SmoothHeightmap() {
			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					int[] bitID = new int[ 5 ];
					bitID[ 0 ] = x + y * size.X;
					bitID[ 1 ] = ( x + 1 ) + y * size.X;
					bitID[ 2 ] = ( x - 1 ) + y * size.X;
					bitID[ 3 ] = x + ( y + 1 ) * size.X;
					bitID[ 4 ] = x + ( y - 1 ) * size.X;

					//Make a list of surrounding bits, considering map edges
					List<float> pixelColor = new List<float>();

					pixelColor.Add( bits[ bitID[ 0 ] ].ToVector4().X );

					if( bitID[ 1 ] > 0 && bitID[ 1 ] < bits.Length )
						pixelColor.Add( bits[ bitID[ 1 ] ].ToVector4().X );
					if( bitID[ 2 ] > 0 && bitID[ 2 ] < bits.Length )
						pixelColor.Add( bits[ bitID[ 2 ] ].ToVector4().X );
					if( bitID[ 3 ] > 0 && bitID[ 3 ] < bits.Length )
						pixelColor.Add( bits[ bitID[ 3 ] ].ToVector4().X );
					if( bitID[ 4 ] > 0 && bitID[ 4 ] < bits.Length )
						pixelColor.Add( bits[ bitID[ 4 ] ].ToVector4().X );

					if( pixelColor.Count > 2 ) {
						//Get average color
						float averageColor = 0f;
						for( int i = 1; i < pixelColor.Count; i++ )
							averageColor += pixelColor[ i ];
						averageColor = averageColor / ( pixelColor.Count - 1 );

						//Set new smoothed color
						SetBitHeight( x + y * size.X, averageColor );
					}
				}
			}

			heightmap.SetData<Color>( bits );
			//CalculateHeightmap();

			CalculateNormals();
			UpdateVertices();
		}

		//----------------------------------------------------------------
		// Fast Computation of Terrain Shadow Maps
		// http://www.gamedev.net/reference/articles/article1817.asp
		//----------------------------------------------------------------
		private int Intersect( Vector3 pos, Ray ray ) //, out float z)
		{
			int w, hits;
			float d, h, D;
			Vector3 v, dir;

			v = pos + ray.Direction;
			w = size.X;

			hits = 0;

			for( int x = 0; x < size.X - 1; x++ ) {
				for( int y = 0; y < size.Y - 1; y++ ) {
					D = Vector3.Distance( new Vector3( v.X, 0, v.Z ), new Vector3( ray.Position.X, 0, ray.Position.Z ) );
					d = Vector3.Distance( pos, v );            // light direction
					h = pos.Y + ( d * ray.Position.Y ) / D;  // X(P) point

					// check if height in point P is bigger than point X's height
					float pixelHeight = bits[ x + y * size.X ].ToVector4().X;
					if( pixelHeight > h ) {
						hits++;   // if so, mark as hit, and skip this work point.
						//z = (h - pixelHeight) / Vector3.Distance(new Vector3(x * size.X, pixelHeight, z * size.Y), ray.Position);
						break;
					};

					dir = ray.Direction;
					dir.Y = 0;
					dir.Normalize();
					v += dir;   // fetch new working point
				}
			}

			/*
			while (!((v.X >= w - 1) || (v.X <= 0) || (v.Z >= w - 1) || (v.Z <= 0)))
			{
				// length of lightdir's projection
				D = Vector3.Distance(new Vector3(v.X, 0, v.Z), new Vector3(ray.Position.X, 0, ray.Position.Z));
				d = Vector3.Distance(pos, v);            // light direction
				h = pos.Y + (d * ray.Position.Y) / D;  // X(P) point

				// check if height in point P is bigger than point X's height
				if (bits[(int)Math.Floor(v.Z) * w + (int)Math.Floor(v.X)].ToVector3().X * maxHeight > h)
				{
					hits++;   // if so, mark as hit, and skip this work point.
					break;
				};

				dir = ray.Direction;
				dir.Y = 0;
				v += dir.Normalize();   // fetch new working point
			};
			*/

			return hits;
		}

		public Nullable<float> pColor( int x, int y ) {
			int pID = x + y * size.X;

			if( pID >= 0 && pID < bits.Length )
				return bits[ pID ].ToVector4().X;
			else
				return null;
		}

		public Nullable<float> pColor( int bitID ) {
			if( bitID >= 0 && bitID < bits.Length )
				return bits[ bitID ].ToVector4().X;
			else
				return null;
		}

		//Was used in conjuncture with a cannonball (see video#1 ending on youtube: XNA Terrain Editor,)
		public void DigHole( int x, int y ) {
			Editor.console.Add( "Digging Hole." );

			float[] height = new float[ 5 ];
			float[] light = new float[ 5 ];

			height[ 0 ] = pColor( x, y ).Value - 50f / maxHeight;
			height[ 1 ] = pColor( x + 1, y ).Value - 30f / maxHeight;
			height[ 2 ] = pColor( x - 1, y ).Value - 30f / maxHeight;
			height[ 3 ] = pColor( x, y + 1 ).Value - 30f / maxHeight;
			height[ 4 ] = pColor( x, y - 1 ).Value - 30f / maxHeight;

			Darken( x + y * size.X, .4f );
			Darken( ( x + 1 ) + y * size.X, .2f );
			Darken( ( x - 1 ) + y * size.X, .2f );
			Darken( x + ( y + 1 ) * size.X, .2f );
			Darken( x + ( y - 1 ) * size.X, .2f );
			Darken( ( x + 1 ) + ( y + 1 ) * size.X, .1f );
			Darken( ( x + 1 ) + ( y - 1 ) * size.X, .1f );
			Darken( ( x - 1 ) + ( y + 1 ) * size.X, .1f );
			Darken( ( x - 1 ) + ( y - 1 ) * size.X, .1f );
			Darken( ( x + 2 ) + y * size.X, .05f );
			Darken( ( x - 2 ) + y * size.X, .05f );
			Darken( x + ( y + 2 ) * size.X, .05f );
			Darken( x + ( y - 2 ) * size.X, .05f );

			try {
				bits[ x + y * size.X ] = new Color( new Vector3( height[ 0 ] ) );
				bits[ ( x + 1 ) + y * size.X ] = new Color( new Vector3( height[ 1 ] ) );
				bits[ ( x - 1 ) + y * size.X ] = new Color( new Vector3( height[ 2 ] ) );
				bits[ x + ( y + 1 ) * size.X ] = new Color( new Vector3( height[ 3 ] ) );
				bits[ x + ( y - 1 ) * size.X ] = new Color( new Vector3( height[ 4 ] ) );
			} catch( Exception e ) {
				Console.WriteLine( "Error: " + e );
			}

			heightmap.SetData<Color>( bits );
			CalculateHeightmap();
		}

		public void CreateIsland() {
			Vector2 center = new Vector2( size.X / 2f, size.Y / 2f );
			float height = 0f;

			for( int x = 0; x < size.X; x++ ) {
				for( int y = 0; y < size.Y; y++ ) {
					Vector2 pos = new Vector2( x, y );
					height = bits[ x + y * size.X ].ToVector4().X;
					height -= Vector2.Distance( pos, center ) / ( ( size.X + size.Y ) / 2f ) * 0.5f;
					bits[ x + y * size.X ] = new Color( new Vector3( height ) );
				}
			}

			heightmap.SetData<Color>( bits );
			CalculateHeightmap();
		}

		public void LoadDefaultTextures() {
			textureLayer[ 0 ] = new Layer( "detail02", 60f );
			textureLayer[ 1 ] = new Layer( "dirt01", 25f );
			textureLayer[ 2 ] = new Layer( "grass01", 25f );
			textureLayer[ 3 ] = new Layer( "rock01", 25f );
			textureLayer[ 4 ] = new Layer( "snow01", 25f );
			LoadTextures();
		}

		public void GenerateColorMap() {
			colorBits = new Color[ size.X * size.Y ];

			//Console.WriteLine("Highest Point: " + highestPoint);
			//Console.WriteLine("Lowest Point: " + lowestPoint);

			for( int x = 0; x < size.X; x++ ) {
				for( int y = 0; y < size.Y; y++ ) {
					float height = Math.Max( 0f, bits[ x + y * size.X ].ToVector4().X - lowestPoint );
					float totalHeight = highestPoint - lowestPoint;

					Vector4 amount = Vector4.Zero;

					amount.X = Math.Max( 1, height / totalHeight );

					if( height > ( totalHeight ) * 0.05f )
						amount.Y = Math.Max( 1, height / totalHeight * 0.4f );

					if( height > ( totalHeight ) * 0.5f )
						amount.Z = Math.Max( 1, height / totalHeight * 0.4f );

					if( height > ( totalHeight ) * 0.85f )
						amount.W = Math.Max( 1, height / totalHeight * 0.6f );

					colorBits[ x + y * size.X ] = new Color( amount );
				}
			}

			try {
				colormap.SetData<Color>( colorBits );
			} catch {
				colormap = new Texture2D( Editor.graphics.GraphicsDevice, size.X, size.Y, 0, TextureUsage.None, SurfaceFormat.Color );
				colormap.SetData<Color>( colorBits );
			}

			Editor.console.Add( "Colormap Generated" );
		}

		public void Darken( int id, float amount ) {
			if( id >= 0 && id < decalBits.Length ) {
				float color = Math.Min( 0.6f, decalBits[ id ].ToVector4().X - amount );
				decalBits[ id ] = new Color( new Vector3( color ) );
			}

			decalMap.SetData<Color>( decalBits );
			effect.Parameters[ "decalMap" ].SetValue( decalMap );
		}

		private void SetBitHeight( int bitID, float bitColor ) {
			if( bitID >= 0 && bitID < bits.Length ) {
				bits[ bitID ] = new Color( new Vector3( bitColor ) );
			}
		}

		private void AddBitHeight( int bitID, float amount ) {
			if( bitID >= 0 && bitID < bits.Length ) {
				float bitColor = bits[ bitID ].ToVector4().X;
				bits[ bitID ] = new Color( new Vector3( bitColor + amount ) );
			}
		}

		private void UpdateHeightmapImage() {
			for( int y = 0; y < size.Y; y++ ) {
				for( int x = 0; x < size.X; x++ ) {
					float h = heightmapVertices[ x + y * size.X ].Position.Y / maxHeight;
					bits[ x + y * size.X ] = new Color( new Vector3( h ) );
				}
			}

			UpdateHeightFile();
		}
	}
}
