namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

    public class HSLFiltering : IFilter
    {
        private int fillH;
        private double fillL;
        private bool fillOutsideRange;
        private double fillS;
        private Range hue;
        private RangeD luminance;
        private RangeD saturation;
        private bool updateH;
        private bool updateL;
        private bool updateS;

        public HSLFiltering()
        {
            this.hue = new Range(0, 0x167);
            this.saturation = new RangeD(0.0, 1.0);
            this.luminance = new RangeD(0.0, 1.0);
            this.fillOutsideRange = true;
            this.updateH = true;
            this.updateS = true;
            this.updateL = true;
        }

        public HSLFiltering(Range hue, RangeD saturation, RangeD luminance)
        {
            this.hue = new Range(0, 0x167);
            this.saturation = new RangeD(0.0, 1.0);
            this.luminance = new RangeD(0.0, 1.0);
            this.fillOutsideRange = true;
            this.updateH = true;
            this.updateS = true;
            this.updateL = true;
            this.hue = hue;
            this.saturation = saturation;
            this.luminance = luminance;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            if (srcImg.PixelFormat != PixelFormat.Format24bppRgb)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            RGB rgb = new RGB();
            HSL hsl = new HSL();
            int num3 = bitmapdata.Stride - (width * 3);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num5 = 0;
                while (num5 < width)
                {
                    rgb.Red = numPtr[2];
                    rgb.Green = numPtr[1];
                    rgb.Blue = numPtr[0];
                    GodLesZ.Library.Imaging.ColorConverter.RGB2HSL(rgb, hsl);
                    if ((((hsl.Saturation >= this.saturation.Min) && (hsl.Saturation <= this.saturation.Max)) && ((hsl.Luminance >= this.luminance.Min) && (hsl.Luminance <= this.luminance.Max))) && ((((this.hue.Min < this.hue.Max) && (hsl.Hue >= this.hue.Min)) && (hsl.Hue <= this.hue.Max)) || ((this.hue.Min > this.hue.Max) && ((hsl.Hue >= this.hue.Min) || (hsl.Hue <= this.hue.Max)))))
                    {
                        if (!this.fillOutsideRange)
                        {
                            if (this.updateH)
                            {
                                hsl.Hue = this.fillH;
                            }
                            if (this.updateS)
                            {
                                hsl.Saturation = this.fillS;
                            }
                            if (this.updateL)
                            {
                                hsl.Luminance = this.fillL;
                            }
                        }
                    }
                    else if (this.fillOutsideRange)
                    {
                        if (this.updateH)
                        {
                            hsl.Hue = this.fillH;
                        }
                        if (this.updateS)
                        {
                            hsl.Saturation = this.fillS;
                        }
                        if (this.updateL)
                        {
                            hsl.Luminance = this.fillL;
                        }
                    }
                    GodLesZ.Library.Imaging.ColorConverter.HSL2RGB(hsl, rgb);
                    numPtr2[2] = rgb.Red;
                    numPtr2[1] = rgb.Green;
                    numPtr2[0] = rgb.Blue;
                    num5++;
                    numPtr += 3;
                    numPtr2 += 3;
                }
                numPtr += num3;
                numPtr2 += num3;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public HSL FillColor
        {
            get
            {
                return new HSL(this.fillH, this.fillS, this.fillL);
            }
            set
            {
                this.fillH = value.Hue;
                this.fillS = value.Saturation;
                this.fillL = value.Luminance;
            }
        }

        public bool FillOutsideRange
        {
            get
            {
                return this.fillOutsideRange;
            }
            set
            {
                this.fillOutsideRange = value;
            }
        }

        public Range Hue
        {
            get
            {
                return this.hue;
            }
            set
            {
                this.hue = value;
            }
        }

        public RangeD Luminance
        {
            get
            {
                return this.luminance;
            }
            set
            {
                this.luminance = value;
            }
        }

        public RangeD Saturation
        {
            get
            {
                return this.saturation;
            }
            set
            {
                this.saturation = value;
            }
        }

        public bool UpdateHue
        {
            get
            {
                return this.updateH;
            }
            set
            {
                this.updateH = value;
            }
        }

        public bool UpdateLuminance
        {
            get
            {
                return this.updateL;
            }
            set
            {
                this.updateL = value;
            }
        }

        public bool UpdateSaturation
        {
            get
            {
                return this.updateS;
            }
            set
            {
                this.updateS = value;
            }
        }
    }
}

