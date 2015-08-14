using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace Puzzle3D {

	public static class PictureDatabase {
		const int PictureCount = 11;

		static List<string> textureNames = new List<string>();
		static int nextIndex = 0;

		public static int Count {
			get { return textureNames.Count; }
		}


		public static void Initialize() {
			for( int i = 1; i <= PictureCount; i++ )
				textureNames.Add( "Pictures/" + i.ToString() );

			RandomHelper.Randomize( textureNames );
		}

		public static PictureSet GetNextPictureSet( int numTextures ) {
			string[] setNames = new string[ numTextures ];
			for( int i = 0; i < numTextures; i++ ) {
				setNames[ i ] = textureNames[ nextIndex ];
				nextIndex = ( nextIndex + 1 ) % textureNames.Count;
			}

			return new PictureSet( setNames );
		}

	}

}
