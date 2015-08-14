using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class WorldObjectRegenerationData {

		public WorldObject Object {
			get;
			set;
		}


		/// <summary>
		/// Marks what stuff you may heal or not (TODO: Enum!)
		/// </summary>
		public ushort Flag {
			get;
			set;
		}

		public ushort HP {
			get;
			set;
		}

		public ushort SP {
			get;
			set;
		}

		public ushort SHP {
			get;
			set;
		}

		public ushort SSP {
			get;
			set;
		}


		public long TickHP {
			get;
			set;
		}

		public long TickSP {
			get;
			set;
		}

		public long TickSHP {
			get;
			set;
		}

		public long TickSSP {
			get;
			set;
		}


		public byte RateHP {
			get;
			set;
		}

		public byte RateSP {
			get;
			set;
		}

		public byte RateSHP {
			get;
			set;
		}

		public byte RateSSP {
			get;
			set;
		}


		/// <summary>
		/// Can you regen even when walking?
		/// </summary>
		public bool StateWlk {
			get;
			set;
		}

		/// <summary>
		/// Tags when you should have double regen due to GVG castle
		/// </summary>
		public bool StateGrandCross {
			get;
			set;
		}

		/// <summary>
		/// overweight state (1: 50%, 2: 90%)
		/// </summary>
		public byte StateOverweight {
			get;
			set;
		}

		/// <summary>
		/// Block regen flag (1: Hp, 2: Sp)
		/// </summary>
		public byte StateBlock {
			get;
			set;
		}


		public CharacterRegenerationData SkillRegen {
			get;
			set;
		}

		public CharacterRegenerationData SittingSkillRegen {
			get;
			set;
		}


		public WorldObjectRegenerationData(WorldObject obj) {
			Object = obj;
		}


		public void Calculate() {
		}

	}

}
