namespace GodLesZ.Library.Imaging.Filters
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public sealed class Sepia : IFilter
    {
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
                int num6 = 0;
                while (num6 < width)
                {
                    byte num4 = (byte) (((0.299 * numPtr[2]) + (0.587 * numPtr[1])) + (0.114 * numPtr[0]));
                    numPtr2[2] = (num4 > 0xce) ? ((byte) 0xff) : ((byte) (num4 + 0x31));
                    numPtr2[1] = (num4 < 14) ? ((byte) 0) : ((byte) (num4 - 14));
                    numPtr2[0] = (num4 < 0x38) ? ((byte) 0) : ((byte) (num4 - 0x38));
                    num6++;
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
    }
}

