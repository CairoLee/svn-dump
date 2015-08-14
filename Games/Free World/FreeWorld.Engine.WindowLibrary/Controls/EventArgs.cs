using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeWorld.Engine.WindowLibrary {

	public class FormResizedEventsArgs : EventArgs {
		private EFormState mFormState;

		public EFormState FormState {
			get { return mFormState; }
			set { mFormState = value; }
		}


		public FormResizedEventsArgs( EFormState FormState ) {
			mFormState = FormState;
		}

	}

}
