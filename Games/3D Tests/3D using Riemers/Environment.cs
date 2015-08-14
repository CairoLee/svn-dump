using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Engine3DFromRiemersTutorial {
	public class Environment : EffectComponent {
		Vector3 windDirection = new Vector3( 0, 0, 1 );

		public Environment( Game game )
			: base( game ) {
		}

		public override void Draw( GameTime gameTime ) {
			float time = (float)gameTime.TotalGameTime.TotalMilliseconds / 1000.0f;
			effect.Parameters[ "xTime" ].SetValue( time );
			effect.Parameters[ "xWindForce" ].SetValue( 0.02f );
			effect.Parameters[ "xWindDirection" ].SetValue( windDirection );
		}
	}
}