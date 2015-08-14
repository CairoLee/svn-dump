using System;
using System.Collections.Generic;
using System.Text;

namespace eAthenaStudio.Library.Plugin {

	public class SaveAttribute : Attribute {
		private readonly bool mSave = true;

		public bool Save {
			get { return mSave; }
		}


		public SaveAttribute(bool save) {
			mSave = save;
		}

		public SaveAttribute()
			: this(true) {
		}

	}

}
