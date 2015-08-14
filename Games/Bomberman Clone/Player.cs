using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Bomberman_Clone {

	public class Player : Character {
		public Vector2 playerPosition = new Vector2( 200, 200 );
		private Animation up;
		private Animation down;
		private Animation left;
		private Animation right;
		private Animation idle;
		public MoveDirection currentDirection;
		public Vector2 center;
		private int currentBombs = 0;
		private bool isDead = false;
		private bool bombPlaced = false;

		public bool IsDead {
			get { return isDead; }
			set { isDead = value; }
		}
		public bool BombPlaced {
			get { return bombPlaced; }
			set { bombPlaced = value; }
		}
		public int CurrentBombs {
			get { return currentBombs; }
			set {
				if( currentBombs <= 0 )
					return;
				currentBombs = value;
			}
		}
		public Animation Up {
			get { return up; }
			set { up = value; }
		}

		public Animation Down {
			get { return down; }
			set { down = value; }
		}

		public Animation Left {
			get { return left; }
			set { left = value; }
		}

		public Animation Right {
			get { return right; }
			set { right = value; }
		}
		public Vector2 PlayerPosition {
			get { return playerPosition; }
			set { playerPosition = value; }
		}
		public Animation Idle {
			get { return idle; }
			set { idle = value; }
		}


		public Player() {
			idle = new Animation( new Vector2( 0, 116 ), new Vector2( 21, 24 ), 16, 9, 0, 0, 0 );
			up = new Animation( new Vector2( 31, 146 ), new Vector2( 19, 22 ), 0, 11, 0, 0, 2 );
			down = new Animation( new Vector2( 31, 116 ), new Vector2( 19, 22 ), 0, 11, 0, 0, 2 );
			right = new Animation( new Vector2( 180, 146 ), new Vector2( 21, 22 ), 0, 11, 0, 0, 2 );
			left = new Animation( new Vector2( 210, 116 ), new Vector2( 22, 22 ), 0, 11, 0, 0, 2 );
		}

		public Vector2 Move( MoveDirection move ) {
			switch( move ) {
				case MoveDirection.Up:
					this.playerPosition.Y--;
					currentDirection = MoveDirection.Up;
					break;
				case MoveDirection.Down:
					this.playerPosition.Y++;
					currentDirection = MoveDirection.Down;
					break;
				case MoveDirection.Left:
					this.playerPosition.X--;
					currentDirection = MoveDirection.Left;
					break;
				case MoveDirection.Right:
					this.playerPosition.X++;
					currentDirection = MoveDirection.Right;
					break;
				default:
					currentDirection = MoveDirection.Idle;
					break;
			}
			center.X = playerPosition.X + 11;
			center.Y = playerPosition.Y + 11;

			return new Vector2( 0, 0 );
		}

		public void plantBomb( Character character ) {

			Bomb bomb = new Bomb( this );
			bomb.CreateBomb( character.PlayerPosition );
			character.CurrentBombs++;
		}


	}

}