namespace GodLesZ.Library.Imaging.Filters
{
	using System.Drawing;
    using System.Drawing.Imaging;

    public class DifferenceEdgeDetector : IFilter
    {
        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            int width = srcImg.Width;
            int height = srcImg.Height;
            bool flag = false;
            if (srcImg.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                flag = true;
                IFilter filter = new GrayscaleRMY();
                srcImg = filter.Apply(srcImg);
            }
            BitmapData bitmapdata = srcImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bitmap = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int stride = bitmapdata.Stride;
            int num4 = stride - width;
            int num5 = width - 1;
            int num6 = height - 1;
            byte* numPtr = (byte*) bitmapdata.Scan0.ToPointer();
            byte* numPtr2 = (byte*) data2.Scan0.ToPointer();
            numPtr += stride;
            numPtr2 += stride;
            for (int i = 1; i < num6; i++)
            {
                numPtr++;
                numPtr2++;
                int num10 = 1;
                while (num10 < num5)
                {
                    int num8 = 0;
                    int num7 = numPtr[-stride - 1] - numPtr[stride + 1];
                    if (num7 < 0)
                    {
                        num7 = -num7;
                    }
                    if (num7 > num8)
                    {
                        num8 = num7;
                    }
                    num7 = numPtr[-stride + 1] - numPtr[stride - 1];
                    if (num7 < 0)
                    {
                        num7 = -num7;
                    }
                    if (num7 > num8)
                    {
                        num8 = num7;
                    }
                    num7 = numPtr[-stride] - numPtr[stride];
                    if (num7 < 0)
                    {
                        num7 = -num7;
                    }
                    if (num7 > num8)
                    {
                        num8 = num7;
                    }
                    num7 = numPtr[-1] - numPtr[1];
                    if (num7 < 0)
                    {
                        num7 = -num7;
                    }
                    if (num7 > num8)
                    {
                        num8 = num7;
                    }
                    numPtr2[0] = (byte) num8;
                    num10++;
                    numPtr++;
                    numPtr2++;
                }
                numPtr += num4 + 1;
                numPtr2 += num4 + 1;
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            if (flag)
            {
                srcImg.Dispose();
            }
            return bitmap;
        }
    }
}

