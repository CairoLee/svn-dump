using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class Listbox : Control {
		Texture2D listBackground;
		Texture2D selectionArea;

		int visibleItems = 0;
		int startIndex = 0;
		int endIndex = 0;

		public bool bHasFocus = false;


		public event EventHandler OnChangeSelection;
		public void listbox_onChangeSelection( Object obj, EventArgs e ) {
		}


		public Listbox() {
		}

		public Listbox( string name, Vector2 origin, Point Csize, Color BackColor, Color ForeColor, SpriteFont Font, SFormStyle Wstyle ) {

			ControlType = EControlType.Listbox;
			Name = name;
			PositionOrg = origin;
			Position = this.PositionOrg;
			ControlSize = Csize;
			ColorBgDefault = BackColor;
			ColorFgDefault = ForeColor;
			SpriteFont = Font;
			WindowStyle = Wstyle;

			InitTextures();
			InitDefaults();
			InitEvents();
		}

		public override void InitDefaults() {
			Items = new System.Collections.ArrayList();
			visibleItems = (int)System.Math.Round( (float)ControlSize.Y / SpriteFont.LineSpacing, MidpointRounding.AwayFromZero ) - 1;
		}

		public override void InitEvents() {
			OnChangeSelection += new EventHandler( listbox_onChangeSelection );
		}

		public override void InitTextures() {
			listBackground = new Texture2D( Constants.GraphicsDevice, ControlSize.X, ControlSize.Y, true, SurfaceFormat.Color );

			Color[] pixels = new Color[ ControlSize.X * ControlSize.Y ];
			for( int y = 0; y < ControlSize.Y; y++ ) {
				for( int x = 0; x < ControlSize.X; x++ ) {
					if( x < 3 || y < 3 || x > ControlSize.X - 3 || y > ControlSize.Y - 3 ) {
						if( x == 0 || y == 0 || x == ControlSize.X - 1 || y == ControlSize.Y - 1 )
							pixels[ x + y * ControlSize.X ] = Color.Black;
						if( x == 1 || y == 1 || x == ControlSize.X - 2 || y == ControlSize.Y - 2 )
							pixels[ x + y * ControlSize.X ] = Color.LightGray;
						if( x == 2 || y == 2 || x == ControlSize.X - 3 || y == ControlSize.Y - 3 )
							pixels[ x + y * ControlSize.X ] = Color.Gray;
					} else {
						float cX = ColorBgDefault.ToVector3().X;
						float cY = ColorBgDefault.ToVector3().X;
						float cZ = ColorBgDefault.ToVector3().X;

						cX *= 1.0f - ( (float)y / (float)ControlSize.Y ) * 0.4f;
						cY *= 1.0f - ( (float)y / (float)ControlSize.Y ) * 0.4f;
						cZ *= 1.0f - ( (float)y / (float)ControlSize.Y ) * 0.4f;

						pixels[ x + y * ControlSize.X ] = new Color( new Vector4( cX, cY, cZ, ColorBgDefault.ToVector4().W ) );
					}

					float currentX = pixels[ x + y * ControlSize.X ].ToVector3().X;
					float currentY = pixels[ x + y * ControlSize.X ].ToVector3().X;
					float currentZ = pixels[ x + y * ControlSize.X ].ToVector3().X;
					pixels[ x + y * ControlSize.X ] = new Color( new Vector4( currentX, currentY, currentZ, 0.85f ) );
				}
			}

			pixels[ 0 ] = Color.Transparent;
			pixels[ControlSize.X] = Color.Transparent;
			pixels[(ControlSize.Y - 1) * ControlSize.X] = Color.Transparent;
			pixels[ControlSize.X - 1 + (ControlSize.Y - 1) * ControlSize.X] = Color.Transparent;

			listBackground.SetData<Color>( pixels );

			selectionArea = new Texture2D( Constants.GraphicsDevice, ControlSize.X - 8, SpriteFont.LineSpacing, true, SurfaceFormat.Color );
			pixels = new Color[ selectionArea.Width * selectionArea.Height ];
			for( int y = 0; y < selectionArea.Height; y++ ) {
				for( int x = 0; x < selectionArea.Width; x++ ) {
					pixels[ x + y * selectionArea.Width ] = new Color( new Vector4( 0f, 0f, 0f, 0.3f ) );
				}
			}

			selectionArea.SetData<Color>( pixels );
		}

		private void InitScrollbar() {
			Scrollbar = new Scrollbar( Name + "Scrollbar", Position + new Vector2( ControlSize.X, 0f ), EScrollBarAxis.Horizontal, 10, ControlSize.Y, Items.Count - 1, 0, this.WindowStyle );
			Scrollbar.OnValueChange += new EventHandler( Scrollbar_onChangeValue );
		}

		public void AddItem( string item ) {
			if( Contains( item ) )
				return;

			Items.Add( item );
			if( SelectedIndex != -1 ) {
				SelectedIndex++;
				SelectedItem = Items[ SelectedIndex ] as string;
			}
			if( Items.Count > visibleItems ) {
				if( Scrollbar == null )
					InitScrollbar();
				Scrollbar.MaxValue = Items.Count - visibleItems;
			}

			if( Items.Count < visibleItems )
				endIndex = Items.Count;
			else
				endIndex = startIndex + visibleItems;
		}

		public void RemoveItem( string item ) {
			Items.Remove( item );
			if( Items.Count <= visibleItems && Scrollbar != null )
				Scrollbar = null;
			if( SelectedItem == item ) {
				SelectedIndex = -1;
				SelectedItem = string.Empty;
			}
			if( Scrollbar != null )
				Scrollbar.MaxValue = Items.Count - visibleItems;

			if( Items.Count < visibleItems )
				endIndex = Items.Count;
			else
				endIndex = startIndex + visibleItems;
		}

		public void RemoveItem( int index ) {
			Items.RemoveAt( index );
			if( Items.Count <= visibleItems && Scrollbar != null )
				Scrollbar = null;
			if( SelectedIndex == index ) {
				SelectedIndex = -1;
				SelectedItem = string.Empty;
			}
			if( Scrollbar != null )
				Scrollbar.MaxValue = Items.Count - visibleItems;

			if( Items.Count < visibleItems )
				endIndex = Items.Count;
			else
				endIndex = startIndex + visibleItems;
		}

		public void Clear() {
			Items.Clear();
			if( Scrollbar != null )
				Scrollbar = null;
			SelectedIndex = -1;
			SelectedItem = string.Empty;
			startIndex = 0;
			endIndex = 0;
		}

		public void Sort() {
			Items.Sort();
			SelectedIndex = -1;
			SelectedItem = string.Empty;
		}

		public bool Contains( string item ) {
			return Items.Contains( item );
		}

		public int IndexOf( string item ) {
			for( int i = 0; i < Items.Count; i++ )
				if( ( Items[ i ] as string ) == item )
					return i;

			return -1;
		}

		public void selectItem( string item ) {
			if( SelectedItem != item ) {
				this.SelectedItem = item;
				this.SelectedIndex = IndexOf( item );
				OnChangeSelection( this, EventArgs.Empty );
			}
		}

		public void selectItem( int index ) {
			if( index >= Items.Count )
				return;

			if( SelectedItem != ( Items[ index ] as string ) ) {
				this.SelectedItem = Items[ index ] as string;
				this.SelectedIndex = index;
				OnChangeSelection( this, EventArgs.Empty );
			} else
				this.SelectedItem = string.Empty;
		}

		public void unselect() {
			SelectedIndex = -1;
			SelectedItem = string.Empty;
		}

		public void Scrollbar_onChangeValue( object obj, EventArgs e ) {
			startIndex = Scrollbar.Value;
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			Position = PositionOrg + formPosition;
			CheckVisibility( formPosition, formSize );

			if( Visible && !Form.InUse ) {
				CheckSelection();
				if( bHasFocus && SelectedIndex != -1 && Form.TopForm == Owner )
					CheckKeyboardState();
			}

			if( Scrollbar != null )
				Scrollbar.Update( gameTime, formPosition, formSize );

			if( startIndex < 0 )
				startIndex = 0;
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Scrollbar != null ) {
				if( Position.X + ControlSize.X + Scrollbar.ControlSize.X > formPosition.X + formSize.X - 15f )
					Visible = false;
				else if( Position.Y + ControlSize.Y > formPosition.Y + formSize.Y - 25f )
					Visible = false;
				else
					Visible = true;
			} else {
				if( Position.X + ControlSize.X > formPosition.X + formSize.X - 15f )
					Visible = false;
				else if( Position.Y + ControlSize.Y > formPosition.Y + formSize.Y - 25f )
					Visible = false;
				else
					Visible = true;
			}
		}

		bool bItemPressed = false;
		private void CheckSelection() {
			MouseState = Mouse.GetState();

			if( MouseState.LeftButton == ButtonState.Pressed ) {
				Rectangle listArea;
				if( Scrollbar == null )
					listArea = new Rectangle( (int)Position.X, (int)Position.Y, ControlSize.X, ControlSize.Y );
				else
					listArea = new Rectangle( (int)Position.X, (int)Position.Y, ControlSize.X + Scrollbar.ControlSize.X, ControlSize.Y );

				if( MathAdd.isInRectangle( new Point( MouseState.X, MouseState.Y ), listArea ) )
					bHasFocus = true;
				else if( bHasFocus ) {
					bHasFocus = false;
					//unselect();
				}

				if( !bItemPressed ) {
					int lastItem = Items.Count;
					if( lastItem > visibleItems )
						lastItem = visibleItems;
					for( int i = 0; i < lastItem; i++ ) {
						if( bIsOverItem( i ) ) {
							selectItem( i + startIndex );
							bItemPressed = true;
						}
					}
				}
			} else if( bItemPressed ) {
				bItemPressed = false;
			}
		}

		bool bKeyPressed = false;
		private void CheckKeyboardState() {
			KeyboardState = Keyboard.GetState();

			if( KeyboardState.IsKeyDown( Keys.Up ) && !bKeyPressed ) {
				bKeyPressed = true;
				if( SelectedIndex > 0 )
					selectItem( SelectedIndex - 1 );
				if( SelectedIndex < startIndex )
					startIndex--;
				if( Scrollbar != null )
					Scrollbar.Value = startIndex;
			} else if( KeyboardState.IsKeyDown( Keys.Down ) && !bKeyPressed ) {
				bKeyPressed = true;
				if( SelectedIndex < Items.Count - 1 )
					selectItem( SelectedIndex + 1 );
				if( SelectedIndex > startIndex + visibleItems - 1 )
					startIndex++;
				if( Scrollbar != null )
					Scrollbar.Value = startIndex;
			} else if( !KeyboardState.IsKeyDown( Keys.Up ) && !KeyboardState.IsKeyDown( Keys.Down ) && bKeyPressed )
				bKeyPressed = false;
		}

		private bool bIsOverItem( int i ) {
			Vector2 itemPosition = Position + new Vector2( 4f, 4f );

			if( MouseState.X > itemPosition.X && MouseState.X < itemPosition.X + listBackground.Width - 8f ) {
				if( MouseState.Y > itemPosition.Y + ( SpriteFont.LineSpacing * i ) && MouseState.Y < itemPosition.Y + +( SpriteFont.LineSpacing * ( i + 1 ) ) ) {
					return true;
				} else
					return false;
			} else
				return false;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicListColor = new Color( new Vector4( ColorBgDefault.ToVector3().X, ColorBgDefault.ToVector3().Y, ColorBgDefault.ToVector3().Z, alpha ) );
			spriteBatch.Draw( listBackground, Position, dynamicListColor );

			//Items
			int endIndex = Items.Count;
			if( startIndex + visibleItems < Items.Count )
				endIndex = startIndex + visibleItems;

			int lastItem = Items.Count;
			if( lastItem > visibleItems )
				lastItem = visibleItems;

			for( int i = 0; i < lastItem; i++ ) {
				Color dynamicTextColor = new Color( new Vector4( ColorFgDefault.ToVector3().X, ColorFgDefault.ToVector3().Y, ColorFgDefault.ToVector3().Z, alpha ) );
				spriteBatch.DrawString( SpriteFont, Items[ i + startIndex ] as string, Position + new Vector2( 4f, 4f ) + new Vector2( 0f, SpriteFont.LineSpacing * i ), dynamicTextColor );

				//Selected Area
				Color dynamicAreaColor = new Color( new Vector4( Color.White.ToVector3().X, Color.White.ToVector3().Y, Color.White.ToVector3().Z, alpha ) );

				if( ( Items[ i + startIndex ] as string ) == SelectedItem )
					spriteBatch.Draw( selectionArea, Position + new Vector2( 4f, 4f ) + new Vector2( 0f, SpriteFont.LineSpacing * i ), dynamicAreaColor );

				//Selection Area                    
				if( MouseState.LeftButton == ButtonState.Released && !Form.InUse ) {
					if( bIsOverItem( i ) ) {
						spriteBatch.Draw( selectionArea, Position + new Vector2( 4f, 4f ) + new Vector2( 0f, SpriteFont.LineSpacing * i ), dynamicAreaColor );
					}
				}
			}

			if( Scrollbar != null )
				Scrollbar.Draw( spriteBatch, alpha );

		}
	}
}
