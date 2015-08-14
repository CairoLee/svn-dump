using Rovolution.Server.Geometry;

namespace Rovolution.Server.Objects {

	/// <summary>Extends the <see cref="NpcScript"/> by warping features.</summary>
	public class NpcWarpScript : NpcScript {

		/// <summary>Gets or sets the information describing the warp.</summary>
		public NpcWarpData WarpData {
			get;
			set;
		}


		public NpcWarpScript(DatabaseID id, NpcWarpData warpData)
			: base(id) {
			WarpData = warpData;
		}

		public NpcWarpScript(DatabaseID id, Point2D point, Location loc)
			: this(id, new NpcWarpData(point, loc)) {
		}


		/// <summary>Executes the warp action.</summary>
		/// <param name="target">Target for the warp.</param>
		public virtual void OnWarp(Character target) {
			// TODO: basic warp
		}

	}

}
