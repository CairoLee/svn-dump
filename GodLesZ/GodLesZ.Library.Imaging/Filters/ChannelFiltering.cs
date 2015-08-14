namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

    public class ChannelFiltering : IFilter
    {
        private Range blue;
        private bool blueFillOutsideRange;
        private byte fillB;
        private byte fillG;
        private byte fillR;
        private Range green;
        private bool greenFillOutsideRange;
        private byte[] mapBlue;
        private byte[] mapGreen;
        private byte[] mapRed;
        private Range red;
        private bool redFillOutsideRange;

        public ChannelFiltering()
        {
            this.red = new Range(0, 0xff);
            this.green = new Range(0, 0xff);
            this.blue = new Range(0, 0xff);
            this.redFillOutsideRange = true;
            this.greenFillOutsideRange = true;
            this.blueFillOutsideRange = true;
            this.mapRed = new byte[0x100];
            this.mapGreen = new byte[0x100];
            this.mapBlue = new byte[0x100];
            this.CalculateMap(this.red, this.fillR, this.redFillOutsideRange, this.mapRed);
            this.CalculateMap(this.green, this.fillG, this.greenFillOutsideRange, this.mapGreen);
            this.CalculateMap(this.blue, this.fillB, this.blueFillOutsideRange, this.mapBlue);
        }

        public ChannelFiltering(Range red, Range green, Range blue)
        {
            this.red = new Range(0, 0xff);
            this.green = new Range(0, 0xff);
            this.blue = new Range(0, 0xff);
            this.redFillOutsideRange = true;
            this.greenFillOutsideRange = true;
            this.blueFillOutsideRange = true;
            this.mapRed = new byte[0x100];
            this.mapGreen = new byte[0x100];
            this.mapBlue = new byte[0x100];
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
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
            int num3 = bitmapdata.Stride - (width * 3);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num5 = 0;
                while (num5 < width)
                {
                    numPtr2[2] = this.mapRed[numPtr[2]];
                    numPtr2[1] = this.mapGreen[numPtr[1]];
                    numPtr2[0] = this.mapBlue[numPtr[0]];
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

        private void CalculateMap(Range range, byte fill, bool fillOutsideRange, byte[] map)
        {
            for (int i = 0; i < 0x100; i++)
            {
                if ((i >= range.Min) && (i <= range.Max))
                {
                    map[i] = fillOutsideRange ? ((byte) i) : fill;
                }
                else
                {
                    map[i] = fillOutsideRange ? fill : ((byte) i);
                }
            }
        }

        public Range Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = value;
                this.CalculateMap(this.blue, this.fillB, this.blueFillOutsideRange, this.mapBlue);
            }
        }

        public bool BlueFillOutsideRange
        {
            get
            {
                return this.blueFillOutsideRange;
            }
            set
            {
                this.blueFillOutsideRange = value;
                this.CalculateMap(this.blue, this.fillB, this.blueFillOutsideRange, this.mapBlue);
            }
        }

        public byte FillBlue
        {
            get
            {
                return this.fillB;
            }
            set
            {
                this.fillB = value;
                this.CalculateMap(this.blue, this.fillB, this.blueFillOutsideRange, this.mapBlue);
            }
        }

        public byte FillGreen
        {
            get
            {
                return this.fillG;
            }
            set
            {
                this.fillG = value;
                this.CalculateMap(this.green, this.fillG, this.greenFillOutsideRange, this.mapGreen);
            }
        }

        public byte FillRed
        {
            get
            {
                return this.fillR;
            }
            set
            {
                this.fillR = value;
                this.CalculateMap(this.red, this.fillR, this.redFillOutsideRange, this.mapRed);
            }
        }

        public Range Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = value;
                this.CalculateMap(this.green, this.fillG, this.greenFillOutsideRange, this.mapGreen);
            }
        }

        public bool GreenFillOutsideRange
        {
            get
            {
                return this.greenFillOutsideRange;
            }
            set
            {
                this.greenFillOutsideRange = value;
                this.CalculateMap(this.green, this.fillG, this.greenFillOutsideRange, this.mapGreen);
            }
        }

        public Range Red
        {
            get
            {
                return this.red;
            }
            set
            {
                this.red = value;
                this.CalculateMap(this.red, this.fillR, this.redFillOutsideRange, this.mapRed);
            }
        }

        public bool RedFillOutsideRange
        {
            get
            {
                return this.redFillOutsideRange;
            }
            set
            {
                this.redFillOutsideRange = value;
                this.CalculateMap(this.red, this.fillR, this.redFillOutsideRange, this.mapRed);
            }
        }
    }
}

