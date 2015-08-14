namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

    public class HSLLinear : IFilter
    {
        private RangeD inLuminance = new RangeD(0.0, 1.0);
        private RangeD inSaturation = new RangeD(0.0, 1.0);
        private RangeD outLuminance = new RangeD(0.0, 1.0);
        private RangeD outSaturation = new RangeD(0.0, 1.0);

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
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            if (this.inLuminance.Max != this.inLuminance.Min)
            {
                num4 = (this.outLuminance.Max - this.outLuminance.Min) / (this.inLuminance.Max - this.inLuminance.Min);
                num5 = this.outLuminance.Min - (num4 * this.inLuminance.Min);
            }
            if (this.inSaturation.Max != this.inSaturation.Min)
            {
                num6 = (this.outSaturation.Max - this.outSaturation.Min) / (this.inSaturation.Max - this.inSaturation.Min);
                num7 = this.outSaturation.Min - (num6 * this.inSaturation.Min);
            }
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num9 = 0;
                while (num9 < width)
                {
                    rgb.Red = numPtr[2];
                    rgb.Green = numPtr[1];
                    rgb.Blue = numPtr[0];
                    GodLesZ.Library.Imaging.ColorConverter.RGB2HSL(rgb, hsl);
                    if (hsl.Luminance >= this.inLuminance.Max)
                    {
                        hsl.Luminance = this.outLuminance.Max;
                    }
                    else if (hsl.Luminance <= this.inLuminance.Min)
                    {
                        hsl.Luminance = this.outLuminance.Min;
                    }
                    else
                    {
                        hsl.Luminance = (num4 * hsl.Luminance) + num5;
                    }
                    if (hsl.Saturation >= this.inSaturation.Max)
                    {
                        hsl.Saturation = this.outSaturation.Max;
                    }
                    else if (hsl.Saturation <= this.inSaturation.Min)
                    {
                        hsl.Saturation = this.outSaturation.Min;
                    }
                    else
                    {
                        hsl.Saturation = (num6 * hsl.Saturation) + num7;
                    }
                    GodLesZ.Library.Imaging.ColorConverter.HSL2RGB(hsl, rgb);
                    numPtr2[2] = rgb.Red;
                    numPtr2[1] = rgb.Green;
                    numPtr2[0] = rgb.Blue;
                    num9++;
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

        public RangeD InLuminance
        {
            get
            {
                return this.inLuminance;
            }
            set
            {
                this.inLuminance = value;
            }
        }

        public RangeD InSaturation
        {
            get
            {
                return this.inSaturation;
            }
            set
            {
                this.inSaturation = value;
            }
        }

        public RangeD OutLuminance
        {
            get
            {
                return this.outLuminance;
            }
            set
            {
                this.outLuminance = value;
            }
        }

        public RangeD OutSaturation
        {
            get
            {
                return this.outSaturation;
            }
            set
            {
                this.outSaturation = value;
            }
        }
    }
}

