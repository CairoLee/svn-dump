using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rovolution.Server.Objects {

	public class WorldObjectStatusChangeList : Dictionary<EStatusChange, WorldObjectStatusChangeEntry> {

		public EStatusOption Option {
			get;
			set;
		}

		public EStatusOption1 Option1 {
			get;
			set;
		}

		public EStatusOption2 Option2 {
			get;
			set;
		}

		public EStatusOption3 Option3 {
			get;
			set;
		}

		// @TODO: See if it is possible to implement the following SC's without requiring extra parameters while the SC is inactive.
		public short JoinBeatFlag {
			get;
			set;
		}

		public ushort MpMatkMin {
			get;
			set;
		}

		public ushort MpMatkMax {
			get;
			set;
		}

		public int StormGustID {
			get;
			set;
		}

		public short StormGustCounter {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the entry based on the key
		/// <para>
		/// Note: If the key dosnt exist, null is returened instead of an exception
		/// </para>
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		new public WorldObjectStatusChangeEntry this[EStatusChange key] {
			get {
				WorldObjectStatusChangeEntry obj;
				if (TryGetValue(key, out obj) == true) {
					return obj;
				}
				return null;
			}
			set {
				if (ContainsKey(key) == true) {
					base[key] = value;
				} else {
					Add(key, value);
				}
			}
		}


		public WorldObjectStatusChangeList() {
		}


		public bool HasStatus(EStatusChange type) {
			return ContainsKey(type);
		}

		new public void Clear() {
			base.Clear();
			Option = EStatusOption.Nothing;
			Option1 = EStatusOption1.None;
			Option2 = EStatusOption2.None;
			Option3 = EStatusOption3.Normal;
			JoinBeatFlag = 0;
			MpMatkMin = 0;
			MpMatkMax = 0;
			StormGustID = 0;
			StormGustCounter = 0;
		}

	}

}
