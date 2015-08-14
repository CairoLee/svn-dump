namespace GodLesZ.Library.Imaging.Filters {

	public sealed class GrayscaleY : Grayscale
    {
        public GrayscaleY() : base(0.299f, 0.587f, 0.114f)
        {
        }
    }
}

