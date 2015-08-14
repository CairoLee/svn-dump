using System;
using System.Collections.Generic;
using System.Drawing;

using ShaiyaMonsterMap.Enumerations;
using ShaiyaMonsterMap.Forms;

namespace ShaiyaMonsterMap.Structs {

	public class SMobPoint : IPoint {
		public static int MarkedImageSize = 12;
		public static int MarkedDiffSize = ( MarkedImageSize - ImageSize ) / 2;
		public static int BossImageSize = 14;
		public static int BossDiffSize = ( BossImageSize - ImageSize ) / 2;
		public static Brush BossBrush = Brushes.Red;

		private int mMobLevelInt = 0;

		private string mName;
		private string mLevel;
		private string mAnzahl;
		private EMobElement mElement = EMobElement.Unbekannt;
		private bool mIsBoss = false;
		private string mInfoDesc = string.Empty;

		public string Name {
			get { return mName; }
			set { mName = value; }
		}
		public string Level {
			get { return mLevel; }
			set { 
				mLevel = value;
				FetchMobLevel(); // re-build LevelInt
			}
		}
		public int LevelInt {
			get {
				if( mMobLevelInt == 0 )
					FetchMobLevel();
				return mMobLevelInt;
			}
		}
		public string Anzahl {
			get { return mAnzahl; }
			set { mAnzahl = value; }
		}
		public EMobElement Element {
			get { return mElement; }
			set { mElement = value; }
		}
		public bool IsBoss {
			get { return mIsBoss; }
			set { mIsBoss = value; }
		}
		public string InfoDesc {
			get { return mInfoDesc; }
			set { mInfoDesc = value; }
		}



		public SMobPoint() {
		}

		public SMobPoint( int x, int y ) {
			X = x;
			Y = y;

			mRectX = X - ( SMobPoint.ImageSize / 2 );
			mRectY = Y - ( SMobPoint.ImageSize / 2 );
			mRectWidth = X + ( SMobPoint.ImageSize / 2 );
			mRectHeight = Y + ( SMobPoint.ImageSize / 2 );
		}



		private void FetchMobLevel() {
			// 0 = 48, 9 = 57
			string levelInt = string.Empty;
			for( int i = 0; i < Level.Length; i++ ) {
				byte b = (byte)Level[ i ];
				if( b < 48 || b > 57 )
					break;
				levelInt += (char)b;
			}
			if( levelInt.Length == 0 || int.TryParse( levelInt, out mMobLevelInt ) == false )
				mMobLevelInt = 1;

		}


		public int RuleLevelToIndex( FactoryMobPoint fac ) {
			int index = 0;
			if( LevelInt >= fac.ActiveMapRule.MobLevelInt4 )
				index = 3;
			else if( LevelInt >= fac.ActiveMapRule.MobLevelInt3 )
				index = 2;
			else if( LevelInt >= fac.ActiveMapRule.MobLevelInt2 )
				index = 1;
			return index;
		}

		public static SMobPoint FromForm( int x, int y, frmMobPoint frm ) {
			SMobPoint p = new SMobPoint( x, y );
			p.Name = frm.txtName.Text;
			p.Level = frm.txtLevel.Text;
			p.Anzahl = frm.cbCount.Text;
			p.Element = (EMobElement)frm.cbElement.SelectedIndex;
			p.IsBoss = frm.chkBoss.Checked;
			p.InfoDesc = frm.txtInfo.Text;
			return p;
		}


		public override string ToString() {
			string nl = Environment.NewLine;
			return string.Format( "{0}[b]Name[/b]: {1}{2}[b]Level[/b]: {3}{4}[b]Anzahl[/b]: {5}{6}[b]Element[/b]: [c={7}]{8}[/c]{9}{10}", ( this.IsBoss ? "-{ Boss Monster }-" + nl : "" ), Name, nl, Level, nl, Anzahl, nl, Element.ToColor( true ).ToHex(), Element.ToString(), ( InfoDesc != "" ? nl + "MobInfo:" + nl + InfoDesc : "" ), ( !Marked ? "" : nl + "-- Markiert" ) );
		}



	}

}
