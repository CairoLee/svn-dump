using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class Checkbox : Control {

		public event EventHandler OnPress;
		public void checkbox_onPress( Object obj, EventArgs e ) {
			BtnState = EBtnState.Pressed;
			Checked = !Checked;
		}


		public Checkbox() {
		}

		public Checkbox( string name, Vector2 origin, string text, SpriteFont Font, SFormStyle WndStyle ) {
			ControlType = EControlType.Checkbox;
			Name = name;
			PositionOrg = origin;
			Position = PositionOrg;
			Text = text;
			SpriteFont = Font;
			WindowStyle = WndStyle;

			InitTextures();

			OnPress += new EventHandler( checkbox_onPress );
		}

		public override void InitDefaults() {
		}

		public override void InitEvents() {
		}

		public override void InitTextures() {
			ControlTextureNames = new string[ 2 ]{
				@"Interface\" + WindowStyle + @"\Button\checkbox",
				@"Interface\" + WindowStyle + @"\Button\checkbox_checked"
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
			if( Position.X + ControlTextures[ 0 ].Width + SpriteFont.MeasureString( Text ).X > formPosition.X + formSize.X - 15f )
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
				else
					return false;
			else
				return false;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( Vector3.One, alpha ) );
			Color dynamicTextColor = new Color( new Vector4( Vector3.Zero, 1f ) * alpha );

			if( Checked )
				spriteBatch.Draw( ControlTextures[ 1 ], Position, dynamicColor );
			else
				spriteBatch.Draw( ControlTextures[ 0 ], Position, dynamicColor );

			spriteBatch.DrawString( SpriteFont, Text, Position + new Vector2( ControlTextures[ 0 ].Width + 5f, -( SpriteFont.LineSpacing - ControlTextures[ 0 ].Height ) / 2 ), dynamicTextColor );
		}
	}
}
