
namespace Rovolution.Server.Objects {

	public class WorldObjectViewData {

		public ushort Class {
			get;
			set;
		}

		public ushort Weapon {
			get;
			set;
		}

		public ushort Shield {
			get;
			set;
		}

		public ushort HeadTop {
			get;
			set;
		}

		public ushort HeadMid {
			get;
			set;
		}

		public ushort HeadBottom {
			get;
			set;
		}

		public ushort HairStlye {
			get;
			set;
		}

		public ushort HairColor {
			get;
			set;
		}

		public ushort ClothesColor {
			get;
			set;
		}


		public EAccountSex Sex {
			get;
			set;
		}

		public byte DeadSit {
			get;
			set;
		}


		public WorldObjectViewData() {
		}


		public static WorldObjectViewData GetViewData(DatabaseObject obj, int classID) {
			// Load base values by ID (mob, npc, hom, merc, ..)
			WorldObjectViewData vd = null;

			// Fetch base view data
			if (obj.Serial.Type == EDatabaseType.Mob) {
				vd = (obj as MonsterDatabaseData).ViewData;
			} else {
				vd = new WorldObjectViewData();
			}

			// Set specific values
			// TODO: why an additional switch for this? Oo ..
			switch (obj.Serial.Type) {
				case EDatabaseType.Npc:
					break;
				case EDatabaseType.Mob:
					break;
				case EDatabaseType.Char:
					Character c = (Character)World.Objects[EDatabaseType.Char, obj.Serial.ID];
					if (Character.CheckID(classID) == true) {
						if ((c.StatusChange.Option & EStatusOption.Wedding) > 0) {
							classID = (int)EClientClass.Wedding;
						} else if ((c.StatusChange.Option & EStatusOption.Summer) > 0) {
							classID = (int)EClientClass.Summer;
						} else if ((c.StatusChange.Option & EStatusOption.Xmas) > 0) {
							classID = (int)EClientClass.Xmas;
						} else if ((c.StatusChange.Option & EStatusOption.Riding) > 0) {
							//Adapt class to a Mounted one.
							switch ((EClientClass)classID) {
								case EClientClass.Knight:
									classID = (int)EClientClass.Knight2;
									break;
								case EClientClass.Crusader:
									classID = (int)EClientClass.Crusader2;
									break;
								case EClientClass.LordKnight:
									classID = (int)EClientClass.LordKnight2;
									break;
								case EClientClass.Paladin:
									classID = (int)EClientClass.Paladin2;
									break;
								case EClientClass.BabyKnight:
									classID = (int)EClientClass.BabyKnight2;
									break;
								case EClientClass.BabyCrusader:
									classID = (int)EClientClass.BabyCrusader2;
									break;
							}
						}

						// TODO: why the hell have they another datatype?
						vd.Class = (ushort)classID;
						//clif_get_weapon_view(sd, &sd->vd.weapon, &sd->vd.shield);
						vd.HeadTop = (ushort)c.Status.HeadTop;
						vd.HeadMid = (ushort)c.Status.HeadMid;
						vd.HeadBottom = (ushort)c.Status.HeadBottom;
						vd.HairStlye = (ushort)c.Status.HairStyle;
						vd.HairColor = (ushort)c.Status.HairColor;
						vd.ClothesColor = (ushort)c.Status.ClothColor;
						vd.Sex = c.Status.Sex;
					} else {

					}
					break;
			}

			return vd;
		}

	}

}
