namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class SobelEdgeDetector : IFilter
    {
        private bool scaleIntensity = true;
        private static int[,] xKernel = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        private static int[,] yKernel = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

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
            double num14 = 0.0;
			byte* numPtr = (byte*)((byte*)bitmapdata.Scan0.ToPointer() + stride);
			byte* numPtr2 = (byte*)((byte*)data2.Scan0.ToPointer() + stride);
            for (int i = 1; i < num6; i++)
            {
                numPtr++;
                numPtr2++;
                int num16 = 1;
                while (num16 < num5)
                {
                    double num12;
                    double num11 = num12 = 0.0;
                    for (int j = 0; j < 3; j++)
                    {
                        int num9 = j - 1;
                        for (int k = 0; k < 3; k++)
                        {
                            double num10 = numPtr[((num9 * stride) + k) - 1];
                            num11 += num10 * xKernel[j, k];
                            num12 += num10 * yKernel[j, k];
                        }
                    }
                    double num13 = Math.Min((double) (Math.Abs(num11) + Math.Abs(num12)), (double) 255.0);
                    if (num13 > num14)
                    {
                        num14 = num13;
                    }
                    numPtr2[0] = (byte) num13;
                    num16++;
                    numPtr++;
                    numPtr2++;
                }
                numPtr += num4 + 1;
                numPtr2 += num4 + 1;
            }
            if (this.scaleIntensity && (num14 != 255.0))
            {
                double num17 = 255.0 / num14;
				numPtr2 = (byte*)((byte*)data2.Scan0.ToPointer() + stride);
                for (int m = 1; m < num6; m++)
                {
                    numPtr2++;
                    int num19 = 1;
                    while (num19 < num5)
                    {
                        numPtr2[0] = (byte) (num17 * numPtr2[0]);
                        num19++;
                        numPtr2++;
                    }
                    numPtr2 += num4 + 1;
                }
            }
            bitmap.UnlockBits(data2);
            srcImg.UnlockBits(bitmapdata);
            if (flag)
            {
                srcImg.Dispose();
            }
            return bitmap;
        }

        public bool ScaleIntensity
        {
            get
            {
                return this.scaleIntensity;
            }
            set
            {
                this.scaleIntensity = value;
            }
        }
    }
}

