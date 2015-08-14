using System;
using System.Collections.Generic;
using System.Text;

namespace FreeWorld.Game.Screens {

	[Flags()]
	public enum EGameScreenState {
		None = 0,

		ScreenWait = 1,
		ScreenLogin = 2,
		ScreenServerSelect = 4,
		ScreenCharSelect = 8,
		ScreenCharCreate = 16,
		ScreenMapLoading = 32,
		ScreenWorld = 64,
	}

}
