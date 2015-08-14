using GodLesZ.Library.Controls;

namespace GrfEditor.Library.Controls {

	public class FilepathHighlightTextRenderer : HighlightTextRenderer {

		public FilepathHighlightTextRenderer(FilepathTextMatchFilter filter)
			: base(filter) {

			CornerRoundness = 0;
			FillBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Goldenrod);
			FramePen = null;
		}

	}

}
