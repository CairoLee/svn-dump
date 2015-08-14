using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FreeWorld.Engine.WindowLibrary {

	[Serializable]
	public class Label : Control {
		private Rectangle mButtonArea = Rectangle.Empty;
		private static Texture2D mTextureBlank = null;

		public event EventHandler OnMouseOver;
		public event EventHandler OnMouseOut;
		public event EventHandler OnMouseClick;
		public event EventHandler OnMouseRelease;


		public Label() {
		}

		public Label( string name, Vector2 position, string text, Color color, SpriteFont font ) {
			ControlType = EControlType.Label;
			Name = name;
			PositionOrg = position;
			Position = this.PositionOrg;
			Text = text;
			ColorFgDefault = color;
			ColorBgDefault = Color.Transparent;
			SpriteFont = font;

			InitDefaults();
			InitEvents();
			InitTextures();
		}

		public override void InitDefaults() {
		}

		public override void InitEvents() {
			OnMouseOver += new EventHandler( buttonMouseOver );
			OnMouseOut += new EventHandler( buttonMouseOut );
			OnMouseClick += new EventHandler( buttonMouseClick );
			OnMouseRelease += new EventHandler( buttonMouseRelease );
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



		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			base.Update( gameTime, formPosition, formSize );
			CheckVisibility( formPosition, formSize );

			if( Form.InUse == false )
				CheckMouseState( formPosition );
		}

		private void CheckMouseState( Vector2 formPosition ) {
			MouseState = Mouse.GetState();

			mButtonArea.X = (int)PositionOrg.X + (int)formPosition.X;
			mButtonArea.Y = (int)PositionOrg.Y + (int)formPosition.Y;

			if( Disabled == false && MathAdd.isInRectangle( new Point( MouseState.X, MouseState.Y ), mButtonArea ) ) {
				if( BtnState != EBtnState.MouseOver && BtnState != EBtnState.Pressed )
					OnMouseOver( this, EventArgs.Empty );

				if( MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ) {
					if( BtnState != EBtnState.Pressed )
						OnMouseClick( this, EventArgs.Empty );
				} else {
					if( BtnState == EBtnState.Pressed ) {
						OnMouseRelease( this, EventArgs.Empty );
					}
				}
			} else if( Disabled == false && BtnState == EBtnState.MouseOver ) {
				OnMouseOut( this, EventArgs.Empty );
			}
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Text == String.Empty )
				Visible = false;
			else if( Position.X + SpriteFont.MeasureString( Name ).X > formPosition.X + formSize.X - 15f )
				Visible = false;
			else if( Position.Y + 15f > formPosition.Y + formSize.Y - 25f )
				Visible = false;
			else
				Visible = true;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( ColorFgDefault.ToVector3(), alpha ) );
			Vector2 drawPos = Position;
			Vector2 textSize = SpriteFont.MeasureString( Text );
			string[] Lines = Text.Split( new char[] { '\n' } );

			if( ColorBgDefault != Color.Transparent ) {
				Color dynBg = new Color( new Vector4( ColorBgDefault.ToVector3(), alpha ) );
				mButtonArea = new Rectangle( (int)Position.X - Value, (int)Position.Y - Value, ControlSize.X, ControlSize.Y );
				if( ControlSize.X == 0 )
					mButtonArea.Width = (int)textSize.X + 5;
				if( ControlSize.Y == 0 )
					mButtonArea.Height = (int)textSize.Y + 5;

				if( mTextureBlank == null )
					mTextureBlank = EngineCore.ContentLoader.Load<Texture2D>( @"Interface\blank" );

				spriteBatch.Draw( mTextureBlank, mButtonArea, dynBg );
				if( BorderColor != Color.Transparent ) {
					Texture2D tex = DrawHelper.Rect2Texture( 1, 1, 0, BorderColor );
					spriteBatch.DrawRectangle( tex, mButtonArea, 1, BorderColor );
				}
			} else
				mButtonArea = new Rectangle( mButtonArea.X, mButtonArea.Y, ControlSize.X, ControlSize.Y );

			for( int i = 0; i < Lines.Length; i++ ) {
				if( i > 0 )
					drawPos.Y += SpriteFont.LineSpacing;
				spriteBatch.DrawString( SpriteFont, Lines[ i ], drawPos, dynamicColor );
			}

		}

	}

}
