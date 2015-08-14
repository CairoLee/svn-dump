namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

    public class LevelsLinear : IFilter
    {
        private Range inBlue = new Range(0, 0xff);
        private Range inGreen = new Range(0, 0xff);
        private Range inRed = new Range(0, 0xff);
        private byte[] mapBlue = new byte[0x100];
        private byte[] mapGreen = new byte[0x100];
        private byte[] mapRed = new byte[0x100];
        private Range outBlue = new Range(0, 0xff);
        private Range outGreen = new Range(0, 0xff);
        private Range outRed = new Range(0, 0xff);

        public LevelsLinear()
        {
            this.CalculateMap(this.inRed, this.outRed, this.mapRed);
            this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
            this.CalculateMap(this.inBlue, this.outBlue, this.mapBlue);
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int num3 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num5 = 0;
                    while (num5 < width)
                    {
                        numPtr2[0] = this.mapGreen[numPtr[0]];
                        num5++;
                        numPtr++;
                        numPtr2++;
                    }
                    numPtr += num3;
                    numPtr2 += num3;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num7 = 0;
                    while (num7 < width)
                    {
                        numPtr2[2] = this.mapRed[numPtr[2]];
                        numPtr2[1] = this.mapGreen[numPtr[1]];
                        numPtr2[0] = this.mapBlue[numPtr[0]];
                        num7++;
                        numPtr += 3;
                        numPtr2 += 3;
                    }
                    numPtr += num3;
                    numPtr2 += num3;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        private void CalculateMap(Range inRange, Range outRange, byte[] map)
        {
            double num = 0.0;
            double num2 = 0.0;
            if (inRange.Max != inRange.Min)
            {
                num = ((double) (outRange.Max - outRange.Min)) / ((double) (inRange.Max - inRange.Min));
                num2 = outRange.Min - (num * inRange.Min);
            }
            for (int i = 0; i < 0x100; i++)
            {
                byte max = (byte) i;
                if (max >= inRange.Max)
                {
                    max = (byte) outRange.Max;
                }
                else if (max <= inRange.Min)
                {
                    max = (byte) outRange.Min;
                }
                else
                {
                    max = (byte) ((num * max) + num2);
                }
                map[i] = max;
            }
        }

        public Range InBlue
        {
            get
            {
                return this.inBlue;
            }
            set
            {
                this.inBlue = value;
                this.CalculateMap(this.inBlue, this.outBlue, this.mapBlue);
            }
        }

        public Range InGray
        {
            get
            {
                return this.inGreen;
            }
            set
            {
                this.inGreen = value;
                this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
            }
        }

        public Range InGreen
        {
            get
            {
                return this.inGreen;
            }
            set
            {
                this.inGreen = value;
                this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
            }
        }

        public Range Input
        {
            set
            {
                this.inRed = this.inGreen = this.inBlue = value;
                this.CalculateMap(this.inRed, this.outRed, this.mapRed);
                this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
                this.CalculateMap(this.inBlue, this.outBlue, this.mapBlue);
            }
        }

        public Range InRed
        {
            get
            {
                return this.inRed;
            }
            set
            {
                this.inRed = value;
                this.CalculateMap(this.inRed, this.outRed, this.mapRed);
            }
        }

        public Range OutBlue
        {
            get
            {
                return this.outBlue;
            }
            set
            {
                this.outBlue = value;
                this.CalculateMap(this.inBlue, this.outBlue, this.mapBlue);
            }
        }

        public Range OutGray
        {
            get
            {
                return this.outGreen;
            }
            set
            {
                this.outGreen = value;
                this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
            }
        }

        public Range OutGreen
        {
            get
            {
                return this.outGreen;
            }
            set
            {
                this.outGreen = value;
                this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
            }
        }

        public Range Output
        {
            set
            {
                this.outRed = this.outGreen = this.outBlue = value;
                this.CalculateMap(this.inRed, this.outRed, this.mapRed);
                this.CalculateMap(this.inGreen, this.outGreen, this.mapGreen);
                this.CalculateMap(this.inBlue, this.outBlue, this.mapBlue);
            }
        }

        public Range OutRed
        {
            get
            {
                return this.outRed;
            }
            set
            {
                this.outRed = value;
                this.CalculateMap(this.inRed, this.outRed, this.mapRed);
            }
        }
    }
}

