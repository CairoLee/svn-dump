namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class GammaCorrection : IFilter
    {
        private double gamma;
        private byte[] table;

        public GammaCorrection()
        {
            this.table = new byte[0x100];
            this.Gamma = 2.2000000476837158;
        }

        public GammaCorrection(double gamma)
        {
            this.table = new byte[0x100];
            this.Gamma = gamma;
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
                        numPtr2[0] = this.table[numPtr[0]];
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
                        numPtr2[2] = this.table[numPtr[2]];
                        numPtr2[1] = this.table[numPtr[1]];
                        numPtr2[0] = this.table[numPtr[0]];
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

        public double Gamma
        {
            get
            {
                return this.gamma;
            }
            set
            {
                this.gamma = Math.Max(0.1, Math.Min(5.0, value));
                double y = 1.0 / this.gamma;
                for (int i = 0; i < 0x100; i++)
                {
                    this.table[i] = (byte) Math.Min(0xff, (int) ((Math.Pow(((double) i) / 255.0, y) * 255.0) + 0.5));
                }
            }
        }
    }
}

