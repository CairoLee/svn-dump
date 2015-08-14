using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Diagnostics;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class TextButton : Control {

		private Texture2D[] ControlTexturesCur;
		private Rectangle buttonArea = Rectangle.Empty;

		public event EventHandler OnMouseOver;
		public event EventHandler OnMouseOut;
		public event EventHandler OnMouseClick;
		public event EventHandler OnMouseRelease;


		public TextButton() {
		}

		public TextButton( string name, Vector2 position, string BtnText, string BtnTextureName, int Width, SpriteFont font, SFormStyle style ) {
			ControlType = EControlType.TextButton;
			Name = name;
			PositionOrg = position;
			Position = position;
			Text = BtnText;
			SpriteFont = font;
			WindowStyle = style;
			ControlSize = new Point( Width, ControlSize.Y );

			InitTextures( BtnTextureName );
			InitDefaults();
			InitEvents();
		}

		public override void InitDefaults() {
			if( ColorBgDefaults == null )
				ColorBgDefaults = new Color[ 2 ] { Color.White, Color.Gray };
		}

		public override void InitEvents() {
			OnMouseOver += new EventHandler( ButtonMouseOver );
			OnMouseOut += new EventHandler( ButtonMouseOut );
			OnMouseClick += new EventHandler( ButtonMouseClick );
			OnMouseRelease += new EventHandler( ButtonMouseRelease );
		}

		public override void InitTextures( string BtnTextureName ) {
			if( BtnTextureName == string.Empty )
				BtnTextureName = "button";

			ControlTextureName = BtnTextureName;
			ControlTextureNames = new string[ 9 ]{
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\left",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\middle",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\right",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\Hover_left",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\Hover_middle",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\Hover_right",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\Pressed_left",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\Pressed_middle",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\Pressed_right"
			};

			ControlTextures = EngineCore.ContentLoader.Load<Texture2D>( ControlTextureNames );
			ControlTexturesCur = new Texture2D[ 3 ]{
				ControlTextures[ 0 ],
				ControlTextures[ 1 ],
				ControlTextures[ 2 ]
			};

			Calculate();
		}

		public void Calculate() {

			ControlRectangles = new Rectangle[ 3 ]{
				new Rectangle( 0, 0, ControlTexturesCur[ 0 ].Width, ControlTexturesCur[ 0 ].Height ),
				new Rectangle( 0, 0, ControlTexturesCur[ 1 ].Width, ControlTexturesCur[ 1 ].Height ),
				new Rectangle( 0, 0, ControlTexturesCur[ 2 ].Width, ControlTexturesCur[ 2 ].Height )
			};

			if( ControlSize.X == 0 ) {
				ControlRectangles[ 1 ].Width = (int)SpriteFont.MeasureString( Text ).X;
			} else if( ControlSize.X > ( ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width ) ) {
				ControlRectangles[ 1 ].Width = ControlSize.X - ( ControlRectangles[ 0 ].Width + ControlRectangles[ 2 ].Width );
			}

			ControlSize = new Point( ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width, ControlRectangles[ 0 ].Height );

			buttonArea.Width = ( ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width );
			buttonArea.Height = ControlRectangles[ 0 ].Height;
		}


		public void ButtonMouseOut( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOut ) {
				BtnState = EBtnState.MouseOut;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 0 ], ControlTextures[ 1 ], ControlTextures[ 2 ] };
				Cursor.Current = Cursors.Default;
			}
		}

		public void ButtonMouseOver( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOver ) {
				BtnState = EBtnState.MouseOver;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 3 ], ControlTextures[ 4 ], ControlTextures[ 5 ] };
				Cursor = Cursors.Hand;
			}
		}

		public void ButtonMouseClick( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Pressed ) {
				BtnState = EBtnState.Pressed;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 6 ], ControlTextures[ 7 ], ControlTextures[ 8 ] };
				Cursor = Cursors.Hand;
			}
		}

		public void ButtonMouseRelease( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Released ) {
				BtnState = EBtnState.Released;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 0 ], ControlTextures[ 1 ], ControlTextures[ 2 ] };
				Cursor = Cursors.Default;
			}
		}


		public override void Update() {
			base.Update();

			Position = PositionOrg;

			ControlRectangles[ 0 ].X = (int)Position.X;
			ControlRectangles[ 0 ].Y = (int)Position.Y;

			ControlRectangles[ 1 ].X = (int)Position.X + ControlRectangles[ 0 ].Width;
			ControlRectangles[ 1 ].Y = (int)Position.Y;

			ControlRectangles[ 2 ].X = (int)Position.X + ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width;
			ControlRectangles[ 2 ].Y = (int)Position.Y;

			if( Form.InUse == false )
				CheckMouseState();
		}


		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			base.Update( gameTime, formPosition, formSize );

			Position = PositionOrg + formPosition;

			ControlRectangles[ 0 ].X = (int)Position.X;
			ControlRectangles[ 0 ].Y = (int)Position.Y;

			ControlRectangles[ 1 ].X = (int)Position.X + ControlRectangles[ 0 ].Width;
			ControlRectangles[ 1 ].Y = (int)Position.Y;

			ControlRectangles[ 2 ].X = (int)Position.X + ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width;
			ControlRectangles[ 2 ].Y = (int)Position.Y;

			if( Form.InUse == false )
				CheckMouseState();

			CheckVisibility( formPosition, formSize );
		}

		private void CheckMouseState() {
			MouseState = Mouse.GetState();

			buttonArea.X = (int)Position.X;
			buttonArea.Y = (int)Position.Y;

			if( Disabled == false && MathAdd.isInRectangle( new Point( MouseState.X, MouseState.Y ), buttonArea ) ) {
				if( BtnState != EBtnState.MouseOver )
					Cursor = Cursors.Hand;
				else if( BtnState == EBtnState.MouseOver && Cursor != Cursors.Hand )
					Cursor = Cursors.Hand;

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
				Cursor = Cursors.Default;
			}
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + buttonArea.Width > formPosition.X + formSize.X )
				Visible = false;
			else if( Position.Y + buttonArea.Height > formPosition.Y + formSize.Y )
				Visible = false;
			else
				Visible = true;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor;
			Vector3 dynamicVector = ( Disabled == false ? ColorBgDefaults[ 0 ].ToVector3() : ColorBgDefaults[ 1 ].ToVector3() );
			dynamicColor = new Color( new Vector4( dynamicVector.X, dynamicVector.Y, dynamicVector.Z, alpha ) );

			spriteBatch.Draw( ControlTexturesCur[ 0 ], ControlRectangles[ 0 ], dynamicColor );
			spriteBatch.Draw( ControlTexturesCur[ 1 ], ControlRectangles[ 1 ], dynamicColor );
			spriteBatch.Draw( ControlTexturesCur[ 2 ], ControlRectangles[ 2 ], dynamicColor );

			Color dynamicTextColor = new Color( new Vector4( 0f, 0f, 0f, alpha ) );

			Vector2 spacing = new Vector2( (int)( buttonArea.Width - SpriteFont.MeasureString( Text ).X ) / 2, 2f );
			if( ( BtnState & EBtnState.Pressed ) != 0 )
				spacing += new Vector2( 1f, 1f );

			spriteBatch.DrawString( SpriteFont, Text, new Vector2( ControlRectangles[ 0 ].X + spacing.X + 1f, ControlRectangles[ 0 ].Y + spacing.Y + 1f ), Color.White );
			spriteBatch.DrawString( SpriteFont, Text, new Vector2( ControlRectangles[ 0 ].X + spacing.X, ControlRectangles[ 0 ].Y + spacing.Y ), dynamicTextColor );
		}
	}
}
