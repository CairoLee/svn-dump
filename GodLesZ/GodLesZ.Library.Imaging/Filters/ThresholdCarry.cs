namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
    using System.Drawing.Imaging;

    public sealed class ThresholdCarry : IFilter
    {
        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            PixelFormat format = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb;
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, format);
            Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int num3 = bitmapdata.Stride - ((format == PixelFormat.Format8bppIndexed) ? width : (width * 3));
            int num4 = data2.Stride - width;
            short num5 = 0;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            if (format == PixelFormat.Format8bppIndexed)
            {
                for (int i = 0; i < height; i++)
                {
                    int num7 = 0;
                    while (num7 < width)
                    {
                        num5 = (short) (num5 + numPtr[0]);
                        if (num5 > 0x7f)
                        {
                            numPtr2[0] = 0xff;
                            num5 = (short) (num5 - 0xff);
                        }
                        else
                        {
                            numPtr2[0] = 0;
                        }
                        num7++;
                        numPtr++;
                        numPtr2++;
                    }
                    numPtr += num3;
                    numPtr2 += num4;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    int num10 = 0;
                    while (num10 < width)
                    {
                        byte num8 = (byte) (((0.2125f * numPtr[2]) + (0.7154f * numPtr[1])) + (0.0721f * numPtr[0]));
                        num5 = (short) (num5 + num8);
                        if (num5 > 0x7f)
                        {
                            numPtr2[0] = 0xff;
                            num5 = (short) (num5 - 0xff);
                        }
                        else
                        {
                            numPtr2[0] = 0;
                        }
                        num10++;
                        numPtr += 3;
                        numPtr2++;
                    }
                    numPtr += num3;
                    numPtr2 += num4;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            return bitmap;
        }
    }
}

