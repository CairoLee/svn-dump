using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GodLesZ.Games.Ragnarok.RoBot.Library.Geometry;
using GodLesZ.Games.Ragnarok.RoBot.Library.Objects;
using GodLesZ.Library;
using GodLesZ.Library.Network.Packets;
using Rovolution.Server;
using Rovolution.Server.Geometry;
using Rovolution.Server.Objects;

namespace GodLesZ.Games.Ragnarok.RoBot.Library {

	public class World {

		private static Queue<WorldObject> mAddQueue, mDelQueue;

		private static ForeachInRangeVoidDelegate mForeachInRangeCallback;

		public static bool Saving {
			get;
			private set;
		}
		public static bool Loaded {
			get;
			private set;
		}
		public static bool Loading {
			get;
			private set;
		}

		public static WorldObjectManager Objects {
			get;
			private set;
		}


		public static void Load() {
			if (Loaded == true || Loading == true) {
				return;
			}

			Loading = true;
			// Trigger events for scripts
			Events.Call("worldLoadStart");

			// Our object manager for world objects (spawned objects)
			Objects = new WorldObjectManager();

			// Delegate for Send() Method
			//mForeachInRangeCallback = new ForeachInRangeVoidDelegate(SendSub);

			mAddQueue = new Queue<WorldObject>();
			mDelQueue = new Queue<WorldObject>();

			// Load globals from config, initialize packets ect
			ServerConsole.InfoLine("Initialize game symantics...");
			Global.Initialize();
			PathHelper.Initialize();

			// Real database loading
			ServerConsole.InfoLine("Begin World loading...");

			DataTable table = null;
			Stopwatch watchAll = Stopwatch.StartNew();
			Stopwatch watch = Stopwatch.StartNew();

			//------------- loading start -------------

			#region Mapcache
			ServerConsole.Info("\t# loading Maps from mapcache...");
			watch.Reset();
			watch.Start();
			Mapcache.Initialize();
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done (" + Mapcache.Maps.Count + " Maps in " + watch.ElapsedMilliseconds + "ms)");
			#endregion


			// Loading other shit
			// o.o

			//------------- loading end -------------

			// Trigger event for scripts
			Events.Call("worldLoadFinish");

			Loading = false;
			Loaded = true;

			ProcessSafetyQueues();

			// TODO: Initialize save timer

			ServerConsole.InfoLine("Finished World loading! Needed {0:F2} sec", watchAll.Elapsed.TotalSeconds);

			watch.Stop();
			watch = null;
			watchAll.Stop();
			watchAll = null;
		}

		public static void Destroy() {
			// Clear and dispose all objects
			if (Objects != null) {
				Objects.Clear(true);
				Objects = null;
			}

			// Maps
			Mapcache.Destroy();
		}

		public static void Save() {
			// Saveable objects:
			//	Character, Account, Guild, Party, Pet, Homunculus, Mercenary
			Saving = true;

			Saving = false;
		}

		
		/// <summary>
		/// Handles Object join/leave after load/save/ect
		/// </summary>
		private static void ProcessSafetyQueues() {
			while (mAddQueue.Count > 0) {
				Objects.Add(mAddQueue.Dequeue());
			}

			while (mDelQueue.Count > 0) {
				WorldObject obj = mDelQueue.Dequeue();
				if (obj != null) {
					obj.Delete();
				}
			}
		}

	}

}
