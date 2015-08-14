namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;

    public class Opening : IFilter
    {
        private IFilter dilatation;
        private IFilter errosion;

        public Opening()
        {
            this.errosion = new Erosion();
            this.dilatation = new Dilatation();
        }

        public Opening(short[,] se)
        {
            this.errosion = new Erosion();
            this.dilatation = new Dilatation();
            this.errosion = new Erosion(se);
            this.dilatation = new Dilatation(se);
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            Bitmap img = this.errosion.Apply(srcImg);
            Bitmap bitmap2 = this.dilatation.Apply(img);
            img.Dispose();
            return bitmap2;
        }
    }
}

