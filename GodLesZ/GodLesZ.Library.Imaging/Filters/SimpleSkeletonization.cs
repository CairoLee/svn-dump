namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class SimpleSkeletonization : IFilter
    {
        private byte bg;
        private byte fg;

        public SimpleSkeletonization()
        {
            this.fg = 0xff;
        }

        public SimpleSkeletonization(byte bg, byte fg)
        {
            this.fg = 0xff;
            this.bg = bg;
            this.fg = fg;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num5;
            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int stride = data2.Stride;
            int num4 = stride - width;
            Win32.memset(data2.Scan0, this.bg, stride * height);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            byte* numPtr3 = numPtr;
            byte* numPtr4 = numPtr2;
            for (int i = 0; i < height; i++)
            {
                num5 = -1;
                int num7 = 0;
                while (num7 < width)
                {
                    if (num5 == -1)
                    {
                        if (numPtr3[0] == this.fg)
                        {
                            num5 = num7;
                        }
                    }
                    else if (numPtr3[0] != this.fg)
                    {
                        numPtr4[num5 + ((num7 - num5) >> 1)] = this.fg;
                        num5 = -1;
                    }
                    num7++;
                    numPtr3++;
                }
                if (num5 != -1)
                {
                    numPtr4[num5 + ((width - num5) >> 1)] = this.fg;
                }
                numPtr3 += num4;
                numPtr4 += stride;
            }
            for (int j = 0; j < width; j++)
            {
                numPtr3 = numPtr + j;
                numPtr4 = numPtr2 + j;
                num5 = -1;
                int num9 = 0;
                while (num9 < height)
                {
                    if (num5 == -1)
                    {
                        if (numPtr3[0] == this.fg)
                        {
                            num5 = num9;
                        }
                    }
                    else if (numPtr3[0] != this.fg)
                    {
                        numPtr4[stride * (num5 + ((num9 - num5) >> 1))] = this.fg;
                        num5 = -1;
                    }
                    num9++;
                    numPtr3 += stride;
                }
                if (num5 != -1)
                {
                    numPtr4[stride * (num5 + ((height - num5) >> 1))] = this.fg;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public byte Background
        {
            get
            {
                return this.bg;
            }
            set
            {
                this.bg = value;
            }
        }

        public byte Foreground
        {
            get
            {
                return this.fg;
            }
            set
            {
                this.fg = value;
            }
        }
    }
}

