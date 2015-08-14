namespace GodLesZ.Library.Imaging.Filters
{
    using System.Drawing;

    public interface IFilter
    {
        Bitmap Apply(Bitmap img);
    }
}

