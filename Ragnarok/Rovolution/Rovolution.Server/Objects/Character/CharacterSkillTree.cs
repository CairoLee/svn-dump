using System.Collections.Generic;
using Rovolution.Server.Helper;

namespace Rovolution.Server.Objects {

	public class CharacterSkillTree : IList<CharacterSkill> {
		private CharacterSkill[] mSkills;

		public int Length {
			get { return mSkills.Length; }
		}

		public int Count {
			get { return Length; }
		}

		public bool IsReadOnly {
			get { return false; }
		}

		public CharacterSkill this[int index] {
			get { return mSkills[index]; }
			set { mSkills[index] = value; }
		}

		public CharacterSkill this[ESkill idx] {
			get { return this[(int)idx]; }
			set { this[(int)idx] = value; }
		}



		public CharacterSkillTree()
			: this((int)ESkill.Max) {
		}

		public CharacterSkillTree(int length) {
			mSkills = new CharacterSkill[length];
		}

		public CharacterSkillTree(CharacterSkillTree tree)
			: this(tree.Length) {
			tree.CopyTo(mSkills, 0);
		}


		public int IndexOf(CharacterSkill skill) {
			// TODO: Skills are saved by ID, so the ID is the key, right?
			return skill.ID;
		}

		public void Insert(int index, CharacterSkill skill) {
			mSkills[index] = skill;
		}

		public void RemoveAt(int index) {
			// We never remove a skill..
			mSkills[index].ID = 0;
		}


		public void Add(CharacterSkill item) {
			mSkills[item.ID] = item;
		}

		public void Clear() {
			for (int i = 0; i < mSkills.Length; i++) {
				if (mSkills[i].Flag != ESkillFlag.Plagiarized) {
					mSkills[i].ID = 0;
				}
			}
		}

		public bool Contains(CharacterSkill item) {
			// TODO: The array contains all skills, so this is always true?
			return true;
		}

		public void CopyTo(CharacterSkill[] array, int arrayIndex) {
			mSkills.CopyTo(array, arrayIndex);
		}

		public bool Remove(CharacterSkill item) {
			RemoveAt(item.ID);
			return true;
		}


		public IEnumerator<CharacterSkill> GetEnumerator() {
			for (int i = 0; i < Length; i++) {
				yield return this[i];
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}


		public void CalculateTree(Character character, EClass normalClass, EClientClass c) {
			for (int i = 0; i < this.Length; i++) {
				CharacterSkill skill = this[i];
				// Restore original level of skills after deleting earned skills.	
				if (skill.Flag != ESkillFlag.Permanent && skill.Flag != ESkillFlag.Plagiarized) {
					skill.Level = (ushort)(skill.Flag == ESkillFlag.Temporary ? 0 : ((int)skill.Flag - (int)ESkillFlag.ReplacedLv0));
					skill.Flag = ESkillFlag.Permanent;
				}

				// Enable Bard/Dancer spirit linked skills
				if (
					character.StatusChange.Count > 0 &&
					character.StatusChange.HasStatus(EStatusChange.Spirit) &&
					character.StatusChange[EStatusChange.Spirit].Value2 == (int)ESkill.SlBarddancer &&
					i >= (int)ESkill.DcHumming && i <= (int)ESkill.DcServiceforyou
				) {
					// Link dancer skills to bard
					if (character.Status.Sex == EAccountSex.Female) {
						// TODO: .. eh what? Why the hell -8? is this safe?
						if (this[i - 8].Level < 10) {
							continue;
						}
						skill.ID = (ushort)i;
						skill.Level = this[i - 8].Level; // Set the level to the same as the linking skill
						skill.Flag = ESkillFlag.Temporary; // Tag it as a non-savable, non-uppable, bonus skill
					} else {
						// Link bard skills to dancer.
						if (skill.Level < 10) {
							continue;
						}
						CharacterSkill tmpSkill = this[i - 8];
						tmpSkill.ID = (ushort)(i - 8);
						tmpSkill.Level = skill.Level; // Set the level to the same as the linking skill
						tmpSkill.Flag = ESkillFlag.Temporary; // Tag it as a non-savable, non-uppable, bonus skill
						this[i - 8] = tmpSkill;
					}
				}

				// save changed skill
				this[i] = skill;
			} // for


			CheckNewSkills(character, normalClass, c);

			/* Taekwon Ranger Bonus Skill Tree
			 * ============================================
			 * - Grant All Taekwon Tree, but only as Bonus Skills in case they drop from ranking.
			 * - (c > 0) to avoid grant Novice Skill Tree in case of Skill Reset (need more logic)
			 * - (sd->status.skill_point == 0) to wait until all skill points are asigned to avoid problems with Job Change quest.
			 */

			if (
				c != EClientClass.Novice &&
				(character.Class & EClass.UPPERMASK) == EClass.Taekwon &&
				character.Status.LevelBase >= 90 &&
				character.Status.SkillPoints == 0 && FameListHelper.Taekwon.Contains(character.ID) == true
			) {
				ESkillInf2 flagQuestWedding = (ESkillInf2.Quest | ESkillInf2.Wedding);
				foreach (SkillTreeJobSkill skill in SkillTree.Tree[(int)c].Values) {
					SkillDatabaseData skillData = (SkillDatabaseData)World.Database.Skill[(ESkill)skill.ID];
					// Do not include Quest/Wedding skills
					if ((skillData.Inf2 & flagQuestWedding) > 0) {
						continue;
					}

					CharacterSkill charSkill = character.Status.Skills[skill.ID];
					if (charSkill.ID == 0) {
						// So it is not saved, and tagged as a "bonus" skill
						charSkill.ID = (ushort)skill.ID;
						charSkill.Flag = ESkillFlag.Temporary;
					} else {
						// Remember original level
						charSkill.Flag = (ESkillFlag)((int)ESkillFlag.ReplacedLv0 + charSkill.Level);
					}

					charSkill.Level = (ushort)skill.MaxLevel;

					character.Status.Skills[skill.ID] = charSkill;
				}

			} // if taekwon

			// GM all skills
			if (Config.GmAllSkill > 0 && character.GMLevel >= Config.GmAllSkill) {
				ESkillInf2 flag = (ESkillInf2.Npc | ESkillInf2.Guild);
				for (int i = 0; i < this.Length; i++) {
					CharacterSkill skill = this[i];
					SkillDatabaseData skillData = (SkillDatabaseData)World.Database.Skill[i];

					// Only skills you can't have are npc/guild ones
					if ((skillData.Inf2 & flag) > 0) {
						continue;
					}
					// Skill is learnable (MaxLevel above 0)
					if (skillData.Max < 1) {
						continue;
					}

					skill.ID = (ushort)i;
					this[i] = skill;
				}
			}

		}

		private void CheckNewSkills(Character character, EClass normalClass, EClientClass c) {
			int flag;
			int iC = (int)c;

			do {
				flag = 0;
				foreach (SkillTreeJobSkill skill in SkillTree.Tree[iC].Values) {
					int j, f, k;
					ESkillInf2 inf2;

					// Skill already known?
					if (character.Status.Skills[skill.ID].ID > 0) {
						continue;
					}

					f = 1;
					if (Config.PlayerSkillfree == false) {
						foreach (SkillTreeJobSkillRequirement req in skill.Values) {
							if (req.ID < 1) {
								continue;
							}

							CharacterSkill charSkill = character.Status.Skills[req.ID];
							int hasLv = 0;
							if (charSkill.ID == 0 || charSkill.Flag == ESkillFlag.Temporary || charSkill.Flag == ESkillFlag.Plagiarized) {
								req.ID = 0; //Not learned.
							} else { //Real lerned level
								if ((int)charSkill.Flag >= (int)ESkillFlag.ReplacedLv0) {
									hasLv = (int)charSkill.Flag - (int)ESkillFlag.ReplacedLv0;
								} else {
									hasLv = charSkill.Level;
								}
							}
							if (hasLv < req.Level) {
								f = 0;
								break;
							}
						}

						// job level requirement wasn't satisfied
						if (character.Status.LevelJob < skill.JobLevel) {
							f = 0;
						}
					}

					if (f == 1) {
						SkillDatabaseData skillData = (SkillDatabaseData)World.Database.Skill[(ESkill)skill.ID];
						CharacterSkill newSkill = character.Status.Skills[skill.ID];
						inf2 = skillData.Inf2;

						// Cannot be learned via normal means
						// Note: this check DOES allows raising already known skills.
						if (newSkill.Level < 1 && (
							((inf2 & ESkillInf2.Quest) > 0 && Config.QuestSkillLearn == false) ||
							(inf2 & ESkillInf2.Wedding) > 0 ||
							((inf2 & ESkillInf2.Spirit) > 0 && !character.StatusChange.HasStatus(EStatusChange.Spirit))
						)) {
							continue;
						}
						newSkill.ID = (ushort)skill.ID;
						// TODO: i couldnt find the place where eA set the level oif newly learned skills
						//		 seems they start with zero, but this cant be!
						if (newSkill.Level < 1) {
							newSkill.Level = 1;
						}

						// Spirit skills cannot be learned, they will only show up on your tree when you get buffed.
						if ((inf2 & ESkillInf2.Spirit) > 0) {
							newSkill.Flag = ESkillFlag.Temporary; //So it is not saved, and tagged as a "bonus" skill.
						}

						// Save back
						character.Status.Skills[skill.ID] = newSkill;
						// skill list has changed, perform another pass
						flag = 1;
					}
				} // foreach 
			} while (flag > 0);

		}

	}

}
