namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using GodLesZ.Library.Imaging.Mathematic;

    public class SaturationCorrection : IFilter
    {
        private double adjustValue;
        private HSLLinear baseFilter;

        public SaturationCorrection()
        {
            this.baseFilter = new HSLLinear();
            this.AdjustValue = 0.05;
        }

        public SaturationCorrection(double adjustValue)
        {
            this.baseFilter = new HSLLinear();
            this.AdjustValue = adjustValue;
        }

        public Bitmap Apply(Bitmap srcImg)
        {
            return this.baseFilter.Apply(srcImg);
        }

        public double AdjustValue
        {
            get
            {
                return this.adjustValue;
            }
            set
            {
                this.adjustValue = Math.Max(-1.0, Math.Min(1.0, value));
                if (this.adjustValue > 0.0)
                {
                    this.baseFilter.InSaturation = new RangeD(0.0, 1.0 - this.adjustValue);
                    this.baseFilter.OutSaturation = new RangeD(this.adjustValue, 1.0);
                }
                else
                {
                    this.baseFilter.InSaturation = new RangeD(-this.adjustValue, 1.0);
                    this.baseFilter.OutSaturation = new RangeD(0.0, 1.0 + this.adjustValue);
                }
            }
        }
    }
}

