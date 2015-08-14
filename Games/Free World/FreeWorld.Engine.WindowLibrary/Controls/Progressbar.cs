using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class Progressbar : Control {
		int numberOfBlocks = 20;
		int blockWidth = 10;

		public Progressbar() {
		}

		public Progressbar( string name, Vector2 position, Point size, Color backgroundColor, Color foregroundColor ) {
			ControlType = EControlType.ProgressBar;
			Name = name;
			PositionOrg = position;
			Position = PositionOrg;
			ControlSize = size;
			ColorBgDefault = backgroundColor;
			ColorFgDefault = foregroundColor;

			InitDefaults();
			InitTextures();
			InitEvents();
		}

		public override void InitDefaults() {

			Value = 0;
			MaxValue = 100;

			numberOfBlocks = ControlSize.X / blockWidth + 1;
		}

		public override void InitEvents() {
		}

		public override void InitTextures() {
			ControlTextures = new Texture2D[ 2 ];
			ControlTextures[ 0 ] = new Texture2D( Constants.GraphicsDevice, ControlSize.X, 18, true, SurfaceFormat.Color );
			ControlTextures[ 1 ] = new Texture2D( Constants.GraphicsDevice, ControlSize.X - 8, ControlTextures[ 0 ].Height - 8, true, SurfaceFormat.Color );

			ControlRectangles = new Rectangle[ 2 ];
			ControlRectangles[ 0 ] = new Rectangle( 0, 0, ControlTextures[ 1 ].Width, ControlTextures[ 1 ].Height );
			ControlRectangles[ 1 ] = new Rectangle( 0, 0, ControlTextures[ 1 ].Width, ControlTextures[ 1 ].Height );

			Color[] borderPixel = new Color[ ControlTextures[ 0 ].Width * ControlTextures[ 0 ].Height ];
			Color[] progressBarPixel = new Color[ ControlTextures[ 1 ].Width * ControlTextures[ 1 ].Height ];

			for( int y = 0; y < ControlTextures[ 0 ].Height; y++ ) {
				for( int x = 0; x < ControlTextures[ 0 ].Width; x++ ) {
					if( x < 3 || y < 3 || x > ControlTextures[ 0 ].Width - 3 || y > ControlTextures[ 0 ].Height - 3 ) {
						if( x == 0 || y == 0 || x == ControlTextures[ 0 ].Width - 1 || y == ControlTextures[ 0 ].Height - 1 )
							borderPixel[ x + y * ControlTextures[ 0 ].Width ] = Color.Black;
						if( x == 1 || y == 1 || x == ControlTextures[ 0 ].Width - 2 || y == ControlTextures[ 0 ].Height - 2 )
							borderPixel[ x + y * ControlTextures[ 0 ].Width ] = Color.LightGray;
						if( x == 2 || y == 2 || x == ControlTextures[ 0 ].Width - 3 || y == ControlTextures[ 0 ].Height - 3 )
							borderPixel[ x + y * ControlTextures[ 0 ].Width ] = Color.Gray;
					} else
						borderPixel[ x + y * ControlTextures[ 0 ].Width ] = new Color( new Vector4( ColorBgDefault.ToVector3(), 1f ) );
				}
			}

			for( int y = 0; y < ControlTextures[ 1 ].Height; y++ ) {
				for( int x = 0; x < ControlTextures[ 1 ].Width; x++ ) {
					bool bInvisiblePixel = false;

					if( ProgressBarStyle == EProgressBarStyle.Blocks ) {
						int xPos = x % (int)( ControlTextures[ 1 ].Width / (float)numberOfBlocks );
						if( xPos == 0 || xPos == 1 )
							bInvisiblePixel = true;
					}

					if( !bInvisiblePixel ) {
						float gradient = 1.0f - y * 0.035f;
						Color pixelColor = new Color( new Vector4( ColorFgDefault.ToVector3() * gradient, 1f ) );
						progressBarPixel[ x + y * ControlTextures[ 1 ].Width ] = pixelColor;
					}
				}
			}

			ControlTextures[ 0 ].SetData<Color>( borderPixel );
			ControlTextures[ 1 ].SetData<Color>( progressBarPixel );
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			base.Update( gameTime, formPosition, formSize );

			if( Value < 0 )
				Value = 0;
			if( Value > 100 )
				Value = 100;

			int rectWidth = (int)( ControlTextures[ 1 ].Width * ( (float)Value / (float)MaxValue ) );

			if( ProgressBarStyle == EProgressBarStyle.Continuous ) {
				ControlRectangles[ 1 ].Width = rectWidth;
				ControlRectangles[ 0 ].Width = ControlRectangles[ 1 ].Width;
			} else {
				int totalBlocks = (int)( ( numberOfBlocks + 1 ) * ( (float)Value / (float)MaxValue ) );

				int blockWidth = 0;
				blockWidth = (int)( ControlTextures[ 1 ].Width / numberOfBlocks );

				ControlRectangles[ 1 ].Width = blockWidth * totalBlocks;
				ControlRectangles[ 0 ].Width = ControlRectangles[ 1 ].Width;
			}

			ControlRectangles[ 1 ].X = (int)Position.X + 2;
			ControlRectangles[ 1 ].Y = (int)Position.Y + 4;

			CheckVisibility( formPosition, formSize );
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + ControlTextures[ 0 ].Width > formPosition.X + formSize.X - 15f )
				Visible = false;
			else if( Position.Y + ControlTextures[ 0 ].Height > formPosition.Y + formSize.Y - 25f )
				Visible = false;
			else
				Visible = true;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( 1f, 1f, 1f, alpha ) );
			spriteBatch.Draw( ControlTextures[ 0 ], Position, dynamicColor );
			spriteBatch.Draw( ControlTextures[ 1 ], ControlRectangles[ 1 ], ControlRectangles[ 0 ], dynamicColor );
		}
	}
}
