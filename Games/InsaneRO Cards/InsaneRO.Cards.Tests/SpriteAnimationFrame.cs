using System;
using System.Collections.Generic;
using System.Text;

namespace InsaneRO.Cards.Tests {

	public class SpriteAnimationFrame : ICloneable {
		public List<SpriteAnimationFrameImage> Images = new List<SpriteAnimationFrameImage>();

		public SpriteAnimationFrameImage this[ int Index ] {
			get { return Images[ Index ]; }
		}


		public SpriteAnimationFrame() {
		}

		public SpriteAnimationFrame( SpriteAnimationFrameImage[] images ) {
			Images = new List<SpriteAnimationFrameImage>();
			for( int i = 0; i < images.Length; i++ )
				Images.Add( images[ i ].Clone() as SpriteAnimationFrameImage );
		}

		public SpriteAnimationFrame( List<SpriteAnimationFrameImage> images ) {
			Images = new List<SpriteAnimationFrameImage>();
			for( int i = 0; i < images.Count; i++ )
				Images.Add( images[ i ].Clone() as SpriteAnimationFrameImage );
		}


		public object Clone() {
			return new SpriteAnimationFrame( Images );
		}

	}

}
