using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using ShaiyaMonsterMap.Enumerations;

namespace ShaiyaMonsterMap.Structs {


	public class SMobPoints : IPointList {
		public static Image[] MobImages;


		public SMobPoints() {
		}

		public SMobPoints( EMap m ) {
			Map = m;
		}


	}

}
