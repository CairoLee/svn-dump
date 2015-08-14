using System;
using System.Collections.Generic;
using System.Text;

namespace InsaneRO.Cards.Library {

	public class Deck {
		private CardList mCards = new CardList();

		public CardList Cards {
			get { return mCards; }
		}

		public int Count {
			get { return mCards.Count; }
		}


		public Deck() {
		}


		public bool Add( Card card ) {
			return mCards.Add( card, this );
		}

		public void Remove( Card card ) {
			mCards.Remove( card );
		}

	}

}
