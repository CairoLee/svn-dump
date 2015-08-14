namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using GodLesZ.Library.Imaging.Mathematic;

    public sealed class GaussianBlur : IFilter
    {
        private Correlation filter;
        private double sigma;
        private int size;

        public GaussianBlur()
        {
            this.sigma = 1.4;
            this.size = 5;
            this.CreateFilter();
        }

        public GaussianBlur(double sigma)
        {
            this.sigma = 1.4;
            this.size = 5;
            this.Sigma = sigma;
        }

        public GaussianBlur(double sigma, int size)
        {
            this.sigma = 1.4;
            this.size = 5;
            this.Sigma = sigma;
            this.Size = size;
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            return this.filter.Apply(srcImg);
        }

        private void CreateFilter()
        {
            int[,] kernel = new Gaussian(this.sigma).KernelDiscret2D(this.size);
            this.filter = new Correlation(kernel);
        }

        public double Sigma
        {
            get
            {
                return this.sigma;
            }
            set
            {
                this.sigma = Math.Max(0.5, Math.Min(5.0, value));
                this.CreateFilter();
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = Math.Max(3, Math.Min(0x15, value | 1));
                this.CreateFilter();
            }
        }
    }
}

