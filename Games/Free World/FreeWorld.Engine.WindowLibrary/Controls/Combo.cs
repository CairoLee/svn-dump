using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class ComboBox : Control {
		Texture2D listBackground;
		Texture2D selectionArea;

		Color color = Color.White;
		Color textColor = Color.Black;
		Color listColor = Color.Snow;

		public event EventHandler OnChangeSelection;
		private void Combo_onChangeSelection( Object obj, EventArgs e ) {
			Close();
		}

		int currentIndex = -1;


		public ComboBox() {
		}

		public ComboBox( string name, Vector2 origin, int Width, SpriteFont font, SFormStyle style ) {
			ControlType = EControlType.Combo;
			PositionOrg = origin;
			ControlSize = new Point( Width, 0 );
			Position = PositionOrg;
			Name = name;
			SpriteFont = font;
			WindowStyle = style;

			InitTextures();
			InitDefaults();
			InitEvents();
		}

		public override void InitDefaults() {
			ControlRectangle = new Rectangle( 0, 0, ( ControlSize.X - ControlTextures[ 0 ].Width ) - ControlTextures[ 1 ].Width + 10, ControlTextures[ 0 ].Height );

			Buttons = new Button[ 1 ]{
				new Button( "bt_Combo", Position + new Vector2( ControlTextures[ 0 ].Width + ControlTextures[ 1 ].Width + ControlTextures[ 2 ].Width, 0f ), "", 0, WindowStyle )
			};

			Calculate();
		}

		public override void InitEvents() {
			Buttons[ 0 ].OnMouseClick += new EventHandler( listBoxButton_onMouseClick );

			OnChangeSelection += new EventHandler( Combo_onChangeSelection );
		}

		public override void InitTextures() {
			ControlTextureNames = new string[ 3 ]{				
				@"Interface\" + WindowStyle + @"\Button\combo_left",
				@"Interface\" + WindowStyle + @"\Button\combo_middle",
				@"Interface\" + WindowStyle + @"\Button\combo_right",
			};

			ControlTextures = EngineCore.ContentLoader.Load<Texture2D>( ControlTextureNames );
		}

		private void Calculate() {
			ControlSize = new Point( ControlTextures[ 0 ].Width + ControlRectangle.Width + ControlTextures[ 2 ].Width + Buttons[ 0 ].ControlSize.X + 10, ControlRectangle.Height );
		}


		public void AddItem( string item ) {
			Items.Add( item );
			if( Items.Count == 1 )
				SelectedItem = Items[ 0 ] as string;
		}

		public void RemoveItem( string item ) {
			Items.Remove( item );
		}

		public void RemoveItem( int index ) {
			Items.RemoveAt( index );
		}

		public void Sort() {
			Items.Sort();
		}

		public void Clear() {
			Items.Clear();
		}

		public bool Contains( string item ) {
			return Items.Contains( item );
		}

		private void SelectItem( int index ) {
			currentIndex = index;
			SelectedItem = Items[ index ] as string;
			OnChangeSelection( this, EventArgs.Empty );
		}

		private void listBoxButton_onMouseClick( Object obj, EventArgs e ) {
			if( ComboBoxState == EComboBoxState.Closed )
				Open();
			else if( ComboBoxState == EComboBoxState.Opened )
				Close();
		}

		public void CreateTextures() {
			int listHeight = Items.Count * SpriteFont.LineSpacing + 8;
			int listWidth = 0;
			for( int i = 0; i < Items.Count; i++ )
				listWidth = Math.Max( listWidth, (int)SpriteFont.MeasureString( Items[ i ] as string ).X );
			listWidth = Math.Max( listWidth, ControlTextures[ 0 ].Width + ControlRectangle.Width + ControlTextures[ 2 ].Width + Buttons[ 0 ].ControlSize.X );
			listWidth += 8; // 4 padding
			listBackground = new Texture2D( Constants.GraphicsDevice, listWidth, listHeight, true, SurfaceFormat.Color );

			Color[] pixels = new Color[ listBackground.Width * listBackground.Height ];
			for( int y = 0; y < listBackground.Height; y++ ) {
				for( int x = 0; x < listBackground.Width; x++ ) {
					/*if( x < 3 || y < 3 || x > listBackground.Width - 3 || y > listBackground.Height - 3 ) {
						if( x == 0 || y == 0 || x == listBackground.Width - 1 || y == listBackground.Height - 1 )
							pixels[ x + y * listBackground.Width ] = Color.Black;
						if( x == 1 || y == 1 || x == listBackground.Width - 2 || y == listBackground.Height - 2 )
							pixels[ x + y * listBackground.Width ] = Color.LightGray;
						if( x == 2 || y == 2 || x == listBackground.Width - 3 || y == listBackground.Height - 3 )
							pixels[ x + y * listBackground.Width ] = Color.Gray;
					} else {*/
						float cX = listColor.ToVector3().X;
						float cY = listColor.ToVector3().Y;
						float cZ = listColor.ToVector3().Z;

						cX *= 1.0f - ( (float)y / (float)listBackground.Height ) * 0.4f;
						cY *= 1.0f - ( (float)y / (float)listBackground.Height ) * 0.4f;
						cZ *= 1.0f - ( (float)y / (float)listBackground.Height ) * 0.4f;

						pixels[ x + y * listBackground.Width ] = new Color( new Vector4( cX, cY, cZ, listColor.ToVector4().W ) );
					//}

					float currentX = pixels[ x + y * listBackground.Width ].ToVector3().X;
					float currentY = pixels[ x + y * listBackground.Width ].ToVector3().Y;
					float currentZ = pixels[ x + y * listBackground.Width ].ToVector3().Z;

					pixels[ x + y * listBackground.Width ] = new Color( new Vector4( currentX, currentY, currentZ, 0.85f ) );
				}
			}

			listBackground.SetData<Color>( pixels );

			selectionArea = new Texture2D( Constants.GraphicsDevice, listBackground.Width - 8, SpriteFont.LineSpacing, true, SurfaceFormat.Color );
			pixels = new Color[ selectionArea.Width * selectionArea.Height ];
			for( int y = 0; y < selectionArea.Height; y++ ) {
				for( int x = 0; x < selectionArea.Width; x++ ) {
					pixels[ x + y * selectionArea.Width ] = new Color( new Vector4( 0f, 0f, 0f, 0.3f ) );
				}
			}

			selectionArea.SetData<Color>( pixels );
		}

		public void Open() {
			CreateTextures();

			if( Owner != null ) {
				foreach( Control control in Owner.Controls.Controls )
					if( control is ComboBox && ( (ComboBox)control ).ComboBoxState == EComboBoxState.Opened )
						( (ComboBox)control ).Close();
			}

			Owner.Controls.TopControl = this;

			ComboBoxState = EComboBoxState.Opened;
		}

		public void Close() {
			Owner.Controls.TopControl = null;
			ComboBoxState = EComboBoxState.Closed;
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			if( SelectedItem == string.Empty && Items.Count > 0 )
				SelectedItem = Items[ 0 ] as string;

			Position = formPosition + PositionOrg;
			ControlRectangle = new Rectangle( (int)Position.X + ControlTextures[ 0 ].Width, (int)Position.Y, ControlRectangle.Width, ControlRectangle.Height );

			Buttons[ 0 ].MoveTo( Position + new Vector2( ControlTextures[ 0 ].Width + ControlRectangle.Width + ControlTextures[ 2 ].Width, 0f ) );

			if( !Form.InUse )
				Buttons[ 0 ].Update();

			CheckVisibility( formPosition, formSize );

			CheckSelection();
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + ControlRectangle.Width + ControlTextures[ 2 ].Width + Buttons[ 0 ].ControlSize.X > formPosition.X + formSize.X )
				Visible = false;
			else if( Position.Y + ControlTextures[ 1 ].Height > formPosition.Y + formSize.Y )
				Visible = false;
			else
				Visible = true;
		}

		private void CheckSelection() {
			MouseState = Mouse.GetState();

			if( MouseState.LeftButton == ButtonState.Pressed ) {
				if( ComboBoxState == EComboBoxState.Opened ) {
					bool bFoundItem = false;
					for( int i = 0; i < Items.Count; i++ ) {
						if( bIsOverItem( i ) ) {
							bFoundItem = true;
							SelectItem( i );
						}
					}

					if( Buttons[ 0 ].BtnState != EBtnState.Pressed && !bFoundItem )
						Close();
				}
			}
		}

		private bool bIsOverItem( int i ) {
			Vector2 itemPosition = Position + new Vector2( 4f, ControlTextures[ 0 ].Height + 4f );

			if( MouseState.X > itemPosition.X && MouseState.X < itemPosition.X + listBackground.Width - 8f )
				if( MouseState.Y > itemPosition.Y + ( SpriteFont.LineSpacing * i ) && MouseState.Y < itemPosition.Y + +( SpriteFont.LineSpacing * ( i + 1 ) ) )
					return true;

			return false;
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			//Text Area
			Color dynamicColor = new Color( new Vector4( color.ToVector3(), alpha ) );
			spriteBatch.Draw( ControlTextures[ 0 ], Position, dynamicColor );
			spriteBatch.Draw( ControlTextures[ 1 ], ControlRectangle, dynamicColor );
			spriteBatch.Draw( ControlTextures[ 2 ], Position + new Vector2( ControlTextures[ 0 ].Width + ControlRectangle.Width, 0f ), dynamicColor );
			Buttons[ 0 ].Draw( spriteBatch, alpha );

			//Text
			Vector2 fontSize = SpriteFont.MeasureString( "A" );
			int index = (int)Math.Round( ( ControlRectangle.Width + 10 ) / fontSize.X );
			string drawString = SelectedItem;
			if( index < SelectedItem.Length )
				drawString = SelectedItem.Substring( 0, index );
			Color dynamicTextColor = new Color( new Vector4( textColor.ToVector3(), alpha ) );
			spriteBatch.DrawString( SpriteFont, drawString, Position + new Vector2( 5f, ControlTextures[ 0 ].Height - 2f - SpriteFont.LineSpacing ), dynamicTextColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f );

			//Listbox
			if( ComboBoxState == EComboBoxState.Opened ) {
				Vector2 listPosition = Position + new Vector2( 0f, ControlTextures[ 0 ].Height );

				//Background
				Color dynamicListboxColor = new Color( new Vector4( listColor.ToVector3(), alpha ) );
				spriteBatch.Draw( listBackground, listPosition, dynamicListboxColor );

				//Items
				for( int i = 0; i < Items.Count; i++ ) {
					spriteBatch.DrawString( SpriteFont, Items[ i ] as string, listPosition + new Vector2( 4f, 4f ) + new Vector2( 0f, SpriteFont.LineSpacing * i ), dynamicTextColor );

					//Selection Area
					if( MouseState.LeftButton == ButtonState.Released && !Form.InUse ) {
						if( bIsOverItem( i ) ) {
							Color dynamicAreaColor = new Color( new Vector4( Vector3.One, alpha ) );
							spriteBatch.Draw( selectionArea, listPosition + new Vector2( 4f, 4f ) + new Vector2( 0f, SpriteFont.LineSpacing * i ), dynamicAreaColor );
						}
					}
				}
			}

		}
	}
}
