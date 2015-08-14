namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public sealed class Merge : IFilter
    {
        private Bitmap overlayImage;
        private Point overlayPos;

        public Merge()
        {
            this.overlayPos = new Point(0, 0);
        }

        public Merge(Bitmap overlayImage)
        {
            this.overlayPos = new Point(0, 0);
            this.overlayImage = overlayImage;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            if (srcImg.PixelFormat != this.overlayImage.PixelFormat)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            int x = this.overlayPos.X;
            int y = this.overlayPos.Y;
            int num5 = this.overlayImage.Width;
            int num6 = this.overlayImage.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            BitmapData data3 = this.overlayImage.LockBits(new Rectangle(0, 0, num5, num6), ImageLockMode.ReadOnly, format);
            int num7 = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int stride = bitmapdata.Stride;
            int num9 = stride - (num7 * width);
            int num10 = data3.Stride;
            byte* src = (byte*) bitmapdata.Scan0.ToPointer();
            byte* dst = (byte*) data2.Scan0.ToPointer();
            byte* numPtr3 = (byte*) data3.Scan0.ToPointer();
            x = -x;
            y = -y;
            if (y > 0)
            {
                numPtr3 += data3.Stride * y;
            }
            if (((width == num5) && (height == num6)) && ((x == 0) && (y == 0)))
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int num13 = 0;
                        while (num13 < num7)
                        {
                            dst[0] = (src[0] > numPtr3[0]) ? src[0] : numPtr3[0];
                            num13++;
                            src++;
                            dst++;
                            numPtr3++;
                        }
                    }
                    src += num9;
                    dst += num9;
                    numPtr3 += num9;
                }
            }
            else
            {
                if (x > 0)
                {
                    numPtr3 += x * num7;
                }
                if (x >= 0)
                {
                    num10 -= num7 * Math.Min(num5 - x, width);
                }
                else
                {
                    num10 -= num7 * Math.Min(num5, width + x);
                }
                for (int k = 0; k < height; k++)
                {
                    if (((y + k) < 0) || ((y + k) >= num6))
                    {
                        Win32.memcpy(dst, src, stride);
                        dst += stride;
                        src += stride;
                    }
                    else
                    {
                        for (int m = 0; m < width; m++)
                        {
                            if (((x + m) < 0) || ((x + m) >= num5))
                            {
                                int num16 = 0;
                                while (num16 < num7)
                                {
                                    dst[0] = src[0];
                                    num16++;
                                    src++;
                                    dst++;
                                }
                            }
                            else
                            {
                                int num17 = 0;
                                while (num17 < num7)
                                {
                                    dst[0] = (src[0] > numPtr3[0]) ? src[0] : numPtr3[0];
                                    num17++;
                                    src++;
                                    dst++;
                                    numPtr3++;
                                }
                            }
                        }
                        src += num9;
                        dst += num9;
                        numPtr3 += num10;
                    }
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            this.overlayImage.UnlockBits(data3);
            return bitmap;
        }

        public Bitmap OverlayImage
        {
            get
            {
                return this.overlayImage;
            }
            set
            {
                this.overlayImage = value;
            }
        }

        public Point OverlayPos
        {
            get
            {
                return this.overlayPos;
            }
            set
            {
                this.overlayPos = value;
            }
        }
    }
}

