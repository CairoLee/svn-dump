namespace GodLesZ.Library.Imaging.Filters {

	public sealed class Mean : Correlation
    {
        public Mean() : base(new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } })
        {
        }
    }
}

