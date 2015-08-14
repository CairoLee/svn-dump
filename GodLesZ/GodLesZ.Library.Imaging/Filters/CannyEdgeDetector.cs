namespace GodLesZ.Library.Imaging.Filters
{
	using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class CannyEdgeDetector : IFilter
    {
        private GaussianBlur gaussianFilter;
        private IFilter grayscaleFilter;
        private byte highThreshold;
        private byte lowThreshold;
        private static int[,] xKernel = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        private static int[,] yKernel = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

        public CannyEdgeDetector()
        {
            this.grayscaleFilter = new GrayscaleBT709();
            this.gaussianFilter = new GaussianBlur();
            this.lowThreshold = 20;
            this.highThreshold = 100;
        }

        public CannyEdgeDetector(byte lowThreshold, byte highThreshold)
        {
            this.grayscaleFilter = new GrayscaleBT709();
            this.gaussianFilter = new GaussianBlur();
            this.lowThreshold = 20;
            this.highThreshold = 100;
            this.lowThreshold = lowThreshold;
            this.highThreshold = highThreshold;
        }

        public CannyEdgeDetector(byte lowThreshold, byte highThreshold, double sigma)
        {
            this.grayscaleFilter = new GrayscaleBT709();
            this.gaussianFilter = new GaussianBlur();
            this.lowThreshold = 20;
            this.highThreshold = 100;
            this.lowThreshold = lowThreshold;
            this.highThreshold = highThreshold;
            this.gaussianFilter.Sigma = sigma;
        }

        public unsafe Bitmap Apply(Bitmap srcImg)
        {
            Bitmap bitmap = (srcImg.PixelFormat == PixelFormat.Format8bppIndexed) ? srcImg : this.grayscaleFilter.Apply(srcImg);
            Bitmap bitmap2 = this.gaussianFilter.Apply(bitmap);
            int width = srcImg.Width;
            int height = srcImg.Height;
            BitmapData bitmapdata = bitmap2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap bitmap3 = GodLesZ.Library.Imaging.Image.CreateGrayscaleImage(width, height);
            BitmapData data2 = bitmap3.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int stride = bitmapdata.Stride;
            int num4 = stride - width;
            int num5 = width - 1;
            int num6 = height - 1;
            double num14 = 57.295779513082323;
            byte num15 = 0;
            byte num16 = 0;
            byte[] buffer = new byte[width * height];
			byte* numPtr = (byte*)((byte*)bitmapdata.Scan0.ToPointer() + stride);
			byte* numPtr2 = (byte*)((byte*)data2.Scan0.ToPointer() + stride);
            int index = width;
            for (int i = 1; i < num6; i++)
            {
                numPtr++;
                numPtr2++;
                index++;
                int num19 = 1;
                while (num19 < num5)
                {
                    double num12;
                    double num13;
                    double num11 = num12 = 0.0;
                    for (int m = 0; m < 3; m++)
                    {
                        int num9 = m - 1;
                        for (int n = 0; n < 3; n++)
                        {
                            double num10 = numPtr[((num9 * stride) + n) - 1];
                            num11 += num10 * xKernel[m, n];
                            num12 += num10 * yKernel[m, n];
                        }
                    }
                    numPtr2[0] = (byte) Math.Min((double) (Math.Abs(num11) + Math.Abs(num12)), (double) 255.0);
                    if (num11 == 0.0)
                    {
                        num13 = (num12 == 0.0) ? ((double) 0) : ((double) 90);
                    }
                    else
                    {
                        double d = num12 / num11;
                        if (d < 0.0)
                        {
                            num13 = 180.0 - (Math.Atan(-d) * num14);
                        }
                        else
                        {
                            num13 = Math.Atan(d) * num14;
                        }
                        if (num13 < 22.5)
                        {
                            num13 = 0.0;
                        }
                        else if (num13 < 67.5)
                        {
                            num13 = 45.0;
                        }
                        else if (num13 < 112.5)
                        {
                            num13 = 90.0;
                        }
                        else if (num13 < 157.5)
                        {
                            num13 = 135.0;
                        }
                        else
                        {
                            num13 = 0.0;
                        }
                    }
                    buffer[index] = (byte) num13;
                    num19++;
                    numPtr++;
                    numPtr2++;
                    index++;
                }
                numPtr += num4 + 1;
                numPtr2 += num4 + 1;
                index++;
            }
			numPtr2 = (byte*)((byte*)data2.Scan0.ToPointer() + stride);
            index = width;
            for (int j = 1; j < num6; j++)
            {
                numPtr2++;
                index++;
                int num22 = 1;
                while (num22 < num5)
                {
                    switch (buffer[index])
                    {
                        case 90:
                            num15 = numPtr2[width];
                            num16 = numPtr2[-width];
                            break;

                        case 0x87:
                            num15 = numPtr2[width + 1];
                            num16 = numPtr2[-width - 1];
                            break;

                        case 0:
                            num15 = numPtr2[-1];
                            num16 = numPtr2[1];
                            break;

                        case 0x2d:
                            num15 = numPtr2[width - 1];
                            num16 = numPtr2[-width + 1];
                            break;
                    }
                    if ((numPtr2[0] < num15) || (numPtr2[0] < num16))
                    {
                        numPtr2[0] = 0;
                    }
                    num22++;
                    numPtr2++;
                    index++;
                }
                numPtr2 += num4 + 1;
                index++;
            }
            numPtr2 = (byte*) ((byte*)data2.Scan0.ToPointer() + stride);
            index = width;
            for (int k = 1; k < num6; k++)
            {
                numPtr2++;
                index++;
                int num24 = 1;
                while (num24 < num5)
                {
                    if (numPtr2[0] < this.highThreshold)
                    {
                        if (numPtr2[0] < this.lowThreshold)
                        {
                            numPtr2[0] = 0;
                        }
                        else if ((((numPtr2[-1] < this.highThreshold) && (numPtr2[1] < this.highThreshold)) && ((numPtr2[-width] < this.highThreshold) && (numPtr2[width] < this.highThreshold))) && (((numPtr2[-width] < this.highThreshold) && (numPtr2[-width] < this.highThreshold)) && ((numPtr2[-width] < this.highThreshold) && (numPtr2[-width] < this.highThreshold))))
                        {
                            numPtr2[0] = 0;
                        }
                    }
                    num24++;
                    numPtr2++;
                    index++;
                }
                numPtr2 += num4 + 1;
                index++;
            }
            bitmap3.UnlockBits(data2);
            bitmap2.UnlockBits(bitmapdata);
            bitmap2.Dispose();
            if (bitmap != srcImg)
            {
                bitmap.Dispose();
            }
            return bitmap3;
        }

        public double GaussianSigma
        {
            get
            {
                return this.gaussianFilter.Sigma;
            }
            set
            {
                this.gaussianFilter.Sigma = value;
            }
        }

        public int GaussianSize
        {
            get
            {
                return this.gaussianFilter.Size;
            }
            set
            {
                this.gaussianFilter.Size = value;
            }
        }

        public byte HighThreshold
        {
            get
            {
                return this.highThreshold;
            }
            set
            {
                this.highThreshold = value;
            }
        }

        public byte LowThreshold
        {
            get
            {
                return this.lowThreshold;
            }
            set
            {
                this.lowThreshold = value;
            }
        }
    }
}

