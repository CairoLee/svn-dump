using Rovolution.Server.Geometry;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// 	An NPC script
	/// 	TODO: An NPC dont need to have attacking features!
	/// 	We need a clean moving interface
	/// </summary>
	public class NpcScript : WorldObjectUnit {

		public string Name {
			get;
			set;
		}

		public string NameUnique {
			get;
			set;
		}

		public short Class {
			get;
			set;
		}

		public ushort Speed {
			get;
			set;
		}

		public ENpcScriptType NpcType {
			get;
			set;
		}


		public Point2D OnTouchArea {
			get;
			set;
		}

		public NpcWarpData WarpData {
			get;
			set;
		}


		public WorldObjectStatusChangeList StatusChange {
			get;
			protected set;
		}


		public NpcScript(DatabaseID id)
			: base(id) {
			OnTouchArea = Point2D.Zero;
		}


		public static void Spawn(string name, int viewID, Location loc) {
			// Search free cell to spawn, if not given
			if (loc.Map.SearchSpawnCell(ref loc) == false) {
				// No spot on the map.. maybe a bug or something else
				ServerConsole.ErrorLine("SpawnSub: Failed to locate spawn pos on map " + loc.Map.Name);
				return;
			}

			NpcScript npc = new NpcScript(new DatabaseID(viewID, EDatabaseType.Npc));
			npc.Location = loc;
			npc.Name = name;
			npc.Class = (short)viewID;
			npc.NpcType = ENpcScriptType.Script;

			// TODO: ontouch area

			npc.StatusChange = new WorldObjectStatusChangeList();
			npc.StatusChange.Clear();

			npc.Spawn();

			return;
		}


		public int Spawn() {
			// Push to world
			World.Objects.Add(this);
			// Push to map
			// TODO: set npc cells on the map
			Location.Map.OnEnter(this);

			Network.Packets.WorldObjectSpawn.Send(this, true);

			return 1;
		}


		#region Events

		/// <summary>Executes the click action.</summary>
		/// <param name="target">Target for the click.</param>
		public virtual void OnClick(Character target) {

		}

		/// <summary>Executes the touch action.</summary>
		/// <param name="target">Target for the touch.</param>
		public virtual void OnTouch(Character target) {

		}
		#endregion

	}

}
