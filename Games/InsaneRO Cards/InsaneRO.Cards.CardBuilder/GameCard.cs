using System;
using System.Collections.Generic;
using System.Text;
using InsaneRO.Cards.Library;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace InsaneRO.Cards.CardBuilder {

	public class GameCard {
		private int mMobID = 4001;
		private string mName = "Poring";
		private ECardType mType = ECardType.MonsterNormal;
		private short mStrength = 0;
		private short mDefence = 1;
		private ECardRace mRace = ECardRace.Formless;
		private ECardElementType mElementType = ECardElementType.Water;
		private int mElementLevel = 1;
		private short mCost = 1;
		private byte mLimitDeck = 4;
		private byte mLimitField = 0;
		private string mEffectText = "Bla\r\nblubb";
		private string mFunText = "Blubb\r\nmoep";
		private string mAuthor = "GodLesZ";
		private float mImageScale = 0.8f;

		[Description( "Die ID des Monster's, auf dem die Karte basiert" ), DefaultValue( 4001 )]
		public int MobID {
			get { return mMobID; }
			set { mMobID = value; }
		}

		[Description( "Name der Karte" ), DefaultValue( "Poring" )]
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		[Description( "Kartentyp" ), DefaultValue( ECardType.MonsterNormal )]
		public ECardType Type {
			get { return mType; }
			set { mType = value; }
		}

		[Description( "Angriffspunkte der Karte" ), DefaultValue( (short)0 )]
		public short Strength {
			get { return mStrength; }
			set { mStrength = value; }
		}

		[Description( "Verteidigungspunkte der Karte" ), DefaultValue( (short)1 )]
		public short Defence {
			get { return mDefence; }
			set { mDefence = value; }
		}

		[Description( "Rasse der Karte" ), DefaultValue( ECardRace.Formless )]
		public ECardRace Race {
			get { return mRace; }
			set { mRace = value; }
		}

		[Description( "Element der Karte" ), DefaultValue( ECardElementType.Water )]
		public ECardElementType ElementType {
			get { return mElementType; }
			set { mElementType = value; }
		}

		[Description( "Element Level der Karte" ), DefaultValue( 1 )]
		public int ElementLevel {
			get { return mElementLevel; }
			set { mElementLevel = value; }
		}

		[Description( "Kosten der Karte in Zeny" ), DefaultValue( (short)1 )]
		public short Cost {
			get { return mCost; }
			set { mCost = value; }
		}

		[Description( "Maximale Anzahl dieser Karte im Deck" ), DefaultValue( (byte)4 )]
		public byte LimitDeck {
			get { return mLimitDeck; }
			set { mLimitDeck = value; }
		}

		[Description( "Maximale Anzahl dieser Karte auf dem Feld" ), DefaultValue( (byte)0 )]
		public byte LimitField {
			get { return mLimitField; }
			set { mLimitField = value; }
		}

		[Description( "Die Beschreibung des Monster Effekt's" ), DefaultValue( "Bla\r\nblubb" ), Editor( typeof( MultilineStringEditor ), typeof( UITypeEditor ) )]
		public string EffectText {
			get { return mEffectText; }
			set { mEffectText = value; }
		}

		[Description( "Eine kurze Beschreibung des Monster's" ), DefaultValue( "Blubb\r\nmoep" ), Editor( typeof( MultilineStringEditor ), typeof( UITypeEditor ) )]
		public string FunText {
			get { return mFunText; }
			set { mFunText = value; }
		}

		[Description( "Größe des Kartenbildes, 0.8 = 80%" ), DefaultValue( 0.8f )]
		public float ImageScale {
			get { return mImageScale; }
			set { mImageScale = value; }
		}

		[Description( "Author der Karte" ), DefaultValue( "GodLesZ" )]
		public string Author {
			get { return mAuthor; }
			set { mAuthor = value; }
		}


		public GameCard() {
		}

	}

}
