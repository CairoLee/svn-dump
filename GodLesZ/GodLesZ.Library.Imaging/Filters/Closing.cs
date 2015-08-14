namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;

    public class Closing : IFilter
    {
        private IFilter dilatation;
        private IFilter errosion;

        public Closing()
        {
            this.errosion = new Erosion();
            this.dilatation = new Dilatation();
        }

        public Closing(short[,] se)
        {
            this.errosion = new Erosion();
            this.dilatation = new Dilatation();
            this.errosion = new Erosion(se);
            this.dilatation = new Dilatation(se);
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            Bitmap img = this.dilatation.Apply(srcImg);
            Bitmap bitmap2 = this.errosion.Apply(img);
            img.Dispose();
            return bitmap2;
        }
    }
}

