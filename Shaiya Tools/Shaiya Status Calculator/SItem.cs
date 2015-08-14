using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Ssc {

	public enum EWeaponType {
		None = 0,
		Nahkampf = 1,
		Fernkampf = 2
	}

	public class SItem : ICloneable {
		public static SItem Empty = new SItem();

		private string mName = "";
		private List<SItemBonus> mBonus = new List<SItemBonus>();
		private int mSockel = 0;
		private EWeaponType mWeaponType = EWeaponType.None;

		[XmlAttribute]
		public string Name {
			get { return mName; }
			set { mName = value; }
		}

		public List<SItemBonus> Bonus {
			get { return mBonus; }
			set {
				mBonus.Clear();
				mBonus.AddRange( value );
			}
		}

		[XmlAttribute]
		public int Sockel {
			get { return mSockel; }
			set { mSockel = value; }
		}

		[XmlAttribute]
		public EWeaponType WeaponType {
			get { return mWeaponType; }
			set { mWeaponType = value; }
		}


		public SItem() {
		}

		public SItem( string name, int sockel ) {
			mName = name;
			mSockel = sockel;
			mWeaponType = EWeaponType.None;
		}

		public SItem( string name, int sockel, EWeaponType wt ) {
			mName = name;
			mSockel = sockel;
			mWeaponType = wt;
		}


		public override string ToString() {
			string toString = string.Empty;
			toString = string.Format( "name={0},sockel={1}", mName, mSockel );
			if( mBonus.Count > 0 ) {
				toString += ",Bonus[";
				for( int i = 0; i < mBonus.Count; i++ )
					toString += "," + mBonus[ i ].Type.ToString() + "=" + mBonus[ i ].Value;
				toString += "]";
			}
			return toString;
		}

		#region ICloneable Member
		public object Clone() {
			SItem i = new SItem( mName, mSockel, mWeaponType );
			i.Bonus.AddRange( mBonus );
			return i;
		}
		object ICloneable.Clone() {
			return Clone();
		}
		#endregion

		public bool Equals( SItem other ) {
			if( other == null || this == null )
				return false;
			if( other.Bonus.Count != this.Bonus.Count )
				return false;
			if( other.Name != this.Name )
				return false;
			if( other.Sockel != this.Sockel )
				return false;
			if( other.WeaponType != this.WeaponType )
				return false;

			return true;
		}


	}

}
