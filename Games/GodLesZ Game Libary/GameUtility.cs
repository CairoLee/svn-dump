using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GLibary {


	public interface IGameService {
		Game Game {
			get;
		}
	}

	public class GameService : IGameService {

		public GameService( Game g ) {
			this.game = g;
		}

		private Game game;

		public Game Game {
			get {
				return game;
			}
		}

		public static implicit operator
			Game( GameService gs ) {
			return gs.Game;
		}
	}


	public partial class Utility {

		private static Game game = null;

		public static Game Game {
			get {
				if( game == null )
					throw new Exception( "Initialize Utility Library with Utility.Game = game;" );

				return game;
			}
			set {
				if( game != null ) {
					RemoveService<GameService>();
				}
				game = value;
				AddService<GameService>( new GameService( game ) );
			}
		}

	}
}
