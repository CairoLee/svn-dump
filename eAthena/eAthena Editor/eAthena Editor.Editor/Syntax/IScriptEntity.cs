using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public interface IScriptEntity {
		string W1 {
			get;
			set;
		}

		string W2 {
			get;
			set;
		}

		string W3 {
			get;
			set;
		}

		string W4 {
			get;
			set;
		}

		EScriptEnityType Type {
			get;
			set;
		}


		string Name {
			get;
		}


		int OffsetStart {
			get;
			set;
		}

		int OffsetEnd {
			get;
			set;
		}


		string GetComboListItemTitle();

	}

}
