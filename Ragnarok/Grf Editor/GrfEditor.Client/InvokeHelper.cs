using System;
using System.Collections.Generic;
using System.Text;

namespace GrfEditor.Client {

	public class InvokeHelper {

		public delegate void InvokeDelegate();
		public static void Invoke(System.Windows.Forms.Control Control, InvokeDelegate Delegate) {
			if (Control.InvokeRequired) {
				Control.Invoke(Delegate);
			} else {
				Delegate();
			}
		}



		internal static void Invoke(System.Windows.Forms.ToolStripItem Control, InvokeDelegate Delegate) {
			Delegate();
		}
	}

}
