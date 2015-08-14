using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Puzzle3D {

	public class Board {

		private int width;
		private int height;
		private bool twoSided;

		private List<Chip> chips = new List<Chip>();
		private Chip[ , ] layout;
		private Matrix[ , ] boardPositionMatrices;
		private const float ChipSpacing = 1.0f;
		private int emptyX;
		private int emptyY;

		private Camera camera;
		private Lighting lighting = new Lighting();
		private LightingEffect lightingEffect = new LightingEffect();
		private Model chipModel;
		private Matrix[] chipTransforms;
		private PictureSet currentPictureSet = null;
		private PictureSet nextPictureSet = null;

		private float textureRotationTime = 0.0f;
		private float textureRotationDuration = 2.5f;

		private List<Chip> shiftingChips = new List<Chip>();
		private int shiftX;
		private int shiftY;
		private float currentShiftTime;
		private const float ShiftDuration = 0.1f;


		public int Width {
			get { return width; }
		}

		public int Height {
			get { return height; }
		}

		public bool TwoSided {
			get { return twoSided; }
		}

		public IEnumerable<Chip> Chips {
			get { return chips; }
		}

		public Chip GetChip( int x, int y ) {
			return layout[ x, y ];
		}

		public int EmptyX {
			get { return emptyX; }
		}

		public int EmptyY {
			get { return emptyY; }
		}


		public Camera Camera {
			get { return this.camera; }
		}

		public LightingEffect LightingEffect {
			get { return lightingEffect; }
		}

		public PictureSet CurrentPictureSet {
			get { return currentPictureSet; }
		}

		public PictureSet NextPictureSet {
			get { return nextPictureSet; }
		}

		public bool IsShifting {
			get { return shiftingChips.Count > 0; }
		}

		public int ShiftX {
			get { return shiftX; }
		}

		public int ShiftY {
			get { return shiftY; }
		}


		public Board( int sizeX, int sizeY, bool twoSided ) {
			this.twoSided = twoSided;
			this.width = sizeX;
			this.height = sizeY;

			camera = new Camera( (float)Math.Max( sizeX, sizeY ) * 400.0f / 5.0f );

			nextPictureSet = PictureDatabase.GetNextPictureSet( twoSided ? 2 : 1 );

			this.layout = new Chip[ Width, Height ];
			this.boardPositionMatrices = new Matrix[ Width, Height ];

			for( int y = 0; y < Height; y++ ) {
				for( int x = 0; x < Width; x++ ) {
					Chip chip = new Chip();
					chips.Add( chip );

					chip.XPosition = x;
					chip.YPosition = y;
					layout[ x, y ] = chip;

					Vector2 chipTexCoordFactor = new Vector2( 1.0f / Width, 1.0f / Height );

					chip.TexCoordScale = chipTexCoordFactor;
					chip.TexCoordTranslationFront = new Vector2( ( x * chipTexCoordFactor.X ), ( ( Height - 1 ) - y ) * chipTexCoordFactor.Y );
					chip.TexCoordTranslationBack = new Vector2( ( ( Width - 1 ) - x ) * chipTexCoordFactor.X, ( ( Height - 1 ) - y ) * chipTexCoordFactor.Y );
				}
			}

			emptyX = RandomHelper.Random.Next( 0, Width );
			emptyY = RandomHelper.Random.Next( 0, Height );
			Chip removed = layout[ emptyX, emptyY ];
			chips.Remove( removed );
			layout[ emptyX, emptyY ] = null;
		}

		public void LoadContent() {
			chipModel = Puzzle3D.Instance.Content.Load<Model>( "Models/Chip" );

			chipTransforms = new Matrix[ chipModel.Bones.Count ];
			chipModel.CopyAbsoluteBoneTransformsTo( chipTransforms );

			float sphereScale = Math.Max( chipTransforms[ 0 ].M11, chipTransforms[ 0 ].M22 );
			float chipSize = chipModel.Meshes[ 0 ].BoundingSphere.Radius * sphereScale * ChipSpacing;

			for( int y = 0; y < Height; y++ ) {
				for( int x = 0; x < Width; x++ ) {
					Vector3 chipPos = new Vector3( ( Width - 1 ) * -0.5f, ( Height - 1 ) * -0.5f, 0.0f );

					chipPos += new Vector3( x, y, 0.0f );
					chipPos *= chipSize;

					boardPositionMatrices[ x, y ] = Matrix.CreateTranslation( chipPos );
				}
			}

			if( currentPictureSet != null )
				currentPictureSet.Load();
			if( nextPictureSet != null )
				nextPictureSet.Load();

			lightingEffect.LoadContent();
		}

		public void UnloadContent() {
			if( nextPictureSet != null )
				nextPictureSet.Unload();
		}


		public bool IsPuzzleComplete() {
			for( int y = 0; y < Height; y++ ) {
				for( int x = 0; x < Width; x++ ) {
					Chip chip = layout[ x, y ];
					if( chip == null )
						return false;
					if( chip.XPosition != x || chip.YPosition != y )
						return false;
					if( !chip.HorizontalRotationCorrect || !chip.VerticalRotationCorrect )
						return false;
				}
			}

			return true;
		}


		public void Shift( int fromX, int fromY ) {
			if( IsShifting )
				return;

			shiftX = Math.Sign( emptyX - fromX );
			shiftY = Math.Sign( emptyY - fromY );

			if( Math.Abs( shiftX ) + Math.Abs( shiftY ) == 1 ) {
				currentShiftTime = 0.0f;
				Audio.Play( "Shift Chip" );

				while( emptyX != fromX || emptyY != fromY ) {
					int nextEmptyX = emptyX - shiftX;
					int nextEmptyY = emptyY - shiftY;

					Chip chip = layout[ nextEmptyX, nextEmptyY ];
					layout[ emptyX, emptyY ] = chip;
					shiftingChips.Add( chip );

					emptyX = nextEmptyX;
					emptyY = nextEmptyY;
				}

				layout[ fromX, fromY ] = null;
			}
		}


		public void Update( GameTime gameTime ) {
			this.camera.Update( gameTime );
			this.lighting.Update( gameTime, camera );

			if( nextPictureSet != null ) {
				textureRotationTime += (float)gameTime.ElapsedRealTime.TotalSeconds;
				if( textureRotationTime >= textureRotationDuration ) {
					if( currentPictureSet != null )
						currentPictureSet.Unload();

					currentPictureSet = nextPictureSet;
					nextPictureSet = null;

					textureRotationTime = 0.0f;
				}
			}

			if( IsShifting ) {
				currentShiftTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

				if( currentShiftTime > ShiftDuration ) {
					shiftingChips.Clear();
					shiftX = 0;
					shiftY = 0;
				}
			}

			foreach( Chip chip in chips )
				chip.Update( gameTime );
		}


		public void Draw() {
			lightingEffect.LightPos.SetValue( this.lighting.Position );
			lightingEffect.CameraPos.SetValue( this.camera.Position );

			DrawHelper.SetState();

			for( int y = 0; y < Height; y++ ) {
				for( int x = 0; x < Width; x++ ) {
					Chip chip = layout[ x, y ];
					if( chip == null )
						continue;

					Matrix transform;
					if( shiftingChips.Contains( chip ) ) {
						Matrix.Lerp( ref boardPositionMatrices[ x - shiftX, y - shiftY ], ref boardPositionMatrices[ x, y ], currentShiftTime / ShiftDuration, out transform );
					} else {
						transform = boardPositionMatrices[ x, y ];
					}

					chip.Draw( this, chipModel, transform, chipTransforms );
				}
			}
		}

	}

}
