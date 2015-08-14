using System;
using Rovolution.Server.Geometry;
using Rovolution.Server.Helper;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// Extends <see cref="WorldObject"/> by moving and attacking
	/// TODO: NPC's dont need all the shit but needs the moving.. abstract this!
	/// </summary>
	public class WorldObjectUnit : WorldObject {
		public struct UnitState {
			public bool ChangeWalkTarget;
			public bool SkillCastCancel;
			public bool AttackContinue;
			public bool WalkEasy;
			public bool Running;
			public bool SpeedChanged;
		}

		public UnitState UState = new UnitState();

		//struct skill_timerskill *skilltimerskill[MAX_SKILLTIMERSKILL];
		//struct skill_unit_group *skillunit[MAX_SKILLUNITGROUP];
		//struct skill_unit_group_tickset skillunittick[MAX_SKILLUNITGROUPTICKSET];

		public short AttackTargetLevel {
			get;
			set;
		}

		public Point2D ActiveSkillLocation {
			get;
			set;
		}

		public short ActiveSkillID {
			get;
			set;
		}

		public short ActiveSkillLevel {
			get;
			set;
		}

		public WorldID ActiveSkillTarget {
			get;
			set;
		}

		public Timer ActiveSkillTimer {
			get;
			set;
		}

		public WorldID Target {
			get;
			set;
		}

		public int ChaseRange {
			get;
			set;
		}

		public int AttackableTime {
			get;
			set;
		}

		public int WalkCount {
			get;
			set;
		}


		public Location Location {
			get;
			set;
		}

		public Point2D TargetLocation {
			get;
			set;
		}

		public int X {
			get { return Location.X; }
		}

		public int Y {
			get { return Location.Y; }
		}

		public int TargetX {
			get { return TargetLocation.X; }
		}

		public int TargetY {
			get { return TargetLocation.Y; }
		}

		public EDirection Direction {
			get { return Location.Direction; }
		}

		public Map Map {
			get { return Location.Map; }
		}

		public WalkpathData Walkpath {
			get;
			set;
		}

		public Timer WalkTimer {
			get;
			set;
		}

		public Timer AttackTimer {
			get;
			set;
		}

		public long AttackableTick {
			get;
			set;
		}

		public long CanActTick {
			get;
			set;
		}

		public long CanMoveTick {
			get;
			set;
		}


		public WorldObjectUnit(DatabaseID dbID, bool addToWorld)
			: base(dbID, addToWorld) {
		}

		public WorldObjectUnit(DatabaseID dbID)
			: this(dbID, false) {
		}


		public virtual void Move(EDirection D) {
			Move(D.ToPoint2D());
		}

		public virtual void Move(Point2D steps) {
			Point2D oldLoc = new Point2D(Location.Point);
			Location.Point += steps;
			Location.Map.OnMove(this, oldLoc);
		}

		/// <summary>
		/// Deletes the object from the map and world list
		/// </summary>
		public override void Delete() {
			// Delete from map
			if (Location != null) {
				Location.Map.OnLeave(this);
			}
			base.Delete();
		}


		public virtual void InitializeTimer() {
			WalkTimer = null;
			ActiveSkillTimer = null;
			AttackTimer = null;
			AttackableTick =
				CanActTick =
				CanMoveTick = DateTime.Now.Ticks;
		}


		public bool InRange(WorldObjectUnit obj, int range) {
			return PathHelper.InRange(X - obj.X, Y - obj.Y, range);
		}
		public bool InRange(Point2D p, int range) {
			return PathHelper.InRange(X - p.X, Y - p.Y, range);
		}
		public bool InRange(int x1, int y1, int range) {
			return PathHelper.InRange(X - x1, Y - y1, range);
		}

		public bool CanReach(Point2D p, int easy) {
			if (p.X == X && p.Y == Y) {
				return true;
			}

			WalkpathData wpd = null;
			bool result = PathHelper.SearchPath(out wpd, Map, Location.Point, p);
			wpd = null;
			return result;
		}


		public void Attack(int targetID, bool continous) {
		}

		/// <summary>
		/// Caused the target object to stop moving.
		/// </summary>
		/// <param name="type">
		/// <para>0x1: Issue a fixpos packet afterwards</para>
		/// <para>0x2: Force the unit to move one cell if it hasn't yet</para>
		/// <para>0x4: Enable moving to the next cell when unit was already half-way there (may cause on-touch/place side-effects, such as a scripted map change)</para>
		/// </param>
		public void StopWalking(byte type) {
			if (Timer.IsValid(WalkTimer) == false) {
				return;
			}

			long timerTick = 0;
			if (WalkTimer != null) {
				//timerTick = WalkTimer.Tick;
				WalkTimer.Stop();
			}
			WalkTimer = null;
			UState.ChangeWalkTarget = false;

			long tick = Timer.Ticks;

			if (((type & 0x02) == 0x02 && Walkpath != null && Walkpath.path_pos == 0) //Force moving at least one cell.
				//|| ((type & 0x04 ) == 0x04&& DIFF_TICK(td->tick, tick) <= td->data / 2) //Enough time has passed to cover half-cell
			) {
				Walkpath.path_len = Walkpath.path_pos + 1;
				WalkingHelper.WalkToXY_Tick(this);
			}

			if ((type & 0x01) == 0x01) {
				World.Send(new Network.Packets.WorldFixpos(this), this, ESendTarget.Area);
			}

			if (Walkpath != null) {
				Walkpath.path_len = 0;
				Walkpath.path_pos = 0;
			}
			TargetLocation = Location.Point;

			// TODO: wtf?
			if (Type == EDatabaseType.Pet && (type & ~0xff) == ~0xff) {
				CanMoveTick = (long)(Timer.Ticks + (type >> 8));
			}

			// the check in unit_set_walkdelay means dmg during running won't fall through to this place in code 
			if (UState.Running == true) {
				//status_change_end(bl, SC_RUN, INVALID_TIMER);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void StopAttack() {
		}


	}

}
