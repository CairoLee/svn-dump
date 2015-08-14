using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	/// <summary>
	/// A special list for skill data, enables faster access
	/// </summary>
	public class SkillDatabaseDataList : SafeDictionary<ESkill, DatabaseObject>, IClearDisposable {

		public DatabaseObject this[int index] {
			get { return this[(ESkill)index]; }
			set { this[(ESkill)index] = value; }
		}


		public void Clear(bool dispose) {

			if (dispose == true) {
				DatabaseObject[] values = new DatabaseObject[Count];
				CopyValuesTo(values, 0);

				foreach (SkillDatabaseData obj in values) {
					// Avoid already disposed
					if (obj is SkillDatabaseData) {
						obj.Dispose();
					}
				}

				values = null;
			}

			base.Clear();
		}

	}

}
