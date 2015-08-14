using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;

using FreeWorld.Engine;

namespace FreeWorld.Engine.WindowLibrary {
	[Serializable]
	public class Textbox : Control {
		private bool bHasFocus = false;

		private Keys[] textKeys = { Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.Space, Keys.Enter, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.OemComma, Keys.OemPeriod, Keys.OemQuotes, Keys.OemOpenBrackets, Keys.OemCloseBrackets, Keys.OemPlus, Keys.OemMinus, Keys.OemTilde, Keys.OemBackslash, Keys.OemPipe, Keys.OemSemicolon, Keys.OemQuestion };
		private Keys[] numericKeys = { Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.Enter, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };
		private List<Keys> pressedKeys;

		private Timer keyTimer;

		private int cursorPos = 0;
		private bool bInputKeyDown = false;
		private bool bBackspaceDown = false;
		private bool bLeftKey = false;
		private bool bRightKey = false;
		private bool bDeleteKey = false;
		private bool bHomeKey = false;
		private bool bEndKey = false;

		private Timer cursorTimer;
		private bool bCursorVisible = false;

		private Point startIndex = Point.Zero;
		private Point endIndex = Point.Zero;
		private Point visibleChar = Point.Zero;
		private string visibleText = string.Empty;
		private Keys registeredKey = Keys.None;
		private float keyDownTime = 0f;

		public bool bLocked = false;
		public bool bNumerical = false;
		public bool bMultiline = false;

		public int maxLength;
		public int minHeigth = 0;

		public string passChar = string.Empty;

		public event EventHandler OnMouseDown;
		public event EventHandler OnKeyPress;


		public Textbox() {
		}

		public Textbox( string name, Vector2 origin, int width, int height, string StndText, string PassChar, int MaxLength, bool Numerical, SpriteFont Font, SFormStyle style ) {
			ControlType = EControlType.Textbox;
			Name = name;
			PositionOrg = origin;
			Position = origin;
			Text = StndText;
			bNumerical = Numerical;
			SpriteFont = Font;
			WindowStyle = style;
			maxLength = MaxLength;
			passChar = PassChar;

			minHeigth = height;
			ControlSize = new Point( width, minHeigth );

			InitTextures();
			InitDefaults();
			InitEvents();
		}


		public override void InitDefaults() {
			Calculate();

			visibleChar.Y = 1;

			pressedKeys = new List<Keys>();

			cursorTimer = new Timer( 500 );
			keyTimer = new Timer( 50 );

			ColorBgDefault = Color.White;
			ColorFgDefault = Color.Black;
		}

		public override void InitEvents() {
			cursorTimer.Elapsed += new ElapsedEventHandler( cursorTimer_Tick );
			keyTimer.Elapsed += new ElapsedEventHandler( keyTimer_Tick );
			OnMouseDown += new EventHandler( Select );
			OnKeyPress += new EventHandler( KeyDown );
		}

		public override void InitTextures() {
			ControlTextureNames = new string[ 9 ]{				
				@"Interface\" + WindowStyle + @"\Button\textbox_topleft",
				@"Interface\" + WindowStyle + @"\Button\textbox_topmiddle",
				@"Interface\" + WindowStyle + @"\Button\textbox_topright",
				@"Interface\" + WindowStyle + @"\Button\textbox_middleleft",
				@"Interface\" + WindowStyle + @"\Button\textbox_middlemiddle",
				@"Interface\" + WindowStyle + @"\Button\textbox_middleright",

				@"Interface\" + WindowStyle + @"\Button\textbox_bottomleft",
				@"Interface\" + WindowStyle + @"\Button\textbox_bottommiddle",
				@"Interface\" + WindowStyle + @"\Button\textbox_bottomright"
			};

			ControlTextures = EngineCore.ContentLoader.Load<Texture2D>( ControlTextureNames );
		}

		public void Calculate() {
			if( ControlSize.Y < ControlTextures[ 0 ].Height + ControlTextures[ 3 ].Height + ControlTextures[ 6 ].Height )
				ControlSize = new Point( ControlSize.X, ControlTextures[ 0 ].Height + ControlTextures[ 3 ].Height + ControlTextures[ 6 ].Height );
			if( ControlSize.X < ControlTextures[ 1 ].Width + ControlTextures[ 4 ].Width + ControlTextures[ 7 ].Width )
				ControlSize = new Point( ControlTextures[ 1 ].Width + ControlTextures[ 4 ].Width + ControlTextures[ 7 ].Width, ControlSize.Y );

			Point middleSize = new Point( ControlSize.X - ( ControlTextures[ 0 ].Width + ControlTextures[ 2 ].Width ), ControlTextures[ 3 ].Height );

			if( middleSize.X < ControlTextures[ 1 ].Width )
				middleSize.X = ControlTextures[ 1 ].Width;
			if( middleSize.Y < ControlTextures[ 3 ].Height )
				middleSize.Y = ControlTextures[ 3 ].Height;

			ControlRectangles = new Rectangle[ 5 ];
			ControlRectangles[ 0 ] = new Rectangle( 0, 0, middleSize.X, ControlTextures[ 1 ].Height );
			ControlRectangles[ 1 ] = new Rectangle( 0, 0, ControlTextures[ 3 ].Width, middleSize.Y );
			ControlRectangles[ 2 ] = new Rectangle( 0, 0, middleSize.X, middleSize.Y );
			ControlRectangles[ 3 ] = new Rectangle( 0, 0, ControlTextures[ 5 ].Width, middleSize.Y );
			ControlRectangles[ 4 ] = new Rectangle( 0, 0, middleSize.X, ControlTextures[ 7 ].Height );

			ControlSize = new Point( ControlTextures[ 0 ].Width + ControlRectangles[ 0 ].Width + ControlTextures[ 2 ].Width, ControlTextures[ 0 ].Height + ControlRectangles[ 1 ].Height + ControlTextures[ 6 ].Height );

		}






		private void cursorTimer_Tick( Object obj, ElapsedEventArgs e ) {
			bCursorVisible = !bCursorVisible;
		}

		private void keyTimer_Tick( Object obj, ElapsedEventArgs e ) {
			if( KeyboardState == null )
				KeyboardState = Keyboard.GetState();
			keyDownTime++;
			if( keyDownTime > 10f && registeredKey != Keys.None ) {
				if( KeyboardState.IsKeyDown( registeredKey ) )
					Repeat( registeredKey );
				else {
					keyTimer.Stop();
					registeredKey = Keys.None;
				}
			}

		}

		private void StartKeyTimer( Keys key ) {
			if( !keyTimer.Enabled || key != registeredKey ) {
				registeredKey = key;
				keyDownTime = 0f;
				keyTimer.Start();
			}
		}

		private void Repeat( Keys key ) {
			switch( key ) {
				case Keys.Space:
					Add( " " );
					break;
				case Keys.Delete:
					if( cursorPos < Text.Length )
						Remove();
					break;
				case Keys.Back:
					if( cursorPos > 0 && cursorPos < Text.Length + 1 )
						Backspace();
					break;
				case Keys.Left:
					if( cursorPos > 0 ) {
						cursorPos -= 1;
						if( cursorPos == startIndex.X - 1 && startIndex.X > 0 )
							startIndex.X -= 1;
						bCursorVisible = true;
					}
					break;
				case Keys.Right:
					if( cursorPos < Text.Length ) {
						cursorPos += 1;
						if( cursorPos > startIndex.X + visibleChar.X )
							startIndex.X += 1;
						bCursorVisible = true;
					}
					break;
				default:
					pressedKeys.Clear();
					KeyDown( key, EventArgs.Empty );
					break;
			}
		}

		public void Clear() {
			Text = string.Empty;
		}

		public void SetFocus() {
			Owner.TabIndex = TabOrder;
			bHasFocus = true;
			bCursorVisible = true;
			cursorTimer.Start();
		}

		public void Unfocus() {
			bHasFocus = false;
			bCursorVisible = false;
			cursorTimer.Stop();
		}

		public override void Update( GameTime gameTime, Vector2 formPosition, Vector2 formSize ) {
			Position = PositionOrg + formPosition;

			ControlRectangles[ 0 ].X = (int)Position.X + ControlTextures[ 0 ].Width;
			ControlRectangles[ 0 ].Y = (int)Position.Y;
			ControlRectangles[ 1 ].X = (int)Position.X;
			ControlRectangles[ 1 ].Y = (int)Position.Y + ControlRectangles[ 0 ].Height;
			ControlRectangles[ 2 ].X = (int)Position.X + ControlRectangles[ 1 ].Width;
			ControlRectangles[ 2 ].Y = (int)Position.Y + ControlRectangles[ 0 ].Height;
			ControlRectangles[ 3 ].X = (int)Position.X + ControlRectangles[ 1 ].Width + ControlRectangles[ 2 ].Width;
			ControlRectangles[ 3 ].Y = (int)Position.Y + ControlRectangles[ 0 ].Height;
			ControlRectangles[ 4 ].X = (int)Position.X + ControlRectangles[ 1 ].Width;
			ControlRectangles[ 4 ].Y = (int)Position.Y + ControlRectangles[ 0 ].Height + ControlRectangles[ 2 ].Height;

			CheckVisibility( formPosition, formSize );

			if( Visible ) {
				if( Text.Length == 0 && cursorPos != 0 ) {
					cursorPos = 0;
					startIndex.X = 0;
				}

				if( !Form.InUse && !bLocked && Form.TopForm == this.Owner ) {
					CheckMouseState();

					if( bHasFocus )
						CheckKeyboardState();
				}
				//else if (bHasFocus)
				//    Unfocus();
			}
		}

		private void CheckVisibility( Vector2 formPosition, Vector2 formSize ) {
			if( Position.X + ControlSize.X > formPosition.X + formSize.X )
				Visible = false;
			else if( Position.Y + ControlSize.Y > formPosition.Y + formSize.Y )
				Visible = false;
			else
				Visible = true;
		}

		private void CheckMouseState() {
			MouseState = Mouse.GetState();

			if( MouseState.LeftButton == ButtonState.Pressed ) {
				if( MouseState.X > Position.X && MouseState.X < Position.X + ControlSize.X ) {
					if( MouseState.Y > Position.Y && MouseState.Y < Position.Y + ControlSize.Y ) {
						if( Cursor != System.Windows.Forms.Cursors.IBeam )
							Cursor = System.Windows.Forms.Cursors.IBeam;
						if( !bHasFocus ) {
							SetFocus();
							Select( this, EventArgs.Empty );
						}
					} else if( bHasFocus ) {
						if( Cursor == System.Windows.Forms.Cursors.IBeam )
							Cursor = System.Windows.Forms.Cursors.Default;
						Unfocus();
						Unselect( this, EventArgs.Empty );
					}
				} else if( bHasFocus ) {
					if( Cursor == System.Windows.Forms.Cursors.IBeam )
						Cursor = System.Windows.Forms.Cursors.Default;
					Unfocus();
					Unselect( this, EventArgs.Empty );
				}
			}
		}

		private void CheckKeyboardState() {
			KeyboardState = Keyboard.GetState();

			bool bFoundKey = false;
			foreach( Keys thisKey in textKeys ) {
				if( KeyboardState.IsKeyDown( thisKey ) ) {
					for( int i = 0; i < pressedKeys.Count; i++ ) {
						if( pressedKeys[ i ] == thisKey )
							bFoundKey = true;
					}

					if( !bFoundKey ) {
						bInputKeyDown = true;
						OnKeyPress( thisKey, null );
						StartKeyTimer( thisKey );
					}
				} else {
					for( int i = 0; i < pressedKeys.Count; i++ ) {
						if( thisKey == pressedKeys[ i ] )
							pressedKeys.RemoveAt( i );
					}
				}
			}

			if( !bFoundKey && bInputKeyDown ) {
				bInputKeyDown = false;
			}

			if( KeyboardState.IsKeyDown( Keys.Back ) ) {

				if( !bBackspaceDown ) {
					bBackspaceDown = true;
					if( cursorPos > 0 && cursorPos < Text.Length + 1 ) {
						StartKeyTimer( Keys.Back );
						Backspace();
					}
				}
			} else if( KeyboardState.IsKeyUp( Keys.Back ) && bBackspaceDown )
				bBackspaceDown = false;

			if( KeyboardState.IsKeyDown( Keys.Delete ) ) {
				if( !bDeleteKey ) {
					bDeleteKey = true;
					if( cursorPos < Text.Length ) {
						StartKeyTimer( Keys.Delete );
						Remove();
					}
				}
			} else if( bDeleteKey )
				bDeleteKey = false;

			if( KeyboardState.IsKeyDown( Keys.Left ) ) {
				if( !bLeftKey ) {
					bLeftKey = true;
					if( cursorPos > 0 ) {
						cursorPos -= 1;
						if( cursorPos == startIndex.X - 1 && startIndex.X > 0 )
							startIndex.X -= 1;
						bCursorVisible = true;
					}
					StartKeyTimer( Keys.Left );
				}
			} else if( bLeftKey )
				bLeftKey = false;

			if( KeyboardState.IsKeyUp( Keys.Right ) ) {
				if( !bRightKey ) {
					bRightKey = true;
					if( cursorPos < Text.Length ) {
						cursorPos += 1;
						bCursorVisible = true;
					}
					StartKeyTimer( Keys.Right );
				}
			} else if( bRightKey ) {
				bRightKey = false;
			}

			if( KeyboardState.IsKeyDown( Keys.Home ) ) {
				if( !bHomeKey ) {
					bHomeKey = true;
					Home();
				}
			} else if( bHomeKey )
				bHomeKey = false;

			if( KeyboardState.IsKeyDown( Keys.End ) ) {
				if( !bEndKey ) {
					bEndKey = true;
					End();
				}
			} else if( bEndKey )
				bEndKey = false;
		}

		private void Select( Object obj, EventArgs e ) {
			cursorPos = Text.Length;
			bHasFocus = true;

			if( !bLocked )
				cursorTimer.Start();
		}

		private void Unselect( Object obj, EventArgs e ) {
			bHasFocus = false;
			cursorTimer.Stop();
			bCursorVisible = false;
		}

		private void KeyDown( Object obj, EventArgs e ) {
			if( obj != null ) {
				bInputKeyDown = true;
				Keys currentKey = (Keys)obj;

				bool bNewKey = true;
				for( int i = 0; i < pressedKeys.Count; i++ )
					if( currentKey == pressedKeys[ i ] )
						bNewKey = false;

				if( bNewKey ) {
					pressedKeys.Add( currentKey );
					string[] strSplit = new string[ 2 ];
					if( this.cursorPos > 0 && this.cursorPos < this.Text.Length + 1 ) {
						strSplit[ 0 ] = this.Text.Substring( 0, this.cursorPos );
						strSplit[ 1 ] = this.Text.Substring( this.cursorPos, this.Text.Length - this.cursorPos );
					}

					if( currentKey == Keys.Space && !bNumerical )
						Add( " " );
					else {
						if( !bNumerical ) {
							bool bNumericKey = false;
							for( int i = 0; i < numericKeys.Length; i++ )
								if( currentKey == numericKeys[ i ] )
									bNumericKey = true;

							if( bNumericKey ) {
								if( currentKey.ToString().Length == 7 &&
									currentKey.ToString().Substring( 0, 6 ) == "NumPad" )
									Add( currentKey.ToString().Substring( 6, 1 ) );
								else if( currentKey.ToString().Length == 2 &&
									currentKey.ToString().Substring( 0, 1 ) == "D" ) {
									if( KeyboardState.IsKeyDown( Keys.LeftShift ) || KeyboardState.IsKeyDown( Keys.RightShift ) )
										Add( GetNumberCharacter( currentKey.ToString().Substring( 1, 1 ) ) );
									else
										Add( currentKey.ToString().Substring( 1, 1 ) );
								}
							} else if( currentKey.ToString().Length > 3 && currentKey.ToString().Substring( 0, 3 ).ToLower() == "oem" ) {
								if( KeyboardState.IsKeyDown( Keys.LeftShift ) || KeyboardState.IsKeyDown( Keys.RightShift ) )
									Add( GetOEMCharacter( currentKey.ToString().ToUpper() ) );
								else
									Add( GetOEMCharacter( currentKey.ToString().ToLower() ) );
							} else {
								if( KeyboardState.IsKeyDown( Keys.LeftShift ) || KeyboardState.IsKeyDown( Keys.RightShift ) || KeyboardState.IsKeyDown( Keys.CapsLock ) )
									Add( currentKey.ToString().ToUpper() );
								else
									Add( currentKey.ToString().ToLower() );
							}
						} else if( bNumerical ) {
							bool bNumericKey = false;
							for( int i = 0; i < numericKeys.Length; i++ )
								if( currentKey == numericKeys[ i ] )
									bNumericKey = true;

							if( bNumericKey ) {
								if( currentKey.ToString().Length == 7 &&
									currentKey.ToString().Substring( 0, 6 ) == "NumPad" )
									Add( currentKey.ToString().Substring( 6, 1 ) );
								else if( currentKey.ToString().Length == 2 &&
									currentKey.ToString().Substring( 0, 1 ) == "D" )
									Add( currentKey.ToString().Substring( 1, 1 ) );
							}
						}
					}
				}
			}
		}

		private void Add( string character ) {
			if( Text.Length == maxLength && maxLength != 0 )
				return;

			if( cursorPos == Text.Length )
				Text = Text + character;
			else {
				if( cursorPos > Text.Length )
					cursorPos = Text.Length;

				Text = Text.Insert( cursorPos, character );
			}

			cursorPos += 1;
		}

		private void Remove() {
			if( cursorPos < 0 )
				cursorPos = 0;

			if( cursorPos < Text.Length - 1 ) {
				string[] strSplit = new string[ 2 ];
				strSplit[ 0 ] = Text.Substring( 0, cursorPos );
				strSplit[ 1 ] = Text.Substring( cursorPos + 1, Text.Length - cursorPos - 1 );
				Text = strSplit[ 0 ] + strSplit[ 1 ];
			} else if( Text.Length > 0 )
				Text = Text.Substring( 0, Text.Length - 1 );
		}

		private void Backspace() {
			if( cursorPos == startIndex.X ) {
				Home();
				End();
			}

			cursorPos -= 1;
			Text = Text.Remove( cursorPos, 1 );

			if( startIndex.X < 0 )
				startIndex.X = 0;
		}

		private void Home() {
			cursorPos = 0;
			startIndex.X = 0;
		}

		private void End() {
			cursorPos = Text.Length;
		}

		private string GetOEMCharacter( string key ) {
			switch( key ) {
				case "oemcomma":
					return ",";
				case "OEMCOMMA":
					return "<";
				case "oemperiod":
					return ".";
				case "OEMPERIOD":
					return ">";
				case "oemquotes":
					return "'";
				case "OEMQUOTES":
					return char.ConvertFromUtf32( 34 );
				case "oemopenbrackets":
					return "[";
				case "OEMOPENBRACKETS":
					return "{";
				case "oemclosebrackets":
					return "]";
				case "OEMCLOSEBRACKETS":
					return "}";
				case "oemplus":
					return "=";
				case "OEMPLUS":
					return "+";
				case "oemminus":
					return "-";
				case "OEMMINUS":
					return "_";
				case "oemtilde":
					return "`";
				case "OEMTILDE":
					return "~";
				case "oembackslash":
					return char.ConvertFromUtf32( 92 );
				case "OEMBACKSLASH":
					return "|";
				case "oempipe":
					return char.ConvertFromUtf32( 92 );
				case "OEMPIPE":
					return "|";
				case "oemsemicolon":
					return ";";
				case "OEMSEMICOLON":
					return ":";
				case "oemquestion":
					return "/";
				case "OEMQUESTION":
					return "?";
				default:
					return "";
			}
		}

		private string GetNumberCharacter( string number ) {
			switch( number ) {
				case "0":
					return "=";
				case "1":
					return "!";
				case "2":
					return "\"";
				case "3":
					return "§";
				case "4":
					return "$";
				case "5":
					return "%";
				case "6":
					return "&";
				case "7":
					return "/";
				case "8":
					return "(";
				case "9":
					return ")";
				default:
					return "";
			}
		}

		public override void Draw( SpriteBatch spriteBatch, float alpha ) {
			Color dynamicColor = new Color( new Vector4( ColorBgDefault.ToVector3().X, ColorBgDefault.ToVector3().Y, ColorBgDefault.ToVector3().Z, alpha ) );
			Color dynamicTextColor = new Color( new Vector4( ColorFgDefault.ToVector3().X, ColorFgDefault.ToVector3().Y, ColorFgDefault.ToVector3().Z, alpha ) );

			spriteBatch.Draw( ControlTextures[ 0 ], Position, dynamicColor );
			spriteBatch.Draw( ControlTextures[ 1 ], ControlRectangles[ 0 ], dynamicColor );
			spriteBatch.Draw( ControlTextures[ 2 ], Position + new Vector2( ControlTextures[ 0 ].Width + ControlRectangles[ 0 ].Width, 0f ), dynamicColor );

			spriteBatch.Draw( ControlTextures[ 3 ], ControlRectangles[ 1 ], dynamicColor );
			spriteBatch.Draw( ControlTextures[ 4 ], ControlRectangles[ 2 ], dynamicColor );
			spriteBatch.Draw( ControlTextures[ 5 ], ControlRectangles[ 3 ], dynamicColor );

			spriteBatch.Draw( ControlTextures[ 6 ], Position + new Vector2( 0f, ControlTextures[ 0 ].Height + ControlRectangles[ 1 ].Height ), dynamicColor );
			spriteBatch.Draw( ControlTextures[ 7 ], ControlRectangles[ 4 ], dynamicColor );
			spriteBatch.Draw( ControlTextures[ 8 ], Position + new Vector2( ControlTextures[ 0 ].Width + ControlRectangles[ 0 ].Width, ControlTextures[ 0 ].Height + ControlRectangles[ 1 ].Height ), dynamicColor );

			visibleText = GetTextFrom( startIndex.X );

			if( passChar != string.Empty ) {
				string passText = "";
				for( int i = 0; i < visibleText.Length; i++ )
					passText += passChar;
				visibleText = passText;
			}

			Vector2 drawPos = Position + new Vector2( 5f, ControlRectangles[ 0 ].Height + ( ControlRectangles[ 2 ].Height - SpriteFont.LineSpacing ) / 2f );
			drawPos.X = (int)drawPos.X;
			drawPos.Y = (int)drawPos.Y;
			spriteBatch.DrawString( SpriteFont, visibleText, drawPos, dynamicTextColor );

			if( !bLocked && bHasFocus && bCursorVisible && Form.TopForm == this.Owner )
				DrawCursor( spriteBatch, dynamicTextColor );
		}

		private void DrawCursor( SpriteBatch spriteBatch, Color dynamicTextColor ) {
			int visibleLength = visibleText.Length;
			while( cursorPos - startIndex.X > visibleLength )
				startIndex.X++;

			Vector2 drawPos;
			if( cursorPos == 0 ) {
				drawPos = Position + new Vector2( 4f, ControlRectangles[ 0 ].Height + ( ControlRectangles[ 2 ].Height - SpriteFont.LineSpacing ) / 2f - 1f );
			} else if( visibleText != string.Empty ) {
				drawPos = Position + new Vector2( SpriteFont.MeasureString( visibleText.Substring( 0, cursorPos - startIndex.X ) ).X + 3f, ControlRectangles[ 0 ].Height + ( ControlRectangles[ 2 ].Height - SpriteFont.LineSpacing ) / 2f - 1f );
			} else {
				drawPos = Position + new Vector2( 6f, ControlRectangles[ 0 ].Height + ( ControlRectangles[ 2 ].Height - SpriteFont.LineSpacing ) / 2f - 1f );
			}

			drawPos.X = (int)drawPos.X;
			drawPos.Y = (int)drawPos.Y;
			spriteBatch.DrawString( SpriteFont, "|", drawPos, dynamicTextColor );
		}

		private string GetTextFrom( int startIndex ) {
			string output = string.Empty;

			if( startIndex < 0 )
				startIndex = 0;

			int endIndex = Text.Length;
			if( endIndex - startIndex > 0 )
				output = Text.Substring( startIndex, endIndex - startIndex );

			if( SpriteFont.MeasureString( output ).X > ControlRectangles[ 2 ].Width ) {
				for( int i = 0; i < endIndex - startIndex; i++ ) {
					output = Text.Substring( startIndex, i );
					if( SpriteFont.MeasureString( output ).X > ControlRectangles[ 2 ].Width ) {
						output = Text.Substring( startIndex, i - 1 );
						break;
					}
				}
			}

			return output;
		}

	}

}
