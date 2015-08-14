namespace GodLesZ.Library.Imaging.Filters {

	public sealed class Sharpen : Correlation
    {
        public Sharpen() : base(new int[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } })
        {
        }
    }
}

