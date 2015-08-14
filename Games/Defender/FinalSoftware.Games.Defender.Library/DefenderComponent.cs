using System;
using System.Collections.Generic;
using System.Text;
using FinalSoftware.Games.Defender.Library.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace FinalSoftware.Games.Defender.Library {

	public class DefenderComponent : DrawableGameComponent {
		protected static InputHelper mInput;

		protected DefenderGame mDefenderGame;

		public InputHelper Input {
			get { return mInput; }
			set { mInput = value; }
		}

		public ContentManager Content {
			get { return Game.Content; }
		}

		new public DefenderGame Game {
			get { return mDefenderGame; }
		}

		public DefenderWorld World {
			get { return DefenderWorld.Instance; }
		}


		public DefenderComponent( DefenderGame game )
			: base( game ) {
			mDefenderGame = game;

			if( mInput == null ) {
				mInput = new InputHelper( game );
				mInput.DrawDebug = false;
				game.Components.Add( mInput );
			}

		}

	}

}
