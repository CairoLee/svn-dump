using Rovolution.Server.Geometry;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Scripts {

	public class SpawnTest {
		public static void OnServerStarted() {
			// Spawn test
			ServerConsole.DebugLine("Spawn a mob");
			Location location = new Location(1, new Point2D(157, 183));
			Monster.SpawnOnce(null, location, "Rovolution Poring", 1002, 1);

			ServerConsole.DebugLine("Spawn a npc");
			location = new Location(1, new Point2D(155, 183));
			NpcScript.Spawn("Test NPC", 46, location);
		}
	}

}
