namespace GodLesZ.Library.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using GodLesZ.Library.Imaging;

    public class Jitter : IFilter
    {
        private bool copyBefore;
        private int radius;

        public Jitter()
        {
            this.radius = 2;
            this.copyBefore = true;
        }

        public Jitter(int radius)
        {
            this.radius = 2;
            this.copyBefore = true;
            this.Radius = radius;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = (format == PixelFormat.Format8bppIndexed) ? GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height) : new Bitmap(width, height, format);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, format);
            int num3 = (format == PixelFormat.Format8bppIndexed) ? 1 : 3;
            int stride = bitmapdata.Stride;
            int num5 = stride - (width * num3);
            int maxValue = (this.radius * 2) + 1;
            Random random = new Random();
            byte* src = (byte*) bitmapdata.Scan0.ToPointer();
            byte* dst = (byte*) data2.Scan0.ToPointer();
            if (this.copyBefore)
            {
                Win32.memcpy(dst, src, stride * height);
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int num6 = (j + random.Next(maxValue)) - this.radius;
                    int num7 = (i + random.Next(maxValue)) - this.radius;
                    if (((num6 >= 0) && (num7 >= 0)) && ((num6 < width) && (num7 < height)))
                    {
                        byte* numPtr3 = (src + (num7 * stride)) + (num6 * num3);
                        int index = 0;
                        while (index < num3)
                        {
                            dst[0] = numPtr3[index];
                            index++;
                            dst++;
                        }
                    }
                    else
                    {
                        dst += num3;
                    }
                }
                dst += num5;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }

        public bool CopyBefore
        {
            get
            {
                return this.copyBefore;
            }
            set
            {
                this.copyBefore = value;
            }
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = Math.Max(1, Math.Min(10, value));
            }
        }
    }
}

