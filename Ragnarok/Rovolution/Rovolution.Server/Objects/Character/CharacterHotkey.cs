using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Rovolution.Server.Database;

namespace Rovolution.Server.Objects {

	public class CharacterHotkey : StoreableObject {

		public short Index {
			get;
			set;
		}

		public int ID {
			get;
			set;
		}

		public ushort Level {
			get;
			set;
		}

		public EHotkeyType Type {
			get;
			set;
		}


		public CharacterHotkey() {
		}


		public static CharacterHotkey Load(DataRow row) {
			CharacterHotkey key = new CharacterHotkey();
			if (key.LoadFromDatabase(row) == false) {
				return null;
			}

			return key;
		}


		protected override bool LoadFromDatabase(DataRow row) {
			Index = row.Field<short>("index");
			ID = row.Field<int>("id");
			Level = row.Field<ushort>("level");
			Type = (EHotkeyType)row.Field<int>("type");

			return true;
		}

	}

}
