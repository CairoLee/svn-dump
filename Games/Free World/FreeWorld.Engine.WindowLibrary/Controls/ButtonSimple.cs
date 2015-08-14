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
	public class ButtonSimple : Control {
		private Texture2D ControlTextureCur;

		public event EventHandler OnMouseOver;
		public event EventHandler OnMouseOut;
		public event EventHandler OnMouseClick;
		public event EventHandler OnMouseRelease;


		public ButtonSimple() {
		}

		public ButtonSimple( string name, Vector2 position, string BtnTextureName, SFormStyle style ) {
			ControlType = EControlType.TextButton;
			Name = name;
			PositionOrg = position;
			Position = position;
			WindowStyle = style;

			InitDefaults();
			InitEvents();
			InitTextures( BtnTextureName );
		}




		public override void InitDefaults() {
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
			ControlTextureNames = new string[ 3 ]{
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\"+BtnTextureName+@"",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\"+BtnTextureName+@"Hover",
				@"Interface\" + WindowStyle + @"\Button\"+BtnTextureName+@"\"+BtnTextureName+@"Pressed"
			};

			ControlTextures = EngineCore.ContentLoader.Load<Texture2D>( ControlTextureNames );
			ControlTextureCur = ControlTextures[ 0 ];

			Calculate();
		}

		public void Calculate() {

			ControlRectangle = new Rectangle( 0, 0, ControlTextureCur.Width, ControlTextureCur.Height );
			ControlSize = new Point( System.Math.Max( ControlTextureCur.Width, ControlSize.X ), System.Math.Max( ControlTextureCur.Height, ControlSize.Y ) );

		}


		private void ButtonMouseOut( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOut ) {
				BtnState = EBtnState.MouseOut;
				ControlTextureCur = ControlTextures[ 0 ];
			}
		}

		private void ButtonMouseOver( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.MouseOver ) {
				BtnState = EBtnState.MouseOver;
				ControlTextureCur = ControlTextures[ 1 ];
			}
		}

		private void ButtonMouseClick( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Pressed ) {
				BtnState = EBtnState.Pressed;
				ControlTextureCur = ControlTextures[ 2 ];
			}
		}

		private void ButtonMouseRelease( Object obj, EventArgs e ) {
			if( BtnState != EBtnState.Released ) {
				BtnState = EBtnState.Released;
				ControlTextureCur = ControlTextures[ 0 ];
			}
		}


		public override void Update() {
			base.Update();

			Position = PositionOrg;

			ControlRectangle = new Rectangle( (int)Position.X, (int)Position.Y, ControlRectangle.Width, ControlRectangle.Height );

			if( Form.InUse == false )
				CheckMouseState();
		}

		public override void Update( GameTime gameTime ) {
			base.Update( gameTime );

			Position = PositionOrg;

			ControlRectangle = new Rectangle( (int)Position.X, (int)Position.Y, ControlRectangle.Width, ControlRectangle.Height );

			if( Form.InUse == false )
				CheckMouseState();
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			base.Update( gameTime, formPosition, formSize );

			Position = PositionOrg + formPosition;

			ControlRectangle = new Rectangle( (int)Position.X, (int)Position.Y, ControlRectangle.Width, ControlRectangle.Height );

			if( Form.InUse == false )
				CheckMouseState();

			CheckVisibility( formPosition, formSize );
		}

		private void CheckMouseState() {
			MouseState = Mouse.GetState();

			if( Disabled == false && MathAdd.isInRectangle( new Point( MouseState.X, MouseState.Y ), ControlRectangle ) ) {
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
			if( Position.X + ControlRectangle.Width > formPosition.X + formSize.X )
				Visible = false;
			else if( Position.Y + ControlRectangle.Height > formPosition.Y + formSize.Y )
				Visible = false;
			else
				Visible = true;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Vector3 dynamicVector = ( Disabled == false ? ColorBgDefaults[ 0 ].ToVector3() : ColorBgDefaults[ 1 ].ToVector3() );
			Color dynamicColor = new Color( new Vector4( dynamicVector.X, dynamicVector.Y, dynamicVector.Z, alpha ) );

			spriteBatch.Draw( ControlTextureCur, ControlRectangle, dynamicColor );
		}
	}
}
