using Awesomium.Core;
using Microsoft.Xna.Framework.Graphics;

namespace GodLesZ.Library.MonoGame.Awesomium {

	public static class BitmapSurfaceExtensions {

		public static Texture2D RenderTexture2D(this BitmapSurface buffer, Texture2D texture) {
			TextureFormatConverter.DirectBlit(buffer, ref texture);
			return texture;
		}

	}

}
