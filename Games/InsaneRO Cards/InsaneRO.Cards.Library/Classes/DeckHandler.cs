using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace InsaneRO.Cards.Library {

	public class DeckHandler {
		private Deck mDeck = new Deck();
		private Random mRand = new Random();

		public Deck Deck {
			get { return mDeck; }
			set { mDeck = value; }
		}


		public DeckHandler() {
		}


		public void LoadCards( ContentManager Content ) {
			foreach( DeckCard card in mDeck.Cards.Values )
				card.Texture = Content.Load<Texture2D>( "Cards/" + card.ID );
		}


		// TODO: find a better way..
		public DeckCard GetRandomCard() {
			if( mDeck.Count == 0 )
				return null;

			int rnd = mRand.Next( 1, mDeck.Count );
			int i = 1;
			foreach( DeckCard deckCard in mDeck.Cards.Values ) {
				if( i == rnd ) {
					if( deckCard.DeckCount == 1 )
						mDeck.Remove( deckCard as Card );
					else
						mDeck.Cards[ deckCard.ID ].DeckCount--;
					return deckCard;
				}
				i++;
			}

			return null; // should never happen?
		}

	}

}
