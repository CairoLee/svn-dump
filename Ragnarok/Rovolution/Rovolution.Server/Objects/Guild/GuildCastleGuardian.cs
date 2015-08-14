using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class GuildCastleGuardian : WorldObject {
		public string Name {
			get;
			protected set;
		}


		// 0-MAX_GUARDIANS-1 = Guardians. MAX_GUARDIANS = Emperium.
		public int Number {
			get;
			protected set;
		}

		public WorldID GuildID {
			get;
			protected set;
		}

		public int EmblemID {
			get;
			protected set;
		}

		public int GuardupLevel {
			get;
			protected set;
		}

		public WorldID CastleID {
			get;
			protected set;
		}


		public GuildCastleGuardian(DatabaseID id)
			: base(id) {
		}

	}

}
