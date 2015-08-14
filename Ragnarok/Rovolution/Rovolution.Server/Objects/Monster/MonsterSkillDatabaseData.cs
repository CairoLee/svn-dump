using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovolution.Server.Database;
using System.Data;

namespace Rovolution.Server.Objects {

	public class MonsterSkillDatabaseData : StoreableObject {

		public int MobID {
			get;
			protected set;
		}

		public EMonsterSkillState State {
			get;
			protected set;
		}

		public int SKillID {
			get;
			protected set;
		}

		public short Level {
			get;
			protected set;
		}

		public short Permillage {
			get;
			protected set;
		}

		public int CastTime {
			get;
			protected set;
		}

		public int Delay {
			get;
			protected set;
		}

		public bool Cancel {
			get;
			protected set;
		}

		public EMonsterSkillCondition1 Condition1 {
			get;
			protected set;
		}

		public EMonsterSkillCondition2 Condition2 {
			get;
			protected set;
		}

		public EMonsterSkillTarget Target {
			get;
			protected set;
		}

		public int[] Value {
			get;
			protected set;
		}

		public short Emotion {
			get;
			protected set;
		}

		public ushort MsgID {
			get;
			protected set;
		}


		public MonsterSkillDatabaseData() {
		}

		public MonsterSkillDatabaseData(DataRow row)
			: base(row) {
		}


		protected override bool LoadFromDatabase(DataRow row) {
			MobID = row.Field<int>("mobID");
			State = (EMonsterSkillState)row.Field<sbyte>("state");
			SKillID = row.Field<int>("skillID");
			Level = row.Field<sbyte>("skillLevel");
			Permillage = row.Field<short>("rate");
			CastTime = row.Field<int>("casttime");
			Delay = row.Field<int>("delay");
			Cancel = row.Field<bool>("cancelable");
			Condition1 = (EMonsterSkillCondition1)row.Field<int>("conditionType");
			Condition2 = (EMonsterSkillCondition2)row.Field<int>("conditionValue");
			Target = (EMonsterSkillTarget)row.Field<int>("target");
			Emotion = row.Field<short>("emotion");
			MsgID = row.Field<ushort>("chatID");

			// Value array
			Value = new int[5];
			for (int i = 0; i < Value.Length; i++) {
				// value1, value2, value3, ..
				Value[i] = row.Field<int>("value" + (i + 1));
			}

			return true;
		}

	}

}
