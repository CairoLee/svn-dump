using System.Drawing;

namespace GodLesZ.Library.Ragnarok.Sprite {

	public class RoSpriteImage {
		public ushort Width;
		public ushort Height;
		public byte[] Data;

		public Bitmap Image;

		public override string ToString() {
			return string.Format("{0}x{1}", Width, Height);
		}

	}

}
