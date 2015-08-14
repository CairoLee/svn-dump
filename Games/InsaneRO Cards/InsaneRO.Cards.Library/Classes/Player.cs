using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace InsaneRO.Cards.Library {

	public class Player {
		private string mName = "UNKNOWN";
		private DeckHandler mDeckHandler = new DeckHandler();
		private short mLife = 10;
		private short mLifeCurrent = 10;
		private EGameStep mStep = EGameStep.None;
		private DeckHandler mHandHandler = new DeckHandler();

		private bool mNeedToDraw = false;
		private float mStepTimer = 0f;

		public string Name {
			get { return mName; }
		}

		public DeckHandler DeckHandler {
			get { return mDeckHandler; }
		}

		public short Life {
			get { return mLife; }
		}

		public short LifeCurrent {
			get { return mLifeCurrent; }
		}

		public EGameStep Step {
			get { return mStep; }
			set { mStep = value; }
		}

		public float StepTimer {
			get { return mStepTimer; }
		}

		public bool NeedToDraw {
			get { return mNeedToDraw; }
			set { mNeedToDraw = value; }
		}


		public DeckHandler HandHandler {
			get { return mHandHandler; }
		}


		public Player( string name, short life ) {
			mName = name;
			mLife = mLifeCurrent = life;
			mStep = EGameStep.None;
		}


		public DeckCard DrawCard() {
			if( NeedToDraw == false || DeckHandler.Deck.Count == 0 )
				return null;

			DeckCard rndCard = DeckHandler.GetRandomCard();
			if( rndCard == null )
				return null; // failed to draw?

			HandHandler.Deck.Add( rndCard );
			NeedToDraw = false;
			return rndCard;
		}

		public void Update( GameTime gameTime ) {
			// is the player in a auto-switch phase?
			if( Step != EGameStep.DrawPhase && Step != EGameStep.EndOfTurn )
				return; // nope
			if( Step == EGameStep.DrawPhase && NeedToDraw == true )
				return; // not yet drawn, no auto-switch

			mStepTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			if( mStepTimer < 1500 )
				return;

			mStepTimer = 0f; // reset timer
			if( Step == EGameStep.EndOfTurn )
				Step = EGameStep.None; // turn ends
			else
				Step++; // draw phase, switch to next phase
		}

	}

}
