using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class BaseMob : SerialObject {

		public BaseMob()
			: base() {
			Serial = Serial.NewMob;
		}

	}

}
