using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GodLesZ.Library;
using Rovolution.Server.Geometry;
using Rovolution.Server.Helper;
using Rovolution.Server.Network;
using Rovolution.Server.Objects;

namespace Rovolution.Server {

	public class World {

		private static Queue<DatabaseObject> mAddQueue, mDelQueue;

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

		public static DatabaseObjectManager Database {
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
			Events.InvokeWorldLoadStart();

			// Our object manager for databsae objects
			Database = new DatabaseObjectManager();
			// Our object manager for world objects (spawned objects)
			Objects = new WorldObjectManager();

			// Delegate for Send() Method
			mForeachInRangeCallback = new ForeachInRangeVoidDelegate(SendSub);

			mAddQueue = new Queue<DatabaseObject>();
			mDelQueue = new Queue<DatabaseObject>();

			// Load globals from config, initialize packets ect
			ServerConsole.InfoLine("Initialize game symantics...");
			Global.Initialize();
			WorldObjectStatus.Initialize();
			ChatHelper.Initialize();
			PlayerCommandHelper.Initialize();
			PathHelper.Initialize();
			SkillTree.Initialize();
			FameListHelper.Initialize();
			CharacterJobBonus.Initialize();
			CharacterJobModifer.Initialize();

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


			#region Items
			ServerConsole.Info("\t# loading Items...");
			watch.Reset();
			watch.Start();
			table = Core.Database.Query("SELECT * FROM dbitem");
			table.TableName = "ItemDB Table";


			if (table == null || table.Rows.Count == 0) {
				if (Core.Database.LastError != null) {
					ServerConsole.ErrorLine("failed to load Item Database!");
					ServerConsole.WriteLine(Core.Database.LastError.ToString());
				}
			} else {
				ItemDatabaseData item;
				for (int i = 0; i < table.Rows.Count; i++) {
					item = ItemDatabaseData.Load(table.Rows[i]);
					if (item == null) {
						ServerConsole.WarningLine("Failed to load item {0}: #{1} {2}", i, table.Rows[i].Field<int>("itemID"), table.Rows[i].Field<string>("nameEnglish"));
						continue;
					}
					Database.Add(item);

					//ServerConsole.DebugLine("\tLoad: #{0} {1}", item.NameID.ToString().PadLeft(5), item.Name);
				}
			}
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done (" + Database.Items.Count + " Items in " + watch.ElapsedMilliseconds + "ms)");
			#endregion


			#region Monster
			ServerConsole.Info("\t# loading Mobs...");
			watch.Reset();
			watch.Start();
			table = Core.Database.Query("SELECT * FROM dbmob");
			table.TableName = "MobDB Table";
			if (table == null || table.Rows.Count == 0) {
				if (Core.Database.LastError != null) {
					ServerConsole.ErrorLine("failed to load Monster Database!");
					ServerConsole.WriteLine(Core.Database.LastError.ToString());
				}
			} else {
				MonsterDatabaseData mob;
				for (int i = 0; i < table.Rows.Count; i++) {
					mob = MonsterDatabaseData.Load(table.Rows[i]);
					if (mob == null) {
						ServerConsole.WarningLine("Failed to load mob {0}: #{1} {2}", i, table.Rows[i].Field<int>("mobID"), table.Rows[i].Field<string>("nameInter"));
						continue;
					}
					Database.Add(mob);

					//ServerConsole.DebugLine("\tLoad: #{0} {1} ({2} drops, {3} skills)", mob.ID.ToString().PadLeft(5), mob.NameInter, mob.Drops.Count, mob.Skills.Count);
				}
			}
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done (" + Database.Monster.Count + " Mobs in " + watch.ElapsedMilliseconds + "ms)");


			ServerConsole.Info("\t# loading Mob Skills...");
			watch.Reset();
			watch.Start();
			table = Core.Database.Query("SELECT * FROM dbmob_skill ORDER BY mobID ASC");
			table.TableName = "MobDB Skill Table";
			if (table == null || table.Rows.Count == 0) {
				if (Core.Database.LastError != null) {
					ServerConsole.ErrorLine("failed to load Mob Skill Database!");
					ServerConsole.WriteLine(Core.Database.LastError.ToString());
				}
			} else {
				MonsterSkill mobSkill;
				for (int i = 0; i < table.Rows.Count; i++) {
					mobSkill = MonsterSkill.Load(table.Rows[i]);
					if (mobSkill == null) {
						throw new Exception(string.Format("Failed to load mob skill #{0}: {1}", table.Rows[i].Field<int>("mobID"), table.Rows[i].Field<string>("info")));
					}

					(Database[EDatabaseType.Mob, mobSkill.MobID] as MonsterDatabaseData).Skills.Add(mobSkill);

					//ServerConsole.DebugLine("\tLoad: #{0} {1} ({2} level)", skill.ID.ToString().PadLeft(5), skill.Name, skill.Level.Count);
				}
			}
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done in " + watch.ElapsedMilliseconds + "ms");


			ServerConsole.Info("\t# loading Mob Drops...");
			watch.Reset();
			watch.Start();
			table = Core.Database.Query("SELECT * FROM dbmob_drop ORDER BY mobID ASC");
			table.TableName = "MobDB Drop Table";
			if (table == null || table.Rows.Count == 0) {
				if (Core.Database.LastError != null) {
					ServerConsole.ErrorLine("failed to load Mob Drop Database!");
					ServerConsole.WriteLine(Core.Database.LastError.ToString());
				}
			} else {
				MonsterDrop drop;
				for (int i = 0; i < table.Rows.Count; i++) {
					drop = MonsterDrop.Load(table.Rows[i]);

					(Database[EDatabaseType.Mob, drop.MobID] as MonsterDatabaseData).Drops.Add(drop);

					//ServerConsole.DebugLine("\tLoad: #{0} {1} ({2} level)", skill.ID.ToString().PadLeft(5), skill.Name, skill.Level.Count);
				}
			}
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done in " + watch.ElapsedMilliseconds + "ms");
			#endregion


			#region General Skills
			ServerConsole.Info("\t# loading Skills...");
			watch.Reset();
			watch.Start();
			table = Core.Database.Query("SELECT * FROM dbskill");
			table.TableName = "SkillDB Table";
			if (table == null || table.Rows.Count == 0) {
				if (Core.Database.LastError != null) {
					ServerConsole.ErrorLine("failed to load Skill Database!");
					ServerConsole.WriteLine(Core.Database.LastError.ToString());
				}
			} else {
				SkillDatabaseData skill;
				for (int i = 0; i < table.Rows.Count; i++) {
					skill = SkillDatabaseData.Load(table.Rows[i]);
					if (skill == null) {
						ServerConsole.WarningLine("Failed to load skill {0}: #{1} {2}", i, table.Rows[i].Field<int>("skillID"), table.Rows[i].Field<string>("name"));
						continue;
					}
					Database.Add(skill.Index, skill);

					//ServerConsole.DebugLine("\tLoad: #{0} {1} ({2} level)", skill.ID.ToString().PadLeft(5), skill.Name, skill.Level.Count);
				}
			}
			watch.Stop();
			ServerConsole.WriteLine(EConsoleColor.Status, " done (" + Database.Skill.Count + " Skills in " + watch.ElapsedMilliseconds + "ms)");
			#endregion


			// Loading other shit
			// o.o

			//------------- loading end -------------

			// Trigger event for scripts
			Events.InvokeWorldLoadFinish();

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
			if (Database != null) {
				Database.Clear(true);
				Database = null;
			}

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



		public static void SendAllClients(Packet p) {
			foreach (WorldObject obj in Objects.Account.Values) {
				if ((obj as Account).Netstate != null && (obj as Account).Netstate.Running == true) {
					(obj as Account).Netstate.Send(p);
				}
			}
		}

		public static void Send(Packet p, WorldObject source, ESendTarget target) {
			if (target != ESendTarget.AllClients && target != ESendTarget.ChatMainchat) {
				if (source == null) {
					ServerConsole.ErrorLine("World.Send: WorldObject (source) cant be null on type " + target + "!");
					return;
				}
			}

			Rectangle2D area;
			switch (target) {
				case ESendTarget.Self:
					if (source is Character && (source as Character).Account.Netstate != null) {
						(source as Character).Account.Netstate.Send(p);
					}
					break;
				case ESendTarget.AllClients:
					World.SendAllClients(p);
					break;
				case ESendTarget.AllSameMap:
					// Source must have a map/is moveable
					if (source is WorldObjectUnit) {
						foreach (MapBlock block in (source as WorldObjectUnit).Map.Blocks) {
							foreach (WorldObject obj in block.Values) {
								if (obj is Character) {
									(obj as Character).Account.Netstate.Send(p);
								}
							}
						}
					}
					break;
				case ESendTarget.Area:
				case ESendTarget.AreaWithoutOwnChatrooms:
				case ESendTarget.AreaWithoutChatrooms:
				case ESendTarget.AreaWithoutSelf:
					//if (sd && bl->prev == NULL) //Otherwise source misses the packet
					// TODO: what means that? how exactly do they using ->prev and ->next pointer?
					if ((source is Character) && (target == ESendTarget.Area || target == ESendTarget.AreaWithoutOwnChatrooms)) {
						(source as Character).Account.Netstate.Send(p);
					}

					if (source is Character) {
						area = new Rectangle2D((source as Character).Location.X - Global.AREA_SIZE, (source as Character).Location.Y - Global.AREA_SIZE, (source as Character).Location.X + Global.AREA_SIZE, (source as Character).Location.Y + Global.AREA_SIZE, true);
						(source as Character).Map.ForeachInRange(area, mForeachInRangeCallback, new object[] { source, p, target });
					}
					break;
				case ESendTarget.HearableAreaWithoutChatrooms:
					if (source is Character) {
						area = new Rectangle2D((source as Character).Location.X - (Global.AREA_SIZE - 5), (source as Character).Location.Y - (Global.AREA_SIZE - 5), (source as Character).Location.X + (Global.AREA_SIZE - 5), (source as Character).Location.Y + (Global.AREA_SIZE - 5), true);
						(source as Character).Map.ForeachInRange(area, mForeachInRangeCallback, new object[] { source, p, ESendTarget.AreaWithoutChatrooms });
					}
					break;
			}

		}

		private static void SendSub(WorldObject obj, object[] args) {
			// Arguments:
			// - source obj
			// - Packet
			// - ESendTarget
			Character source = args[0] as Character;
			Packet p = args[1] as Packet;
			ESendTarget sendType = (ESendTarget)args[2];
			Character target = (obj as Character);

			// Both needs to be player (to receive packets)
			if (source == null || target == null) {
				return;
			}

			switch (sendType) {
				case ESendTarget.AreaWithoutSelf:
					if (source.ID == target.ID) {
						return;
					}
					break;
				case ESendTarget.AreaWithoutChatrooms:
					if (target.Status.ChatID is WorldID || source.ID == target.ID) {
						return;
					}
					break;
				case ESendTarget.AreaWithoutOwnChatrooms:
					if (target.Status.ChatID is WorldID || (source.Status.ChatID is WorldID && source.Status.ChatID == target.Status.ChatID)) {
						return;
					}
					break;
			}

			target.Account.Netstate.Send(p);

			return;
		}


		/// <summary>
		/// Handles Object join/leave after load/save/ect
		/// </summary>
		private static void ProcessSafetyQueues() {
			while (mAddQueue.Count > 0) {
				Database.Add(mAddQueue.Dequeue());
			}

			while (mDelQueue.Count > 0) {
				DatabaseObject obj = mDelQueue.Dequeue();
				if (obj != null) {
					obj.Delete();
				}
			}
		}

	}

}
