using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class RadioButton : Control {
		int charWidth;

		public event EventHandler OnPress;
		public void checkbox_onPress( Object obj, EventArgs e ) {
			BtnState = EBtnState.Pressed;
			Checked = !Checked;
		}

		public RadioButton() {
		}

		public RadioButton( string name, Vector2 origin, string text, bool bChecked, SpriteFont font, SFormStyle style ) {
			ControlType = EControlType.RadioButton;
			Name = name;
			PositionOrg = origin;
			Position = PositionOrg;
			Text = text;
			Checked = bChecked;
			SpriteFont = font;

			InitTextures();
			InitDefaults();
			InitEvents();
		}

		public override void InitDefaults() {
			charWidth = 9;
		}

		public override void InitEvents() {
			OnPress += new EventHandler( checkbox_onPress );
		}

		public override void InitTextures() {
			ControlTextureNames = new string[ 2 ]{
				@"Interface\" + WindowStyle + @"\Button\radio_button",
				@"Interface\" + WindowStyle + @"\Button\radio_button_checked"
			};

			ControlTextures = EngineCore.ContentLoader.Load<Texture2D>( ControlTextureNames );
		}



		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			Position = PositionOrg + formPosition;

			CheckVisibility( formPosition, formSize );

			if( !Form.InUse )
				CheckSelection();
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + ControlTextures[ 0 ].Width + charWidth * Text.Length > formPosition.X + formSize.X - 15f )
				Visible = false;
			else if( Position.Y + ControlTextures[ 0 ].Height > formPosition.Y + formSize.Y - 25f )
				Visible = false;
			else
				Visible = true;
		}

		private void CheckSelection() {
			MouseState = Mouse.GetState();
			if( MouseState.LeftButton == ButtonState.Pressed ) {
				if( BtnState != EBtnState.Pressed && bIsOverButton() )
					OnPress( this, EventArgs.Empty );
			} else if( BtnState == EBtnState.Pressed )
				BtnState = EBtnState.Released;
			else {
				if( BtnState != EBtnState.MouseOver && bIsOverButton() )
					BtnState = EBtnState.MouseOver;
				else if( BtnState == EBtnState.MouseOver && !bIsOverButton() )
					BtnState = EBtnState.MouseOut;
			}
		}

		private bool bIsOverButton() {
			if( MouseState.X > Position.X && MouseState.X < Position.X + ControlTextures[ 0 ].Width )
				if( MouseState.Y > Position.Y && MouseState.Y < Position.Y + ControlTextures[ 0 ].Height )
					return true;

			return false;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( 1f, 1f, 1f, alpha ) );
			Color dynamicTextColor = new Color( new Vector4( 0f, 0f, 0f, 1f ) * alpha );

			if( Checked )
				spriteBatch.Draw( ControlTextures[ 1 ], Position, dynamicColor );
			else
				spriteBatch.Draw( ControlTextures[ 0 ], Position, dynamicColor );

			spriteBatch.DrawString( SpriteFont, Text, Position + new Vector2( ControlTextures[ 0 ].Width + 5f, -( SpriteFont.LineSpacing - ControlTextures[ 0 ].Height ) / 2 ), dynamicTextColor );
		}
	}
}
