namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using GodLesZ.Library.Imaging.Mathematic;

    public class ContrastCorrection : IFilter
    {
        private HSLLinear baseFilter;
        private double factor;

        public ContrastCorrection()
        {
            this.baseFilter = new HSLLinear();
            this.Factor = 1.25;
        }

        public ContrastCorrection(double factor)
        {
            this.baseFilter = new HSLLinear();
            this.Factor = factor;
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            return this.baseFilter.Apply(srcImg);
        }

        public double Factor
        {
            get
            {
                return this.factor;
            }
            set
            {
                this.factor = Math.Max(1E-06, value);
                this.baseFilter.InLuminance = new RangeD(0.0, 1.0);
                this.baseFilter.OutLuminance = new RangeD(0.0, 1.0);
                if (this.factor > 1.0)
                {
                    this.baseFilter.InLuminance = new RangeD(0.5 - (0.5 / this.factor), 0.5 + (0.5 / this.factor));
                }
                else
                {
                    this.baseFilter.OutLuminance = new RangeD(0.5 - (0.5 * this.factor), 0.5 + (0.5 * this.factor));
                }
            }
        }
    }
}

