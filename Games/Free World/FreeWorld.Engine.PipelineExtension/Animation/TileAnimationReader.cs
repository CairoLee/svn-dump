using FreeWorld.Engine.TileEngine.Animation;
using Microsoft.Xna.Framework.Content;

namespace FreeWorld.Engine.PipelineExtension.Animation {
	/// <summary>
	/// Content Reader, reads the Binary compiled File and Convert it to readable Data
	/// </summary>
	public class TileAnimationReader : ContentTypeReader<TileAnimation> {

		protected override TileAnimation Read(ContentReader input, TileAnimation existingInstance) {
			TileAnimation ani;
			TileAnimation.Load(input.BaseStream, out ani);

			return ani;
		}

	}


}
