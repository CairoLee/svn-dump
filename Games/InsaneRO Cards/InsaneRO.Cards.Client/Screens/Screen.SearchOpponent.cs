using System;
using System.Collections.Generic;
using System.Text;

namespace InsaneRO.Cards.Client.Screens {

	public class ScreenSearchOpponent : GameScreen {

		public ScreenSearchOpponent( GameClient game )
			: base( game ) {
			Name = "SearchOpponent";
			IsActive = true;
			InputHandle = true;
		}


		public override void Initialize() {
			base.Initialize();


		}

	}

}
