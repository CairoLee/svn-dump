using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaiya.Reader.API {


	public static class Constants {
		public static long CharPointer = 0x0083BBB4L;

		public enum EOffsets : long {
			Hp = 0x130L,
			HpMax = 0x134L,
			Mp = 0x138L,
			MpMax = 0x13CL,
			Ap = 0x140L,
			ApMax = 0x144L,

			PositionX = 0x10L,
			PositionY = 0x14L,
			PositionZ = 0x18L,
			PositionFutureX = 0x148L,
			PositionFutureY = 0x14cL,
			PositionFutureZ = 0x150L,
		}

		public enum EAddress : long {
			Level = 0x8441C0L,
			Exp = 0x8441CCL,
			ExpMax = 0x8441D4L,
			Name = 0x84758EL,

			StatusInt = 0x8441DAL,
			StatusStr = 0x8441D8L,
			StatusGes = 0x8441DCL,
			StatusWei = 0x8441DEL,
			StatusAbw = 0x8441E0L,
			StatusGlu = 0x8441E2L,
		}

	}

}
