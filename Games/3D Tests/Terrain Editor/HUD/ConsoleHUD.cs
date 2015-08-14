using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ragnarok3D.Editor {
	public class ConsoleHUD {
		private Vector2 position = Vector2.Zero;
		private int width = 0;
		private int height = 120;
		private float speed = 0.06f;

		private SpriteFont font;
		private Color fontColor = Color.White;

		private SpriteBatch spriteBatch;

		private Texture2D background;

		bool bAllowInput = false;

		private Line[] line;
		public struct Line {
			public Line( string strText, Vector2 pos ) {
				text = strText;
				position = pos;
			}
			public string text;
			public Vector2 position;
		}

		private List<string> lineContent;
		private int scrollPos = 0;

		private string input = ">";
		Keys[] keyList = { Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.Space };
		Boolean keyExists = false;

		public State state = State.Closed;
		public enum State {
			Closed,
			Closing,
			Opened,
			Opening
		}

		public ConsoleHUD() {
			position.Y = -height;

			if( bAllowInput )
				line = new Line[ 5 ];
			else
				line = new Line[ 7 ];

			for( int i = 0; i < line.Length; i++ )
				line[ i ] = new Line( "", new Vector2( 5f, 5f + ( 15f * i ) ) );

			font = Editor.Content.Load<SpriteFont>( @"Fonts\tahoma" );
			spriteBatch = new SpriteBatch( Editor.graphics.GraphicsDevice );
			width = Editor.graphics.GraphicsDevice.Viewport.Width;
			lineContent = new List<string>();

			GenerateBackground();
		}

		private void GenerateBackground() {
			background = new Texture2D( Editor.graphics.GraphicsDevice, width, height, 1, TextureUsage.None, SurfaceFormat.Color );

			Color[] colors = new Color[ width * height ];
			int bitID = 0;

			for( int y = 0; y < height; y++ ) {
				for( int x = 0; x < width; x++ ) {
					if( y < height - 2 )
						colors[ x + y * width ] = new Color( new Vector4( (float)x / width, (float)y / height, 1f, 0.4f ) );
					else
						colors[ x + y * width ] = new Color( new Vector4( (float)x / width, (float)y - height - 2 / height, 0.4f, 0.5f ) );
					bitID++;
				}
			}

			background.SetData<Color>( colors );
		}

		public void Add( string text ) {
			lineContent.Add( text );
			ScrollDown( 1 );

			if( lineContent.Count > 100 )
				lineContent.RemoveAt( 0 );

			//Console.WriteLine(text);
		}

		public void Update() {
			if( state == State.Opening )
				Open();
			else if( state == State.Closing )
				Close();

			CheckPCInput();
		}

		private void Open() {
			if( position.Y + height * speed < 0f )
				position.Y += height * speed;
			else {
				position.Y = 0f;
				state = State.Opened;
			}
		}

		private void Close() {
			if( position.Y - height * speed > -height )
				position.Y -= height * speed;
			else {
				position.Y = -height;
				state = State.Closed;
			}
		}

		bool bTabDown = false;
		bool bUpKey = false;
		bool bDownKey = false;
		bool bPgUp = false;
		bool bPgDn = false;
		bool bBackspace = false;
		bool bTyping = false;
		public void CheckPCInput() {
			KeyboardState ks = Keyboard.GetState();

			if( Editor.settings == null || !Editor.settings.ContainsFocus ) {
				if( ks.IsKeyDown( Keys.Tab ) ) {
					if( !bTabDown ) {
						bTabDown = true;
						Toggle();
					}
				} else if( bTabDown )
					bTabDown = false;
			}

			if( state == State.Opened ) {
				if( bAllowInput ) {
					Keys[] currentKeys = ks.GetPressedKeys();

					if( currentKeys.Length > 0 )
						keyExists = Array.Exists<Keys>( keyList, new Predicate<Keys>( delegate( Keys currentKey ) { return currentKey == currentKeys[ 0 ]; } ) );
					else
						keyExists = false;

					if( keyExists ) {
						if( !bTyping ) {
							bTyping = true;
							input += currentKeys[ 0 ].ToString();
						}
					} else if( bTyping )
						bTyping = false;

					if( ks.IsKeyDown( Keys.Back ) ) {
						if( !bBackspace ) {
							bBackspace = true;
							if( input.Length > 0 )
								input.Remove( input.Length - 1, 1 );
						}
					} else if( bBackspace )
						bBackspace = false;
				}

				if( ks.IsKeyDown( Keys.Up ) ) {
					if( !bUpKey ) {
						bUpKey = true;
						ScrollUp( 1 );
					}
				} else if( bUpKey )
					bUpKey = false;

				if( ks.IsKeyDown( Keys.Down ) ) {
					if( !bDownKey ) {
						bDownKey = true;
						ScrollDown( 1 );
					}
				} else if( bDownKey )
					bDownKey = false;

				if( ks.IsKeyDown( Keys.PageUp ) ) {
					if( !bPgUp ) {
						bPgUp = true;
						ScrollUp( line.Length - 1 );
					}
				} else if( bPgUp )
					bPgUp = false;

				if( ks.IsKeyDown( Keys.PageDown ) ) {
					if( !bPgDn ) {
						bPgDn = true;
						ScrollDown( line.Length - 1 );
					}
				} else if( bPgDn )
					bPgDn = false;
			}
		}

		public void Draw() {
			spriteBatch.Begin( SpriteBlendMode.AlphaBlend );
			spriteBatch.Draw( background, position, Color.White );
			DrawLines();
			spriteBatch.End();
		}

		private void DrawLines() {
			for( int i = 0; i < line.Length; i++ )
				spriteBatch.DrawString( font, line[ i ].text, new Vector2( 5f, 5f + ( 15f * i ) ) + position, fontColor );

			if( bAllowInput )
				spriteBatch.DrawString( font, input, new Vector2( 5f, 80f ) + position, fontColor );
		}

		private void Toggle() {
			if( state == State.Opened || state == State.Opening )
				Hide();
			else if( state == State.Closed || state == State.Closing )
				Show();
		}

		public void Show() {
			state = State.Opening;
		}

		public void Hide() {
			state = State.Closing;
		}

		private void ScrollUp( int amount ) {
			if( lineContent.Count > line.Length ) {
				if( scrollPos - amount > 0 )
					scrollPos -= amount;
				else
					scrollPos = 0;
			}

			SetVisibleText();
		}

		private void ScrollDown( int amount ) {
			if( lineContent.Count > line.Length ) {
				if( scrollPos + amount < lineContent.Count - line.Length )
					scrollPos += amount;
				else
					scrollPos = lineContent.Count - line.Length;
			}

			SetVisibleText();
		}

		private void SetVisibleText() {
			if( lineContent.Count > 0 ) {
				for( int i = 0; i < line.Length; i++ ) {
					if( scrollPos + i < lineContent.Count ) {
						if( lineContent[ scrollPos + i ] != null )
							line[ i ].text = lineContent[ scrollPos + i ];
					}
				}
			}
		}
	}
}
