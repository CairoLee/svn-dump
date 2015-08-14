namespace GodLesZ.Library.Imaging.Filters {

	public sealed class Edges : Correlation
    {
        public Edges() : base(new int[,] { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } })
        {
        }
    }
}

