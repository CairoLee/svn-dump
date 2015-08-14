namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using GodLesZ.Library.Imaging.Mathematic;

    public class SharpenEx : IFilter
    {
        private Correlation filter;
        private double sigma;
        private int size;

        public SharpenEx()
        {
            this.sigma = 1.4;
            this.size = 5;
            this.CreateFilter();
        }

        public SharpenEx(double sigma)
        {
            this.sigma = 1.4;
            this.size = 5;
            this.Sigma = sigma;
        }

        public SharpenEx(double sigma, int size)
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
            int num = 0;
            for (int i = 0; i < this.size; i++)
            {
                for (int k = 0; k < this.size; k++)
                {
                    num += kernel[i, k];
                }
            }
            int num4 = this.size >> 1;
            for (int j = 0; j < this.size; j++)
            {
                for (int m = 0; m < this.size; m++)
                {
                    if ((j == num4) && (m == num4))
                    {
                        kernel[j, m] = (2 * num) - kernel[j, m];
                    }
                    else
                    {
                        kernel[j, m] = -kernel[j, m];
                    }
                }
            }
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

