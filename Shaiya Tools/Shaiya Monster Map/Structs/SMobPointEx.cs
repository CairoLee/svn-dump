using System;
using System.Collections.Generic;
using System.Text;
using ShaiyaMonsterMap.Components;

namespace ShaiyaMonsterMap.Structs {

	public class SMobPointEx : SMobPoint {
		private string mMapname;
		private MapControl mMapControl;
		private MapControlSelector mMapControlSelector;
		private int mTabIndex;

		public string Mapname {
			get { return mMapname; }
			set { mMapname = value; }
		}

		public MapControl MapControl {
			get { return mMapControl; }
			set { mMapControl = value; }
		}

		public MapControlSelector MapControlSelector {
			get { return mMapControlSelector; }
			set { mMapControlSelector = value; }
		}

		public int TabIndex {
			get { return mTabIndex; }
			set { mTabIndex = value; }
		}


		public SMobPointEx() {
		}


		public static SMobPointEx FromPoint( SMobPoint Point ) {
			SMobPointEx p = new SMobPointEx();
			p.Anzahl = Point.Anzahl;
			p.Element = Point.Element;
			p.ID = Point.ID;
			p.InfoDesc = Point.InfoDesc;
			p.IsBoss = Point.IsBoss;
			p.Level = Point.Level;
			p.Marked = Point.Marked;
			p.Name = Point.Name;
			p.X = Point.X;
			p.Y = Point.Y;

			return p;
		}

	}

}
