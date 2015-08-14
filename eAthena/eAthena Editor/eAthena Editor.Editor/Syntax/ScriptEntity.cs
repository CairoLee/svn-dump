using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GodLesZ.eAthenaEditor.Editor.Syntax {

	public class ScriptEntity : IScriptEntity {
		public string W1 {
			get;
			set;
		}

		public string W2 {
			get;
			set;
		}

		public string W3 {
			get;
			set;
		}

		public string W4 {
			get;
			set;
		}

		public EScriptEnityType Type {
			get;
			set;
		}


		public virtual string Name {
			get { return GetComboListItemTitle(); }
		}


		public int OffsetStart {
			get;
			set;
		}

		public int OffsetEnd {
			get;
			set;
		}



		public ScriptEntity(string w1, string w2, string w3, string w4, EScriptEnityType type, int offsetStart, int offsetEnd) {
			W1 = w1;
			W2 = w2;
			W3 = w3;
			W4 =w4;
			Type = type;
			OffsetStart = offsetStart;
			OffsetEnd = offsetEnd;
		}


		public virtual string GetComboListItemTitle() {
			return W3;
		}


		public override string ToString() {
			return string.Format("[{0}] {1}, {2}, {3}, {4}", Type, W1, W2, W3, W4);
		}
		
	}

}
