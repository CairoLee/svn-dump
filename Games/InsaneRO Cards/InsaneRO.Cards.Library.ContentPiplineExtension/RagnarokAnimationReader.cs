using Microsoft.Xna.Framework.Content;
using InsaneRO.Cards.Library.Formats;

namespace InsaneRO.Cards.Library.PiplineExtension {

	public class RagnarokAnimationReader : ContentTypeReader<RagnarokAnimation> {

		protected override RagnarokAnimation Read( ContentReader input, RagnarokAnimation existingInstance ) {
			RagnarokAnimation ani = new RagnarokAnimation();
			ani.Read( input.BaseStream );
			return ani;
		}

	}

}
