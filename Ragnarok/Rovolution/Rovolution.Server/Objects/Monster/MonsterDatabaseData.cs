using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Rovolution.Server.Objects {

	public class MonsterDatabaseData : DatabaseObject {
		private static readonly WorldObject mEmptyMonster = new WorldObject(new DatabaseID(0, EDatabaseType.Mob));


		public uint MobID {
			get { return base.ID; }
			protected set { base.Serial = new DatabaseID(value, EDatabaseType.Mob); }
		}

		public string NameKorea {
			get;
			protected set;
		}

		public string NameInter {
			get;
			protected set;
		}

		public ushort Level {
			get;
			protected set;
		}

		public uint ExpBase {
			get;
			protected set;
		}

		public uint ExpJob {
			get;
			protected set;
		}

		public ushort RangeAttack {
			get;
			protected set;
		}

		public ushort RangeView {
			get;
			protected set;
		}

		public ushort RangeChase {
			get;
			protected set;
		}

		public EStatusOption Option {
			get;
			protected set;
		}

		public uint ExpMvp {
			get;
			protected set;
		}

		public WorldObjectStatus Status {
			get;
			protected set;
		}

		public MonsterDropList Drops {
			get;
			protected set;
		}

		public MonsterSkillList Skills {
			get;
			protected set;
		}

		public WorldObjectViewData ViewData {
			get;
			protected set;
		}


		public List<MonsterSpawnInfo> SpawnInfo {
			get;
			protected set;
		}


		public MonsterDatabaseData()
			: base() {
			// TODO: this is just a hack to let status know that this is mob status
			//		 find some other way than a none-existing mob..
			Status = new WorldObjectStatus(mEmptyMonster);
			Drops = new MonsterDropList();
			Skills = new MonsterSkillList();
			ViewData = new WorldObjectViewData();
			SpawnInfo = new List<MonsterSpawnInfo>();
		}


		public static MonsterDatabaseData Load(DataRow row) {
			MonsterDatabaseData mob = new MonsterDatabaseData();
			if (mob.LoadFromDatabase(row) == false) {
				return null;
			}

			return mob;
		}


		protected override bool LoadFromDatabase(DataRow row) {

			MobID = row.Field<uint>("mobID");
			NameKorea = row.Field<string>("nameKorea");
			NameInter = row.Field<string>("nameInter");
			Level = row.Field<byte>("level");
			Status.HPMax = row.Field<uint>("hp");
			Status.SPMax = row.Field<uint>("sp");
			ExpBase = row.Field<uint>("expBase");
			ExpJob = row.Field<uint>("expJob");
			Status.Rhw.Range = row.Field<byte>("rangeAttack");
			Status.Rhw.AtkMin = row.Field<ushort>("atkMin");
			Status.Rhw.AtkMax = row.Field<ushort>("atkMax");
			Status.Def = (byte)row.Field<ushort>("defence");
			Status.MDef = (byte)row.Field<ushort>("defenceMagic");
			Status.Str = row.Field<byte>("attStr");
			Status.Agi = row.Field<byte>("attAgi");
			Status.Vit = row.Field<byte>("attVit");
			Status.Int = row.Field<byte>("attInt");
			Status.Dex = row.Field<byte>("attDex");
			Status.Luk = row.Field<byte>("attLuk");
			RangeView = row.Field<byte>("rangeView");
			RangeChase = row.Field<byte>("rangeChase");
			Status.Size = (ESize)row.Field<byte>("scale");
			Status.Race = (ERace)row.Field<byte>("race");
			Status.DefEle = (EElement)(row.Field<byte>("element") % 10);
			Status.EleLv = (byte)(row.Field<byte>("element") / 20);
			Status.Mode = (EMonsterMode)row.Field<ushort>("mode");
			Status.Speed = row.Field<ushort>("walkspeed");
			Status.ADelay = row.Field<ushort>("attackDelay");
			Status.AMotion = row.Field<ushort>("attackAnimation");
			Status.DMotion = row.Field<ushort>("damagerAnimation");
			ExpMvp = row.Field<uint>("expMvp");

			// Initialize view data
			ViewData.Class = (ushort)MobID;

			// Initialize status data
			Status.CalculateMisc(Level);

			// Since mobs always respawn with full life...
			Status.HP = Status.HPMax;
			Status.SP = Status.SPMax;

			return true;
		}

	}

}
