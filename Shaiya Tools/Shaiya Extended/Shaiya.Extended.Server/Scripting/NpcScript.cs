using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shaiya.Extended.Library.Geometry;

namespace Shaiya.Extended.Server.Scripting {

	public partial class NpcScript : BaseScript {

		/// <summary>
		/// Triggered everytime the Npc got Clicked by a Player
		/// </summary>
		public virtual void OnClick() {
		}

		/// <summary>
		/// Triggered everytime the Npc got Closed by a Player
		/// </summary>
		public virtual void OnClose() {
			//TODO: maybe auto-clean Garbage/Temp Variables?
		}

		/// <summary>
		/// Triggered everytime the Npc Area got reached by a Player
		/// <para>Will only be Triggered if an Trigger Area is defined!</para>
		/// </summary>
		/// <param name="p">the Point from which the Player has reached the NPC Area</param>
		public virtual void OnAreaIncome( Point2D p ) {
		}

		/// <summary>
		/// Triggered everytime the Npc Area got left by a Player
		/// <para>Will only be Triggered if an Trigger Area is defined!</para>
		/// </summary>
		/// <param name="ns">the Player</param>
		/// <param name="p">the Point from which the Player has left the Npc Area</param>
		public virtual void OnAreaLeave(Point2D p ) {
		}

	}

}
