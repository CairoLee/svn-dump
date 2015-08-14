using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GodLesZ.Library;

namespace Rovolution.Server {

	public class ExceptionHandler {

		public static void Trace( Exception ex ) {
			try {
				using( StreamWriter op = new StreamWriter( "network-errors.log", true ) ) {
					op.WriteLine( "# {0}", DateTime.Now );

					op.WriteLine( ex );

					op.WriteLine();
					op.WriteLine();
				}
			} catch {
			}

			try {
				ServerConsole.ErrorLine( ex.ToString() );
			} catch {
			}
		}

	}

}
