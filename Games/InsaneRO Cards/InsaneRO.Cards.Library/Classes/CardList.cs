using System;
using System.Collections.Generic;
using System.Text;

namespace InsaneRO.Cards.Library {

	public class CardList : Dictionary<int, DeckCard> {

		public bool Add( Card card, Deck deck ) {
			DeckCard newCard = new DeckCard( deck, card );
			newCard.DeckCount = 1;
			if( card is DeckCard )
				newCard.Texture = ( card as DeckCard ).Texture; // copy texture

			if( this.ContainsKey( newCard.ID ) == true ) {
				if( ( newCard.DeckCount + this[ newCard.ID ].DeckCount ) > newCard.LimitDeck )
					return false;
				this[ newCard.ID ].DeckCount++;
				return true;
			}

			this.Add( newCard.ID, newCard );
			return true;
		}

		public void Remove( Card card ) {
			if( this.ContainsKey( card.ID ) == true )
				this.Remove( card.ID );
		}

	}

}
