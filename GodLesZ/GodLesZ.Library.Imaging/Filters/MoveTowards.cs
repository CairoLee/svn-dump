namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class MoveTowards : IFilter
    {
        private Bitmap overlayImage;
        private int stepSize;

        public MoveTowards()
        {
            this.stepSize = 1;
        }

        public MoveTowards(Bitmap overlayImage)
        {
            this.stepSize = 1;
            this.overlayImage = overlayImage;
        }

        public MoveTowards(int stepSize)
        {
            this.stepSize = 1;
            this.StepSize = stepSize;
        }

        public MoveTowards(Bitmap overlayImage, int stepSize)
        {
            this.stepSize = 1;
            this.overlayImage = overlayImage;
            this.StepSize = stepSize;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
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
            int num5 = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int num7 = bitmapdata.Stride - (num5 * width);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            byte* numPtr3 = (byte*) data3.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int num11 = 0;
                    while (num11 < num5)
                    {
                        int num8 = numPtr3[0] - numPtr[0];
                        numPtr2[0] = numPtr[0];
                        if (num8 > 0)
                        {
                            numPtr2[0] = (byte) (numPtr2[0] + ((this.stepSize < num8) ? ((byte) this.stepSize) : ((byte) num8)));
                        }
                        else if (num8 < 0)
                        {
                            num8 = -num8;
                            numPtr2[0] = (byte) (numPtr2[0] - ((this.stepSize < num8) ? ((byte) this.stepSize) : ((byte) num8)));
                        }
                        num11++;
                        numPtr++;
                        numPtr2++;
                        numPtr3++;
                    }
                }
                numPtr += num7;
                numPtr2 += num7;
                numPtr3 += num7;
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

        public int StepSize
        {
            get
            {
                return this.stepSize;
            }
            set
            {
                this.stepSize = Math.Max(1, Math.Min(0xff, value));
            }
        }
    }
}

