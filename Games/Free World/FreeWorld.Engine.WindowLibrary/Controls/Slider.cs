using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class Slider : Control {
		private Texture2D sliderBar;
		private Texture2D slider;

		private Vector2 sliderPosition = Vector2.Zero;
		private Vector2 oldSliderPosition = Vector2.Zero;

		private Vector2 mousePosition = Vector2.Zero;
		private Vector2 oldMousePosition = Vector2.Zero;

		bool bSliding = false;

		public event EventHandler OnChangeValue;
		public void slider_onChangeValue( Object obj, EventArgs e ) {
		}


		public Slider() {
		}

		public Slider( string name, Vector2 position, Texture2D Texture, int Width, int min, int max, int value, SFormStyle WndStyle ) {
			ControlType = EControlType.Slider;
			Name = name;
			PositionOrg = position;
			Position = PositionOrg;
			ControlSize = new Point( Width, ControlSize.Y );
			MinValue = min;
			MaxValue = max;
			Value = value;
			WindowStyle = WndStyle;
			slider = Texture;

			InitTextures();
			InitDefaults();
			InitEvents();
		}

		public override void InitDefaults() {
			float percentage = 0f;
			percentage = (float)( this.Value - this.MinValue ) / (float)( this.MaxValue - this.MinValue );
			sliderPosition.X = ControlSize.X * percentage;
			oldSliderPosition = sliderPosition;
		}

		public override void InitEvents() {

			OnChangeValue += new EventHandler( slider_onChangeValue );
		}

		public override void InitTextures() {
			sliderBar = new Texture2D( Constants.GraphicsDevice, ControlSize.X, 5, true, SurfaceFormat.Color );

			Color[] pixels = new Color[ sliderBar.Width * sliderBar.Height ];
			for( int y = 0; y < sliderBar.Height; y++ ) {
				for( int x = 0; x < sliderBar.Width; x++ ) {
					if( y == 0 )
						pixels[ x + y * sliderBar.Width ] = new Color( new Vector4( 0.5f, 0.5f, 0.5f, 1f ) );
					else if( y == 1 )
						pixels[ x + y * sliderBar.Width ] = new Color( new Vector4( 0.7f, 0.7f, 0.7f, 1f ) );
					else if( y == 2 )
						pixels[ x + y * sliderBar.Width ] = new Color( new Vector4( 0.6f, 0.6f, 0.6f, 1f ) );
					else if( y == 3 )
						pixels[ x + y * sliderBar.Width ] = new Color( new Vector4( 0f, 0f, 0f, 1f ) );
					else if( y == 4 )
						pixels[ x + y * sliderBar.Width ] = new Color( new Vector4( 0.1f, 0.1f, 0.1f, 1f ) );
				}
			}

			sliderBar.SetData<Color>( pixels );
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			Position = PositionOrg + formPosition;
			CheckVisibility( formPosition, formSize );

			if( Visible )
				CheckSliding();
		}

		private void CheckSliding() {
			MouseState = Mouse.GetState();
			mousePosition.X = MouseState.X;
			mousePosition.Y = MouseState.Y;

			if( MouseState.LeftButton == ButtonState.Pressed ) {
				if( !bSliding && bIsOverSlider() ) {
					Form.InUse = true;
					bSliding = true;
					oldMousePosition = mousePosition;
					oldSliderPosition = sliderPosition;
				} else if( bSliding ) {
					sliderPosition.X = oldSliderPosition.X + ( mousePosition.X - oldMousePosition.X );

					if( sliderPosition.X < 0f )
						sliderPosition.X = 0f;
					else if( sliderPosition.X > ControlSize.X )
						sliderPosition.X = ControlSize.X;

					int valuesLength = MaxValue - MinValue;
					int percentage = (int)( ( ( sliderPosition.X / ControlSize.X ) * 100f ) );
					SetValue( (int)( valuesLength * percentage / 100 ) + MinValue );
				}
			} else if( bSliding ) {
				Form.InUse = false;
				bSliding = false;
			}
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + ControlSize.X > formPosition.X + formSize.X - 15f )
				Visible = false;
			else if( Position.Y + slider.Height > formPosition.Y + formSize.Y - 25f )
				Visible = false;
			else
				Visible = true;
		}

		private void SetValue( int value ) {
			this.Value = value;
			OnChangeValue( this, EventArgs.Empty );
		}

		private bool bIsOverSlider() {
			if( !bSliding ) {
				if( MouseState.X > Position.X + sliderPosition.X - slider.Width / 2f && MouseState.X < Position.X + sliderPosition.X + slider.Width / 2f ) {
					if( MouseState.Y > Position.Y + sliderPosition.Y && MouseState.Y < Position.Y + sliderPosition.Y + slider.Width ) {
						return true;
					} else
						return false;
				} else
					return false;
			} else
				return true;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( 1f, 1f, 1f, alpha ) );
			spriteBatch.Draw( sliderBar, Position + new Vector2( 0f, slider.Height * 0.3f ), dynamicColor );
			spriteBatch.Draw( slider, Position + sliderPosition - new Vector2( slider.Width / 2f, 0f ), dynamicColor );
		}
	}
}
