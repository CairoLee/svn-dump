using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace InsaneRO.Cards.Library {

	public class DeckCard : Card, ICloneable {
		private Deck mDeck;
		private int mDeckCount = 0;

		private byte mLimitDeck = 4;
		private byte mLimitField = 0;
		private Texture2D mTexture;

		/// <summary>
		/// The attached Deck
		/// </summary>
		public Deck Deck {
			get { return mDeck; }
			internal set { mDeck = value; }
		}

		/// <summary>
		/// Number of this cards in the current Deck
		/// </summary>
		public int DeckCount {
			get { return mDeckCount; }
			set { mDeckCount = value; }
		}


		/// <summary>
		/// Limit of this card in the deck
		/// <para>Default: 4</para>
		/// </summary>
		public byte LimitDeck {
			get { return mLimitDeck; }
			set { mLimitDeck = value; }
		}

		/// <summary>
		/// Limit of this card on the field
		/// <para>Default: 0</para>
		/// </summary>
		public byte LimitField {
			get { return mLimitField; }
			set { mLimitField = value; }
		}


		public Texture2D Texture {
			get { return mTexture; }
			set { mTexture = value; }
		}


		public DeckCard()
			: base() {
		}

		public DeckCard( Deck deck, Card card )
			: base( card ) {
			mDeck = deck;
		}


		public new object Clone() {
			DeckCard newCard = this.Clone() as DeckCard;
			newCard.Deck = Deck;

			return newCard;
		}

	}

}
