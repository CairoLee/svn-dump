using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Puzzle3D {

	public class PictureSet {
		string[] names;
		Texture2D[] textures;
		ContentManager content;

		public int Count {
			get { return names.Length; }
		}


		public PictureSet( string[] names ) {
			this.names = names;
			textures = new Texture2D[ names.Length ];
			content = new ContentManager( Puzzle3D.Instance.Services );
		}


		public void Load() {
			for( int i = 0; i < names.Length; i++ )
				textures[ i ] = Load( names[ i ] );
		}

		static Texture2D Load( string name ) {
			return Puzzle3D.Instance.Content.Load<Texture2D>( name );
		}

		public void Unload() {
			content.Unload();
		}

		public Texture2D GetTexture( int index ) {
			return textures[ index ];
		}

	}

}