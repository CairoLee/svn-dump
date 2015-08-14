using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Systems {
	
	public class PlayerCommandAttribute : Attribute {
		/// <summary>
		/// The command name (the player needs to type that name in any case)
		/// </summary>
		public string Name {
			get;
			set;
		}

		/// <summary>
		/// Some sort of a command description
		/// </summary>
		public string Description {
			get;
			set;
		}


		public PlayerCommandAttribute(string name)
			: this(name, "") {
		}

		public PlayerCommandAttribute(string name, string description) {
			Name = name;
			Description = description;
		}


		public override string ToString() {
			return string.Format("{0}{1}", Name, (Description.Length > 0 ? " (" + Description + ")" : ""));
		}

	}

}
