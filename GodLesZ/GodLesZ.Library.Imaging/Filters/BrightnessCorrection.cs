namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using GodLesZ.Library.Imaging.Mathematic;

    public class BrightnessCorrection : IFilter
    {
        private double adjustValue;
        private HSLLinear baseFilter;

        public BrightnessCorrection()
        {
            this.baseFilter = new HSLLinear();
            this.AdjustValue = 0.05;
        }

        public BrightnessCorrection(double adjustValue)
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
                    this.baseFilter.InLuminance = new RangeD(0.0, 1.0 - this.adjustValue);
                    this.baseFilter.OutLuminance = new RangeD(this.adjustValue, 1.0);
                }
                else
                {
                    this.baseFilter.InLuminance = new RangeD(-this.adjustValue, 1.0);
                    this.baseFilter.OutLuminance = new RangeD(0.0, 1.0 + this.adjustValue);
                }
            }
        }
    }
}

