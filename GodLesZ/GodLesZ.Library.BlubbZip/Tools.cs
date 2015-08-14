using System;
using System.Collections.Generic;
using System.IO;

using GodLesZ.Library.BlubbZip.Blubb;
using GodLesZ.Library.BlubbZip.Checksums;

namespace GodLesZ.Library.BlubbZip {

	public static class Tools {

		public static string PatchKnownProblems( string fileName ) {
			if( fileName.StartsWith( "." ) )
				fileName = fileName.Remove( 0, 1 );
			if( fileName.StartsWith( "\\" ) )
				fileName = fileName.Remove( 0, 1 );
			return fileName;
		}

		public static string MakePathRelative( string baseFolder, string path ) {
			if( path == null )
				return null;
			if( baseFolder == null )
				return path;

			return ( path.StartsWith( baseFolder ) == true ) ? path.Remove( 0, baseFolder.Length ) : path;
		}

	}

}
