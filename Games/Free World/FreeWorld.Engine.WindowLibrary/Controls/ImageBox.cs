using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;
using System.IO;

namespace FreeWorld.Engine.WindowLibrary {
	
	[Serializable]
	public class ImageBox : Control {

		public event EventHandler OnMouseOver;
		public void onMouseOver( Object obj, EventArgs e ) {
		}
		public event EventHandler OnMouseOut;
		public void onMouseOut( Object obj, EventArgs e ) {
		}
		public event EventHandler OnMouseClick;
		public void onMouseClick( Object obj, EventArgs e ) {
		}
		public event EventHandler OnMouseRelease;
		public void onMouseRelease( Object obj, EventArgs e ) {
		}


		public ImageBox() {
		}

		public ImageBox( string ImageName, Vector2 Pos, Point Size, Texture2D ImgTexture, Color DefaultColor, SFormStyle Style ) {
			ControlType = EControlType.ImageBox;
			Name = ImageName;
			PositionOrg = Pos;
			Position = Pos;
			WindowStyle = Style;
			ControlTexture = ImgTexture;
			ColorBgDefault = DefaultColor;
			ControlSize = Size;

			OnMouseOver += new EventHandler( buttonMouseOver );
			OnMouseOut += new EventHandler( buttonMouseOut );
			OnMouseClick += new EventHandler( buttonMouseClick );
			OnMouseRelease += new EventHandler( buttonMouseRelease );
		}

		public override void InitDefaults() {
		}

		public override void InitEvents() {
		}

		public override void InitTextures() {
		}

		private void buttonMouseOut( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOut ) {
				BtnState = EBtnState.MouseOut;
			}
		}

		private void buttonMouseOver( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOver ) {
				BtnState = EBtnState.MouseOver;
			}
		}

		private void buttonMouseClick( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Pressed ) {
				BtnState = EBtnState.Pressed;
			}
		}

		private void buttonMouseRelease( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Released ) {
				BtnState = EBtnState.Released;
			}
		}

		public override void Update() {
			if( !Form.InUse )
				UpdateEButtonState();

			if( Form.TopForm == Owner && Owner.TabIndex == this.TabOrder )
				CheckKeyboardState();
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			Position = PositionOrg + formPosition;

			if( !Form.InUse )
				UpdateEButtonState();

			CheckVisibility( formPosition, formSize );

			if( Form.TopForm == Owner && Owner.TabIndex == this.TabOrder )
				CheckKeyboardState();

			base.Update( gameTime );
		}

		private void UpdateEButtonState() {
			MouseState = Mouse.GetState();

			ColorBgCurrent = ColorBgDefault;

			if( ControlTexture == null || Disabled == true )
				return;

			if( MouseState.X > Position.X && MouseState.X < Position.X + ControlTexture.Width ) {
				if( MouseState.Y > Position.Y && MouseState.Y < Position.Y + ControlTexture.Height ) {
					if( BtnState != EBtnState.MouseOver && BtnState!= EBtnState.Pressed )
						OnMouseOver( this, EventArgs.Empty );

					if( MouseState.LeftButton == ButtonState.Pressed ) {
						if( BtnState != EBtnState.Pressed )
							OnMouseClick( this, EventArgs.Empty );
					} else {
						if( BtnState == EBtnState.Pressed )
							OnMouseRelease( this, EventArgs.Empty );
					}
				} else {
					if( BtnState == EBtnState.MouseOver )
						OnMouseOut( this, EventArgs.Empty );
					return;
				}
			} else {
				if( BtnState == EBtnState.MouseOver )
					OnMouseOut( this, EventArgs.Empty );
				return;
			}

			if( MouseState.LeftButton == ButtonState.Released && BtnState == EBtnState.Pressed ) {
				OnMouseOut( this, EventArgs.Empty );
			}
		}

		bool bSpaceDown = false;
		private void CheckKeyboardState() {
			KeyboardState = Keyboard.GetState();

			if( KeyboardState.IsKeyDown( Keys.Space ) || KeyboardState.IsKeyDown( Keys.Enter ) ) {
				if( !bSpaceDown ) {
					bSpaceDown = true;
					OnMouseClick( this, EventArgs.Empty );
				}
			} else if( bSpaceDown )
				bSpaceDown = false;
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( ControlTexture == null )
				Visible = false;
			else if( Position.X + ControlTexture.Width > formPosition.X + formSize.X - 15f )
				Visible = false;
			else if( Position.Y + ControlTexture.Height > formPosition.Y + formSize.Y - 25f )
				Visible = false;
			else
				Visible = true;
		}

		public void Draw( SpriteBatch spriteBatch, Vector2 formPosition, float alpha ) {
			Color dynamicColor = new Color( new Vector4( ColorBgCurrent.ToVector3(), alpha ) );
			Position = formPosition + PositionOrg;

			if( ControlTexture != null && Disabled == false )
				spriteBatch.Draw( ControlTexture, Position, new Rectangle( 0, 0, ControlSize.X, ControlSize.Y ), dynamicColor );
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( ColorBgCurrent.ToVector3(), alpha ) );

			if( ControlTexture != null && Disabled == false )
				spriteBatch.Draw( ControlTexture, Position, new Rectangle( 0, 0, ControlSize.X, ControlSize.Y ), dynamicColor );
		}
	}

}
