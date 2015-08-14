namespace GodLesZ.Library.Imaging.Filters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public sealed class GrayscaleToRGB : IFilter
    {
        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException();
            }
            int width = srcImg.Width;
            int height = srcImg.Height;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int num3 = bitmapdata.Stride - width;
            int num4 = data2.Stride - (width * 3);
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            for (int i = 0; i < height; i++)
            {
                int num6 = 0;
                while (num6 < width)
                {
                    byte num7;
                    numPtr2[0] = num7 = numPtr[0];
                    numPtr2[2] = numPtr2[1] = num7;
                    num6++;
                    numPtr++;
                    numPtr2 += 3;
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

