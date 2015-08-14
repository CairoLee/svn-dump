using System;
using System.Collections.Generic;
using Rovolution.Server.Geometry;
using Rovolution.Server.Network;

namespace Rovolution.Server.Objects {

	public class Monster : WorldObjectUnit {
		public string Name {
			get;
			set;
		}

		public WorldObjectStatusChangeList StatusChange {
			get;
			protected set;
		}

		public ESize Size {
			get;
			set;
		}

		public EMonsterAiType AI {
			get;
			set;
		}


		public EMonsterSkillState SkillState {
			get;
			set;
		}

		public bool Aggressive {
			get;
			set;
		}

		public byte StealFlag {
			get;
			set;
		}

		public bool StealCoinFlag {
			get;
			set;
		}

		public bool SpulChangeFlag {
			get;
			set;
		}

		public bool Alchemist {
			get;
			set;
		}

		public bool Spotted {
			get;
			set;
		}

		public byte AttackedCount {
			get;
			set;
		}

		public int ProvokeFlag {
			get;
			set;
		}

		public bool NpcKillmonster {
			get;
			set;
		}

		public bool Rebirth {
			get;
			set;
		}

		public WorldID BattlegroundID {
			get;
			set;
		}

		public GuildCastleGuardian GuardianData {
			get;
			protected set;
		}

		public MonsterDamageLog DamageLog {
			get;
			protected set;
		}

		public MonsterSpawnData SpawnData {
			get;
			protected set;
		}

		public Timer SpawnTimer {
			get;
			set;
		}

		public List<Item> LootItem {
			get;
			protected set;
		}

		public short Class {
			get;
			set;
		}

		public bool IsBoss {
			get;
			set;
		}

		public uint TotalDamage {
			get;
			set;
		}

		public int Level {
			get;
			set;
		}

		public WorldID TargetID {
			get;
			set;
		}

		public WorldID AttackedID {
			get;
			set;
		}

		public WorldID AreaNpcID {
			get;
			set;
		}


		public long NextWalktime {
			get;
			set;
		}

		public long LastThinktime {
			get;
			set;
		}

		public long LastLinktime {
			get;
			set;
		}

		public long LastPcNeartime {
			get;
			set;
		}

		public short MoveFailCount {
			get;
			set;
		}

		public short MinChase {
			get;
			set;
		}

		public Timer DeleteTimer {
			get;
			set;
		}

		public WorldID MasterID {
			get;
			set;
		}

		public int MasterDistance {
			get;
			set;
		}

		public short SkillIdx {
			get;
			set;
		}

		public List<uint> SkillDelays {
			get;
			protected set;
		}


		public WorldObjectStatus Status {
			get;
			protected set;
		}

		public WorldObjectStatus BaseStatus {
			get;
			set;
		}

		public WorldObjectViewData ViewData {
			get;
			internal set;
		}

		public WorldObjectRegenerationData Regen {
			get;
			protected set;
		}

		public MonsterDatabaseData Database {
			get { return (MonsterDatabaseData)GetDatabaseData(); }
		}


		public Monster(DatabaseID dbID, bool addToWorld)
			: base(dbID, addToWorld) {
			DamageLog = new MonsterDamageLog();
			SkillDelays = new List<uint>();
			StatusChange = new WorldObjectStatusChangeList();
			LootItem = new List<Item>();
			Regen = new WorldObjectRegenerationData(this);
		}

		public Monster(DatabaseID dbID)
			: this(dbID, false) {
		}


		public static void SpawnOnce(NetState state, Location loc, string name, int mobID, int amount) {
			// TODO: calllback/event
			Character character = (state != null && state.Account != null && state.Account.ActiveChar != null ? state.Account.ActiveChar : null);
			int lv = (int)(character != null ? character.Status.LevelBase : 255);
			mobID = (mobID >= 0 ? mobID : GetRandomMobID(state.Account.ActiveChar, -mobID - 1, 3, lv));

			amount = Math.Min(amount, 1000);
			for (int i = 0; i < amount; i++) {
				Monster mob = SpawnOnceSub(character, loc, name, mobID);
				if (mob == null) {
					continue;
				}

				// TODO: check for emperium, add guardian & castle data
				mob.Spawn();

				// TODO: check for negative mobID (Dead branch) and mode changes
			}
		}

		private static Monster SpawnOnceSub(Character character, Location loc, string name, int mobID) {
			// Create new world object based on mobID
			Monster mob = new Monster(new DatabaseID(mobID, EDatabaseType.Mob));
			// Search free cell to spawn, if no given
			Point2D spawnPoint = loc.Point;
			if (character != null && (spawnPoint.X < 0 || spawnPoint.Y < 0)) {
				// if none found, pick random position on map
				if (loc.Map.SearchFreeCell(character, ref spawnPoint, 1, 1, 0) == false) {
					if (spawnPoint.X <= 0 || spawnPoint.Y <= 0 || loc.Map.CheckCell(spawnPoint, ECollisionType.Reachable) == false) {
						// Failed to fetch random spot on the whole map?
						if (loc.Map.SearchFreeCell(null, ref spawnPoint, -1, -1, 1) == false) {
							ServerConsole.ErrorLine("SpawnSub: Failed to locate spawn pos on map " + loc.Map.Name);
							return null;
						}
					}
				}
			}

			mob.Location = new Location(loc.Map.ID, spawnPoint);
			mob.Name = name;
			mob.Class = (short)mobID;

			// mob_parse_dataset here; check for tiny/large, event and so on

			// TODO: takeover of special_state AI ect; need mob_parse_dataset before
			//		 and place in Monster class to store it (look @ eA mob_data)

			mob.ViewData = WorldObjectViewData.GetViewData(mob.Database, mobID);
			mob.Status = new WorldObjectStatus(mob);
			mob.BaseStatus = new WorldObjectStatus(mob);
			mob.StatusChange.Clear();

			return mob;
		}

		/*==========================================
		 * Fetches a random mobID
		 * type: Where to fetch from:
		 * 0: dead branch list
		 * 1: poring list
		 * 2: bloody branch list
		 * flag:
		 * &1: Apply the summon success chance found in the list (otherwise get any monster from the db)
		 * &2: Apply a monster check level.
		 * &4: Selected monster should not be a boss type
		 * &8: Selected monster must have normal spawn.
		 * lv: Mob level to check against
		 *------------------------------------------*/
		public static int GetRandomMobID(Character character, int type, int flag, int lv) {
			int mobID = 0;
			// TODO: implement me q.q
			/*
			do {
				if (type > 0)
					class_ = summon[type].class_[rand()%summon[type].qty];
				else //Dead branch
					class_ = rand() % MAX_MOB_DB;
				mob = mob_db(class_);
			} while ((mob == mob_dummy ||
				mob_is_clone(class_) ||
				(flag&1 && mob->summonper[type] <= rand() % 1000000) ||
				(flag&2 && lv < mob->lv) ||
				(flag&4 && mob->status.mode&MD_BOSS) ||
				(flag&8 && mob->spawn[0].qty < 1)
			) && (i++) < MAX_MOB_DB);

			if(i >= MAX_MOB_DB)  // no suitable monster found, use fallback for given list
				class_ = mob_db_data[0]->summonper[type];
			*/
			return mobID;
		}

		public int Spawn() {
			long tick = DateTime.Now.Ticks;

			LastThinktime = tick;
			// TODO: check for respawn and bla

			// Reset status if no respawn
			Status = new WorldObjectStatus(this);
			Status.CalculateMonster(true);

			AttackedID = WorldID.Null;
			TargetID = WorldID.Null;
			MoveFailCount = 0;
			// Respawn timer kill
			if (SpawnTimer != null) {
				SpawnTimer.Stop();
			}
			MasterID = WorldID.Null;
			MasterDistance = 0;

			Aggressive = ((Database.Status.Mode & EMonsterMode.Angry) > 0 ? true : false);
			SkillState = EMonsterSkillState.Idle;
			NextWalktime = tick + (new Random().Next(5000) + 1000);
			LastLinktime = tick;
			LastPcNeartime = 0;

			SkillDelays.Clear();
			DamageLog.Clear();
			LootItem.Clear();

			if (Database.Option != EStatusOption.Nothing) {
				StatusChange.Option = Database.Option;
			}


			// Push to world
			World.Objects.Add(this);
			// Push to map
			Location.Map.OnEnter(this);
			Network.Packets.WorldObjectSpawn.Send(this, true);
			//skill_unit_move(&md->bl,tick,1);
			//mobskill_use(md, tick, MSC_SPAWN);

			return 1;
		}

	}

}
