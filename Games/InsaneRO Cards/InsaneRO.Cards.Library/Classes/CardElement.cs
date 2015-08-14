using System;
using System.Collections.Generic;
using System.Text;

namespace InsaneRO.Cards.Library {

	public class CardElement {
		private ECardElementType mElementType;
		private int mElementLevel;

		public ECardElementType ElementType {
			get { return mElementType; }
			set { mElementType = value; }
		}

		public int ElementLevel {
			get { return mElementLevel; }
			set {
				if( value >= 1 && value <= 4 )
					mElementLevel = value;
			}
		}


		public CardElement( ECardElementType type, int lvl ) {
			mElementType = type;
			mElementLevel = lvl;
		}

		public CardElement()
			: this( ECardElementType.Neutral, 1 ) {
		}


		public override string ToString() {
			return string.Format( "{0} Lv {1}", ElementType.ToString(), ElementLevel );
		}

	}

}
