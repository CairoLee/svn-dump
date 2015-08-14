using System;
using System.Collections.Generic;
using System.Text;
using InsaneRO.Cards.Library.Formats;

namespace InsaneRO.Cards.Client {

	public class RagnarokAnimationHandler {
		public static Dictionary<int, RagnarokAnimation> Animations = new Dictionary<int, RagnarokAnimation>();


		public static void Load( string rootDir, int animationID ) {
			if( Animations.ContainsKey( animationID ) == true )
				return;

			RagnarokAnimation ani = new RagnarokAnimation();
			ani.Read( rootDir + @"\Mobs\" + animationID + ".ani", true );

			Animations.Add( animationID, ani );
		}


	}

}
