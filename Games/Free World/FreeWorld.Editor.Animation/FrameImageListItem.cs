using System.Globalization;
using System.Windows.Forms;
using FreeWorld.Engine.TileEngine.Animation;

namespace FreeWorld.Editor.Animation {

	public class FrameImageListItem : ListViewItem {

		public int FrameIndex {
			get;
			protected set;
		}

		public int FrameImageIndex {
			get;
			protected set;
		}

		public TileAnimationFrameImage FrameImage {
			get;
			protected set;
		}


		public FrameImageListItem(int frame, int frameImage, TileAnimationFrameImage image)
			: base(new[] {
				(frameImage + 1).ToString(CultureInfo.InvariantCulture),
				(image.IsBackground ? "Back" : "Front")
				}) {
			FrameIndex = frame;
			FrameImageIndex = frameImage;
			FrameImage = image;
		}

	}

}
