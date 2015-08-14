using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class Guild : WorldObject {

		public List<GuildMember> Member {
			get;
			protected set;
		}


		public Guild(DatabaseID id)
			: base(id) {
			Member = new List<GuildMember>();
		}

	}

}
