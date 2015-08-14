using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GLibary {
	public class SimpleMenu {
		private static int MAX = 20;
		private int menuItemCount;
		private int curMenuItem;
		private string[] menuItems;
		private Vector2[] pos;
		private double[] scale;
		private Color unselected;
		private Color selected;
		private SpriteFont SpriteFont;

		private bool isUp = false;
		private bool isDown = false;

		private double MaxScale = 2.0f;

		public bool Down {
			get {
				return isDown;
			}
			set {
				isDown = value;
			}
		}
		public bool Up {
			get {
				return isUp;
			}
			set {
				isUp = value;
			}
		}

		public SpriteFont Font {
			get {
				return SpriteFont;
			}
			set {
				SpriteFont = value;
			}
		}

		public double Scale {
			get {
				return MaxScale;
			}
			set {
				MaxScale = value;
			}
		}

		public SimpleMenu( Color unslectedColor, Color selectedColor ) {
			menuItems = new string[ MAX ];
			pos = new Vector2[ MAX ];
			scale = new double[ MAX ];
			unselected = unslectedColor;
			selected = selectedColor;
			menuItemCount = 0;
			curMenuItem = 0;
		}

		public void addMenuItem( string name, Vector2 p ) {
			if( menuItemCount < MAX ) {
				menuItems[ menuItemCount ] = name;
				scale[ menuItemCount ] = 1.0f;
				pos[ menuItemCount++ ] = p;
			}
		}

		public void Update( KeyboardState kState, GameTime gameTime ) {
			if( kState.IsKeyDown( Keys.Up ) && Up == true ) {
				selectPrev();
				Up = false;
			} else if( kState.IsKeyUp( Keys.Up ) ) {
				Up = true;
			}
			if( kState.IsKeyDown( Keys.Down ) && Down == true ) {
				selectNext();
				Down = false;
			} else if( kState.IsKeyUp( Keys.Down ) ) {
				Down = true;
			}

			double val = 0.04 + 10.0f * gameTime.ElapsedGameTime.Seconds;
			for( int x = 0; x < menuItemCount; x++ ) {
				if( x == curMenuItem && scale[ x ] < MaxScale )
					scale[ x ] += val;
				else if( scale[ x ] > 1.0f && x != curMenuItem )
					scale[ x ] -= val;
			}
		}

		public void Draw( SpriteBatch spriteBatch ) {
			Color Col;
			spriteBatch.Begin();

			for( int x = 0; x < menuItemCount; x++ ) {
				Col = unselected;
				if( x == curMenuItem )
					Col = selected;
				Vector2 p = pos[ x ];
				p.X -= (float)( 22 * scale[ x ] / 2 );
				p.Y -= (float)( 22 * scale[ x ] / 2 );
				spriteBatch.DrawString( SpriteFont, menuItems[ x ], p, Col, 0.0f, new Vector2( 0, 0 ), (float)scale[ x ], SpriteEffects.None, 0 );
			}
			spriteBatch.End();
		}

		public int getSelectedNum() {
			return curMenuItem;
		}

		public string getSelectedName() {
			return menuItems[ curMenuItem ];
		}

		public void selectNext() {
			if( curMenuItem < menuItemCount - 1 ) {
				curMenuItem++;
			} else {
				curMenuItem = 0;
			}
		}

		public void selectPrev() {
			if( curMenuItem > 0 ) {
				curMenuItem--;
			} else {
				curMenuItem = menuItemCount - 1;
			}
		}

	}
}
