
namespace GodLesZ.Library.Ragnarok.Sprite {

	public class RoSpriteImagePal : RoSpriteImage {

		public ushort Size;

		public bool Decoded;

		public override string ToString() {
			return string.Format("{0}x{1} ({2} bytes)", Width, Height, Size);
		}

	}

}
