namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public sealed class Difference : IFilter
    {
        private Bitmap overlayImage;

        public Difference()
        {
        }

        public Difference(Bitmap overlayImage)
        {
            this.overlayImage = overlayImage;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int num7;
            int width = srcImg.Width;
            int height = srcImg.Height;
            int num3 = this.overlayImage.Width;
            int num4 = this.overlayImage.Height;
            if (((srcImg.PixelFormat != this.overlayImage.PixelFormat) || (width != num3)) || (height != num4))
            {
                throw new ArgumentException();
            }
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            BitmapData data3 = this.overlayImage.LockBits(new Rectangle(0, 0, num3, num4), ImageLockMode.ReadOnly, format);
            int num6 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            byte* numPtr3 = (byte*) data3.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num9 = 0;
                    while (num9 < width)
                    {
                        num7 = numPtr[0] - numPtr3[0];
                        numPtr2[0] = (num7 < 0) ? ((byte) -num7) : ((byte) num7);
                        num9++;
                        numPtr++;
                        numPtr2++;
                        numPtr3++;
                    }
                    numPtr += num6;
                    numPtr2 += num6;
                    numPtr3 += num6;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num11 = 0;
                    while (num11 < width)
                    {
                        num7 = numPtr[2] - numPtr3[2];
                        numPtr2[2] = (num7 < 0) ? ((byte) -num7) : ((byte) num7);
                        num7 = numPtr[1] - numPtr3[1];
                        numPtr2[1] = (num7 < 0) ? ((byte) -num7) : ((byte) num7);
                        num7 = numPtr[0] - numPtr3[0];
                        numPtr2[0] = (num7 < 0) ? ((byte) -num7) : ((byte) num7);
                        num11++;
                        numPtr += 3;
                        numPtr2 += 3;
                        numPtr3 += 3;
                    }
                    numPtr += num6;
                    numPtr2 += num6;
                    numPtr3 += num6;
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
    }
}

