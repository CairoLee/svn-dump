using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;

namespace InsaneRO.Cards.Library {

	public class Card : ICloneable {
		public static List<Card> CardList = new List<Card>();

		private int mID = 1002;
		private string mName = "Poring";
		private ECardType mType = ECardType.MonsterNormal;
		private short mStrength = 0;
		private short mStrengthCurrent = 0;
		private short mDefence = 1;
		private short mDefenceCurrent = 1;
		private ECardRace mRace = ECardRace.Formless;
		private CardElement mElement = new CardElement( ECardElementType.Water, 1 );
		private short mCost = 1;

		/// <summary>
		/// CardID
		/// </summary>
		public int ID {
			get { return mID; }
			set { mID = value; }
		}

		/// <summary>
		/// Card name
		/// </summary>
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		/// <summary>
		/// Card type
		/// </summary>
		public ECardType Type {
			get { return mType; }
			set { mType = value; }
		}

		/// <summary>
		/// Card strength
		/// </summary>
		public short Strength {
			get { return mStrength; }
			set { mStrength = value; }
		}

		/// <summary>
		/// Card current strength
		/// </summary>
		public short StrengthCurrent {
			get { return mStrengthCurrent; }
			set { mStrengthCurrent = value; }
		}

		/// <summary>
		/// Card defence
		/// </summary>
		public short Defence {
			get { return mDefence; }
			set { mDefence = value; }
		}

		/// <summary>
		/// Card current defence
		/// </summary>
		public short DefenceCurrent {
			get { return mDefenceCurrent; }
			set { mDefenceCurrent = value; }
		}

		/// <summary>
		/// Card race
		/// </summary>
		public ECardRace Race {
			get { return mRace; }
			set { mRace = value; }
		}

		/// <summary>
		/// Card element
		/// </summary>
		public CardElement Element {
			get { return mElement; }
			set { mElement = value; }
		}

		/// <summary>
		/// Card cost in Zeny
		/// </summary>
		public short Cost {
			get { return mCost; }
			set { mCost = value; }
		}


		/// <summary>
		/// basic ctor, creates a new card
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="str"></param>
		/// <param name="def"></param>
		/// <param name="race"></param>
		/// <param name="eleType"></param>
		/// <param name="eleLv"></param>
		/// <param name="cost"></param>
		public Card( int id, string name, ECardType type, short str, short def, ECardRace race, ECardElementType eleType, int eleLv, short cost ) {
			ID = id;
			Name = name;
			Type = type;
			Strength = StrengthCurrent = str;
			Defence = DefenceCurrent = def;
			Race = race;
			Element = new CardElement( eleType, eleLv );
			Cost = cost;
		}

		/// <summary>
		/// Clone the card
		/// </summary>
		/// <param name="copy"></param>
		public Card( Card copy )
			: this( copy.ID, copy.Name, copy.Type, copy.Strength, copy.Defence, copy.Race, copy.Element.ElementType, copy.Element.ElementLevel, copy.Cost ) {
			StrengthCurrent = copy.StrengthCurrent;
			DefenceCurrent = copy.DefenceCurrent;
		}

		/// <summary>
		/// empty ctor, default to Poring stats
		/// </summary>
		public Card()
			: this( 1002, "Poring", ECardType.MonsterNormal, 0, 1, ECardRace.Formless, ECardElementType.Water, 1, 1 ) {
		}



		public object Clone() {
			return new Card( this );
		}

		public override string ToString() {
			return string.Format( "{0} [{1}] [{2}/{3}]", Name, ID, Strength, Defence );
		}

	}

}
