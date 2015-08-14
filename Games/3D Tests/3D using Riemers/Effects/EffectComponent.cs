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

	public class EffectComponent : DrawableGameComponent {
		protected EffectComponent( Game g ) : base( g ) { }
		protected Effect effect;

		public override void Initialize() {
			effect = Game.Content.Load<Effect>( @"Effects\Series4Effects" );
			base.Initialize();
		}
	}





}