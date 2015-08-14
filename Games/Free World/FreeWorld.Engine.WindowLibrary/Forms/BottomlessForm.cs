using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FreeWorld.Engine.WindowLibrary {

	public class BottomlessForm : Form {
		new public bool CanResize {
			set {
				mCanResize = value;
				if( FormTexture != null && FormTextureName != null ) {
					FormTextureName[ 8 ] = @"Interface\" + FormStyle + @"\Form\form_bottomless_bottomright" + ( mCanResize ? "_resize" : "" ) + "";
					FormTexture[ 8 ] = EngineCore.ContentLoader.Load<Texture2D>( FormTextureName[ 8 ] );
				}
			}
			get { return mCanResize; }
		}


		public BottomlessForm()
			: base() {
		}

		public BottomlessForm( Vector2 WndPos, Vector2 WndSize, string WndTitle, Color ColBg, Color ColFg, SpriteFont WndFont, SFormStyle WndStyle )
			: base( WndPos, WndSize, WndTitle, true, ColBg, ColFg, WndFont, WndStyle ) {
		}


		public override void InitTexture( bool isManualInit ) {
			FormTextureName = new string[ 9 ]{
				@"Interface\" + FormStyle + @"\Form\form_bottomless_topleft",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_topmiddle",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_topright",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_middleleft",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_middlemiddle",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_middleright",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_bottomleft",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_bottommiddle",
				@"Interface\" + FormStyle + @"\Form\form_bottomless_bottomright",
			};
			base.InitTexture( true );
		}

	}

}
