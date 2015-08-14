using System;

namespace GodLesZ.Library.Ragnarok.Gat {

	public class RoGatCell {
		public float LeftBottom {
			get;
			set;
		}

		public float RightBottom {
			get;
			set;
		}

		public float LeftTop {
			get;
			set;
		}

		public float RightTop {
			get;
			set;
		}

		public ERoGatCellType Type {
			get;
			set;
		}



		public RoGatCell(float f1, float f2, float f3, float f4, byte t) {
			LeftBottom = f1;
			RightBottom = f2;
			LeftTop = f3;
			RightTop = f4;
			Type = (ERoGatCellType)Enum.Parse(typeof(ERoGatCellType), t.ToString());
		}
	};

}
