namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public abstract class Grayscale : IFilter
    {
        private float cb;
        private float cg;
        private float cr;

        public Grayscale(float cr, float cg, float cb)
        {
            this.cr = cr;
            this.cg = cg;
            this.cb = cb;
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
            Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int num3 = bitmapdata.Stride - (width * 3);
            int num4 = data2.Stride - width;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num6 = 0;
                while (num6 < width)
                {
                    numPtr2[0] = (byte) (((this.cr * numPtr[2]) + (this.cg * numPtr[1])) + (this.cb * numPtr[0]));
                    num6++;
                    numPtr += 3;
                    numPtr2++;
                }
                numPtr += num3;
                numPtr2 += num4;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }
    }
}

