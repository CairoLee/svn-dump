
namespace GodLesZ.Library.Ragnarok.MonoGame.Format.Sprite {

	public class DrawableRoSpriteImagePal : DrawableRoSpriteImage {

		public ushort Size;

		public bool Decoded;

		public override string ToString() {
			return string.Format("{0}x{1} ({2} bytes)", Width, Height, Size);
		}

	}

}
