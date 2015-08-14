using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ragnarok3D.Editor {
	class EffectParams {
		private Effect effect;
		private EffectParameter worldViewProjParam;
		private EffectParameter worldParam;
		private EffectParameter viewParam;
		private EffectParameter colorParam;

		Matrix worldViewProj;

		public EffectParams( ref Effect effect, string technique ) {
			this.effect = effect;
			this.effect.CurrentTechnique = effect.Techniques[ technique ];
			InitParams();
		}

		private void InitParams() {
			worldViewProjParam = effect.Parameters[ "WorldViewProj" ];
			worldParam = effect.Parameters[ "World" ];
			viewParam = effect.Parameters[ "View" ];
			colorParam = effect.Parameters[ "color" ];
		}

		public void Update( Matrix world, Matrix view, Matrix projection ) {
			worldViewProj = world * view * projection;
			if( worldViewProjParam != null )
				worldViewProjParam.SetValue( worldViewProj );
			if( worldParam != null )
				worldParam.SetValue( world );
			if( viewParam != null )
				viewParam.SetValue( view );
		}

		public void Update( Vector3 color ) {
			if( colorParam != null )
				colorParam.SetValue( color );
		}

		public void Update( Vector4 color ) {
			if( colorParam != null )
				colorParam.SetValue( color );
		}
	}
}
