namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;
	using GodLesZ.Library.Imaging.Mathematic;

    public class ColorFiltering : IFilter
    {
        private Range blue;
        private byte fillB;
        private byte fillG;
        private bool fillOutsideRange;
        private byte fillR;
        private Range green;
        private Range red;

        public ColorFiltering()
        {
            this.red = new Range(0, 0xff);
            this.green = new Range(0, 0xff);
            this.blue = new Range(0, 0xff);
            this.fillOutsideRange = true;
        }

        public ColorFiltering(Range red, Range green, Range blue)
        {
            this.red = new Range(0, 0xff);
            this.green = new Range(0, 0xff);
            this.blue = new Range(0, 0xff);
            this.fillOutsideRange = true;
            this.red = red;
            this.green = green;
            this.blue = blue;
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
                int num8 = 0;
                while (num8 < width)
                {
                    byte num4 = numPtr[2];
                    byte num5 = numPtr[1];
                    byte num6 = numPtr[0];
                    if ((((num4 >= this.red.Min) && (num4 <= this.red.Max)) && ((num5 >= this.green.Min) && (num5 <= this.green.Max))) && ((num6 >= this.blue.Min) && (num6 <= this.blue.Max)))
                    {
                        if (this.fillOutsideRange)
                        {
                            numPtr2[2] = num4;
                            numPtr2[1] = num5;
                            numPtr2[0] = num6;
                        }
                        else
                        {
                            numPtr2[2] = this.fillR;
                            numPtr2[1] = this.fillG;
                            numPtr2[0] = this.fillB;
                        }
                    }
                    else if (this.fillOutsideRange)
                    {
                        numPtr2[2] = this.fillR;
                        numPtr2[1] = this.fillG;
                        numPtr2[0] = this.fillB;
                    }
                    else
                    {
                        numPtr2[2] = num4;
                        numPtr2[1] = num5;
                        numPtr2[0] = num6;
                    }
                    num8++;
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

        public Range Blue
        {
            get
            {
                return this.blue;
            }
            set
            {
                this.blue = value;
            }
        }

        public RGB FillColor
        {
            get
            {
                return new RGB(this.fillR, this.fillG, this.fillB);
            }
            set
            {
                this.fillR = value.Red;
                this.fillG = value.Green;
                this.fillB = value.Blue;
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

        public Range Green
        {
            get
            {
                return this.green;
            }
            set
            {
                this.green = value;
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
            }
        }
    }
}

