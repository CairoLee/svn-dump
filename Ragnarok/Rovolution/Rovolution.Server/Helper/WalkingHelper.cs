using System;
using Rovolution.Server.Geometry;
using Rovolution.Server.Network.Packets;
using Rovolution.Server.Objects;

namespace Rovolution.Server.Helper {

	public class WalkingHelper {

		/// <summary>
		/// Initialize defines, globals, bla..
		/// </summary>
		public static void Initialize() {
		}


		public static void WalkToXY(WorldObjectUnit obj, Point2D targetLoc) {

			// Walking in process?
			if (obj.Walkpath != null || obj.WalkTimer != null) {
				// Stop and reset walking
				if (obj.WalkTimer != null) {
					obj.WalkTimer.Stop();
					obj.WalkTimer = null;
				}
				obj.Walkpath = null;
			}

			obj.TargetLocation = targetLoc;
			if (obj.Location.Point == obj.TargetLocation) {
				return;
			}

			// Calc path
			WalkpathData wpd;
			if (PathHelper.SearchPath(out wpd, obj.Map, obj.Location.Point, obj.TargetLocation) == false) {
				ServerConsole.ErrorLine("Bad path, cancel moving");
				//obj.Map.DrawGat();
				return;
			}

			obj.Walkpath = wpd;
			// Player needs to notify clients about a successfull move
			if ((obj is Character)) {
				(obj as Character).Account.Netstate.Send(new WorldResponseWalkOK(obj as Character));
			}

			// Get speed and start timer
			int speed = CalcWalkspeed(obj);
			if (speed > 0) {
				obj.WalkTimer = Timer.DelayCall(TimeSpan.FromMilliseconds(speed), TimeSpan.Zero, 1, new TimerStateCallback<WorldObjectUnit>(WalkToXY_Tick), obj);
			}
		}


		public static void WalkToXY_Tick(WorldObjectUnit obj) {
			if (obj.Walkpath == null) {
				return;
			} else if (obj.Walkpath.path_pos >= obj.Walkpath.path_len) {
				return;
			} else if (obj.Walkpath.path[obj.Walkpath.path_pos] == EDirection.None) {
				return;
			} else if ((int)obj.Walkpath.path[obj.Walkpath.path_pos] > 8) {
				return;
			} else {

			}

			// TODO: this is the point there the client seems to look laggy
			//		 eAthena sends before any movement the WalkOk() packet
			//		 and the client animates the move to the target location.
			//		 But if we attacked by a skill or w00tever,
			//		 eAthena updates the position (i think) 
			//		 AND THIS is the all-known movement/position-reset.
			//		 
			//		 In future, we may test to send a WalkOk() Packet in every single step
			//		 So the client maybe display it more accurate..

			EDirection dir = obj.Walkpath.path[obj.Walkpath.path_pos];
			Point2D targetLoc = obj.Location.Point + dir.ToPoint2D();
			ServerConsole.DebugLine("{0}: walk from {1} to {2} ({3})", obj, obj.Location.Point, targetLoc, dir);
			//obj.Map.DrawGat();
			//Mapcache.Maps[obj.Map.Name].DrawGat();
			if (obj.Map.CheckCell(targetLoc, ECollisionType.Walkable) == false) {
				// Target location is not walkable - recalc path!
				ServerConsole.DebugLine("WalkToXY_Tick: location {0} not walkable, recalc path..", targetLoc);
				WalkToXY(obj, obj.TargetLocation);
				return;
			}

			obj.Move(dir);

			obj.Walkpath.path_pos++;
			int speed = CalcWalkspeed(obj);
			// Next step?
			if (speed > 0) {
				obj.WalkTimer = Timer.DelayCall(TimeSpan.FromMilliseconds(speed), TimeSpan.Zero, 1, new TimerStateCallback<WorldObjectUnit>(WalkToXY_Tick), obj);
			} else {
				// No next step, target location reached, update target location
				// just to be sure..
				obj.TargetLocation = obj.Location.Point;
				obj.Walkpath = null;
				ServerConsole.DebugLine("WalkToXY_Tick: finished moving to location {0}", obj.Location.Point);
			}
		}


		private static int CalcWalkspeed(WorldObjectUnit obj) {
			// In final case, the speed comes from status and/or calculation..
			int speed = Global.DEFAULT_WALK_SPEED;
			if (obj.Walkpath.path_pos >= obj.Walkpath.path_len) {
				speed = -1;
			} else if ((obj.Walkpath.path[obj.Walkpath.path_pos] & EDirection.Up) > 0) {

			} else {

			}
			return speed;
		}

	}

}
