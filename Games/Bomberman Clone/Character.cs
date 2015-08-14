using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Bomberman_Clone {

	public enum MoveDirection {
		Up,
		Down,
		Left,
		Right,
		Idle
	}

	public interface Character {
		Animation Up {
			get;
			set;
		}
		Animation Down {
			get;
			set;
		}
		Animation Left {
			get;
			set;
		}
		Animation Right {
			get;
			set;
		}
		Animation Idle {
			get;
			set;
		}
		Vector2 PlayerPosition {
			get;
			set;
		}
		int CurrentBombs {
			get;
			set;
		}
		bool IsDead {
			get;
			set;
		}


		Vector2 Move( MoveDirection moveDirection );

	}

}
