using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {

	[Serializable]
	public class Scrollbar : Control {
		ButtonSimple scrollUp, scrollDown;
		Texture2D barTex, scrollerTex;

		Vector2 scrollerPosition = Vector2.Zero;

		bool bIsScrolling = false;
		bool bMouseClicked = false;
		Rectangle scrollerArea = Rectangle.Empty;
		Rectangle barArea = Rectangle.Empty;
		int scrollStart = 0;

		int tick = 1;
		int pageSize = 5;

		public event EventHandler OnValueChange;


		public Scrollbar() {
		}

		public Scrollbar( string name, Vector2 position, EScrollBarAxis Axis, int width, int height, int max, int value, SFormStyle WndStyle ) {
			ControlType = EControlType.Scrollbar;
			Name = name;
			PositionOrg = position;
			Position = position;
			ScrollBarAxis = Axis;
			WindowStyle = WndStyle;

			InitDefaults();
			InitTextures();
			InitEvents();
		}

		public override void InitDefaults() {
			switch( ScrollBarAxis ) {
				case EScrollBarAxis.Horizontal:
					scrollUp = new ButtonSimple( "btScrollUp", Vector2.Zero, "scroll_up", WindowStyle );
					scrollDown = new ButtonSimple( "btScrollDown", Vector2.Zero, "scroll_down", WindowStyle );
					break;
				case EScrollBarAxis.Vertical:
					scrollUp = new ButtonSimple( "btScrollUp", Vector2.Zero, "scroll_left", WindowStyle );
					scrollDown = new ButtonSimple( "btScrollDown", Vector2.Zero, "scroll_right", WindowStyle );
					break;
			}
		}

		public override void InitEvents() {
			scrollUp.OnMouseClick += new EventHandler( On_ScrollUp );
			scrollDown.OnMouseClick += new EventHandler( On_ScrollDown );
			OnValueChange += new EventHandler( onValueChange );
		}


		public override void InitTextures() {
			switch( ScrollBarAxis ) {
				case EScrollBarAxis.Horizontal:
					ControlTexture = EngineCore.ContentLoader.Load<Texture2D>( WindowStyle + @"\Button\scrollbar_horizontal" );
					barTex = EngineCore.ContentLoader.Load<Texture2D>( WindowStyle + @"\Button\scrollbar_horizontal" );
					break;
				case EScrollBarAxis.Vertical:
					ControlTexture = EngineCore.ContentLoader.Load<Texture2D>( WindowStyle + @"\Button\scrollbar_vertical" );
					barTex = EngineCore.ContentLoader.Load<Texture2D>( WindowStyle + @"\Button\scrollbar_vertical" );
					break;
			}

			scrollerTex = EngineCore.ContentLoader.Load<Texture2D>( WindowStyle + @"\Button\scrollbar_scroller" );
		}

		public void On_ScrollUp( object obj, EventArgs e ) {
			Value -= tick;
			if( Value < 0 )
				Value = 0;
			OnValueChange( this, EventArgs.Empty );
		}

		public void On_ScrollDown( object obj, EventArgs e ) {
			Value += tick;
			if( Value > MaxValue )
				Value = MaxValue;
			OnValueChange( this, EventArgs.Empty );
		}

		private void onValueChange( object obj, EventArgs e ) {
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			base.Update( gameTime, formPosition, formSize );

			scrollUp.Update( gameTime, Position, formSize );
			scrollDown.Update( gameTime, Position, formSize );

			MouseState = Mouse.GetState();

			scrollerArea = new Rectangle( (int)scrollerPosition.X, (int)scrollerPosition.Y, scrollerTex.Width, scrollerTex.Height );

			if( !Form.InUse && MaxValue > 0 ) {
				switch( ScrollBarAxis ) {
					case EScrollBarAxis.Horizontal:
						CheckHorizontalBar();
						break;
					case EScrollBarAxis.Vertical:
						CheckVerticalBar();
						break;
				}
			}

			UpdateScroller( gameTime, formSize );

			CheckVisibility( formPosition, formSize );
		}

		public void UpdateScroller( GameTime gameTime, Vector2 formSize ) {
			float percentage = (float)Value / MaxValue;

			switch( ScrollBarAxis ) {
				case EScrollBarAxis.Horizontal:

					scrollDown.Update( gameTime, Position + new Vector2( ControlSize.X - scrollUp.ControlSize.X, 0f ), formSize );

					float ControlSizeX = ControlSize.X - ( scrollUp.ControlSize.X + scrollDown.ControlSize.X + scrollerTex.Width );
					float posX = ControlSizeX * percentage;

					if( !bIsScrolling )
						scrollerPosition = new Vector2( Position.X + scrollUp.ControlSize.X + posX, Position.Y + 1f );
					else
						scrollerPosition = new Vector2( Position.X + scrollUp.ControlSize.X + posX + ( MouseState.X - scrollStart ), Position.Y + 1f );

					if( scrollerPosition.X < Position.X + scrollUp.ControlSize.X )
						scrollerPosition.X = Position.X + scrollUp.ControlSize.X;
					else if( scrollerPosition.X > Position.X + ControlSize.X - ( scrollUp.ControlSize.X + scrollerTex.Width ) )
						scrollerPosition.X = Position.X + ControlSize.X - ( scrollUp.ControlSize.X + scrollerTex.Width );

					break;

				case EScrollBarAxis.Vertical:

					scrollDown.Update( gameTime, Position + new Vector2( 0f, ControlSize.Y - scrollUp.ControlSize.Y ), formSize );

					float ControlSizeY = ControlSize.Y - ( scrollUp.ControlSize.Y + scrollDown.ControlSize.Y + scrollerTex.Height );
					float posY = ControlSizeY * percentage;

					if( !bIsScrolling )
						scrollerPosition = new Vector2( Position.X + 1f, Position.Y + scrollUp.ControlSize.Y + posY );
					else
						scrollerPosition = new Vector2( Position.X + 1f, Position.Y + scrollUp.ControlSize.Y + posY + ( MouseState.Y - scrollStart ) );

					if( scrollerPosition.Y < Position.Y + scrollUp.ControlSize.Y )
						scrollerPosition.Y = Position.Y + scrollUp.ControlSize.Y;
					else if( scrollerPosition.Y > Position.Y + ControlSize.Y - ( scrollUp.ControlSize.Y + scrollerTex.Height ) )
						scrollerPosition.Y = Position.Y + ControlSize.Y - ( scrollUp.ControlSize.Y + scrollerTex.Height );

					break;
			}
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + ControlSize.X > formPosition.X + formSize.X - 15f )
				Visible = false;
			else if( Position.Y + ControlSize.Y > formPosition.Y + formSize.Y - 25f )
				Visible = false;
			else
				Visible = true;
		}

		private void CheckVerticalScrolling() {
			if( MathAdd.isInRectangle( new Point( MouseState.X, MouseState.Y ), scrollerArea ) ) {
				//FIX ME
			}
		}

		private void CheckHorizontalScrolling() {
			if( MathAdd.isInRectangle( new Point( MouseState.X, MouseState.Y ), scrollerArea ) ) {
				//FIX ME
			}
		}

		private void CheckVerticalBar() {
			barArea = new Rectangle( (int)Position.X, (int)Position.Y + scrollUp.ControlSize.Y, ControlSize.X, ControlSize.Y - ( scrollUp.ControlSize.Y + scrollDown.ControlSize.Y ) );
			Point mp = new Point( MouseState.X, MouseState.Y );

			if( MathAdd.isInRectangle( mp, barArea ) && !MathAdd.isInRectangle( mp, scrollerArea ) ) {
				if( MouseState.LeftButton == ButtonState.Pressed && !bMouseClicked ) {
					bMouseClicked = true;
					if( MouseState.Y < scrollerPosition.Y )
						PageUp();
					else
						PageDown();
					OnValueChange( this, EventArgs.Empty );
				} else if( MouseState.LeftButton == ButtonState.Released && bMouseClicked )
					bMouseClicked = false;
			} else if( MouseState.LeftButton == ButtonState.Released && bMouseClicked )
				bMouseClicked = false;
		}

		private void CheckHorizontalBar() {
			barArea = new Rectangle( (int)Position.X + scrollUp.ControlSize.X, (int)Position.Y, ControlSize.X - ( scrollUp.ControlSize.X + scrollDown.ControlSize.X ), ControlSize.Y );
			Point mp = new Point( MouseState.X, MouseState.Y );

			if( MathAdd.isInRectangle( mp, barArea ) && !MathAdd.isInRectangle( mp, scrollerArea ) ) {
				if( MouseState.LeftButton == ButtonState.Pressed && !bMouseClicked ) {
					bMouseClicked = true;
					if( MouseState.X < scrollerPosition.X )
						PageUp();
					else
						PageDown();
					OnValueChange( this, EventArgs.Empty );
				} else if( MouseState.LeftButton == ButtonState.Released && bMouseClicked )
					bMouseClicked = false;
			} else if( MouseState.LeftButton == ButtonState.Released && bMouseClicked )
				bMouseClicked = false;
		}

		public void PageUp() {
			Value -= pageSize;
			if( Value < MinValue )
				Value = MinValue;
		}

		public void PageDown() {
			Value += pageSize;
			if( Value > MaxValue )
				Value = MaxValue;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			if( MaxValue == 0 )
				alpha *= 0.5f;

			Color dynamicColor = new Color( new Vector4( 1f, 1f, 1f, alpha ) );

			switch( ScrollBarAxis ) {
				case EScrollBarAxis.Horizontal:
					spriteBatch.Draw( barTex, new Rectangle( (int)Position.X + scrollUp.ControlSize.X, (int)Position.Y + scrollUp.ControlSize.Y, barTex.Width, ControlSize.Y ), dynamicColor );
					break;
				case EScrollBarAxis.Vertical:
					spriteBatch.Draw( barTex, new Rectangle( (int)Position.X, (int)Position.Y + ControlSize.Y, ControlSize.Y, barTex.Height ), dynamicColor );
					break;
			}

			scrollUp.Draw( spriteBatch, alpha );
			scrollDown.Draw( spriteBatch, alpha );

			if( MaxValue > MinValue )
				spriteBatch.Draw( scrollerTex, scrollerPosition, dynamicColor );
		}
	}
}
