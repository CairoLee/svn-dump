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
	public class Button : Control {

		private Texture2D[] ControlTexturesCur;
		private Rectangle buttonArea = Rectangle.Empty;

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



		public Button() {
		}

		public Button( string name, Vector2 position, string BtnTextureName, int Width, SFormStyle style ) {
			ControlType = EControlType.TextButton;
			Name = name;
			PositionOrg = position;
			Position = position;
			WindowStyle = style;
			ControlSize = new Point( Width, ControlSize.Y );

			InitDefaults();
			InitEvents();
			InitTextures( BtnTextureName );
		}




		public override void InitDefaults() {
			ColorBgDefaults = new Color[ 2 ] { Color.White, Color.Gray };
		}

		public override void InitEvents() {
			OnMouseOver += new EventHandler( buttonMouseOver );
			OnMouseOut += new EventHandler( buttonMouseOut );
			OnMouseClick += new EventHandler( buttonMouseClick );
			OnMouseRelease += new EventHandler( buttonMouseRelease );
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

			if( ControlSize.X > ( ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width ) )
				ControlRectangles[ 1 ].Width = ControlSize.X - ( ControlRectangles[ 0 ].Width + ControlRectangles[ 2 ].Width );

			buttonArea.Width = ( ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width );
			buttonArea.Height = ControlRectangles[ 0 ].Height;

			ControlSize = new Point( ControlRectangles[ 0 ].Width + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width, ControlRectangles[ 0 ].Height );
		}


		private void buttonMouseOut( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOut ) {
				BtnState = EBtnState.MouseOut;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 0 ], ControlTextures[ 1 ], ControlTextures[ 2 ] };
			}
		}

		private void buttonMouseOver( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOver ) {
				BtnState = EBtnState.MouseOver;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 3 ], ControlTextures[ 4 ], ControlTextures[ 5 ] };
			}
		}

		private void buttonMouseClick( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Pressed ) {
				BtnState = EBtnState.Pressed;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 6 ], ControlTextures[ 7 ], ControlTextures[ 8 ] };
			}
		}

		private void buttonMouseRelease( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Released ) {
				BtnState = EBtnState.Released;
				ControlTexturesCur = new Texture2D[ 3 ] { ControlTextures[ 0 ], ControlTextures[ 1 ], ControlTextures[ 2 ] };
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
			Vector3 dynamicVector = ( Disabled == false ? ColorBgDefaults[ 0 ].ToVector3() : ColorBgDefaults[ 1 ].ToVector3() );
			Color dynamicColor = new Color( new Vector4( dynamicVector.X, dynamicVector.Y, dynamicVector.Z, alpha ) );

			spriteBatch.Draw( ControlTexturesCur[ 0 ], ControlRectangles[ 0 ], dynamicColor );
			spriteBatch.Draw( ControlTexturesCur[ 1 ], ControlRectangles[ 1 ], dynamicColor );
			spriteBatch.Draw( ControlTexturesCur[ 2 ], ControlRectangles[ 2 ], dynamicColor );
		}
	}
}
